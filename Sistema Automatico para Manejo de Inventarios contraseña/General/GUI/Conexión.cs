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
        public bool Validar { get => _validar; set => _validar = value; }
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
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _validar = false;
            Close();
        }
    }
}
