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
                lblRegistros.Text = dtgDatos.Rows.Count.ToString() + " Registros Encontrados";
            }
            catch { }
        }

        private void Registro()
        {
            try
            {
                //Consulta para obtener Id del producto de los pedidos ya que solo se muestra el nombre del producto
                String Consulta1 = "SELECT * from Pedidos where IdPedido = " + dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString() + ";";
                DataTable Datos1 = new DataTable();
                DataManager.CLS.DBOperacion Consultor1 = new DataManager.CLS.DBOperacion();
                Datos1 = Consultor1.Consultar(Consulta1);
                String idprod = Datos1.Rows[0]["IDProducto"].ToString();

                //REGISTRA EN EL HISTORIAL LOS DATOS DEL PEDIDO
                CLS.Registros oRegistros = new CLS.Registros();
                oRegistros.IDUsuario = _SESION.Informacion.IDUsuario;
                oRegistros.IDProducto = idprod;
                oRegistros.Accion = "Inserción";
                oRegistros.Cantidad = dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString();
                oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");

                oRegistros.Guardar();

                //Consulta para obtener el producto a actualizar luego del ingreso del pedido
                String Consulta3 = "SELECT * from Productos where IDProducto = '" + idprod + "';";
                DataTable Datos3 = new DataTable();
                DataManager.CLS.DBOperacion Consultor3 = new DataManager.CLS.DBOperacion();
                Datos3 = Consultor3.Consultar(Consulta3);

                //REGISTRA EN BODEGA LOS DATOS DEL PEDIDO
                CLS.Producto oProducto = new CLS.Producto();
                oProducto.IDProducto = Datos3.Rows[0]["IDProducto"].ToString();
                oProducto.NombreProducto = Datos3.Rows[0]["NombreProducto"].ToString();
                oProducto.Estado = Datos3.Rows[0]["Estado"].ToString();
                oProducto.IdClasificacion = Datos3.Rows[0]["IdClasificacion"].ToString();
                oProducto.Descripcion = Datos3.Rows[0]["Descripcion"].ToString();
                oProducto.Cantidad = Convert.ToString(Int32.Parse(Datos3.Rows[0]["Cantidad"].ToString()) + Int32.Parse(dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString()));
                oProducto.IDAlmacenamiento = Datos3.Rows[0]["IDAlmacenamiento"].ToString();
                oProducto.Existencia = "Existente";

                oProducto.Actualizar();
            }
            catch { }

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

        private void btnMarcarRecibido_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("¿Marcar como recibido? se registrara en bodega", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    String Consulta = "SELECT * FROM Pedidos WHERE IdPedido =" + dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString() + ";";
                    DataTable Datos = new DataTable();
                    DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                    Datos = Consultor.Consultar(Consulta);
                    if (Datos.Rows[0]["Estado"].ToString() == "Pedido")
                    {
                        CLS.Pedidos oPedidos = new CLS.Pedidos();
                        oPedidos.IdPedido = Datos.Rows[0]["IDPedido"].ToString();
                        oPedidos.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                        oPedidos.Cantidad = Datos.Rows[0]["Cantidad"].ToString();
                        oPedidos.IDProveedor = Datos.Rows[0]["IDProveedor"].ToString();
                        oPedidos.Fecha_de_pedido = dtgDatos.CurrentRow.Cells["Fecha_de_pedido"].Value.ToString();
                        oPedidos.TiempoPromedio = Datos.Rows[0]["TiempoPromedio"].ToString();
                        oPedidos.Estado = "Recibido";
                        oPedidos.Actualizar();
                        Registro();
                    }
                    Cargar();

                }
            }
            catch {
                MessageBox.Show("No se a hecho ningun pedido", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public GestionPedidos()
        {
            InitializeComponent();
            Cargar();
        }

        private void btnProductosPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                Pendientes f = new Pendientes();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void GestionPedidos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
        }
    }
}
