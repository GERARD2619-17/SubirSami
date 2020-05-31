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
    public partial class PrincipalEntrada : Form
    {
        public PrincipalEntrada()
        {
            InitializeComponent();
        }

        private void PrincipalEntrada_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
        }
    }
}
