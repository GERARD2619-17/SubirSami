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
    public partial class VisorReportesProductos : Form
    {
        private void Generar()
        {
            REP.ReporteProductos oReporte = new REP.ReporteProductos();
            oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTES_PRODUCTOS());
            crvVisor.ReportSource = oReporte;
        }
        public VisorReportesProductos()
        {
            InitializeComponent();
        }

        private void VisorReportesProductos_Load(object sender, EventArgs e)
        {
            Generar();
        }
    }
}
