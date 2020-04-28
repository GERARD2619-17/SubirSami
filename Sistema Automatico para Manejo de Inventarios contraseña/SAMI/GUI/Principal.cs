using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAMI.GUI
{
    public partial class Principal : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public Principal()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            dtgInformacion.DataSource = CacheManager.CLS.Cache.TODOS_LOS_EMPLEADOS();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + _SESION.Informacion.Usuario;
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            dtgInformacion.DataSource = CacheManager.CLS.Cache.TODOS_LOS_ROLES();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            dtgInformacion.DataSource = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                General.GUI.GestionProductos f = new General.GUI.GestionProductos();
                f.ShowDialog();
            }
            catch { }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                General.GUI.EdicionProductos f = new General.GUI.EdicionProductos();
                f.ShowDialog();
            }
            catch { }
        }
    }
}
