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
        public EdicionPedidos()
        {
            InitializeComponent();
            Configurar();
            Cargar();
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
                if (f.PROCESAR) {
                    DataRow NuevaFila = _DATOS2.NewRow();
                    NuevaFila["NombreProducto"] = f.LProductos[f.LProductos.Count-1];
                    NuevaFila["Estado"] = f.LEstado[f.LProductos.Count-1];
                    NuevaFila["Cantidad"] = f.LCantidad[f.LProductos.Count-1];
                    _DATOS2.Rows.Add(NuevaFila);
                }
                Cargar();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
