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

            lblUsuario.Text = "Usuario: " + _SESION.Informacion.Usuario;
            Cargar_Principal();
            
        }

        //Cierra todos los formularios abiertos
        private void Cerrar_Todo() {
            foreach (Form childForm in MdiChildren)
            {
                
                childForm.Close();
                
            }
        }
        private void Cargar_Principal() {

            try
            {
                General.GUI.GestionProductos f = new General.GUI.GestionProductos();
                f.MdiParent = this;
               
                f.Show();
            }
            catch
            {}
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar_Todo();
            Cargar_Principal();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Cerrar_Todo();
            Cargar_Principal();
        }
    }
}
