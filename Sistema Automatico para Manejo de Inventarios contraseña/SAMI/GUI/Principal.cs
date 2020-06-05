using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAMI.GUI
{
    public partial class Principal : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = _SESION.Informacion.Usuario;
            lblRol.Text = _SESION.Informacion.Rol;
            Cargar_Principal();
        }

        //Cierra todos los formularios abiertos
        private void Cerrar_Todo() {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void Cargar_Productos()
        {
            try
            {
                General.GUI.GestionProductos f = new General.GUI.GestionProductos();
                f.MdiParent = this;

                f.Show();
            }
            catch
            { }
        }
        private void Cargar_Usuarios()
        {
            try
            {
                General.GUI.GestionUsuarios f = new General.GUI.GestionUsuarios();
                f.MdiParent = this;

                f.Show();
            }
            catch
            { }
        }
        private void Cargar_Principal() {
            try
            {
                General.GUI.PrincipalEntrada f = new General.GUI.PrincipalEntrada();
                f.MdiParent = this;
                f.Show();
            }
            catch
            {}
        }
        private void Cargar_Bodega()
        {
            try
            {
                General.GUI.GestionBodega f = new General.GUI.GestionBodega();
                f.MdiParent = this;

                f.Show();
            }
            catch
            { }
        }
        private void Cargar_Historial()
        {
            try
            {
                General.GUI.Historial f = new General.GUI.Historial();
                f.MdiParent = this;
                f.Show();
            }
            catch
            { }
        }
        private void Cargar_Pedidos()
        {
            try
            {
                General.GUI.GestionPedidos f = new General.GUI.GestionPedidos();
                f.MdiParent = this;
                f.Show();
            }
            catch
            { }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar_Todo();
            Cargar_Principal();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Cerrar_Todo();
            Cargar_Principal();
           
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(1))
            {
                Cerrar_Todo();
                Cargar_Productos();
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(6)) {
                General.GUI.Configuracion f = new General.GUI.Configuracion();
                f.Show();
            }
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(3))
            {
                Cerrar_Todo();
                Cargar_Bodega();
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(4))
            {
                Cerrar_Todo();
                Cargar_Historial();
            }
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(5)) {
                Cerrar_Todo();
                Cargar_Pedidos();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(2))
            {
                Cerrar_Todo();
                Cargar_Usuarios();
            }
        }

        private void btnPrincipal_Click_1(object sender, EventArgs e)
        {
            Cerrar_Todo();
            Cargar_Principal();
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(6))
            {
                Reportes.GUI.VisorReportesProductos f = new Reportes.GUI.VisorReportesProductos();
                f.Show();
            }
        }

        private void reporteDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reporteHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (_SESION.Informacion.VerificarPermiso(6))
            {
                Reportes.GUI.VisorReportesHistorial f = new Reportes.GUI.VisorReportesHistorial();
                f.Validar = false;
                f.Show();
            }
        }

        private void reportePorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(6))
            {
                General.GUI.Fecha f = new General.GUI.Fecha();
                f.Opcion = 2;
                f.Show();
            }
        }

        private void reporteGeneralToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(6))
            {
                Reportes.GUI.VisorReportesPedidos f = new Reportes.GUI.VisorReportesPedidos();
                f.Validar = false;
                f.Show();
            }
        }

        private void reportePorFechaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.Informacion.VerificarPermiso(6))
            {

                General.GUI.Fecha f = new General.GUI.Fecha();
       
                f.Opcion = 1;
                f.Show();
            }
        }
    }
}
