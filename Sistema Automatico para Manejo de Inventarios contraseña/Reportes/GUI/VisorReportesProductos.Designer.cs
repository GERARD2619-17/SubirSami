namespace Reportes.GUI
{
    partial class VisorReportesProductos
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
            this.cvrVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cvrVisor
            // 
            this.cvrVisor.ActiveViewIndex = -1;
            this.cvrVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvrVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvrVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvrVisor.Location = new System.Drawing.Point(0, 0);
            this.cvrVisor.Name = "cvrVisor";
            this.cvrVisor.Size = new System.Drawing.Size(800, 450);
            this.cvrVisor.TabIndex = 0;
            this.cvrVisor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisorReportesProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cvrVisor);
            this.Name = "VisorReportesProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisorReportesProductos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorReportesProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvrVisor;
    }
}