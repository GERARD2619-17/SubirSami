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
    public partial class DevolverProducto : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        private void Cargar()
        {
            try
            {
                String Consulta = "SELECT a.IDProducto, b.NombreProducto, b.Estado, Sum(if(Accion = 'Devolucion', -1 * a.Cantidad, a.Cantidad)) as Retirados from registros a, Productos b where a.IDProducto = b.IDProducto AND IDUsuario = "+ _SESION.Informacion.IDUsuario +" group by IDProducto order by IDProducto;";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = Datos;
            }
            catch { }
        }
        private Boolean Validar(String numero)
        {
            int cant = Int32.Parse(numero);
            Boolean verificado = true;
            Notificador.Clear();
            if (Int32.Parse(nudCantidad.Text) > cant)
            {
                Notificador.SetError(nudCantidad, "No se pueden devolver mas de " + numero + " Productos");
                verificado = false;
            }
            if (Int32.Parse(nudCantidad.Text) == 0)
            {
                Notificador.SetError(nudCantidad, "No se pueden devolver 0 Productos");
                verificado = false;
            }
            return verificado;
        }
        private void Registro()
        {
            try
            {
                CLS.Registros oRegistros = new CLS.Registros();
                oRegistros.IDUsuario = _SESION.Informacion.IDUsuario;
                oRegistros.IDProducto = txbId.Text;
                oRegistros.Accion = lblProducto.Text;
                oRegistros.Cantidad = nudCantidad.Text;
                oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");

                oRegistros.Guardar();
            }
            catch
            {
            }
        }
        public DevolverProducto()
        {
            InitializeComponent();
            Cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbId.TextLength < 1)
                {
                    MessageBox.Show("Por favor selecciona el producto a devolver", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                String Consulta = "SELECT * from Productos where IDProducto="+ txbId.Text + ";";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                String cant = dtgDatos.CurrentRow.Cells["Retirados"].Value.ToString();
                String cant1 = Datos.Rows[0]["Cantidad"].ToString();
                String cant2 = (Int32.Parse(cant1) + Int32.Parse(nudCantidad.Text)).ToString();
                if (Validar(cant))
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    oProducto.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    oProducto.NombreProducto = Datos.Rows[0]["NombreProducto"].ToString();
                    oProducto.Estado = Datos.Rows[0]["Estado"].ToString();
                    oProducto.IdClasificacion = Datos.Rows[0]["IdClasificacion"].ToString();
                    oProducto.Precio = Datos.Rows[0]["Precio"].ToString().Replace(",", ".");
                    oProducto.Descripcion = Datos.Rows[0]["Descripcion"].ToString();
                    oProducto.Cantidad = cant2;
                    oProducto.IDAlmacenamiento = Datos.Rows[0]["IDAlmacenamiento"].ToString();
                    oProducto.Existencia = Datos.Rows[0]["Existencia"].ToString();
                    Registro();
                    if (oProducto.Actualizar())
                    {
                        Close();
                    }
                }
            }
            catch { }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txbId.Text = dtgDatos.CurrentRow.Cells["IDProducto"].Value.ToString();
            txbNombre.Text = dtgDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
            txbEstado.Text = dtgDatos.CurrentRow.Cells["Estado"].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
