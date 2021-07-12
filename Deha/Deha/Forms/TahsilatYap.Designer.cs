namespace Deha.Forms
{
    partial class TahsilatYap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TahsilatYap));
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtNot = new System.Windows.Forms.RichTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnFisBul = new DevExpress.XtraEditors.SimpleButton();
            this.KrediKarti = new DevExpress.XtraEditors.CheckEdit();
            this.Nakit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMusteriAdi = new DevExpress.XtraEditors.TextEdit();
            this.btnMusteriBul = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.FooterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KrediKarti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nakit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FooterPanel.Controls.Add(this.btnIptal);
            this.FooterPanel.Controls.Add(this.btnKaydet);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 185);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(437, 40);
            this.FooterPanel.TabIndex = 26;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(157, 8);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal - ESC";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(293, 8);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet - ENTER";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(95, 90);
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(276, 78);
            this.txtNot.TabIndex = 36;
            this.txtNot.Text = "";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(59, 92);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(30, 14);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Not :";
            // 
            // btnFisBul
            // 
            this.btnFisBul.Location = new System.Drawing.Point(340, 11);
            this.btnFisBul.Name = "btnFisBul";
            this.btnFisBul.Size = new System.Drawing.Size(83, 19);
            this.btnFisBul.TabIndex = 35;
            this.btnFisBul.Text = "Fiş Bul";
            this.btnFisBul.Click += new System.EventHandler(this.btnFisBul_Click);
            // 
            // KrediKarti
            // 
            this.KrediKarti.Location = new System.Drawing.Point(174, 64);
            this.KrediKarti.Name = "KrediKarti";
            this.KrediKarti.Properties.Caption = "Kredi Kartı";
            this.KrediKarti.Size = new System.Drawing.Size(73, 20);
            this.KrediKarti.TabIndex = 33;
            this.KrediKarti.CheckedChanged += new System.EventHandler(this.KrediKarti_CheckedChanged);
            // 
            // Nakit
            // 
            this.Nakit.Location = new System.Drawing.Point(95, 64);
            this.Nakit.Name = "Nakit";
            this.Nakit.Properties.Caption = "Nakit";
            this.Nakit.Size = new System.Drawing.Size(73, 20);
            this.Nakit.TabIndex = 32;
            this.Nakit.CheckedChanged += new System.EventHandler(this.Nakit_CheckedChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(7, 66);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(82, 14);
            this.labelControl8.TabIndex = 34;
            this.labelControl8.Text = "Ödeme Türü :";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(95, 38);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(150, 20);
            this.txtTutar.TabIndex = 30;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(48, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 14);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Tutar :";
            // 
            // txtMusteriAdi
            // 
            this.txtMusteriAdi.Location = new System.Drawing.Point(95, 12);
            this.txtMusteriAdi.Name = "txtMusteriAdi";
            this.txtMusteriAdi.Size = new System.Drawing.Size(150, 20);
            this.txtMusteriAdi.TabIndex = 27;
            // 
            // btnMusteriBul
            // 
            this.btnMusteriBul.Location = new System.Drawing.Point(251, 11);
            this.btnMusteriBul.Name = "btnMusteriBul";
            this.btnMusteriBul.Size = new System.Drawing.Size(83, 19);
            this.btnMusteriBul.TabIndex = 28;
            this.btnMusteriBul.Text = "Müşteri Bul";
            this.btnMusteriBul.Click += new System.EventHandler(this.btnMusteriBul_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(35, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Müşteri :";
            // 
            // TahsilatYap
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(437, 225);
            this.Controls.Add(this.FooterPanel);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnFisBul);
            this.Controls.Add(this.KrediKarti);
            this.Controls.Add(this.Nakit);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtMusteriAdi);
            this.Controls.Add(this.btnMusteriBul);
            this.Controls.Add(this.labelControl3);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("TahsilatYap.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TahsilatYap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tahsilat Yap";
            this.Load += new System.EventHandler(this.TahsilatYap_Load);
            this.FooterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KrediKarti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nakit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FooterPanel;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.RichTextBox txtNot;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnFisBul;
        private DevExpress.XtraEditors.CheckEdit KrediKarti;
        private DevExpress.XtraEditors.CheckEdit Nakit;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMusteriAdi;
        private DevExpress.XtraEditors.SimpleButton btnMusteriBul;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}