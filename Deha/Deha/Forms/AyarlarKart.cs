using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    
    public partial class AyarlarKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id

        public setting _setting;

        public AyarlarKart(formMode mode, int? id)
        {
            InitializeComponent();
            
            _id = id;
            _mode = mode;
            switch (_mode)
            {
                case formMode.edit:

                    _setting = db.settings.FirstOrDefault(q => q.id == _id);

                    if (_setting == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        txtName.Text = _setting.business_name;
                        txtUnit.Text = _setting.money_unit;
                        txtProcess.Text = Convert.ToString(_setting.howmanyday_process);
                        // eski faturadetay kayıtlarını çek
                        this.Text = "Yıkamaya Gönder - Kayıt Düzenleme";
                    }
                    break;
            }
            
        }

        private void AyarlarKart_Load(object sender, EventArgs e)
        {
            ActiveControl = txtName;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Lütfen FİRMA ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return;
            }

            if (String.IsNullOrWhiteSpace(txtUnit.Text))
            {
                XtraMessageBox.Show("Lütfen PARA BİRİMİ giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtUnit;
                return;
            }

            if (String.IsNullOrWhiteSpace(txtProcess.Text))
            {
                XtraMessageBox.Show("Lütfen İŞLEM GÜNÜ giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtProcess;
                return;
            }

            try
            {
                _setting.business_name = txtName.Text;
                _setting.money_unit = txtUnit.Text;
                _setting.howmanyday_process = Convert.ToInt32(txtProcess.Text);
                db.SaveChanges();
                XtraMessageBox.Show("Firma bilgileri başarıyla güncellendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Başarısız", MessageBoxButtons.OK);
            }
        
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
    
}