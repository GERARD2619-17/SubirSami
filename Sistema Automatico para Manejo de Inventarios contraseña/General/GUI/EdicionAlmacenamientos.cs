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
    public partial class EdicionAlmacenamientos : Form
    {
        public EdicionAlmacenamientos()
        {
            InitializeComponent();
        }

        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbAlmacenamientos.TextLength == 0)
            {
                Notificador.SetError(txbAlmacenamientos, "Este campo no puede quedar vacío");
                verificado = false;
            }
            //Verificacion para que no se repita un dato
            String Consulta = "SELECT LugarAlamacenamiento From almacenamientos WHERE LugarAlmacenamiento = '" + txbAlmacenamientos.Text + "';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta);
            if (Datos.Rows.Count == 1)
            {
                verificado = false;
                MessageBox.Show("La zona de almacenamiento ya se encuentra registrada", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            return verificado;



        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Almacenamientos oAlmacenamientos = new CLS.Almacenamientos();
                    oAlmacenamientos.IdAlmacenamiento = txbId.Text;
                    oAlmacenamientos.ZonaAlmacenamiento = txbAlmacenamientos.Text;
                    if (txbId.TextLength > 0)
                    {
                        if (oAlmacenamientos.Actualizar())
                        {
                            Close();
                        }
                    }
                    else
                    {
                        if (oAlmacenamientos.Guardar())
                        {
                            Close();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
