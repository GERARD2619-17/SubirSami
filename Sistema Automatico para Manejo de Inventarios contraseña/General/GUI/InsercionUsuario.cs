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

            ////Verificacion para que no se repita un dato
            //String Consulta = "SELECT NombreProveedor From Proveedores WHERE NombreProveedor = '" + txbNombres.Text + "';";
            //DataTable Datos = new DataTable();
            //DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            //Datos = Consultor.Consultar(Consulta);
            //if (Datos.Rows.Count == 1)
            //{
            //    verificado = false;
            //    MessageBox.Show("Este proveedor ya se encuentra registrado", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}



            return verificado;
        }

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

            //Se llena el ComboBox con una lista de los empleados
            List<string> listaEmpleados = new List<string>();
            try
            {
                String Consulta2 = "SELECT * FROM empleados;";
                DataTable Datos2 = new DataTable();
                DataManager.CLS.DBOperacion Consultor2 = new DataManager.CLS.DBOperacion();
                Datos2 = Consultor2.Consultar(Consulta2);
                for (int i = 0; i < Datos2.Rows.Count; i++)
                {
                    listaEmpleados.Add(Datos2.Rows[i]["Nombres"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de clasificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbEmpleados.DataSource = listaEmpleados;


        }



        public InsercionUsuario()
        {
            InitializeComponent();
            LlenarComboBox();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                String Consulta1 = "select IDRol  from Roles where Rol = '" + cbRol.Text + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta1);

                String Consulta2 = "select IDEmpleado  from empleados where nombres = '" + cbEmpleados.Text + "';";
                DataTable Datos2 = new DataTable();
                DataManager.CLS.DBOperacion Consultor2 = new DataManager.CLS.DBOperacion();
                Datos2 = Consultor2.Consultar(Consulta2);


                CLS.Usuarios oUsuarios = new CLS.Usuarios();
                oUsuarios.Usuario = txbUsuarios.Text;
                oUsuarios.Credencial = txbCredencial.Text;
                oUsuarios.IDRol = Datos.Rows[0]["IDRol"].ToString();
                oUsuarios.IDEmpleado = Datos2.Rows[0]["IDEmpleado"].ToString();


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
