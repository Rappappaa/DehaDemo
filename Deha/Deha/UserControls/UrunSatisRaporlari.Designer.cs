namespace Deha.UserControls
{
    partial class UrunSatisRaporlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunSatisRaporlari));
            this.panel2 = new System.Windows.Forms.Panel();
            this.UrunSatisRaporlariGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbltoplam = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblkredikarti = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblnakit = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbldiger = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnTarihFiltre = new DevExpress.XtraEditors.SimpleButton();
            this.LastDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.FirstDate = new DevExpress.XtraEditors.DateEdit();
            this.panelDate = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunSatisRaporlariGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties)).BeginInit();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UrunSatisRaporlariGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 542);
            this.panel2.TabIndex = 19;
            // 
            // UrunSatisRaporlariGrid
            // 
            this.UrunSatisRaporlariGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrunSatisRaporlariGrid.Location = new System.Drawing.Point(0, 0);
            this.UrunSatisRaporlariGrid.MainView = this.gridView1;
            this.UrunSatisRaporlariGrid.Name = "UrunSatisRaporlariGrid";
            this.UrunSatisRaporlariGrid.Size = new System.Drawing.Size(1278, 542);
            this.UrunSatisRaporlariGrid.TabIndex = 14;
            this.UrunSatisRaporlariGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView1.GridControl = this.UrunSatisRaporlariGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ÜRÜN";
            this.gridColumn1.FieldName = "urunadi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ADET";
            this.gridColumn2.FieldName = "adet";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "adet", "TOPLAM {0:0.##} Adet")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TUTAR";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "toplam";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "toplam", "TOPLAM {0:c2}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // lbltoplam
            // 
            this.lbltoplam.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbltoplam.Appearance.Options.UseFont = true;
            this.lbltoplam.Location = new System.Drawing.Point(839, 8);
            this.lbltoplam.Name = "lbltoplam";
            this.lbltoplam.Size = new System.Drawing.Size(54, 16);
            this.lbltoplam.TabIndex = 8;
            this.lbltoplam.Text = "Toplam :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(517, 8);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(43, 16);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Diğer :";
            // 
            // lblkredikarti
            // 
            this.lblkredikarti.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblkredikarti.Appearance.Options.UseFont = true;
            this.lblkredikarti.Location = new System.Drawing.Point(313, 8);
            this.lblkredikarti.Name = "lblkredikarti";
            this.lblkredikarti.Size = new System.Drawing.Size(41, 16);
            this.lblkredikarti.TabIndex = 6;
            this.lblkredikarti.Text = "Nakit :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(230, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Kredi Kartı :";
            // 
            // lblnakit
            // 
            this.lblnakit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblnakit.Appearance.Options.UseFont = true;
            this.lblnakit.Location = new System.Drawing.Point(74, 8);
            this.lblnakit.Name = "lblnakit";
            this.lblnakit.Size = new System.Drawing.Size(41, 16);
            this.lblnakit.TabIndex = 4;
            this.lblnakit.Text = "Nakit :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbldiger);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.lbltoplam);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.lblkredikarti);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.lblnakit);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 33);
            this.panel1.TabIndex = 18;
            // 
            // lbldiger
            // 
            this.lbldiger.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbldiger.Appearance.Options.UseFont = true;
            this.lbldiger.Location = new System.Drawing.Point(566, 8);
            this.lbldiger.Name = "lbldiger";
            this.lbldiger.Size = new System.Drawing.Size(54, 16);
            this.lbldiger.TabIndex = 10;
            this.lbldiger.Text = "Toplam :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(779, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 16);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Toplam :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(27, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Nakit :";
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(587, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExport.Size = new System.Drawing.Size(130, 20);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // panelDate
            // 
            this.panelDate.Controls.Add(this.btnExport);
            this.panelDate.Controls.Add(this.btnTarihFiltre);
            this.panelDate.Controls.Add(this.LastDate);
            this.panelDate.Controls.Add(this.labelControl1);
            this.panelDate.Controls.Add(this.FirstDate);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDate.Location = new System.Drawing.Point(0, 0);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(1278, 40);
            this.panelDate.TabIndex = 17;
            // 
            // UrunSatisRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDate);
            this.Name = "UrunSatisRaporlari";
            this.Size = new System.Drawing.Size(1278, 615);
            this.Load += new System.EventHandler(this.UrunSatisRaporlari_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UrunSatisRaporlariGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDate.Properties)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl UrunSatisRaporlariGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl lbltoplam;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblkredikarti;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblnakit;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnTarihFiltre;
        private DevExpress.XtraEditors.DateEdit LastDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit FirstDate;
        private System.Windows.Forms.Panel panelDate;
        private DevExpress.XtraEditors.LabelControl lbldiger;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
