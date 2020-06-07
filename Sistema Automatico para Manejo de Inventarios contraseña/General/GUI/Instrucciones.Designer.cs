namespace General.GUI
{
    partial class Instrucciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instrucciones));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Anterior = new System.Windows.Forms.ToolStripButton();
            this.Siguiente = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Anterior,
            this.Siguiente});
            this.toolStrip1.Location = new System.Drawing.Point(0, 408);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Anterior
            // 
            this.Anterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Anterior.Image = ((System.Drawing.Image)(resources.GetObject("Anterior.Image")));
            this.Anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Anterior.Name = "Anterior";
            this.Anterior.Size = new System.Drawing.Size(39, 39);
            this.Anterior.Text = "Anterior";
            // 
            // Siguiente
            // 
            this.Siguiente.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Siguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Siguiente.Image = ((System.Drawing.Image)(resources.GetObject("Siguiente.Image")));
            this.Siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(39, 39);
            this.Siguiente.Text = "Siguiente";
            // 
            // Instrucciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Instrucciones";
            this.Text = "Instrucciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Anterior;
        private System.Windows.Forms.ToolStripButton Siguiente;
    }
}