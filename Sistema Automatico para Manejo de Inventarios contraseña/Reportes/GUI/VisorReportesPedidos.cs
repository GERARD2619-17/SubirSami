using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class VisorReportesPedidos : Form
    {
        private void Generar1()
        {
            try
            {
                REP.ReportePedidos oReporte = new REP.ReportePedidos();
                oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTES_PEDIDOS());
                crvVisorP.ReportSource = oReporte;
            }
            catch
            {

            }

        }
        public VisorReportesPedidos()
        {
            InitializeComponent();
        }

        private void VisorReportesPedidos_Load(object sender, EventArgs e)
        {
            Generar1();
        }
    }
}
