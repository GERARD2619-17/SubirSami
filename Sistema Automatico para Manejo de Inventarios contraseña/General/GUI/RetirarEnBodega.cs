﻿using System;
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
    public partial class RetirarEnBodega : Form
    {
        SessionManager.CLS.Sesion _SESION = SessionManager.CLS.Sesion.Instancia;
        public RetirarEnBodega()
        {
            InitializeComponent();
        }
        private Boolean Validar(String numero)
        {
            int cant = Int32.Parse(numero);
            Boolean verificado = true;
            Notificador.Clear();
            if (Int32.Parse(nudCantidad.Text) > cant)
            {
                Notificador.SetError(nudCantidad, "No se pueden retirar mas de " + numero + " Productos");
                verificado = false;
            }
            if (Int32.Parse(nudCantidad.Text) == 0)
            {
                Notificador.SetError(nudCantidad, "No se pueden retirar 0 Productos");
                verificado = false;
            }
            return verificado;
        }
        private void Registro() {
            try
            {
                String Consulta = "SELECT * from Productos where NombreProducto = '" + txbNombre.Text + "' AND Estado = '" + txbEstado.Text + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                String id = Datos.Rows[0]["IDProducto"].ToString();

                CLS.Registros oRegistros = new CLS.Registros();
                oRegistros.IDUsuario = _SESION.Informacion.IDUsuario;
                oRegistros.IDProducto = id;
                oRegistros.Accion = lblProducto.Text;
                oRegistros.Cantidad = nudCantidad.Text;
                oRegistros.TiempoAccion = DateTime.Now.ToString("yyy/MM/dd") + " " + DateTime.Now.ToString("hh:mm:ss");

                oRegistros.Guardar();
            }
            catch {
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String Consulta = "SELECT * from Productos where NombreProducto = '" + txbNombre.Text + "' AND Estado = '" + txbEstado.Text + "';";
                DataTable Datos = new DataTable();
                DataManager.CLS.DBOperacion Consultor = new DataManager.CLS.DBOperacion();
                Datos = Consultor.Consultar(Consulta);
                String cant = Datos.Rows[0]["Cantidad"].ToString();
                String cant1 = (Int32.Parse(cant) - Int32.Parse(nudCantidad.Text)).ToString();
                if (Validar(cant))
                {
                    CLS.Producto oProducto = new CLS.Producto();
                    //SINCRONIZAR
                    oProducto.IDProducto = Datos.Rows[0]["IDProducto"].ToString();
                    oProducto.NombreProducto = Datos.Rows[0]["NombreProducto"].ToString();
                    oProducto.Estado = Datos.Rows[0]["Estado"].ToString();
                    oProducto.IdClasificacion = Datos.Rows[0]["IdClasificacion"].ToString();
                    oProducto.Precio = Datos.Rows[0]["Precio"].ToString().Replace(",", ".");
                    oProducto.Descripcion = Datos.Rows[0]["Descripcion"].ToString();
                    oProducto.Cantidad = cant1;
                    oProducto.IDAlmacenamiento = Datos.Rows[0]["IDAlmacenamiento"].ToString();
                    oProducto.Existencia = Datos.Rows[0]["Existencia"].ToString();
                    Registro();
                    if (oProducto.Actualizar())
                    {
                        Close();
                    }
                }
            }
            catch { }
        }
    }
}
