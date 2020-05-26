using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class EdicionPedidos : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void LlenarComboBox()
        {
            List<string> listaProveedor = new List<string>();
            try
            {
                String Consulta = "SELECT NombreProveedor FROM Proveedores;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    listaProveedor.Add(Datos.Rows[i]["NombreProveedor"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbProveedor.DataSource = listaProveedor;
        }
        private void Cargar()
        {
            try
            {
                DataTable Resultado = new DataTable();
                String Consulta;
                DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
                try
                {
                Consulta = "SELECT NombreProducto, Estado, Cantidad FROM Productos";
                Resultado = oConsulta.Consultar(Consulta);
                }
                catch
                {
                    Resultado = new DataTable();
                }
                _DATOS.DataSource = Resultado;
                FiltrarLocalmente();
            }
            catch { }
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (txbBuscar.TextLength > 0)
                {
                    _DATOS.Filter = "NombreProducto LIKE '%" + txbBuscar.Text + "%'";
                }
                else
                {
                    _DATOS.RemoveFilter();
                }
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }
        public EdicionPedidos()
        {
            InitializeComponent();
            Cargar();
            LlenarComboBox();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txbProducto.Text = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
            txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
        }
        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbProducto.TextLength == 0)
            {
                Notificador.SetError(txbProducto, "Este campo no puede quedar vacío");
                verificado = false;
            }
            if (txbEstado.TextLength == 0)
            {
                Notificador.SetError(txbEstado, "Este campo no puede quedar vacío");
                verificado = false;
            }
            if (Int32.Parse(nudCantidad.Text) <= 0)
            {
                Notificador.SetError(nudCantidad, "Este campo debe ser mayor a cero");
                verificado = false;
            }
            if (Int32.Parse(nudDias.Text) <= 0)
            {
                Notificador.SetError(nudDias, "Este campo debe ser mayor a cero");
                verificado = false;
            }
            return verificado;
        }
        private void Procesar()
        {
            try
            {
                if (Validar())
                {
                    String Consulta = "SELECT * FROM Productos WHERE NombreProducto ='" + dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString() + "' AND Estado ='"+ dtgDatos.CurrentRow.Cells["Estado"].Value.ToString() + "';";
                    DataTable Datos = new DataTable();
                    DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                    Datos = Consultor.Consultar(Consulta);

                    String Consulta2 = "SELECT * FROM Proveedores WHERE NombreProveedor ='"+cbProveedor.Text+"'";
                    DataTable Datos2 = new DataTable();
                    DataManager.CLS.DBOperacion Consultor2 = new DataManager.CLS.DBOperacion();
                    Datos2 = Consultor2.Consultar(Consulta2);

                    CLS.Pedidos oPedido = new CLS.Pedidos();
                    oPedido.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    oPedido.Cantidad = nudCantidad.Text;
                    oPedido.IDProveedor = Datos2.Rows[0]["IDProveedor"].ToString();
                    oPedido.Fecha_de_pedido = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");
                    oPedido.TiempoPromedio = nudDias.Text;
                    oPedido.Estado = "Pedido";

                    //GUARDAR
                    if (oPedido.Guardar())
                    {
                        Close();
                    }
                    
                }
            }
            catch
            {

            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Procesar();
        }
    }
}
