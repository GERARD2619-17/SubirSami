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
            try
            {
             

                REP.ReporteProductos oReporte = new REP.ReporteProductos();
                oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTE_PRODUCTO());
                
                cvrVisor.ReportSource = oReporte;

               
            }
            catch
            {

            }

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
