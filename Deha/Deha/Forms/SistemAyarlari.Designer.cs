namespace Deha.Forms
{
    partial class SistemAyarlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SistemAyarlari));
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtFirmaAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chckEvet = new DevExpress.XtraEditors.CheckEdit();
            this.chckHayir = new DevExpress.XtraEditors.CheckEdit();
            this.FooterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckEvet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckHayir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FooterPanel.Controls.Add(this.btnIptal);
            this.FooterPanel.Controls.Add(this.btnKaydet);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 103);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(422, 40);
            this.FooterPanel.TabIndex = 4;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(144, 8);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal - ESC";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(280, 8);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet - ENTER";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(280, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 20);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Ayarları Sıfırla";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(21, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(189, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Ürünler Adetli Hesaplansın mı ?";
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Enabled = false;
            this.txtFirmaAdi.Location = new System.Drawing.Point(91, 12);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(150, 20);
            this.txtFirmaAdi.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Firma Adı :";
            // 
            // chckEvet
            // 
            this.chckEvet.Location = new System.Drawing.Point(21, 67);
            this.chckEvet.Name = "chckEvet";
            this.chckEvet.Properties.Caption = "Evet";
            this.chckEvet.Size = new System.Drawing.Size(90, 20);
            this.chckEvet.TabIndex = 9;
            this.chckEvet.CheckedChanged += new System.EventHandler(this.chckEvet_CheckedChanged);
            // 
            // chckHayir
            // 
            this.chckHayir.Location = new System.Drawing.Point(117, 67);
            this.chckHayir.Name = "chckHayir";
            this.chckHayir.Properties.Caption = "Hayır";
            this.chckHayir.Size = new System.Drawing.Size(90, 20);
            this.chckHayir.TabIndex = 10;
            this.chckHayir.CheckedChanged += new System.EventHandler(this.chckHayir_CheckedChanged);
            // 
            // SistemAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 143);
            this.Controls.Add(this.chckHayir);
            this.Controls.Add(this.chckEvet);
            this.Controls.Add(this.txtFirmaAdi);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.FooterPanel);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("SistemAyarlari.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SistemAyarlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Ayarları";
            this.FooterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckEvet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckHayir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FooterPanel;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtFirmaAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chckEvet;
        private DevExpress.XtraEditors.CheckEdit chckHayir;
    }
}