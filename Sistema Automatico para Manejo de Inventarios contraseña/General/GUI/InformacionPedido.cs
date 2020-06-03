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
    public partial class InformacionPedido : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar(String ID)
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PEDIDOS_PRODUCTOS(ID);
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }

        public InformacionPedido(String ID)
        {
            InitializeComponent();
            Cargar(ID);
        }

        
    }
}
