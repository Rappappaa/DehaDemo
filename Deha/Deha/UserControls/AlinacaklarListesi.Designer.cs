namespace Deha
{
    partial class AlinacaklarListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlinacaklarListesi));
            this.FirstDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.LastDate = new DevExpress.XtraEditors.DateEdit();
            this.btnTarihFiltre = new DevExpress.XtraEditors.SimpleButton();
            this.panelDate = new System.Windows.Forms.Panel();
            this.btnTumunuGoster = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BolgelerCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoruntule = new DevExpress.XtraEditors.SimpleButton();
            this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.AlinacaklarGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AraclarCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.müşteriGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties)).BeginInit();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BolgelerCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlinacaklarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AraclarCombo.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstDate
            // 
            this.FirstDate.EditValue = null;
            this.FirstDate.Location = new System.Drawing.Point(90, 10);
            this.FirstDate.Name = "FirstDate";
            this.FirstDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirstDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirstDate.Size = new System.Drawing.Size(150, 20);
            this.FirstDate.TabIndex = 0;
            this.FirstDate.EditValueChanged += new System.EventHandler(this.FirstDate_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tarih Aralığı";
            // 
            // LastDate
            // 
            this.LastDate.EditValue = null;
            this.LastDate.Location = new System.Drawing.Point(246, 10);
            this.LastDate.Name = "LastDate";
            this.LastDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LastDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LastDate.Size = new System.Drawing.Size(150, 20);
            this.LastDate.TabIndex = 3;
            this.LastDate.EditValueChanged += new System.EventHandler(this.LastDate_EditValueChanged);
            // 
            // btnTarihFiltre
            // 
            this.btnTarihFiltre.Location = new System.Drawing.Point(402, 10);
            this.btnTarihFiltre.Name = "btnTarihFiltre";
            this.btnTarihFiltre.Size = new System.Drawing.Size(130, 20);
            this.btnTarihFiltre.TabIndex = 4;
            this.btnTarihFiltre.Text = "Filtrele";
            this.btnTarihFiltre.Click += new System.EventHandler(this.btnTarihFiltre_Click);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.btnTumunuGoster);
            this.panelDate.Controls.Add(this.labelControl4);
            this.panelDate.Controls.Add(this.BolgelerCombo);
            this.panelDate.Controls.Add(this.btnExport);
            this.panelDate.Controls.Add(this.btnYenile);
            this.panelDate.Controls.Add(this.btnGoruntule);
            this.panelDate.Controls.Add(this.btnGonder);
            this.panelDate.Controls.Add(this.btnIptal);
            this.panelDate.Controls.Add(this.btnEkle);
            this.panelDate.Controls.Add(this.btnTarihFiltre);
            this.panelDate.Controls.Add(this.LastDate);
            this.panelDate.Controls.Add(this.labelControl1);
            this.panelDate.Controls.Add(this.FirstDate);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDate.Location = new System.Drawing.Point(0, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(1278, 60);
            this.panelDate.TabIndex = 1;
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Location = new System.Drawing.Point(747, 10);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.Size = new System.Drawing.Size(188, 20);
            this.btnTumunuGoster.TabIndex = 27;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.Click += new System.EventHandler(this.btnTumunuGoster_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(539, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Bölgeler";
            // 
            // BolgelerCombo
            // 
            this.BolgelerCombo.Location = new System.Drawing.Point(591, 10);
            this.BolgelerCombo.Name = "BolgelerCombo";
            this.BolgelerCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BolgelerCombo.Size = new System.Drawing.Size(150, 20);
            this.BolgelerCombo.TabIndex = 25;
            this.BolgelerCombo.SelectedIndexChanged += new System.EventHandler(this.BolgelerCombo_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(696, 36);
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExport.Size = new System.Drawing.Size(130, 20);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Yazdır";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYenile.ImageOptions.Image")));
            this.btnYenile.Location = new System.Drawing.Point(560, 36);
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
            this.btnGoruntule.Location = new System.Drawing.Point(424, 36);
            this.btnGoruntule.Name = "btnGoruntule";
            this.btnGoruntule.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGoruntule.Size = new System.Drawing.Size(130, 20);
            this.btnGoruntule.TabIndex = 16;
            this.btnGoruntule.Text = "Düzenle";
            this.btnGoruntule.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.Image")));
            this.btnGonder.Location = new System.Drawing.Point(152, 36);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGonder.Size = new System.Drawing.Size(130, 20);
            this.btnGonder.TabIndex = 15;
            this.btnGonder.Text = "Yıkamaya Gönder";
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.ImageOptions.Image")));
            this.btnIptal.Location = new System.Drawing.Point(288, 36);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnIptal.Size = new System.Drawing.Size(130, 20);
            this.btnIptal.TabIndex = 14;
            this.btnIptal.Text = "İptal Et";
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
            this.btnEkle.Text = "Alınacak  Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // AlinacaklarGrid
            // 
            this.AlinacaklarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlinacaklarGrid.Location = new System.Drawing.Point(0, 60);
            this.AlinacaklarGrid.MainView = this.gridView1;
            this.AlinacaklarGrid.Name = "AlinacaklarGrid";
            this.AlinacaklarGrid.Size = new System.Drawing.Size(1278, 555);
            this.AlinacaklarGrid.TabIndex = 6;
            this.AlinacaklarGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.AlinacaklarGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlinacaklarGrid_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn20,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn15,
            this.gridColumn22,
            this.gridColumn21,
            this.gridColumn18,
            this.gridColumn14,
            this.gridColumn19});
            this.gridView1.GridControl = this.AlinacaklarGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "SIRA";
            this.gridColumn12.FieldName = "ranking";
            this.gridColumn12.MaxWidth = 75;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 50;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "KAYIT NO";
            this.gridColumn20.FieldName = "customer.id";
            this.gridColumn20.MaxWidth = 75;
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "FİŞ NO";
            this.gridColumn11.FieldName = "id";
            this.gridColumn11.MaxWidth = 75;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 50;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "MÜŞTERİ";
            this.gridColumn13.FieldName = "customer.name";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "TELEFON";
            this.gridColumn16.FieldName = "customer.phone";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 3;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "GSM";
            this.gridColumn17.FieldName = "customer.gsm";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "ADRES";
            this.gridColumn15.FieldName = "customer.adress";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "BAKİYE";
            this.gridColumn22.DisplayFormat.FormatString = "c2";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "customer.balance";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 6;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "FİRMA";
            this.gridColumn21.FieldName = "company.name";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 7;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "SERVİS";
            this.gridColumn18.FieldName = "vehicle.name";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 8;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "TESLİM ALACAK";
            this.gridColumn14.FieldName = "user.fullname";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "SİPARİŞ TARİHİ";
            this.gridColumn19.FieldName = "ref_date";
            this.gridColumn19.MaxWidth = 200;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 10;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "RANK";
            this.gridColumn2.FieldName = "ranking";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "MÜŞTERİ";
            this.gridColumn3.FieldName = "customer.name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TESLİM ALAN";
            this.gridColumn4.FieldName = "user.fullname";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ADRES";
            this.gridColumn5.FieldName = "customer.adress";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TELEFON";
            this.gridColumn6.FieldName = "customer.gsm";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "BÖLGE";
            this.gridColumn7.FieldName = "area.name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SERVİS";
            this.gridColumn8.FieldName = "vehicle.name";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "TARİH";
            this.gridColumn9.FieldName = "purchase_date";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "FİRMA";
            this.gridColumn10.FieldName = "company.name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // AraclarCombo
            // 
            this.AraclarCombo.Location = new System.Drawing.Point(540, 501);
            this.AraclarCombo.Name = "AraclarCombo";
            this.AraclarCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AraclarCombo.Size = new System.Drawing.Size(150, 20);
            this.AraclarCombo.TabIndex = 23;
            this.AraclarCombo.SelectedIndexChanged += new System.EventHandler(this.AraclarCombo_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(493, 504);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Araçlar";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriGörüntüleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 26);
            // 
            // müşteriGörüntüleToolStripMenuItem
            // 
            this.müşteriGörüntüleToolStripMenuItem.Name = "müşteriGörüntüleToolStripMenuItem";
            this.müşteriGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.müşteriGörüntüleToolStripMenuItem.Text = "Müşteri Görüntüle";
            this.müşteriGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.müşteriGörüntüleToolStripMenuItem_Click);
            // 
            // AlinacaklarListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AlinacaklarGrid);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.AraclarCombo);
            this.Controls.Add(this.labelControl3);
            this.Name = "AlinacaklarListesi";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.AlinacaklarListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BolgelerCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlinacaklarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AraclarCombo.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit FirstDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit LastDate;
        private DevExpress.XtraEditors.SimpleButton btnTarihFiltre;
        private System.Windows.Forms.Panel panelDate;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnGoruntule;
        private DevExpress.XtraEditors.SimpleButton btnGonder;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraGrid.GridControl AlinacaklarGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit BolgelerCombo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.SimpleButton btnTumunuGoster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit AraclarCombo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriGörüntüleToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
    }
}
