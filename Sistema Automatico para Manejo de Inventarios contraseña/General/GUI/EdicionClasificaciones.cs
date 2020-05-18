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
    public partial class EdicionClasificaciones : Form
    {
        public EdicionClasificaciones()
        {
            InitializeComponent();
        }

        private Boolean Validar() {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbClasificacion.TextLength == 0)
            {
                Notificador.SetError(txbClasificacion, "Este campo no puede quedar vacío");
                verificado = false;
            }

            //Verificacion para que no se repita un dato
            String Consulta = "SELECT Clasificacion From clasificaciones WHERE Clasificacion = '"+txbClasificacion.Text+"';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta);
            if (Datos.Rows.Count == 1) {
                verificado = false;
                MessageBox.Show("Esta clasificacion ya se encuentra registrada", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            return verificado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar()) {
                    CLS.Clasificaciones oClasificaciones = new CLS.Clasificaciones();
                    oClasificaciones.IdClasificacion = txbId.Text;
                    oClasificaciones.Clasificacion = txbClasificacion.Text;
                    if (txbId.TextLength > 0) {
                        if (oClasificaciones.Actualizar())
                        {
                            Close();
                        }
                    }
                    else {
                        if (oClasificaciones.Guardar())
                        {
                            Close();
                        }
                    }
                }
            }
            catch { }
        }
    }
}
