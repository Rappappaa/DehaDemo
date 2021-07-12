namespace Deha.UserControls
{
    partial class SmsSablonlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsSablonlari));
            this.panelDate = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.StatuCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoruntule = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.SmsSablonlariGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatuCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsSablonlariGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDate
            // 
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
            this.panelDate.TabIndex = 4;
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
            this.StatuCombo.SelectedIndexChanged += new System.EventHandler(this.StatuCombo_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(560, 34);
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
            this.btnYenile.Location = new System.Drawing.Point(424, 34);
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
            // SmsSablonlariGrid
            // 
            this.SmsSablonlariGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmsSablonlariGrid.Location = new System.Drawing.Point(0, 60);
            this.SmsSablonlariGrid.MainView = this.gridView1;
            this.SmsSablonlariGrid.Name = "SmsSablonlariGrid";
            this.SmsSablonlariGrid.Size = new System.Drawing.Size(1278, 555);
            this.SmsSablonlariGrid.TabIndex = 9;
            this.SmsSablonlariGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn8});
            this.gridView1.GridControl = this.SmsSablonlariGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
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
            this.gridColumn1.Caption = "BAŞLIK";
            this.gridColumn1.FieldName = "title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MESAJ";
            this.gridColumn2.FieldName = "message";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TÜR";
            this.gridColumn4.FieldName = "type";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DURUM";
            this.gridColumn3.FieldName = "active";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "TARİH";
            this.gridColumn8.FieldName = "ref_date";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // SmsSablonlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SmsSablonlariGrid);
            this.Controls.Add(this.panelDate);
            this.Name = "SmsSablonlari";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.SmsSablonlari_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatuCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsSablonlariGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl SmsSablonlariGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
