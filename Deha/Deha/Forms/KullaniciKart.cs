using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.Forms
{
    public partial class KullaniciKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public user item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public KullaniciKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new user()
                    {
                        admin = false,
                        auth_direct_sale = false,
                        auth_order = false,
                        auth_customer_change = false,
                        auth_expense_add = false,
                        auth_report = false,
                        auth_product = false,
                        auth_vehicle = false,
                        auth_area = false,
                        auth_settings = false,
                        auth_company = false,
                        auth_collective_sms = false,
                        auth_sms_user = false,
                        auth_all_vehicle = false,
                        auth_offline_mode = false,
                        active = true,
                        ref_date = DateTime.Now,
                        ref_printnormal = null,
                        ref_printtag = null

                    };
                    this.Text = "Kullanıcılar - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.users.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Kullanıcılar - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void KullaniciKart_Load(object sender, EventArgs e)
        {
            // Araç ComboBox Doldur
            AracCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 0));
            foreach (var i in db.vehicles.Where(q => q.active == true).ToList())
            {
                AracCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }

            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtFullname.Text = item.fullname;
                txtPassword.Text = item.password;
                txtUsername.Text = item.username;

                admin.Checked = item.admin;
                auth_direct_sale.Checked = item.auth_direct_sale;
                auth_order.Checked = item.auth_order;
                auth_customer_change.Checked = item.auth_customer_change;
                auth_expense_add.Checked = item.auth_expense_add;
                auth_report.Checked = item.auth_report;
                auth_product.Checked = item.auth_product;
                auth_vehicle.Checked = item.auth_vehicle;
                auth_area.Checked = item.auth_area;
                auth_settings.Checked = item.auth_settings;
                auth_company.Checked = item.auth_company;
                auth_collective_sms.Checked = item.auth_collective_sms;
                auth_sms_user.Checked = item.auth_sms_user;
                auth_all_vehicle.Checked = item.auth_all_vehicle;
                auth_offline_mode.Checked = item.auth_offline_mode == true ? true : false;
                AktifMi.Checked = item.active;

                AracCombo.SelectedIndex = Convert.ToInt32(item.ref_vehicle);

            }
            else
            {
                AracCombo.SelectedIndex = 0;
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
                    item.fullname = txtFullname.Text;
                    item.password = txtPassword.Text;
                    item.username = txtUsername.Text;

                    item.admin = admin.Checked;
                    item.auth_direct_sale = auth_direct_sale.Checked;
                    item.auth_order = auth_order.Checked;
                    item.auth_customer_change = auth_customer_change.Checked;
                    item.auth_expense_add = auth_expense_add.Checked;
                    item.auth_report = auth_report.Checked;
                    item.auth_product = auth_product.Checked;
                    item.auth_vehicle = auth_vehicle.Checked;
                    item.auth_area = auth_area.Checked;
                    item.auth_settings = auth_settings.Checked;
                    item.auth_company = auth_company.Checked;
                    item.auth_collective_sms = auth_collective_sms.Checked;
                    item.auth_sms_user = auth_sms_user.Checked;
                    item.auth_all_vehicle = auth_all_vehicle.Checked;
                    item.auth_offline_mode = auth_offline_mode.Checked;
                    item.active = AktifMi.Checked;

                    item.ref_vehicle = AracCombo.SelectedIndex;

                    if (varmi == false) db.users.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Kullanıcı başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Kullanıcı başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

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
            if (String.IsNullOrWhiteSpace(txtFullname.Text))
            {
                XtraMessageBox.Show("Lütfen AD SOYAD giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtFullname;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Lütfen ŞİFRE giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtPassword;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                XtraMessageBox.Show("Lütfen KULLANICI ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtUsername;
                return false;
            }
            return true;
        }
    }
}