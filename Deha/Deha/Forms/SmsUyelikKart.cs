using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.DataAccess.Native.Json;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class SmsUyelikKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public sms_users item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public SmsUyelikKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new sms_users()
                    {
                        active = true,
                        ref_date = DateTime.Now
                    };
                    this.Text = "Sms Üyelikleri - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.sms_users.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Sms Üyelikleri - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void SmsUyelikleri_Load(object sender, EventArgs e)
        {

            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtName.Text = item.username;
                txtPassword.Text = item.password;
                txtTitle.Text = item.title;
            }

            // Aktiflik durumu item daki değere göre atanıyor
            AktifMi.Checked = item.active == true ? true : false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckField())
                {
                    item.username = txtName.Text;
                    item.password = txtPassword.Text;
                    item.title = txtTitle.Text;
                    item.active = AktifMi.Checked == true ? true : false;
                    item.ref_user = Program._loginuser.id;
                    if (varmi == false) db.sms_users.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Sms Üyeliği başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Sms Üyeliği başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckField()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Lütfen KULLANICI ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Lütfen ŞİFRE giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtPassword;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                XtraMessageBox.Show("Lütfen BAŞLIK giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtTitle;
                return false;
            }
            return true;
        }
    }
}