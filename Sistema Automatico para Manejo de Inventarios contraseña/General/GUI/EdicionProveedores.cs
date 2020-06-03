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
    public partial class EdicionProveedores : Form
    {
        public EdicionProveedores()
        {
            InitializeComponent();
        }


        private Boolean Validar()
        {
            Boolean verificado = true;
            Notificador.Clear();
            if (txbProveedor.TextLength == 0)
            {
                Notificador.SetError(txbProveedor, "Este campo no puede quedar vacío");
                verificado = false;
            }
            //Verificacion para que no se repita un dato
            String Consulta = "SELECT NombreProveedor From Proveedores WHERE NombreProveedor = '" + txbProveedor.Text + "';";
            DataTable Datos = new DataTable();
            DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
            Datos = Consultor.Consultar(Consulta);
            if (Datos.Rows.Count == 1)
            {
                verificado = false;
                MessageBox.Show("Este proveedor ya se encuentra registrado", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return verificado;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Proveedores oProveedores = new CLS.Proveedores();
                    oProveedores.IdProveedor = txbId.Text;
                    oProveedores.NombreProveedor = txbProveedor.Text;
                    if (txbId.TextLength > 0)
                    {
                        if (oProveedores.Actualizar())
                        {
                            Close();
                        }
                    }
                    else
                    {
                        if (oProveedores.Guardar())
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
