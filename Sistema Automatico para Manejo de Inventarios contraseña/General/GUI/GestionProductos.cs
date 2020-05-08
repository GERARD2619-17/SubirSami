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
    public partial class GestionProductos : Form
    {
        BindingSource _DATOS = new BindingSource();

        //RESIVE LOS PARAMETROS DE NOMBRE DEL PRODUCTO Y SU ESTADO Y DEVUELVE SU TABLA
        private DataTable ObtenerTabla(String Nombre, String Estado) {
            DataTable Datos = new DataTable();
            try
            {
                String Consulta = @"SELECT 
                a.IDProducto, a.NombreProducto, a.Estado, b.Clasificacion, a.Descripcion, a.Cantidad, c.LugarAlmacenamiento, a.Existencia 
                FROM Productos a, Clasificaciones b, Almacenamientos c 
                WHERE a.IdClasificacion = b.IdClasificacion AND a.IDAlmacenamiento = c.IDAlmacenamiento AND a.NombreProducto = '" + Nombre + "' AND a.Estado = '" + Estado + "';";
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                
            }
            catch {
                MessageBox.Show("Ha ocurrido un error al llenar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos;
        }

        private void Cargar() {
            try {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PRODUCTOS();
                FiltrarLocalmente();
            }
            catch { }
        }
        private void FiltrarLocalmente() {
            try
            {
                if (txbBuscar.TextLength > 0)
                {
                    _DATOS.Filter = "NombreProducto LIKE '%" + txbBuscar.Text + "%' OR Estado LIKE '%" + txbBuscar.Text + "%' OR Clasificacion LIKE '%" + txbBuscar.Text + "%'";
                }
                else {
                    _DATOS.RemoveFilter();
                }
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
                lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
            }
            catch { }
        }




        public GestionProductos()
        {
            InitializeComponent();
            Cargar();
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EdicionProductos f = new EdicionProductos();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EdicionProductos f = new EdicionProductos();
                    //SINCRONIZAR
                    String Nombre = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
                    String Estado = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
                    DataTable Datos = new DataTable();
                    Datos = ObtenerTabla(Nombre, Estado);
                    f.txbId.Text = Datos.Rows[0]["IDProducto"].ToString();
                    f.txbNombre.Text = Datos.Rows[0]["NombreProducto"].ToString();
                    f.cbClasificacion.Text = Datos.Rows[0]["Clasificacion"].ToString();
                    f.nudCantidad.Text = Datos.Rows[0]["Cantidad"].ToString();
                    f.cbAlmacenamiento.Text = Datos.Rows[0]["LugarAlmacenamiento"].ToString();
                    f.cbExistencia.Text = Datos.Rows[0]["Existencia"].ToString();
                    f.txbDescripcion.Text = Datos.Rows[0]["Descripcion"].ToString();
                    if (Datos.Rows[0]["Estado"].ToString() == "Nuevo")
                    {
                        f.rbNuevo.Checked = true;
                        f.rbUsado.Checked = false;
                    }
                    else
                    {
                        f.rbNuevo.Checked = false;
                        f.rbUsado.Checked = true;
                    }
                    f.ShowDialog();
                    Cargar();
                }

            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea ELIMINAR el registro seleccionado? esta accion no se podra deshacer", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    //SINCRONIZAR
                    String Nombre = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
                    String Estado = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
                    DataTable Datos = new DataTable();
                    Datos = ObtenerTabla(Nombre, Estado);
                    oProducto.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    if (oProducto.Eliminar())
                    {
                        Cargar();
                    }
                }
            }
            catch
            {
            }
        }
    }
}
