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
    public partial class GestionUsuarios : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }
        
        public GestionUsuarios()
        {
            InitializeComponent();
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EdicionUsuario f = new EdicionUsuario();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }
    }

}
