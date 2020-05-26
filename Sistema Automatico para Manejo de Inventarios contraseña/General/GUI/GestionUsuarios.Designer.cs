namespace General.GUI
{
    partial class GestionUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREDENCIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPLEADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToDeleteRows = false;
            this.dtgDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.USUARIOS,
            this.CREDENCIAL,
            this.ROL,
            this.EMPLEADO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos.Location = new System.Drawing.Point(0, 0);
            this.dtgDatos.MultiSelect = false;
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.ReadOnly = true;
            this.dtgDatos.RowHeadersVisible = false;
            this.dtgDatos.RowTemplate.Height = 24;
            this.dtgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos.Size = new System.Drawing.Size(800, 450);
            this.dtgDatos.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // USUARIOS
            // 
            this.USUARIOS.DataPropertyName = "USUARIOS";
            this.USUARIOS.HeaderText = "USUARIOS";
            this.USUARIOS.Name = "USUARIOS";
            this.USUARIOS.ReadOnly = true;
            // 
            // CREDENCIAL
            // 
            this.CREDENCIAL.DataPropertyName = "CREDENCIAL";
            this.CREDENCIAL.HeaderText = "CREDENCIALES";
            this.CREDENCIAL.Name = "CREDENCIAL";
            this.CREDENCIAL.ReadOnly = true;
            // 
            // ROL
            // 
            this.ROL.DataPropertyName = "ROL";
            this.ROL.HeaderText = "ROL";
            this.ROL.Name = "ROL";
            this.ROL.ReadOnly = true;
            // 
            // EMPLEADO
            // 
            this.EMPLEADO.DataPropertyName = "EMPLEADO";
            this.EMPLEADO.HeaderText = "EMPLEADO";
            this.EMPLEADO.Name = "EMPLEADO";
            this.EMPLEADO.ReadOnly = true;
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgDatos);
            this.Name = "GestionUsuarios";
            this.Text = "GestionUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREDENCIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLEADO;
    }
}