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
    public partial class EdicionEmpleados : Form
    {
        public EdicionEmpleados()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Boolean Validar() {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbNombres.TextLength == 0)
            {
                Notificador.SetError(txbNombres, "Este campo no puede quedar vacío");
                verificado = false;
            }
            if (txbApellidos.TextLength == 0)
            {
                Notificador.SetError(txbApellidos, "Este campo no puede quedar vacío");
                verificado = false;
            }
            return verificado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Empleado oEmpleados = new CLS.Empleado();
                    oEmpleados.IDEmpleado = txbId.Text;
                    oEmpleados.Nombres = txbNombres.Text;
                    oEmpleados.Apellidos = txbApellidos.Text;
                    if (rbMasculino.Checked) { oEmpleados.Genero = "Masculino"; }
                    else { oEmpleados.Genero = "Femenino"; }
                    if (txbId.TextLength > 0)
                    {
                        if (oEmpleados.Actualizar())
                        {
                            Close();
                        }
                    }
                    else
                    {
                        if (oEmpleados.Guardar())
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
