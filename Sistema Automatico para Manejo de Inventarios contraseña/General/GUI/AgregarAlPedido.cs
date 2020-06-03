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
    public partial class AgregarAlPedido : Form
    {
        Boolean _PROCESAR = false;
        List<string> _LProductos = new List<string>();
        List<string> _LEstado = new List<string>();
        List<string> _LCantidad = new List<string>();

        public List<string> LProductos { get => _LProductos; set => _LProductos = value; }
        public List<string> LEstado { get => _LEstado; set => _LEstado = value; }
        public bool PROCESAR { get => _PROCESAR; set => _PROCESAR = value; }
        public List<string> LCantidad { get => _LCantidad; set => _LCantidad = value; }

        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (nudCantidad.Value == 0)
            {
                Notificador.SetError(nudCantidad, "Este campo no puede ser cero");
                verificado = false;
            }
            return verificado;
        }
        public AgregarAlPedido()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar()) {
                    _LProductos.Add(txbProducto.Text);
                    _LEstado.Add(txbEstado.Text);
                    _LCantidad.Add(nudCantidad.Text);
                    _PROCESAR = true;
                    Close();
                }
            }
            catch {
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
