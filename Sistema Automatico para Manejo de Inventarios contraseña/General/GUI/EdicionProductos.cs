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
        private Boolean VerificarProducto(String nombre, String estado)
        {
            Boolean verificar = false;
            try
            {
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
        private Boolean VerificarProducto2(String nombre, String estado)
        {
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
                else
                {
                    if (Datos.Rows[0]["Estado"].ToString() != estado)
                    {
                        verificar = VerificarProducto(nombre, estado);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return verificar;
        }

        private void CargarClasificaciones()
        {
            DataTable Clasificaciones = new DataTable();
            Clasificaciones = CacheManager.CLS.Cache.TODAS_LAS_CLASIFICACIONES();
            cbClasificacion.DataSource = Clasificaciones;
            cbClasificacion.DisplayMember = "Clasificacion";
            cbClasificacion.ValueMember = "IdClasificacion";
        }
        private void CargarAlmacenamientos()
        {
            DataTable Almacenamientos = new DataTable();
            Almacenamientos = CacheManager.CLS.Cache.TODOS_LOS_ALMACENAMIENTOS();
            cbAlmacenamiento.DataSource = Almacenamientos;
            cbAlmacenamiento.DisplayMember = "LugarAlmacenamiento";
            cbAlmacenamiento.ValueMember = "IDAlmacenamiento";
        }
        private void CargarExistencia()
        {
            List<string> Existencia1 = new List<string>();
            List<string> Existencia2 = new List<string>();
            Existencia1.Add("Existente");
            Existencia2.Add("En envio");
            Existencia2.Add("Faltante");
            cbExistencia.DataSource = Existencia2;
            if (Int32.Parse(nudCantidad.Text) > 0)
            {
                cbExistencia.DataSource = Existencia1;
            }
            else {
                cbExistencia.DataSource = Existencia2;
            }
        }

        private Boolean VerificarDatos()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbNombre.TextLength == 0)
            {
                Notificador.SetError(txbNombre, "Este campo no puede quedar vacío");
                verificado = false;
            }

            //VALOR DEL ESTADO DEL PRODUCTO
            String estado;
            if (rbNuevo.Checked) { estado = "Nuevo"; }
            else { estado = "Usado"; }
            //EN CASO DE SER ACTUALIZACION
            if (txbId.TextLength > 0)
            {
                if (VerificarProducto2(txbNombre.Text, estado))
                {
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

        private void Procesar()
        {
            try
            {
                if (VerificarDatos())
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    //SINCRONIZAR
                    oProducto.IDProducto = txbId.Text;
                    oProducto.NombreProducto = txbNombre.Text;
                    oProducto.IdClasificacion = cbClasificacion.SelectedValue.ToString();
                    oProducto.Cantidad = nudCantidad.Text;
                    oProducto.IDAlmacenamiento = cbAlmacenamiento.SelectedValue.ToString();
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
            catch
            {

            }
        }


        public EdicionProductos()
        {
            InitializeComponent();
            CargarClasificaciones();
            CargarAlmacenamientos();
            CargarExistencia();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CargarExistencia();
        }
    }
}
