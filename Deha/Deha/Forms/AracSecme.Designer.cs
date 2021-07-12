namespace Deha.Forms
{
    partial class AracSecme
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.AracCombo = new System.Windows.Forms.ComboBox();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(22, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 14);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Araç :";
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FooterPanel.Controls.Add(this.btnIptal);
            this.FooterPanel.Controls.Add(this.btnKaydet);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 48);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(312, 40);
            this.FooterPanel.TabIndex = 18;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(23, 9);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal - ESC";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(159, 9);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet - ENTER";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // AracCombo
            // 
            this.AracCombo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.AracCombo.FormattingEnabled = true;
            this.AracCombo.Location = new System.Drawing.Point(63, 12);
            this.AracCombo.Name = "AracCombo";
            this.AracCombo.Size = new System.Drawing.Size(220, 21);
            this.AracCombo.TabIndex = 33;
            // 
            // AracSecme
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(312, 88);
            this.Controls.Add(this.AracCombo);
            this.Controls.Add(this.FooterPanel);
            this.Controls.Add(this.labelControl4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AracSecme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç/Servis Seçme";
            this.Load += new System.EventHandler(this.AracSecme_Load);
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel FooterPanel;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.ComboBox AracCombo;
    }
}