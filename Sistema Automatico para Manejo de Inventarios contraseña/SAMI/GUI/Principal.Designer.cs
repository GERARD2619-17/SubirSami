namespace SAMI.GUI
{
    partial class Principal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgInformacion = new System.Windows.Forms.DataGridView();
            this.texto = new System.Windows.Forms.Label();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónInNueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgInformacion
            // 
            this.dtgInformacion.AllowUserToAddRows = false;
            this.dtgInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgInformacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgInformacion.BackgroundColor = System.Drawing.Color.White;
            this.dtgInformacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgInformacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInformacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgInformacion.ColumnHeadersHeight = 30;
            this.dtgInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgInformacion.EnableHeadersVisualStyles = false;
            this.dtgInformacion.Location = new System.Drawing.Point(34, 146);
            this.dtgInformacion.Name = "dtgInformacion";
            this.dtgInformacion.RowHeadersVisible = false;
            this.dtgInformacion.RowTemplate.Height = 24;
            this.dtgInformacion.Size = new System.Drawing.Size(995, 251);
            this.dtgInformacion.TabIndex = 0;
            // 
            // texto
            // 
            this.texto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.texto.AutoSize = true;
            this.texto.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto.Location = new System.Drawing.Point(445, 9);
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(204, 39);
            this.texto.TabIndex = 1;
            this.texto.Text = "Tablas existentes";
            this.texto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.Location = new System.Drawing.Point(34, 74);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEmpleados.Size = new System.Drawing.Size(204, 50);
            this.btnEmpleados.TabIndex = 2;
            this.btnEmpleados.Text = "Mostrar lista de empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRoles.AutoEllipsis = true;
            this.btnRoles.Location = new System.Drawing.Point(296, 74);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(204, 50);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "Mostrar lista de roles";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.Location = new System.Drawing.Point(562, 74);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(204, 50);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "Mostrar lista de usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Green;
            this.lblUsuario.Location = new System.Drawing.Point(-4, 28);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(72, 20);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1068, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónInNueToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // gestiónInNueToolStripMenuItem
            // 
            this.gestiónInNueToolStripMenuItem.Name = "gestiónInNueToolStripMenuItem";
            this.gestiónInNueToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.gestiónInNueToolStripMenuItem.Text = "GestiónInNue";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "Mostrar lista de Productos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.texto);
            this.Controls.Add(this.dtgInformacion);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgInformacion;
        private System.Windows.Forms.Label texto;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónInNueToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}