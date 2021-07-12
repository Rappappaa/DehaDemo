namespace Deha
{
    partial class AlinacakKart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlinacakKart));
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.AlisTarihi = new DevExpress.XtraEditors.DateEdit();
            this.TeslimTarihi = new DevExpress.XtraEditors.DateEdit();
            this.FirmaCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.AracCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtNot = new System.Windows.Forms.RichTextBox();
            this.AktifMi = new DevExpress.XtraEditors.CheckEdit();
            this.txtRank = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnMusteriBul = new DevExpress.XtraEditors.SimpleButton();
            this.txtMusteriAdi = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.FooterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlisTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlisTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeslimTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeslimTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AracCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktifMi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FooterPanel.Controls.Add(this.btnIptal);
            this.FooterPanel.Controls.Add(this.btnKaydet);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 288);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(444, 40);
            this.FooterPanel.TabIndex = 9;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(120, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal - ESC";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(256, 10);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet - ENTER";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(28, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Alış Tarihi :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 14);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Teslim Tarihi :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(40, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Müşteri :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(59, 142);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 14);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Araç :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(39, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Firmalar :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(64, 168);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(30, 14);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "Not :";
            // 
            // AlisTarihi
            // 
            this.AlisTarihi.EditValue = null;
            this.AlisTarihi.Location = new System.Drawing.Point(100, 36);
            this.AlisTarihi.Name = "AlisTarihi";
            this.AlisTarihi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.AlisTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlisTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AlisTarihi.Size = new System.Drawing.Size(150, 20);
            this.AlisTarihi.TabIndex = 1;
            // 
            // TeslimTarihi
            // 
            this.TeslimTarihi.EditValue = null;
            this.TeslimTarihi.Location = new System.Drawing.Point(100, 62);
            this.TeslimTarihi.Name = "TeslimTarihi";
            this.TeslimTarihi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.TeslimTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TeslimTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TeslimTarihi.Size = new System.Drawing.Size(150, 20);
            this.TeslimTarihi.TabIndex = 2;
            this.TeslimTarihi.EditValueChanged += new System.EventHandler(this.TeslimTarihi_EditValueChanged);
            // 
            // FirmaCombo
            // 
            this.FirmaCombo.Location = new System.Drawing.Point(100, 114);
            this.FirmaCombo.Name = "FirmaCombo";
            this.FirmaCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirmaCombo.Size = new System.Drawing.Size(150, 20);
            this.FirmaCombo.TabIndex = 5;
            // 
            // AracCombo
            // 
            this.AracCombo.Location = new System.Drawing.Point(100, 140);
            this.AracCombo.Name = "AracCombo";
            this.AracCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AracCombo.Size = new System.Drawing.Size(150, 20);
            this.AracCombo.TabIndex = 6;
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(100, 166);
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(276, 78);
            this.txtNot.TabIndex = 7;
            this.txtNot.Text = "";
            // 
            // AktifMi
            // 
            this.AktifMi.Location = new System.Drawing.Point(100, 249);
            this.AktifMi.Name = "AktifMi";
            this.AktifMi.Properties.Caption = "Aktif Kayıt";
            this.AktifMi.Size = new System.Drawing.Size(90, 20);
            this.AktifMi.TabIndex = 8;
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(100, 10);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(150, 20);
            this.txtRank.TabIndex = 0;
            this.txtRank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRank_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(63, 12);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 14);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Sıra :";
            // 
            // btnMusteriBul
            // 
            this.btnMusteriBul.Location = new System.Drawing.Point(256, 88);
            this.btnMusteriBul.Name = "btnMusteriBul";
            this.btnMusteriBul.Size = new System.Drawing.Size(83, 19);
            this.btnMusteriBul.TabIndex = 4;
            this.btnMusteriBul.Text = "Müşteri Bul";
            this.btnMusteriBul.Click += new System.EventHandler(this.btnMusteriBul_Click);
            // 
            // txtMusteriAdi
            // 
            this.txtMusteriAdi.Location = new System.Drawing.Point(100, 89);
            this.txtMusteriAdi.Name = "txtMusteriAdi";
            this.txtMusteriAdi.Size = new System.Drawing.Size(150, 20);
            this.txtMusteriAdi.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(345, 88);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 19);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "Fiş Bul";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // AlinacakKart
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(444, 328);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtMusteriAdi);
            this.Controls.Add(this.btnMusteriBul);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.AktifMi);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.AracCombo);
            this.Controls.Add(this.FirmaCombo);
            this.Controls.Add(this.TeslimTarihi);
            this.Controls.Add(this.AlisTarihi);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.FooterPanel);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("AlinacakKart.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlinacakKart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlinacakKart";
            this.Load += new System.EventHandler(this.AlinacakKart_Load);
            this.FooterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlisTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlisTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeslimTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeslimTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AracCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AktifMi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FooterPanel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.DateEdit AlisTarihi;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.DateEdit TeslimTarihi;
        private DevExpress.XtraEditors.ImageComboBoxEdit FirmaCombo;
        private DevExpress.XtraEditors.ImageComboBoxEdit AracCombo;
        private System.Windows.Forms.RichTextBox txtNot;
        private DevExpress.XtraEditors.CheckEdit AktifMi;
        private DevExpress.XtraEditors.TextEdit txtRank;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnMusteriBul;
        private DevExpress.XtraEditors.TextEdit txtMusteriAdi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}