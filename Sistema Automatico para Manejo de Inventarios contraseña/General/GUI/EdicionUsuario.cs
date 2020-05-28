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
        //LLENA LOS COMBOBOX DE CLASIFICACIONES Y LUGAR DE ALMACENAMIENTO
        private void LlenarComboBox()
        {
            //Se llena el ComboBox con una lista de las clasificaciones
            List<string> listaRoles = new List<string>();
            try
            {
                String Consulta1 = "SELECT * FROM Roles;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta1);
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    listaRoles.Add(Datos.Rows[i]["Rol"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de clasificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbRol.DataSource = listaRoles;

           


        }

        public EdicionUsuario()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String Consulta1 = "select IDRol  from Roles where Rol = '" + cbRol.Text + "';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta1);

            CLS.Usuarios oUsuarios = new CLS.Usuarios();
            oUsuarios.IDUsuario = txbID.Text;
            oUsuarios.Usuario = txbUsuarios.Text;
            oUsuarios.Credencial = txbCredencial.Text;
            oUsuarios.IDRol = Datos.Rows[0]["IDRol"].ToString();

            if (oUsuarios.Actualizar2())
            {
                Close();
            }
           
               


            
                


                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
