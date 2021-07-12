using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Forms;
using Deha.Properties;
using System.Diagnostics;

namespace Deha.UserControls
{
    public partial class Ayarlar : DevExpress.XtraEditors.XtraUserControl
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            LoadData();

            if (Settings.Default["_adetlimi"].ToString() == "true")
            {
                chckEvet.Checked = true;
            }
            else
            {
                chckHayir.Checked = true;
            }

            gridView1.BestFitColumns();
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            return val;
        }

        private void LoadData()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            var data = db.settings.ToList();
            AyarlarGrid.DataSource = data;

            }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                AyarlarKart frm = new AyarlarKart(formMode.edit, RowGetir());
                frm.Show();
                LoadData();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chckEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEvet.Checked == true) chckHayir.Checked = false;
            
        }

        private void chckHayir_CheckedChanged(object sender, EventArgs e)
        {
            if (chckHayir.Checked == true) chckEvet.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (chckEvet.Checked == true) Settings.Default["_adetlimi"] = "true";
            if (chckHayir.Checked == true) Settings.Default["_adetlimi"] = "false";
            Settings.Default.Save();

            XtraMessageBox.Show("Ayarlar kayıt edildi. Program yeniden başlatılacak.", "İşlem Tamamlandı", MessageBoxButtons.YesNo);
            Application.Exit();
            Process.Start(Application.ExecutablePath);
        }
    }

}
