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
    public partial class Login : Form
    {
        Boolean _Autorizado = false;
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public Boolean Autorizado { get { return _Autorizado; } }

        private void Validar()
        {
            try
            {
                String Consulta = @"SELECT 
            a.IDUsuario, a.Usuario, 
            a.Credencial, a.IDRol, 
            b.Rol,
            a.IDEmpleado, CONCAT(c.Nombres,' ',c.Apellidos) as 'Empleado',
            c.Genero
            FROM 
            usuarios a, roles b, empleados c
            WHERE a.Usuario='" + txbUsuario.Text + @"'
            AND a.Credencial=md5(sha1('" + txbPassword.Text + @"'))
            AND a.IDRol=b.IDRol
            AND a.IDEmpleado=c.IDEmpleado;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                if (Datos.Rows.Count == 1)
                {
                    _SESION.Informacion.IDUsuario = Datos.Rows[0]["IDUsuario"].ToString();
                    _SESION.Informacion.Usuario = Datos.Rows[0]["Usuario"].ToString();
                    _SESION.Informacion.IDRol = Datos.Rows[0]["IDRol"].ToString();
                    _SESION.Informacion.Rol = Datos.Rows[0]["Rol"].ToString();
                    _Autorizado = true;
                    Close();
                }
                else
                {
                    lblMensaje.Text = "USUARIO O CONTRASEÑA ERRÓNEOS.";
                    //esto espara que cuando metamos las credenciales erroneas salga las letras de color rojo
                    lblMensaje.ForeColor = Color.Red;
                }
            }
            catch
            {
                lblMensaje.Text = "HA OCURRIDO UN ERROR AL PROCESAR EL COMANDO";
                //lblMensaje.ForeColor = Color.Red;
            }

        }





        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
         
            
            Validar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
          //  Application.Exit();
           
            
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Validar();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txbPassword.PasswordChar == '°')
                {
                    txbPassword.PasswordChar = '\0';
                }
            }
            else
            {
                txbPassword.PasswordChar = '°';
            }
        }
    }
}
