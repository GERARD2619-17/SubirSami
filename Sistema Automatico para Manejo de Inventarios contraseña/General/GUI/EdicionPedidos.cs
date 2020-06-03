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
        DataTable _DATOS2 = new DataTable();

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
        private void Configurar()
        {
            _DATOS2.Columns.Add("NombreProducto");
            _DATOS2.Columns.Add("Estado");
            _DATOS2.Columns.Add("Cantidad");
            dtgDatos2.AutoGenerateColumns = false;
            dtgDatos2.DataSource = _DATOS2;
        }
        private Boolean Validar(String p1, String p2) {
            Boolean resultado=true;
            for (int i=0; i< dtgDatos2.Rows.Count; i++) {
                if (dtgDatos2.Rows[i].Cells["NombreProducto"].Value.ToString()==p1) {
                    if (dtgDatos2.Rows[i].Cells["Estado"].Value.ToString() == p2) {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }
        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (Int32.Parse(nudTiempo.Text) < 1)
            {
                Notificador.SetError(nudTiempo, "Este campo no puede ser cero");
                verificado = false;
            }
            if (nudCosto.Text == "0,00")
            {
                Notificador.SetError(nudCosto, "Este campo no puede ser cero");
                verificado = false;
            }
            return verificado;
        }
        private void CargarProveedores()
        {
            DataTable Proveedor = new DataTable();
            Proveedor = CacheManager.CLS.Cache.TODOS_LOS_PROVEEDORES();
            cbProveedor.DataSource = Proveedor;
            cbProveedor.DisplayMember = "NombreProveedor";
            cbProveedor.ValueMember = "IDProveedor";
        }

        public EdicionPedidos()
        {
            InitializeComponent();
            Configurar();
            Cargar();
            CargarProveedores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txbBuscar_TextChanged_1(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar(dtgDatos.CurrentRow.Cells["NombreProducto2"].Value.ToString(), dtgDatos.CurrentRow.Cells["Estado2"].Value.ToString()))
            {
                AgregarAlPedido f = new AgregarAlPedido();
                f.txbProducto.Text = dtgDatos.CurrentRow.Cells["NombreProducto2"].Value.ToString();
                f.txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado2"].Value.ToString();
                List<string> listaProductos = new List<string>();
                List<string> listaEstado = new List<string>();
                List<string> listaCantidad = new List<string>();
                for (int i = 0; i < dtgDatos2.Rows.Count; i++)
                {
                    listaProductos.Add(dtgDatos2.Rows[i].Cells["NombreProducto"].Value.ToString());
                    listaEstado.Add(dtgDatos2.Rows[i].Cells["Estado"].Value.ToString());
                    listaCantidad.Add(dtgDatos2.Rows[i].Cells["Cantidad"].Value.ToString());
                }
                f.LProductos = listaProductos;
                f.LEstado = listaEstado;
                f.LCantidad = listaCantidad;
                f.ShowDialog();
                if (f.PROCESAR)
                {
                    DataRow NuevaFila = _DATOS2.NewRow();
                    NuevaFila["NombreProducto"] = f.LProductos[f.LProductos.Count - 1];
                    NuevaFila["Estado"] = f.LEstado[f.LProductos.Count - 1];
                    NuevaFila["Cantidad"] = f.LCantidad[f.LProductos.Count - 1];
                    _DATOS2.Rows.Add(NuevaFila);
                }
                Cargar();
            }
            else {
                MessageBox.Show("El rpoducto ya se encuentra en el pedido", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                CLS.Pedidos oPedidos = new CLS.Pedidos();
                oPedidos.IDProveedor = cbProveedor.SelectedValue.ToString();
                oPedidos.Fecha_de_pedido = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");
                oPedidos.TiempoPromedio = nudTiempo.Text;
                oPedidos.Costo = nudCosto.Text.Replace(",", ".");
                oPedidos.Estado = "Pedido";
                if (oPedidos.Guardar())
                {
                    Close();
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            dtgDatos2.Rows.RemoveAt(dtgDatos2.CurrentRow.Index);
        }
    }
}
