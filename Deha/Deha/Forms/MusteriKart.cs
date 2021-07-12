using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.Forms
{
    public partial class MusteriKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public customer item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false; // gelen id li kayıt varmı bakıcaz

        public MusteriKart(formMode mode, int? id)
        {
            InitializeComponent();

            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new customer()
                    {
                        active = true,
                        countryCode = "+90",
                        balance = 0,
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now
                    };
                    this.Text = "Müşteriler - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.customers.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        this.Text = "Müşteriler - Kayıt Düzenleme";
                        varmi = true;
                    }
                    break;
            }

        }

        private void MusteriKart_Load(object sender, EventArgs e)
        {
            txtBalance.Enabled = false;

            // Bölge Combobox Doldur
            AreaCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 0));
            foreach (var i in db.areas.Where(q => q.active == true).ToList())
            {
                AreaCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }
            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtName.Text = item.name;
                txtPhone.Text = item.phone;
                txtGsm.Text = item.gsm;
                AreaCombo.SelectedIndex = item.ref_areas;
                txtAdress.Text = item.adress;
                txtCoordinat.Text = item.coordinat;
                txtBalance.Text = String.Format("{0:C}", item.balance);
            }
            // Kayıt Yoksa Default Getir
            else
            {
                AreaCombo.SelectedIndex = 0;
                txtBalance.Text = String.Format("{0:C}",0);
            }

            // Aktiflik durumu item daki değere göre atanıyor
            AktifMi.Checked = item.active == true ? true : false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                try
                {
                    item.name = txtName.Text;
                    item.phone = txtPhone.Text;
                    item.gsm = txtGsm.Text;
                    item.ref_areas = AreaCombo.SelectedIndex;
                    item.adress = txtAdress.Text;
                    item.coordinat = txtCoordinat.Text;

                    item.active = AktifMi.Checked == true ? true : false;
                    if (varmi == false) db.customers.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode)
                    {
                        XtraMessageBox.Show("Kayıt Başarıyla Eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

                        if (XtraMessageBox.Show("Müşteriye ait sipariş oluşturmak ister misiniz?", "Sipariş Oluşturma", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            AlinacakKart frm = new AlinacakKart(formMode.insert,null,null);
                            frm.ShowDialog();
                        }
                        
                    }

                    if (formMode.edit == _mode) XtraMessageBox.Show("Kayıt Başarıyla Düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "Başarısız", MessageBoxButtons.OK);
                }
            }

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckField()
        {
            // MüşteriComboBox kontrolü
            if (String.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("Lütfen Ad Soyad giriniz.", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return false;
            }

            // AraçComboBox kontrolü
            if (AreaCombo.SelectedIndex == 0)
            {
                XtraMessageBox.Show("Lütfen Bölge Seçiniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = AreaCombo;
                return false;
            }

            // FirmaComboBox kontrolü
            if (String.IsNullOrEmpty(txtAdress.Text))
            {
                XtraMessageBox.Show("Lütfen Adres giriniz.", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = txtAdress;
                return false;
            }

            // Herşey tamamsa return true
            return true;
        }
    }
}