﻿namespace Reportes.GUI
{
    partial class VisorReportesPedidos
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
            this.crvVisorP = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVisorP
            // 
            this.crvVisorP.ActiveViewIndex = -1;
            this.crvVisorP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisorP.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisorP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisorP.Location = new System.Drawing.Point(0, 0);
            this.crvVisorP.Name = "crvVisorP";
            this.crvVisorP.Size = new System.Drawing.Size(800, 450);
            this.crvVisorP.TabIndex = 0;
            this.crvVisorP.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisorReportesPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvVisorP);
            this.Name = "VisorReportesPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisorReportesPedidos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorReportesPedidos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisorP;
    }
}