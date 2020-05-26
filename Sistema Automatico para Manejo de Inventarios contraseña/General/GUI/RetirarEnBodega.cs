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
    public partial class RetirarEnBodega : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public RetirarEnBodega()
        {
            InitializeComponent();
        }
        private Boolean Validar(String numero)
        {
            int id = Int32.Parse(numero);
            Boolean verificado = true;
            Notificador.Clear();
            if (lblProducto.Text == "Retiro")
            {
                if (Int32.Parse(nudCantidad.Text) > id)
                {
                    Notificador.SetError(nudCantidad, "No se pueden retirar mas de " + numero + " Productos");
                    verificado = false;
                }
            }
            return verificado;
        }
        private void Registro() {
            try
            {
                String Consulta = "SELECT * from Productos where NombreProducto = '" + txbNombre.Text + "' AND Estado = '" + txbEstado.Text + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                String id = Datos.Rows[0]["IDProducto"].ToString();

                String Consulta2 = "SELECT * from Usuarios where Usuario = '" + _SESION.Informacion.Usuario +"';";
                DataTable Datos2 = new DataTable();
                DataManager.CLS.DBOperacion Consultor2 = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta2);
                String id2 = Datos.Rows[0]["IDUsuario"].ToString();

                CLS.Registros oRegistros = new CLS.Registros();
                oRegistros.IDUsuario = id2;
                oRegistros.IDProducto = id;
                oRegistros.Accion = lblProducto.Text;
                oRegistros.Cantidad = nudCantidad.Text;
                oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");

                oRegistros.Guardar();
            }
            catch {
            }
            

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String Consulta = "SELECT * from Productos where NombreProducto = '" + txbNombre.Text + "' AND Estado = '" + txbEstado.Text + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                String id = Datos.Rows[0]["Cantidad"].ToString();
                String cant1 = (Int32.Parse(id) - Int32.Parse(nudCantidad.Text)).ToString();
                String cant2 = (Int32.Parse(id) + Int32.Parse(nudCantidad.Text)).ToString();
                if (Validar(id))
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    //SINCRONIZAR
                    oProducto.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    oProducto.NombreProducto = Datos.Rows[0]["NombreProducto"].ToString();
                    oProducto.Estado = Datos.Rows[0]["Estado"].ToString();
                    oProducto.IdClasificacion = Datos.Rows[0]["IdClasificacion"].ToString();
                    oProducto.Descripcion = Datos.Rows[0]["Descripcion"].ToString();
                    if (lblProducto.Text == "Retiro") {
                        oProducto.Cantidad = cant1;
                    }
                    else {
                        oProducto.Cantidad = cant2;
                    }
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
    }
}
