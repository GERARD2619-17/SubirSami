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
    public partial class GestionProductos : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void Cargar() {
            try {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PRODUCTOS();
                FiltrarLocalmente();
            }
            catch { }
        }
        private void FiltrarLocalmente() {
            try
            {
                if (txbBuscar.TextLength > 0)
                {
                    _DATOS.Filter = "NombreProducto LIKE '%" + txbBuscar.Text + "%' OR Estado LIKE '%" + txbBuscar.Text + "%' OR Clasificacion LIKE '%" + txbBuscar.Text + "%'";
                }
                else {
                    _DATOS.RemoveFilter();
                }
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
                lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
            }
            catch { }
        }




        public GestionProductos()
        {
            InitializeComponent();
            Cargar();
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
