namespace Reportes.GUI
{
    partial class VisorReportesHistorial
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
            this.crvVisorH = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVisorH
            // 
            this.crvVisorH.ActiveViewIndex = -1;
            this.crvVisorH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisorH.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisorH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisorH.Location = new System.Drawing.Point(0, 0);
            this.crvVisorH.Name = "crvVisorH";
            this.crvVisorH.Size = new System.Drawing.Size(800, 450);
            this.crvVisorH.TabIndex = 0;
            this.crvVisorH.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisorReportesHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvVisorH);
            this.Name = "VisorReportesHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor Reportes - Historial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorReportesHistorial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisorH;
    }
}