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
    public partial class EdicionClasificaciones : Form
    {
        public EdicionClasificaciones()
        {
            InitializeComponent();
        }

        private Boolean Validar() {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbClasificacion.TextLength == 0)
            {
                Notificador.SetError(txbClasificacion, "Este campo no puede quedar vacío");
                verificado = false;
            }
            return verificado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar()) {

                }
            }
            catch { }
        }
    }
}
