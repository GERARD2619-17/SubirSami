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
        String _Fecha1;
        String _Fecha2;
        Boolean _Validar = false;

        public string Fecha1 { get => _Fecha1; set => _Fecha1 = value; }
        public string Fecha2 { get => _Fecha2; set => _Fecha2 = value; }
        public bool Validar { get => _Validar; set => _Validar = value; }

        private void Generar2()
        {
            try
            {
                REP.ReporteHistorial oReporte = new REP.ReporteHistorial();
                if (_Validar)
                {
                    oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTES_HISTORIAL(_Fecha1, _Fecha2));
                    
                }
                else
                {
                    oReporte.SetDataSource(CacheManager.CLS.Cache.REPORTES_HISTORIAL());
                }
               
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
