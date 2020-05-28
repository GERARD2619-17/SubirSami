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
                InsercionUsuario f = new InsercionUsuario();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EdicionUsuario f = new EdicionUsuario();
            f.txbID.Text = dtgDatos.CurrentRow.Cells["IDUsuario"].Value.ToString();
            f.txbUsuarios.Text = dtgDatos.CurrentRow.Cells["Usuario"].Value.ToString();
            f.cbRol.Text = dtgDatos.CurrentRow.Cells["Rol"].Value.ToString();
            f.ShowDialog();
            Cargar();
        }
    }

}
