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
    public partial class Fecha : Form
    {
        int _Opcion;

        public int Opcion { get => _Opcion; set => _Opcion = value; }

        public Fecha()
        {
            InitializeComponent();
        }

       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_Opcion == 1)
            {
                Reportes.GUI.VisorReportesPedidos f = new Reportes.GUI.VisorReportesPedidos();
                f.Fecha1 = dtFechaI.Value.ToString("yyyy-MM-dd");
                f.Fecha2 = dtFechaF.Value.ToString("yyyy-MM-dd");
                f.Validar = true;
                f.Show();
            }
            if (_Opcion == 2)
            {
                Reportes.GUI.VisorReportesHistorial f = new Reportes.GUI.VisorReportesHistorial();
                f.Fecha1 = dtFechaI.Value.ToString("yyyy-MM-dd");
                f.Fecha2 = dtFechaF.Value.ToString("yyyy-MM-dd");
                f.Validar = true;
                f.Show();
            }
         
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
