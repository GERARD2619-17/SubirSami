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
    public partial class GestionBodega : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void LlenarComboBox()
        {
            //Se llena el ComboBox con una lista de las clasificaciones
            List<string> listaClasificacion = new List<string>();
            try
            {
                String Consulta1 = "SELECT Clasificacion FROM Clasificaciones;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta1);
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    listaClasificacion.Add(Datos.Rows[i]["Clasificacion"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de clasificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbClasificaciones.ComboBox.DataSource = listaClasificacion;
        }
        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PRODUCTOS();
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
                lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
            }
            catch { }
        }
        private void Filtrar2()
        {
            try
            {
                _DATOS.Filter = "Clasificacion LIKE '%" + cbClasificaciones.Text + "%'";
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
                lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
            }
            catch { }
        }
        private void DesFiltrar() {
            _DATOS.RemoveFilter();
            dtgDatos.AutoGenerateColumns = false;
            dtgDatos.DataSource = _DATOS;
            lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
        }
        public GestionBodega()
        {
            InitializeComponent();
            LlenarComboBox();
            Cargar();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se retirara el producto, a continuación seleccione la cantidad", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    RetirarEnBodega f = new RetirarEnBodega();
                    f.txbNombre.Text = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
                    f.txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
                catch { }
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se devolvera un producto, a continuación seleccione la cantidad", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    RetirarEnBodega f = new RetirarEnBodega();
                    f.lblProducto.Text = "Devolución";
                    f.txbNombre.Text = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
                    f.txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
                catch { }
            }
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            Filtrar2();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DesFiltrar();
        }
    }
}
