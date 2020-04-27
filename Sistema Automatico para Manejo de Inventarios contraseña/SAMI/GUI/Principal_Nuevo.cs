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
    public partial class Principal_Nuevo : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public Principal_Nuevo()
        {
            InitializeComponent();
        }

        private void gestionProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                General.GUI.GestionProductos f = new General.GUI.GestionProductos();
                f.MdiParent = this;
                f.Show();
            }
            catch
            {

            }
        }
    }
}
