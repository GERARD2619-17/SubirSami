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
    public partial class GestionPedidos : Form
    {
        BindingSource _DATOS = new BindingSource();
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PEDIDOS();
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }


        public GestionPedidos()
        {
            InitializeComponent();
            Cargar();
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                EdicionPedidos f = new EdicionPedidos();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionPedido f = new InformacionPedido(dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString());
                f.ShowDialog();
                Cargar();
            }
            catch {
                MessageBox.Show("No se encontraron pedidos registrados", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataTable GetProducto(String nombre, String estado)
        {
            String Consulta = "SELECT * from Productos where NombreProducto = '" + nombre + "' AND Estado = '" + estado + "';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta);
            return Datos;
        }
        private void ActualizarProducto(String ID, String Cantidad1, String Cantidad2) {
            CLS.Producto oProducto = new CLS.Producto();
            oProducto.IDProducto = ID;
            oProducto.Insertar(Convert.ToString(Int32.Parse(Cantidad1) + Int32.Parse(Cantidad2)));
            RegistrarEnHistorial(ID, Cantidad1);
        }
        private void RegistrarEnHistorial(String idprod, String cant) {
            CLS.Registros oRegistros = new CLS.Registros();
            oRegistros.IDUsuario = _SESION.Informacion.IDUsuario;
            oRegistros.IDProducto = idprod;
            oRegistros.Accion = "Inserción";
            oRegistros.Cantidad = cant;
            oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");
            oRegistros.Guardar();
        }
        private void Registrar(String ID) {
            DataTable PedidosPorProducto = new DataTable();
            PedidosPorProducto = CacheManager.CLS.Cache.TODOS_LOS_PEDIDOS_PRODUCTOS(ID);
            DataTable Producto = new DataTable();
            for (int i=0; i< PedidosPorProducto.Rows.Count; i++) {
                Producto = GetProducto(PedidosPorProducto.Rows[i]["NombreProducto"].ToString(), PedidosPorProducto.Rows[i]["Estado"].ToString());
                ActualizarProducto(Producto.Rows[0]["IDProducto"].ToString(), PedidosPorProducto.Rows[i]["Cantidad"].ToString(), Producto.Rows[0]["Cantidad"].ToString());
            }
        }
        private void btnRecibido_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDatos.CurrentRow.Cells["Estado"].Value.ToString() == "Pedido")
                {
                    if (MessageBox.Show("¿Marcar como recibido? se actualizara en bodega", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        String Id = dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString();
                        CLS.Pedidos oPedidos = new CLS.Pedidos();
                        oPedidos.IdPedido = Id;
                        Registrar(Id);
                        oPedidos.Actualizar();
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("Este pedido ya esta registrado como recibido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch {
                MessageBox.Show("No se encontraron pedidos registrados", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GestionPedidos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
