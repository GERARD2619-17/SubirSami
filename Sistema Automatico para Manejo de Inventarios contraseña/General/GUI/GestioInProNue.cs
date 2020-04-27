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
    public partial class GestioInProNue : Form
    {
        public GestioInProNue()
        {
            InitializeComponent();
            
        }

        private void btnEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
        }

    }
}
