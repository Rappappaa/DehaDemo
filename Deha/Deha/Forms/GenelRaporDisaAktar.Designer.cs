namespace Deha.Forms
{
    partial class GenelRaporDisaAktar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenelRaporDisaAktar));
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gelirtoplam = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gelirnakit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gelirkredikarti = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gelirdiger = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gider = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tamamlanmissiparisler = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.alinansiparisler = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.FooterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gelirtoplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirnakit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirkredikarti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirdiger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamamlanmissiparisler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alinansiparisler.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FooterPanel.Controls.Add(this.btnIptal);
            this.FooterPanel.Controls.Add(this.btnKaydet);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 198);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(293, 40);
            this.FooterPanel.TabIndex = 7;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(12, 8);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal - ESC";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(148, 8);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet - ENTER";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // gelirtoplam
            // 
            this.gelirtoplam.Location = new System.Drawing.Point(167, 8);
            this.gelirtoplam.Name = "gelirtoplam";
            this.gelirtoplam.Properties.Caption = "Aktar";
            this.gelirtoplam.Size = new System.Drawing.Size(90, 20);
            this.gelirtoplam.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(79, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(82, 14);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Toplam Gelir :";
            // 
            // gelirnakit
            // 
            this.gelirnakit.Location = new System.Drawing.Point(167, 34);
            this.gelirnakit.Name = "gelirnakit";
            this.gelirnakit.Properties.Caption = "Aktar";
            this.gelirnakit.Size = new System.Drawing.Size(90, 20);
            this.gelirnakit.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(44, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Toplam Gelir Nakit :";
            // 
            // gelirkredikarti
            // 
            this.gelirkredikarti.Location = new System.Drawing.Point(167, 60);
            this.gelirkredikarti.Name = "gelirkredikarti";
            this.gelirkredikarti.Properties.Caption = "Aktar";
            this.gelirkredikarti.Size = new System.Drawing.Size(90, 20);
            this.gelirkredikarti.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(150, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Toplam Gelir Kredi Kartı :";
            // 
            // gelirdiger
            // 
            this.gelirdiger.Location = new System.Drawing.Point(167, 86);
            this.gelirdiger.Name = "gelirdiger";
            this.gelirdiger.Properties.Caption = "Aktar";
            this.gelirdiger.Size = new System.Drawing.Size(90, 20);
            this.gelirdiger.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(118, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Toplam Gelir Diğer :";
            // 
            // gider
            // 
            this.gider.Location = new System.Drawing.Point(167, 112);
            this.gider.Name = "gider";
            this.gider.Properties.Caption = "Aktar";
            this.gider.Size = new System.Drawing.Size(90, 20);
            this.gider.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(74, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Toplam Gider :";
            // 
            // tamamlanmissiparisler
            // 
            this.tamamlanmissiparisler.Location = new System.Drawing.Point(167, 135);
            this.tamamlanmissiparisler.Name = "tamamlanmissiparisler";
            this.tamamlanmissiparisler.Properties.Caption = "Aktar";
            this.tamamlanmissiparisler.Size = new System.Drawing.Size(90, 20);
            this.tamamlanmissiparisler.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(18, 139);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(143, 14);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Tamamlanan Siparişler :";
            // 
            // alinansiparisler
            // 
            this.alinansiparisler.Location = new System.Drawing.Point(167, 161);
            this.alinansiparisler.Name = "alinansiparisler";
            this.alinansiparisler.Properties.Caption = "Aktar";
            this.alinansiparisler.Size = new System.Drawing.Size(90, 20);
            this.alinansiparisler.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(56, 165);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(105, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Alınan Siparişler :";
            // 
            // GenelRaporDisaAktar
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(293, 238);
            this.Controls.Add(this.alinansiparisler);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tamamlanmissiparisler);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.gider);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.gelirdiger);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.gelirkredikarti);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gelirnakit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gelirtoplam);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.FooterPanel);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("GenelRaporDisaAktar.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenelRaporDisaAktar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dışa Aktar";
            this.Load += new System.EventHandler(this.GenelRaporDisaAktar_Load);
            this.FooterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gelirtoplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirnakit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirkredikarti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gelirdiger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamamlanmissiparisler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alinansiparisler.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FooterPanel;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.CheckEdit gelirtoplam;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit gelirnakit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit gelirkredikarti;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit gelirdiger;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit gider;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit tamamlanmissiparisler;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckEdit alinansiparisler;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}