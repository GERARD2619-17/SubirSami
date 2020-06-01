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
    public partial class InsercionUsuario : Form
    {
        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbUsuarios.TextLength == 0)
            {
                Notificador.SetError(txbUsuarios, "Este campo no puede quedar vacío");
                verificado = false;
            }

            if (txbCredencial.TextLength == 0)
            {
                Notificador.SetError(txbCredencial, "Este campo no puede quedar vacío");
                verificado = false;
            }
            String Consulta = "SELECT Usuario From Usuarios WHERE usuario = '" + txbUsuarios.Text + "';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta);
            if (Datos.Rows.Count == 1)
            {
                verificado = false;
               MessageBox.Show("Este Usuario ya se encuentra registrado", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return verificado;
        }
        private void CargarRoles()
        {
            DataTable Roles = new DataTable();
            Roles = CacheManager.CLS.Cache.TODOS_LOS_ROLES();
            cbRol.DataSource = Roles;
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "IDRol";
        }
        private void CargarEmpleados()
        {
            DataTable Empleados = new DataTable();
            Empleados = CacheManager.CLS.Cache.TODOS_LOS_EMPLEADOS();
            cbEmpleados.DataSource = Empleados;
            cbEmpleados.DisplayMember = "Nombre";
            cbEmpleados.ValueMember = "ID";
        }
        
        public InsercionUsuario()
        {
            InitializeComponent();
            CargarRoles();
            CargarEmpleados();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                CLS.Usuarios oUsuarios = new CLS.Usuarios();
                oUsuarios.Usuario = txbUsuarios.Text;
                oUsuarios.Credencial = txbCredencial.Text;
                oUsuarios.IDRol = cbRol.SelectedValue.ToString();
                oUsuarios.IDEmpleado = cbEmpleados.SelectedValue.ToString();
                try
                {
                    if (oUsuarios.Guardar())
                    {
                        Close();
                    }
                   
                }
                catch
                {

                }

                
            }
        }
    }
}
