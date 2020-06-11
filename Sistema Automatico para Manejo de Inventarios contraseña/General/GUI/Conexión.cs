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
    public partial class Conexión : Form
    {
        Boolean _validar;
        Boolean _Provando;

        public bool Validar { get => _validar; set => _validar = value; }
        public bool Provando { get => _Provando; set => _Provando = value; }

        public static String Usuario = "";
        public static String password = "";
        DataTable _DATOS = new DataTable();
        private void GuardarConfiguracion()
        {

            try
            {
                _DATOS.TableName = "Configurar";
                _DATOS.WriteXml("Configuracion.xml");
            }
            catch { }

        }
        private void Configurar()
        {
            _DATOS.Columns.Add("cUsuario");
            _DATOS.Columns.Add("cPassword");
        }
        private void LeerConfiguracion()
        {
            try
            {
                _DATOS.TableName = "Configurar";
                _DATOS.ReadXml("Configuracion.xml");
                String dato1 = Convert.ToString(_DATOS.Rows[0]["cUsuario"]);
                String dato2 = Convert.ToString(_DATOS.Rows[0]["cPassword"]);
                txbUsuario.Text = dato1;
                txbPassword.Text = dato2;
                Usuario = dato1;
                password = dato2;
            }

            catch { }

        }
        public Conexión()
        {
            InitializeComponent();
            Configurar();
            LeerConfiguracion();
            img();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean acceso = false;
            try
            {

                DataManager.CLS.DBConexion._User = txbUsuario.Text;
                DataManager.CLS.DBConexion._password = txbPassword.Text;
                DataTable provar = new DataTable();
                provar = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
                if (provar.Rows.Count >= 1)
                {
                    acceso = true;
                }
            }
            catch
            {
            }
            if (lblConexion.Text == "Conectado" || acceso)
            {
                _validar = true;
                DataRow NuevaFila = _DATOS.NewRow();
                _DATOS.Rows.Clear();
                NuevaFila["cUsuario"] = txbUsuario.Text;
                NuevaFila["cPassword"] = txbPassword.Text;
                DataManager.CLS.DBConexion._User = txbUsuario.Text;
                DataManager.CLS.DBConexion._password = txbPassword.Text;
                _DATOS.Rows.Add(NuevaFila);
                GuardarConfiguracion();
                LeerConfiguracion();
                Close();
            }
            else {
                MessageBox.Show("No se pudo establecer una conexión a la base de datos, por favor ingrese el usuario y la contraseña y seleccione provar conexión", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _validar = false;
            Close();
        }
        private void img() {
            if (lblConexion.Text == "Desconectado")
            {
                lblConexion.ForeColor = Color.Red;
                pbNo.Visible = true;
                pbSi.Visible = false;
            }
            else {
                lblConexion.ForeColor = Color.Green;
                pbNo.Visible = false;
                pbSi.Visible = true;
            }
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try {
                DataManager.CLS.DBConexion._User = txbUsuario.Text;
                DataManager.CLS.DBConexion._password = txbPassword.Text;
                DataTable provar = new DataTable();
                provar = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
                if (provar.Rows.Count >= 1)
                {
                    lblConexion.Text = "Conectado";
                }
            }
            catch {
            }
            img();
        }

        private void txbUsuario_TextChanged(object sender, EventArgs e)
        {
            lblConexion.Text = "Desconectado";
            img();
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            lblConexion.Text = "Desconectado";
            img();
        }
    }
}
