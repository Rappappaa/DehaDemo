namespace Deha.UserControls
{
    partial class Ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.panelDate = new System.Windows.Forms.Panel();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoruntule = new DevExpress.XtraEditors.SimpleButton();
            this.AyarlarGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chckHayir = new DevExpress.XtraEditors.CheckEdit();
            this.chckEvet = new DevExpress.XtraEditors.CheckEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AyarlarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckHayir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckEvet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.btnKaydet);
            this.panelDate.Controls.Add(this.chckHayir);
            this.panelDate.Controls.Add(this.chckEvet);
            this.panelDate.Controls.Add(this.labelControl1);
            this.panelDate.Controls.Add(this.btnYenile);
            this.panelDate.Controls.Add(this.btnGoruntule);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDate.Location = new System.Drawing.Point(0, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(1278, 36);
            this.panelDate.TabIndex = 8;
            // 
            // btnYenile
            // 
            this.btnYenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYenile.ImageOptions.Image")));
            this.btnYenile.Location = new System.Drawing.Point(147, 9);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnYenile.Size = new System.Drawing.Size(130, 20);
            this.btnYenile.TabIndex = 19;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnGoruntule
            // 
            this.btnGoruntule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGoruntule.ImageOptions.Image")));
            this.btnGoruntule.Location = new System.Drawing.Point(11, 9);
            this.btnGoruntule.Name = "btnGoruntule";
            this.btnGoruntule.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGoruntule.Size = new System.Drawing.Size(130, 20);
            this.btnGoruntule.TabIndex = 16;
            this.btnGoruntule.Text = "Düzenle";
            this.btnGoruntule.Click += new System.EventHandler(this.btnGoruntule_Click);
            // 
            // AyarlarGrid
            // 
            this.AyarlarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AyarlarGrid.Location = new System.Drawing.Point(0, 36);
            this.AyarlarGrid.MainView = this.gridView1;
            this.AyarlarGrid.Name = "AyarlarGrid";
            this.AyarlarGrid.Size = new System.Drawing.Size(1278, 579);
            this.AyarlarGrid.TabIndex = 9;
            this.AyarlarGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn15,
            this.gridColumn18,
            this.gridColumn16});
            this.gridView1.GridControl = this.AyarlarGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "ID";
            this.gridColumn11.FieldName = "id";
            this.gridColumn11.MaxWidth = 50;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 50;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "FİRMA ADI";
            this.gridColumn12.FieldName = "business_name";
            this.gridColumn12.MinWidth = 450;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 450;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PARA BİRİMİ";
            this.gridColumn13.FieldName = "money_unit";
            this.gridColumn13.MinWidth = 125;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 125;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "İŞLEM SÜRESİ";
            this.gridColumn15.FieldName = "howmanyday_process";
            this.gridColumn15.MinWidth = 125;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 125;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "VERSİYON";
            this.gridColumn18.FieldName = "app_version";
            this.gridColumn18.MinWidth = 125;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            this.gridColumn18.Width = 125;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "MAX FİRMA SAYISI";
            this.gridColumn16.FieldName = "max_firm";
            this.gridColumn16.MinWidth = 125;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            this.gridColumn16.Width = 150;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(283, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(325, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Sistem de adet x M2 x fiyat hesaplama kullanılsın mı?";
            // 
            // chckHayir
            // 
            this.chckHayir.Location = new System.Drawing.Point(673, 9);
            this.chckHayir.Name = "chckHayir";
            this.chckHayir.Properties.Caption = "Hayır";
            this.chckHayir.Size = new System.Drawing.Size(90, 20);
            this.chckHayir.TabIndex = 21;
            this.chckHayir.CheckedChanged += new System.EventHandler(this.chckHayir_CheckedChanged);
            // 
            // chckEvet
            // 
            this.chckEvet.Location = new System.Drawing.Point(614, 9);
            this.chckEvet.Name = "chckEvet";
            this.chckEvet.Properties.Caption = "Evet";
            this.chckEvet.Size = new System.Drawing.Size(90, 20);
            this.chckEvet.TabIndex = 20;
            this.chckEvet.CheckedChanged += new System.EventHandler(this.chckEvet_CheckedChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(769, 9);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(130, 20);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AyarlarGrid);
            this.Controls.Add(this.panelDate);
            this.Name = "Ayarlar";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AyarlarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckHayir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckEvet.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDate;
        private DevExpress.XtraEditors.SimpleButton btnGoruntule;
        private DevExpress.XtraGrid.GridControl AyarlarGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chckHayir;
        private DevExpress.XtraEditors.CheckEdit chckEvet;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
