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
    public partial class EdicionProductos : Form
    {
        //VERIFICA SI EL NOMBRE INGRESADO Y EL ESTADO SELECCIONADO, YA SE ENCUENTRAR REGISTRADOS PARA NO INGRESAR 2 VECES EL MISMO PRODUCTO
        private Boolean VerificarProducto(String nombre, String estado) {
            Boolean verificar = false;
            try {
                String Consulta = "SELECT NombreProducto, Estado from Productos where NombreProducto = '" + nombre + "' AND Estado = '" + estado + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                if (Datos.Rows.Count == 1)
                {
                    verificar = true;
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return verificar;
        }
        private Boolean VerificarProducto2(String nombre, String estado) {
            Boolean verificar = false;
            try
            {
                String Consulta = "SELECT NombreProducto, Estado from Productos where IDProducto = " + txbId.Text + ";";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                if (Datos.Rows[0]["NombreProducto"].ToString() != nombre)
                {
                    verificar = VerificarProducto(nombre, estado);
                }
                else {
                    if (Datos.Rows[0]["Estado"].ToString() != estado) {
                        verificar = VerificarProducto(nombre, estado);
                    }
                }
            }
            catch {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return verificar;
        }

        //LLENA LOS COMBOBOX DE CLASIFICACIONES Y LUGAR DE ALMACENAMIENTO
        private void LlenarComboBox() {
            //Se llena el ComboBox con una lista de las clasificaciones
            List<string> listaClasificacion = new List<string>();
            try
            {
                String Consulta1 = "SELECT Clasificacion FROM Clasificaciones;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta1);
                for (int i = 0; i < Datos.Rows.Count; i++) {
                    listaClasificacion.Add(Datos.Rows[i]["Clasificacion"].ToString());
                }
            }
            catch {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de clasificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbClasificacion.DataSource = listaClasificacion;

            //Se llena el ComboBox con una lista de los almacenamientos
            List<string> listaAlmacenamiento = new List<string>();
            try
            {
                String Consulta2 = "SELECT LugarAlmacenamiento FROM Almacenamientos;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta2);
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    listaAlmacenamiento.Add(Datos.Rows[i]["LugarAlmacenamiento"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al llenar la lista de almacenamientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbAlmacenamiento.DataSource = listaAlmacenamiento;
            cbClasificacion.DataSource = listaClasificacion;
        }

        //RESIVE EL DATO STRING Y SU NUMERO DE TABLA Y DEVUELVE EL SU ID PRETENESIENTE
        private String ConvertirId(String cadena, int tabla) {
            String _id="";
            try {
                String Cadena = "";
                if (tabla == 1)
                {
                    //tabla de clasificaciones
                    Cadena = "SELECT IdClasificacion FROM Clasificaciones WHERE Clasificacion = '"+cadena+"';";
                    DataTable Datos = new DataTable();
                    DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                    Datos = Consultor.Consultar(Cadena);
                    _id = Datos.Rows[0]["IdClasificacion"].ToString();
                }
                else
                {
                    //tabla de almacenamientos
                    Cadena = "SELECT IDAlmacenamiento FROM Almacenamientos WHERE LugarAlmacenamiento = '"+cadena+"';";
                    DataTable Datos = new DataTable();
                    DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                    Datos = Consultor.Consultar(Cadena);
                    _id = Datos.Rows[0]["IDAlmacenamiento"].ToString();
                }
                
            }
            catch {
                MessageBox.Show("Ha ocurrido un error con los ids", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return _id;
        }

        private Boolean VerificarDatos() {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbNombre.TextLength == 0) {
                Notificador.SetError(txbNombre, "Este campo no puede quedar vacío");
                verificado = false;
            }

            //VALOR DEL ESTADO DEL PRODUCTO
            String estado;
            if (rbNuevo.Checked) { estado = "Nuevo"; }
            else { estado = "Usado"; }
            //EN CASO DE SER ACTUALIZACION
            if (txbId.TextLength > 0) {
                if (VerificarProducto2(txbNombre.Text, estado)) {
                    MessageBox.Show("El producto no puede actualizarse, ya se encuentra registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    verificado = false;
                }
            }
            //EN CASO DE SER INSERSION
            else
            {
                if (VerificarProducto(txbNombre.Text, estado))
                {
                    MessageBox.Show("El producto ya se encuentra registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    verificado = false;
                }
            }

            
            return verificado;
        }

        private void Procesar() {
            try {
                if (VerificarDatos())
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    //SINCRONIZAR
                    oProducto.IDProducto = txbId.Text;
                    oProducto.NombreProducto = txbNombre.Text;
                    oProducto.IdClasificacion = ConvertirId(cbClasificacion.Text,1);
                    oProducto.Cantidad = nudCantidad.Text;
                    oProducto.IDAlmacenamiento = ConvertirId(cbAlmacenamiento.Text,2);
                    oProducto.Existencia = cbExistencia.Text;
                    oProducto.Descripcion = txbDescripcion.Text;
                    if (rbNuevo.Checked) { oProducto.Estado = "Nuevo"; }
                    else { oProducto.Estado = "Usado"; }
                    if (txbId.TextLength > 0)
                    {
                        //ACTUALIZAR
                        if (oProducto.Actualizar())
                        {
                            Close();
                        }
                    }
                    else
                    {
                        //GUARDAR
                        if (oProducto.Guardar())
                        {
                            Close();
                        }
                    }
                }
            }
            catch {

            }
        }






        public EdicionProductos()
        {
            InitializeComponent();
            LlenarComboBox();
            cbExistencia.SelectedIndex = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Procesar();
        }
    }
}
