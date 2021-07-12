using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;
using System.Diagnostics;

namespace Deha.Forms
{
    public partial class SistemAyarlari : DevExpress.XtraEditors.XtraForm
    {
        public SistemAyarlari()
        {
            InitializeComponent();
            txtFirmaAdi.Text = Settings.Default["_businessname"].ToString();
            if (Settings.Default["_adetlimi"].ToString() == "true") chckEvet.Checked = true;
            if (Settings.Default["_adetlimi"].ToString() == "false") chckHayir.Checked = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Program ayarlarını sıfırlamak istediğinize emin misiniz?", "Programı Sıfırla", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default["_adetlimi"] = "false";
                Settings.Default["_asked"] = "false";
                Settings.Default["_businessname"] = "bos";
                Settings.Default["_firstlogin"] = "true";
                Settings.Default.Save();

                Application.Exit();
                Process.Start(Application.ExecutablePath);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (chckEvet.Checked == true) Settings.Default["_adetlimi"] = "true";
                if (chckHayir.Checked == true) Settings.Default["_adetlimi"] = "false";
                if (!string.IsNullOrWhiteSpace(txtFirmaAdi.Text)) Settings.Default["_businessname"] = txtFirmaAdi.Text;
                Settings.Default.Save();

                XtraMessageBox.Show("Ayarlar kayıt edildi. Program yeniden başlatılacak.", "İşlem Tamamlandı", MessageBoxButtons.YesNo);
                Application.Exit();
                Process.Start(Application.ExecutablePath);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Hatalı İşlem", MessageBoxButtons.YesNo);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chckEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEvet.Checked == true) chckHayir.Checked = false;
        }

        private void chckHayir_CheckedChanged(object sender, EventArgs e)
        {
            if (chckHayir.Checked == true) chckEvet.Checked = false;
        }
    }
}