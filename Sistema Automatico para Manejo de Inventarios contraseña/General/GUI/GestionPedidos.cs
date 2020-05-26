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
                String Consulta1 = "SELECT * from Pedidos where IdPedido = " + dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString() + ";";
                DataTable Datos1 = new DataTable();
                DataManager.CLS.DBOperacion Consultor1 = new DataManager.CLS.DBOperacion();
                Datos1 = Consultor1.Consultar(Consulta1);
                String idprod = Datos1.Rows[0]["IDProducto"].ToString();
                /////////////////////////////////////////////////////////

                String Consulta2 = "SELECT * from Usuarios where Usuario = '" + _SESION.Informacion.Usuario + "';";
                DataTable Datos2 = new DataTable();
                DataManager.CLS.DBOperacion Consultor2 = new DataManager.CLS.DBOperacion();
                Datos2 = Consultor2.Consultar(Consulta2);
                String id2 = Datos2.Rows[0]["IDUsuario"].ToString();

                CLS.Registros oRegistros = new CLS.Registros();
                oRegistros.IDUsuario = id2;
                oRegistros.IDProducto = idprod;
                oRegistros.Accion = "Inserción";
                oRegistros.Cantidad = dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString();
                oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");

                oRegistros.Guardar();

                String Consulta3 = "SELECT * from Productos where IDProducto = '" + idprod + "';";
                DataTable Datos3 = new DataTable();
                DataManager.CLS.DBOperacion Consultor3 = new DataManager.CLS.DBOperacion();
                Datos3 = Consultor3.Consultar(Consulta3);

                CLS.Producto oProducto = new CLS.Producto();
                oProducto.NombreProducto = Datos3.Rows[0]["NombreProducto"].ToString();
                oProducto.Estado = Datos3.Rows[0]["Estado"].ToString();
                oProducto.IdClasificacion = Datos3.Rows[0]["IdClasificacion"].ToString();
                oProducto.Descripcion = Datos3.Rows[0]["Descripcion"].ToString();
                oProducto.Cantidad = (Int32.Parse(Datos3.Rows[0]["Cantidad"].ToString()) + Int32.Parse(dtgDatos.CurrentRow.Cells["Cantidad"].Value.ToString())).ToString();
                oProducto.IDAlmacenamiento = Datos3.Rows[0]["IDAlmacenamiento"].ToString();
                oProducto.Existencia = "Existente";
                oProducto.Guardar();
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
            if (MessageBox.Show("¿Marcar como recibido? se registrara en bodega", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    String Consulta = "SELECT * FROM Pedidos WHERE IdPedido ="+ dtgDatos.CurrentRow.Cells["IdPedido"].Value.ToString() + ";";
                    DataTable Datos = new DataTable();
                    DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                    Datos = Consultor.Consultar(Consulta);
                    if (Datos.Rows[0]["Estado"].ToString() == "Pedido") {
                        CLS.Pedidos oPedidos = new CLS.Pedidos();
                        oPedidos.IdPedido = Datos.Rows[0]["IDPedido"].ToString();
                        oPedidos.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                        oPedidos.Cantidad= Datos.Rows[0]["Cantidad"].ToString();
                        oPedidos.IDProveedor = Datos.Rows[0]["IDProveedor"].ToString();
                        oPedidos.Fecha_de_pedido = dtgDatos.CurrentRow.Cells["Fecha_de_pedido"].Value.ToString();
                        oPedidos.TiempoPromedio = Datos.Rows[0]["TiempoPromedio"].ToString();
                        oPedidos.Estado = "Recibido";
                        oPedidos.Actualizar();
                        Registro();
                    }
                    Cargar();
                }
                catch { }
            }
        }
        public GestionPedidos()
        {
            InitializeComponent();
            Cargar();
        }
    }
}
