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
    public partial class VisorReportesHistorial : Form
    {

        private void Generar2()
        {
            try
            {
                REP.ReporteHistorial oReporte = new REP.ReporteHistorial();
                oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTES_HISTORIAL());
                crvVisorH.ReportSource = oReporte;
            }
            catch
            {

            }

        }
        public VisorReportesHistorial()
        {
            InitializeComponent();
            
        }

        private void VisorReportesHistorial_Load(object sender, EventArgs e)
        {
            Generar2();
        }
    }
}
