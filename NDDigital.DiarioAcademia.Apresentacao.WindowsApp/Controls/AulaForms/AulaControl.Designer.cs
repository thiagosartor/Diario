﻿namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    partial class AulaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listAulas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listAulas
            // 
            this.listAulas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAulas.FormattingEnabled = true;
            this.listAulas.Location = new System.Drawing.Point(0, 0);
            this.listAulas.Name = "listAulas";
            this.listAulas.Size = new System.Drawing.Size(317, 267);
            this.listAulas.TabIndex = 0;
            // 
            // AulaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listAulas);
            this.Name = "AulaControl";
            this.Size = new System.Drawing.Size(317, 267);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listAulas;
    }
}
