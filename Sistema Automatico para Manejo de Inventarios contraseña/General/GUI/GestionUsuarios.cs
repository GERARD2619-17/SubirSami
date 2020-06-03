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
    public partial class GestionUsuarios : Form
    {
        BindingSource _DATOS = new BindingSource();
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        
        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
                dtgDatos.AutoGenerateColumns = false;
                dtgDatos.DataSource = _DATOS;
            }
            catch { }
        }

        public GestionUsuarios()
        {
            InitializeComponent();
            Cargar();
        }
        
        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EdicionUsuario f = new EdicionUsuario();
                    f.txbID.Text = dtgDatos.CurrentRow.Cells["IDUsuario"].Value.ToString();
                    f.txbUsuarios.Text = dtgDatos.CurrentRow.Cells["Usuario"].Value.ToString();
                    f.cbRol.Text = dtgDatos.CurrentRow.Cells["Rol"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
            }
            catch {
                MessageBox.Show("Ocurrio un error inesperado", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                InsercionUsuario f = new InsercionUsuario();
                f.ShowDialog();
                Cargar();
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea ELIMINAR el registro seleccionado? esta accion no se podra deshacer", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_SESION.Informacion.Usuario == dtgDatos.CurrentRow.Cells["Usuario"].Value.ToString())
                    {
                        MessageBox.Show("No se puede eliminar este usario porque esta en uso", "Pregunta", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    else
                    {
                        CLS.Usuarios oUsuario = new CLS.Usuarios();
                        //SINCRONIZAR
                        oUsuario.IDUsuario = dtgDatos.CurrentRow.Cells["IDUsuario"].Value.ToString();

                        if (oUsuario.Eliminar())
                        {
                            Cargar();
                        }
                    }

                   
                }
            }
            catch
            {
                MessageBox.Show("No se puede eliminar este usuario", "NOTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
