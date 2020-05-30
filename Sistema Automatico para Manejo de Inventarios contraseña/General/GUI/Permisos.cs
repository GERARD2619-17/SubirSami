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
    public partial class Permisos : Form
    {
        BindingSource OPCIONES = new BindingSource();
        private void CargarRoles() {
            DataTable Roles = new DataTable();
            Roles = CacheManager.CLS.Cache.TODOS_LOS_ROLES();
            cbRoles.DataSource = Roles;
            cbRoles.DisplayMember = "Rol";
            cbRoles.ValueMember = "IDRol";
        }

        private void CargarAsignaciones() {
            OPCIONES.DataSource = CacheManager.CLS.Cache.ASIGNACIONES_DE_PERMISOS_SEGUN_IDROL(cbRoles.SelectedValue.ToString());
            dtgOpciones.AutoGenerateColumns = false;
            dtgOpciones.DataSource = OPCIONES;
        }


        public Permisos()
        {
            InitializeComponent();
            CargarRoles();
            cbRoles.SelectedIndex = 0;
            CargarAsignaciones();
        }

        private void cbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }

        private void dtgOpciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0) {
                    Int32 Valor = 0;
                    CLS.Permisos oPermiso = new CLS.Permisos();
                    oPermiso.IDRol = cbRoles.SelectedValue.ToString();
                    Valor = Convert.ToInt32(dtgOpciones.CurrentRow.Cells["IDPermiso"].Value.ToString());
                    if (Valor > 0)
                    {
                        oPermiso.IDPermiso = Valor.ToString();
                        oPermiso.Revocar();
                    }
                    else {
                        oPermiso.IDOpcion = dtgOpciones.CurrentRow.Cells["IDOpcion"].Value.ToString();
                        oPermiso.Conceder();
                    }
                    CargarAsignaciones();
                }
            }
            catch {
            }
        }
    }
}
