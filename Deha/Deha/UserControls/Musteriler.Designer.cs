namespace Deha.UserControls
{
    partial class Musteriler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Musteriler));
            this.panelDate = new System.Windows.Forms.Panel();
            this.btnTahsilatYap = new DevExpress.XtraEditors.SimpleButton();
            this.btnBorcEkle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BorcCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.StatuCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoruntule = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.MusterilerGrid = new DevExpress.XtraGrid.GridControl();
            this.MusterilerView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MusteriRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alınacakEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriyiGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geçmişSiparişlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorcCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatuCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusterilerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusterilerView)).BeginInit();
            this.MusteriRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.btnTahsilatYap);
            this.panelDate.Controls.Add(this.btnBorcEkle);
            this.panelDate.Controls.Add(this.labelControl1);
            this.panelDate.Controls.Add(this.BorcCombo);
            this.panelDate.Controls.Add(this.labelControl2);
            this.panelDate.Controls.Add(this.StatuCombo);
            this.panelDate.Controls.Add(this.btnExport);
            this.panelDate.Controls.Add(this.btnYenile);
            this.panelDate.Controls.Add(this.btnGoruntule);
            this.panelDate.Controls.Add(this.btnIptal);
            this.panelDate.Controls.Add(this.btnEkle);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDate.Location = new System.Drawing.Point(0, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(1278, 60);
            this.panelDate.TabIndex = 2;
            // 
            // btnTahsilatYap
            // 
            this.btnTahsilatYap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTahsilatYap.ImageOptions.Image")));
            this.btnTahsilatYap.Location = new System.Drawing.Point(560, 36);
            this.btnTahsilatYap.Name = "btnTahsilatYap";
            this.btnTahsilatYap.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnTahsilatYap.Size = new System.Drawing.Size(130, 20);
            this.btnTahsilatYap.TabIndex = 26;
            this.btnTahsilatYap.Text = "Tahsilat Yap";
            this.btnTahsilatYap.Click += new System.EventHandler(this.btnTahsilatYap_Click);
            // 
            // btnBorcEkle
            // 
            this.btnBorcEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBorcEkle.ImageOptions.Image")));
            this.btnBorcEkle.Location = new System.Drawing.Point(424, 36);
            this.btnBorcEkle.Name = "btnBorcEkle";
            this.btnBorcEkle.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBorcEkle.Size = new System.Drawing.Size(130, 20);
            this.btnBorcEkle.TabIndex = 25;
            this.btnBorcEkle.Text = "Borç Ekle";
            this.btnBorcEkle.Click += new System.EventHandler(this.btnBorcEkle_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(272, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Borç Durumu";
            // 
            // BorcCombo
            // 
            this.BorcCombo.Location = new System.Drawing.Point(351, 10);
            this.BorcCombo.Name = "BorcCombo";
            this.BorcCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BorcCombo.Size = new System.Drawing.Size(150, 20);
            this.BorcCombo.TabIndex = 23;
            this.BorcCombo.SelectedValueChanged += new System.EventHandler(this.BorcCombo_SelectedValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(20, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Kayıt Türü";
            // 
            // StatuCombo
            // 
            this.StatuCombo.Location = new System.Drawing.Point(84, 10);
            this.StatuCombo.Name = "StatuCombo";
            this.StatuCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatuCombo.Size = new System.Drawing.Size(150, 20);
            this.StatuCombo.TabIndex = 21;
            this.StatuCombo.SelectedValueChanged += new System.EventHandler(this.StatuCombo_SelectedValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(832, 36);
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExport.Size = new System.Drawing.Size(130, 20);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYenile.ImageOptions.Image")));
            this.btnYenile.Location = new System.Drawing.Point(696, 36);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnYenile.Size = new System.Drawing.Size(130, 20);
            this.btnYenile.TabIndex = 18;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnGoruntule
            // 
            this.btnGoruntule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGoruntule.ImageOptions.Image")));
            this.btnGoruntule.Location = new System.Drawing.Point(152, 36);
            this.btnGoruntule.Name = "btnGoruntule";
            this.btnGoruntule.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGoruntule.Size = new System.Drawing.Size(130, 20);
            this.btnGoruntule.TabIndex = 16;
            this.btnGoruntule.Text = "Düzenle";
            this.btnGoruntule.Click += new System.EventHandler(this.btnGoruntule_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.ImageOptions.Image")));
            this.btnIptal.Location = new System.Drawing.Point(288, 36);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 14;
            this.btnIptal.Text = "Sil";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
            this.btnEkle.Location = new System.Drawing.Point(16, 36);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEkle.Size = new System.Drawing.Size(130, 20);
            this.btnEkle.TabIndex = 13;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // MusterilerGrid
            // 
            this.MusterilerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusterilerGrid.Location = new System.Drawing.Point(0, 60);
            this.MusterilerGrid.MainView = this.MusterilerView;
            this.MusterilerGrid.Name = "MusterilerGrid";
            this.MusterilerGrid.Size = new System.Drawing.Size(1278, 555);
            this.MusterilerGrid.TabIndex = 7;
            this.MusterilerGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MusterilerView});
            this.MusterilerGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MusterilerGrid_MouseDown);
            // 
            // MusterilerView
            // 
            this.MusterilerView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.MusterilerView.GridControl = this.MusterilerGrid;
            this.MusterilerView.Name = "MusterilerView";
            this.MusterilerView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.MusterilerView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.MusterilerView.OptionsBehavior.Editable = false;
            this.MusterilerView.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "KAYIT NO";
            this.gridColumn11.FieldName = "id";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AD";
            this.gridColumn1.FieldName = "name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ÜLKE KODU";
            this.gridColumn2.FieldName = "countryCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "TELEFON";
            this.gridColumn3.FieldName = "phone";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "GSM";
            this.gridColumn4.FieldName = "gsm";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ADRES";
            this.gridColumn5.FieldName = "adress";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "BAKİYE";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "balance";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "DURUM";
            this.gridColumn7.FieldName = "active";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "TARİH";
            this.gridColumn8.FieldName = "ref_date";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // MusteriRightClick
            // 
            this.MusteriRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alınacakEkleToolStripMenuItem,
            this.müşteriyiGörüntüleToolStripMenuItem,
            this.geçmişSiparişlerToolStripMenuItem});
            this.MusteriRightClick.Name = "MusteriRightClick";
            this.MusteriRightClick.Size = new System.Drawing.Size(180, 70);
            // 
            // alınacakEkleToolStripMenuItem
            // 
            this.alınacakEkleToolStripMenuItem.Name = "alınacakEkleToolStripMenuItem";
            this.alınacakEkleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.alınacakEkleToolStripMenuItem.Text = "Alınacak Ekle";
            this.alınacakEkleToolStripMenuItem.Click += new System.EventHandler(this.alınacakEkleToolStripMenuItem_Click);
            // 
            // müşteriyiGörüntüleToolStripMenuItem
            // 
            this.müşteriyiGörüntüleToolStripMenuItem.Name = "müşteriyiGörüntüleToolStripMenuItem";
            this.müşteriyiGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.müşteriyiGörüntüleToolStripMenuItem.Text = "Müşteriyi Görüntüle";
            this.müşteriyiGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.müşteriyiGörüntüleToolStripMenuItem_Click);
            // 
            // geçmişSiparişlerToolStripMenuItem
            // 
            this.geçmişSiparişlerToolStripMenuItem.Name = "geçmişSiparişlerToolStripMenuItem";
            this.geçmişSiparişlerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.geçmişSiparişlerToolStripMenuItem.Text = "Geçmiş Siparişler";
            this.geçmişSiparişlerToolStripMenuItem.Click += new System.EventHandler(this.geçmişSiparişlerToolStripMenuItem_Click);
            // 
            // Musteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MusterilerGrid);
            this.Controls.Add(this.panelDate);
            this.Name = "Musteriler";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.Musteriler_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorcCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatuCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusterilerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusterilerView)).EndInit();
            this.MusteriRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ImageComboBoxEdit StatuCombo;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnGoruntule;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraGrid.GridControl MusterilerGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView MusterilerView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ContextMenuStrip MusteriRightClick;
        private System.Windows.Forms.ToolStripMenuItem alınacakEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşteriyiGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçmişSiparişlerToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit BorcCombo;
        private DevExpress.XtraEditors.SimpleButton btnTahsilatYap;
        private DevExpress.XtraEditors.SimpleButton btnBorcEkle;
    }
}
