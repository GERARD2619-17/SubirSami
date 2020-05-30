namespace General.GUI
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClasificaciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBodega = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProveedores = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmpleados = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRoles = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.dtgDatos1 = new System.Windows.Forms.DataGridView();
            this.IdClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDatos2 = new System.Windows.Forms.DataGridView();
            this.IdAlmacenamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LugarAlmacenamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDatos3 = new System.Windows.Forms.DataGridView();
            this.IDProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDatos4 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos4)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClasificaciones,
            this.toolStripSeparator1,
            this.btnBodega,
            this.toolStripSeparator2,
            this.btnProveedores,
            this.toolStripSeparator3,
            this.btnEmpleados,
            this.toolStripSeparator4,
            this.btnRoles});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(120, 450);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClasificaciones
            // 
            this.btnClasificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClasificaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnClasificaciones.Image")));
            this.btnClasificaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClasificaciones.Name = "btnClasificaciones";
            this.btnClasificaciones.Size = new System.Drawing.Size(117, 24);
            this.btnClasificaciones.Text = "Clasificaciones";
            this.btnClasificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClasificaciones.Click += new System.EventHandler(this.btnClasificaciones_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // btnBodega
            // 
            this.btnBodega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBodega.Image = ((System.Drawing.Image)(resources.GetObject("btnBodega.Image")));
            this.btnBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBodega.Name = "btnBodega";
            this.btnBodega.Size = new System.Drawing.Size(117, 24);
            this.btnBodega.Text = "Bodega";
            this.btnBodega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBodega.Click += new System.EventHandler(this.btnBodega_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // btnProveedores
            // 
            this.btnProveedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(117, 24);
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(117, 6);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.Image")));
            this.btnEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(117, 24);
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(117, 6);
            // 
            // btnRoles
            // 
            this.btnRoles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRoles.Image = ((System.Drawing.Image)(resources.GetObject("btnRoles.Image")));
            this.btnRoles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(117, 24);
            this.btnRoles.Text = "Roles de acceso";
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.toolStripSeparator5,
            this.btnEditar,
            this.toolStripSeparator6,
            this.btnEliminar});
            this.toolStrip2.Location = new System.Drawing.Point(120, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(645, 32);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 29);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(77, 29);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 29);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtgDatos1
            // 
            this.dtgDatos1.AllowUserToAddRows = false;
            this.dtgDatos1.AllowUserToDeleteRows = false;
            this.dtgDatos1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgDatos1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDatos1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDatos1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDatos1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgDatos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdClasificacion,
            this.Clasificacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDatos1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDatos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos1.Location = new System.Drawing.Point(120, 32);
            this.dtgDatos1.MultiSelect = false;
            this.dtgDatos1.Name = "dtgDatos1";
            this.dtgDatos1.ReadOnly = true;
            this.dtgDatos1.RowHeadersVisible = false;
            this.dtgDatos1.RowTemplate.Height = 24;
            this.dtgDatos1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos1.Size = new System.Drawing.Size(645, 418);
            this.dtgDatos1.TabIndex = 8;
            // 
            // IdClasificacion
            // 
            this.IdClasificacion.DataPropertyName = "IdClasificacion";
            this.IdClasificacion.HeaderText = "Id";
            this.IdClasificacion.Name = "IdClasificacion";
            this.IdClasificacion.ReadOnly = true;
            // 
            // Clasificacion
            // 
            this.Clasificacion.DataPropertyName = "Clasificacion";
            this.Clasificacion.HeaderText = "Clasificacion";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            // 
            // dtgDatos2
            // 
            this.dtgDatos2.AllowUserToAddRows = false;
            this.dtgDatos2.AllowUserToDeleteRows = false;
            this.dtgDatos2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgDatos2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgDatos2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDatos2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDatos2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgDatos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAlmacenamiento,
            this.LugarAlmacenamiento});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDatos2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgDatos2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos2.Location = new System.Drawing.Point(120, 32);
            this.dtgDatos2.MultiSelect = false;
            this.dtgDatos2.Name = "dtgDatos2";
            this.dtgDatos2.ReadOnly = true;
            this.dtgDatos2.RowHeadersVisible = false;
            this.dtgDatos2.RowTemplate.Height = 24;
            this.dtgDatos2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos2.Size = new System.Drawing.Size(645, 418);
            this.dtgDatos2.TabIndex = 9;
            this.dtgDatos2.Visible = false;
            // 
            // IdAlmacenamiento
            // 
            this.IdAlmacenamiento.DataPropertyName = "IdAlmacenamiento";
            this.IdAlmacenamiento.HeaderText = "Id";
            this.IdAlmacenamiento.Name = "IdAlmacenamiento";
            this.IdAlmacenamiento.ReadOnly = true;
            // 
            // LugarAlmacenamiento
            // 
            this.LugarAlmacenamiento.DataPropertyName = "LugarAlmacenamiento";
            this.LugarAlmacenamiento.HeaderText = "Lugar de almacenamiento";
            this.LugarAlmacenamiento.Name = "LugarAlmacenamiento";
            this.LugarAlmacenamiento.ReadOnly = true;
            // 
            // dtgDatos3
            // 
            this.dtgDatos3.AllowUserToAddRows = false;
            this.dtgDatos3.AllowUserToDeleteRows = false;
            this.dtgDatos3.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgDatos3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgDatos3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos3.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDatos3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDatos3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgDatos3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProveedor,
            this.NombreProveedor});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDatos3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgDatos3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos3.Location = new System.Drawing.Point(120, 32);
            this.dtgDatos3.MultiSelect = false;
            this.dtgDatos3.Name = "dtgDatos3";
            this.dtgDatos3.ReadOnly = true;
            this.dtgDatos3.RowHeadersVisible = false;
            this.dtgDatos3.RowTemplate.Height = 24;
            this.dtgDatos3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos3.Size = new System.Drawing.Size(645, 418);
            this.dtgDatos3.TabIndex = 10;
            this.dtgDatos3.Visible = false;
            // 
            // IDProveedor
            // 
            this.IDProveedor.DataPropertyName = "IDProveedor";
            this.IDProveedor.HeaderText = "Id";
            this.IDProveedor.Name = "IDProveedor";
            this.IDProveedor.ReadOnly = true;
            // 
            // NombreProveedor
            // 
            this.NombreProveedor.DataPropertyName = "NombreProveedor";
            this.NombreProveedor.HeaderText = "Proveedor";
            this.NombreProveedor.Name = "NombreProveedor";
            this.NombreProveedor.ReadOnly = true;
            // 
            // dtgDatos4
            // 
            this.dtgDatos4.AllowUserToAddRows = false;
            this.dtgDatos4.AllowUserToDeleteRows = false;
            this.dtgDatos4.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgDatos4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgDatos4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos4.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDatos4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDatos4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgDatos4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Genero});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDatos4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgDatos4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos4.Location = new System.Drawing.Point(120, 32);
            this.dtgDatos4.MultiSelect = false;
            this.dtgDatos4.Name = "dtgDatos4";
            this.dtgDatos4.ReadOnly = true;
            this.dtgDatos4.RowHeadersVisible = false;
            this.dtgDatos4.RowTemplate.Height = 24;
            this.dtgDatos4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos4.Size = new System.Drawing.Size(645, 418);
            this.dtgDatos4.TabIndex = 11;
            this.dtgDatos4.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombres";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Genero
            // 
            this.Genero.DataPropertyName = "Genero";
            this.Genero.HeaderText = "Genero";
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.dtgDatos4);
            this.Controls.Add(this.dtgDatos3);
            this.Controls.Add(this.dtgDatos2);
            this.Controls.Add(this.dtgDatos1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClasificaciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBodega;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnProveedores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEmpleados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRoles;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.DataGridView dtgDatos1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridView dtgDatos2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAlmacenamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LugarAlmacenamiento;
        private System.Windows.Forms.DataGridView dtgDatos3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProveedor;
        private System.Windows.Forms.DataGridView dtgDatos4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
    }
}