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
        
        private void CargarPedidos()
        {
            DataTable Proveedores = new DataTable();
            Proveedores = CacheManager.CLS.Cache.TODOS_LOS_PROVEEDORES();
            cbProveedor.DataSource = Proveedores;
            cbProveedor.DisplayMember = "NombreProveedor";
            cbProveedor.ValueMember = "IDProveedor";
        }
        private void Cargar()
        {
            try
            {
                DataTable Resultado = new DataTable();
                try
                {
                    Resultado = CacheManager.CLS.Cache.TODOS_LOS_PRODUCTOS();
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
            CargarPedidos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
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
                    CLS.Pedidos oPedido = new CLS.Pedidos();
                    oPedido.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    oPedido.Cantidad = nudCantidad.Text;
                    oPedido.IDProveedor = cbProveedor.SelectedValue.ToString();
                    oPedido.Fecha_de_pedido = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");
                    oPedido.TiempoPromedio = nudDias.Text;
                    oPedido.Estado = "Pedido";
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

        private void dtgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txbProducto.Text = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
            txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
        }
    }
}
