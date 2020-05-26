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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
