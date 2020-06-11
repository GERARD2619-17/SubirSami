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
    public partial class EdicionUsuario : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        private void CargarRoles()
        {
            DataTable Roles = new DataTable();
            Roles = CacheManager.CLS.Cache.TODOS_LOS_ROLES();
            cbRol.DataSource = Roles;
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "IDRol";
        }

        public EdicionUsuario()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CLS.Usuarios oUsuarios = new CLS.Usuarios();
            oUsuarios.IDUsuario = txbID.Text;
            oUsuarios.Usuario = txbUsuarios.Text;
            oUsuarios.Credencial = txbCredencial.Text;
            oUsuarios.IDRol = cbRol.SelectedValue.ToString();
            oUsuarios.Actualizar2();
              Close();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
