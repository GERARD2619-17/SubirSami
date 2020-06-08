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
    public partial class Instrucciones : Form
    {
        int _Indice;
        public int Indice { get => _Indice; set => _Indice = value; }

        private void imagenVisible()
        {
            switch (_Indice)
            {
                case 1:
                    pb1.Visible = true;
                    pb2.Visible = false;
                    pb3.Visible = false;
                    pb4.Visible = false;
                    pb5.Visible = false;
                    pb6.Visible = false;
                    pb7.Visible = false;
                    break;

                case 2:
                    pb1.Visible = false;
                    pb2.Visible = true;
                    pb3.Visible = false;
                    pb4.Visible = false;
                    pb5.Visible = false;
                    pb6.Visible = false;
                    pb7.Visible = false;
                    break;

                case 3:
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = true;
                    pb4.Visible = false;
                    pb5.Visible = false;
                    pb6.Visible = false;
                    pb7.Visible = false;
                    break;
                case 4:
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = false;
                    pb4.Visible = true;
                    pb5.Visible = false;
                    pb6.Visible = false;
                    pb7.Visible = false;
                    break;
                case 5:
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = false;
                    pb4.Visible = false;
                    pb5.Visible = true;
                    pb6.Visible = false;
                    pb7.Visible = false;
                    break;
                case 6:
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = false;
                    pb4.Visible = false;
                    pb5.Visible = false;
                    pb6.Visible = true;
                    pb7.Visible = false;
                    break;
                case 7:
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = false;
                    pb4.Visible = false;
                    pb5.Visible = false;
                    pb6.Visible = false;
                    pb7.Visible = true;
                    break;
            }
        }

        public Instrucciones()
        {
            InitializeComponent();
            imagenVisible();
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            if(_Indice < 7)
            {
                _Indice++;
            }
            imagenVisible();
        }

        private void Anterior_Click(object sender, EventArgs e)
        {
            if (_Indice > 1)
            {
                _Indice--;
            }
            imagenVisible();
        }

        private void Instrucciones_Load(object sender, EventArgs e)
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
