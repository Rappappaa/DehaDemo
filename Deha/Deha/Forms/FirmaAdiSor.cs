using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class FirmaAdiSor : DevExpress.XtraEditors.XtraForm
    {
        private haliposmain _haliposmain;
        public FirmaAdiSor()
        {
            InitializeComponent();
            ActiveControl = txtIsletmeAdi;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MainModel db = new MainModel();

            _haliposmain = db.haliposmains.FirstOrDefault(q => q.businesscode == txtIsletmeAdi.Text);

            if (_haliposmain == null)
            {
                XtraMessageBox.Show("Kayıtlı Firma Bulunamadı.");
            }
            else
            {
                string connectionString = string.Format();
                Settings.Default["_connectionstring"] = connectionString;
                try
                {
                    Settings.Default["_businessname"] = txtIsletmeAdi.Text;
                    Settings.Default["_firstlogin"] = "false";
                    Settings.Default.Save();
                    XtraMessageBox.Show("Yapılandırmanın geçerli olması için uygulama yeniden başlatılıyor.");
                    DehaPosModel.Create(connectionString);
                    Application.Exit();
                    Process.Start(Application.ExecutablePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
