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

        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PEDIDOS();
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }


        public GestionPedidos()
        {
            InitializeComponent();
            Cargar();
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
    }
}
