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
    public partial class Historial : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_REGISTROS();
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }
        public Historial()
        {
            InitializeComponent();
            Cargar();
        }
    }
}
