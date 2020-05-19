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
    public partial class Configuracion : Form
    {
        private int Opcion = 1;
        BindingSource _DATOS1 = new BindingSource();
        BindingSource _DATOS2 = new BindingSource();
        BindingSource _DATOS3 = new BindingSource();
        BindingSource _DATOS4 = new BindingSource();
        //BindingSource _DATOS5 = new BindingSource();

        private void Cargar() {
            try
            {
                _DATOS1.DataSource = CacheManager.CLS.Cache.TODAS_LAS_CLASIFICACIONES();
                _DATOS2.DataSource = CacheManager.CLS.Cache.TODOS_LOS_ALMACENAMIENTOS();
                _DATOS3.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PROVEEDORES();
                _DATOS4.DataSource = CacheManager.CLS.Cache.TODOS_LOS_EMPLEADOS();
                //_DATOS5.DataSource = CacheManager.CLS.Cache.TODAS_LAS_CLASIFICACIONES();
            }
            catch
            {
            }
        }
        private void Clasificaciones()
        {
            Opcion = 1;
            dtgDatos1.AutoGenerateColumns = false;
            dtgDatos1.DataSource = _DATOS1;
            dtgDatos1.Visible = true;
            dtgDatos2.Visible = false;
            dtgDatos3.Visible = false;
            dtgDatos4.Visible = false;
        }
        private void Almacenamientos()
        {
            Opcion = 2;
            dtgDatos2.AutoGenerateColumns = false;
            dtgDatos2.DataSource = _DATOS2;
            dtgDatos1.Visible = false;
            dtgDatos2.Visible = true;
            dtgDatos3.Visible = false;
            dtgDatos4.Visible = false;
        }
        private void Proveedores()
        {
            Opcion = 3;
            dtgDatos3.AutoGenerateColumns = false;
            dtgDatos3.DataSource = _DATOS3;
            dtgDatos1.Visible = false;
            dtgDatos2.Visible = false;
            dtgDatos3.Visible = true;
            dtgDatos4.Visible = false;
        }
        private void Empleados()
        {
            Opcion = 4;
            dtgDatos4.AutoGenerateColumns = false;
            dtgDatos4.DataSource = _DATOS4;
            dtgDatos1.Visible = false;
            dtgDatos2.Visible = false;
            dtgDatos3.Visible = false;
            dtgDatos4.Visible = true;
        }


        public Configuracion()
        {
            InitializeComponent();
            Cargar();
            Clasificaciones();
        }
        
        private void btnClasificaciones_Click(object sender, EventArgs e)
        {
            Clasificaciones();
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            Almacenamientos();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Empleados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (Opcion){
                case 1:
                    AgregarClasificaciones();
                    break;
                case 2:
                    AgregarAlmacenamientos();
                    break;
                case 3:
                    AgregarProveedores();
                    break;
                case 4:
                    AgregarEmpleados();
                    break;

            }
        }
        private void AgregarClasificaciones()
        {
            try
            {
                EdicionClasificaciones f = new EdicionClasificaciones();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }
        private void AgregarAlmacenamientos()
        {
            try
            {
                EdicionAlmacenamientos f = new EdicionAlmacenamientos();
                f.ShowDialog();
                Cargar();
            }
            catch { }
           
        }
        private void AgregarProveedores()
        {
            MessageBox.Show("Agregar Proveedores", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void AgregarEmpleados()
        {
            try
            {
                EdicionEmpleados f = new EdicionEmpleados();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            switch (Opcion)
            {
                case 1:
                    EditarClasificaciones();
                    break;
                case 2:
                    EditarAlmacenamientos();
                    break;
                case 3:
                    EditarProveedores();
                    break;
                case 4:
                    EditarEmpleados();
                    break;
            }
        }

        private void EditarClasificaciones() {
            if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                try
                {
                    EdicionClasificaciones f = new EdicionClasificaciones();
                    f.txbId.Text = dtgDatos1.CurrentRow.Cells["IdClasificacion"].Value.ToString();
                    f.txbClasificacion.Text = dtgDatos1.CurrentRow.Cells["Clasificacion"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
                catch { }
            }
        }
        private void EditarAlmacenamientos() {

        }
        private void EditarProveedores() {
        }
        private void EditarEmpleados() {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (Opcion)
            {
                case 1:
                    EliminarClasificaciones();
                    break;
                case 2:
                    EliminarAlmacenamientos();
                    break;
                case 3:
                    EliminarProveedores();
                    break;
                case 4:
                    EliminarEmpleados();
                    break;
            }
        }
        private void EliminarClasificaciones() {
            try
            {
                if (MessageBox.Show("¿Realmente desea ELIMINAR el registro seleccionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CLS.Clasificaciones oClasificaciones = new CLS.Clasificaciones();
                    oClasificaciones.IdClasificacion = dtgDatos1.CurrentRow.Cells["IdClasificacion"].Value.ToString();
                    oClasificaciones.Eliminar();
                }
            }
            catch {
            }
            Cargar();
        }
        private void EliminarAlmacenamientos() { }
        private void EliminarProveedores() { }
        private void EliminarEmpleados() { }
    }
}
