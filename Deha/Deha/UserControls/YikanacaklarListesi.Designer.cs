namespace Deha.UserControls
{
    partial class YikanacaklarListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YikanacaklarListesi));
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoruntule = new DevExpress.XtraEditors.SimpleButton();
            this.btnTeslimeGonder = new DevExpress.XtraEditors.SimpleButton();
            this.panelDate = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BolgelerCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.AraclarCombo = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.YikanacaklarGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.müşteriGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BolgelerCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AraclarCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YikanacaklarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "TARİH";
            this.gridColumn9.FieldName = "purchase_date";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "RANK";
            this.gridColumn2.FieldName = "ranking";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "FİRMA";
            this.gridColumn10.FieldName = "company.name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(424, 36);
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
            this.btnYenile.Location = new System.Drawing.Point(288, 36);
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
            // btnTeslimeGonder
            // 
            this.btnTeslimeGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTeslimeGonder.ImageOptions.Image")));
            this.btnTeslimeGonder.Location = new System.Drawing.Point(16, 36);
            this.btnTeslimeGonder.Name = "btnTeslimeGonder";
            this.btnTeslimeGonder.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnTeslimeGonder.Size = new System.Drawing.Size(130, 20);
            this.btnTeslimeGonder.TabIndex = 13;
            this.btnTeslimeGonder.Text = "Teslime Gönder";
            this.btnTeslimeGonder.Click += new System.EventHandler(this.btnTeslimeGonder_Click);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.labelControl4);
            this.panelDate.Controls.Add(this.BolgelerCombo);
            this.panelDate.Controls.Add(this.labelControl3);
            this.panelDate.Controls.Add(this.AraclarCombo);
            this.panelDate.Controls.Add(this.btnExport);
            this.panelDate.Controls.Add(this.btnYenile);
            this.panelDate.Controls.Add(this.btnGoruntule);
            this.panelDate.Controls.Add(this.btnTeslimeGonder);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDate.Location = new System.Drawing.Point(0, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(1278, 60);
            this.panelDate.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(251, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "Bölgeler";
            // 
            // BolgelerCombo
            // 
            this.BolgelerCombo.Location = new System.Drawing.Point(303, 10);
            this.BolgelerCombo.Name = "BolgelerCombo";
            this.BolgelerCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BolgelerCombo.Size = new System.Drawing.Size(150, 20);
            this.BolgelerCombo.TabIndex = 30;
            this.BolgelerCombo.SelectedIndexChanged += new System.EventHandler(this.BolgelerCombo_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(19, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Araçlar";
            // 
            // AraclarCombo
            // 
            this.AraclarCombo.Location = new System.Drawing.Point(66, 10);
            this.AraclarCombo.Name = "AraclarCombo";
            this.AraclarCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AraclarCombo.Size = new System.Drawing.Size(150, 20);
            this.AraclarCombo.TabIndex = 28;
            this.AraclarCombo.SelectedIndexChanged += new System.EventHandler(this.AraclarCombo_SelectedIndexChanged);
            // 
            // YikanacaklarGrid
            // 
            this.YikanacaklarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YikanacaklarGrid.Location = new System.Drawing.Point(0, 60);
            this.YikanacaklarGrid.MainView = this.gridView1;
            this.YikanacaklarGrid.Name = "YikanacaklarGrid";
            this.YikanacaklarGrid.Size = new System.Drawing.Size(1278, 555);
            this.YikanacaklarGrid.TabIndex = 8;
            this.YikanacaklarGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.YikanacaklarGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YikanacaklarGrid_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn21,
            this.gridColumn18,
            this.gridColumn14,
            this.gridColumn19});
            this.gridView1.GridControl = this.YikanacaklarGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "KAYIT NO";
            this.gridColumn20.FieldName = "customer.id";
            this.gridColumn20.MaxWidth = 75;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
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
            // gridColumn12
            // 
            this.gridColumn12.Caption = "SIRA";
            this.gridColumn12.FieldName = "ranking";
            this.gridColumn12.MaxWidth = 75;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 50;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "ADRES";
            this.gridColumn15.FieldName = "customer.adress";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "TELEFON";
            this.gridColumn16.FieldName = "customer.phone";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "GSM";
            this.gridColumn17.FieldName = "customer.gsm";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
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
            this.gridColumn14.Caption = "TESLİM ALAN";
            this.gridColumn14.FieldName = "user.fullname";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "YIKAMA TARİHİ";
            this.gridColumn19.FieldName = "mod_date";
            this.gridColumn19.MaxWidth = 200;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 10;
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
            // YikanacaklarListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YikanacaklarGrid);
            this.Controls.Add(this.panelDate);
            this.Name = "YikanacaklarListesi";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.YikanacaklarListesi_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BolgelerCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AraclarCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YikanacaklarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnGoruntule;
        private DevExpress.XtraEditors.SimpleButton btnTeslimeGonder;
        private System.Windows.Forms.Panel panelDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit BolgelerCombo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit AraclarCombo;
        private DevExpress.XtraGrid.GridControl YikanacaklarGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriGörüntüleToolStripMenuItem;
    }
}
