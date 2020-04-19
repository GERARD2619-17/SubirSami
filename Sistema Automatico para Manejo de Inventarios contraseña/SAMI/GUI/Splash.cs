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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void cronometro_Tick(object sender, EventArgs e)
        {
            cronometro.Start();
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {

                cronometro.Stop();
               // Login lg = new Login();
                this.Hide();
               // lg.Show();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            cronometro.Start();
        }
        
    }
}
