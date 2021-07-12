using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.Forms
{
    public partial class FirmaKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public company item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public FirmaKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new company()
                    {
                        active = true,
                        ref_date = DateTime.Now
                    };
                    this.Text = "Firmalar - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.companies.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Firmalar - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void FirmaKart_Load(object sender, EventArgs e)
        {
            // Sms Üyelikleri Combobox Doldur
            SmsUyeligiCombo.DataSource = db.sms_users.Where(q => q.active == true).ToList();
            SmsUyeligiCombo.DisplayMember = "title";
            SmsUyeligiCombo.ValueMember = "id";

            //Teslim Alınca Mesaj Combobox Doldur
            TeslimAlincaSablon.DataSource = db.sms_template.Where(q => q.active == true).Where(q => q.type == 0).ToList();
            TeslimAlincaSablon.DisplayMember = "title";
            TeslimAlincaSablon.ValueMember = "id";

            // Sepete Ekleyince Mesaj Combobox Doldur
            SepeteEkleyinceSablon.DataSource = db.sms_template.Where(q => q.active == true).Where(q => q.type == 1).ToList();
            SepeteEkleyinceSablon.DisplayMember = "title";
            SepeteEkleyinceSablon.ValueMember = "id";

            // Teslim Edince Mesaj Combobox Doldur
            TeslimEdinceSablon.DataSource = db.sms_template.Where(q => q.active == true).Where(q => q.type == 2).ToList();
            TeslimEdinceSablon.DisplayMember = "title";
            TeslimEdinceSablon.ValueMember = "id";


            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtName.Text = item.name;
                txtDescription.Text = item.description;

                SmsUyeligiCombo.SelectedValue = Convert.ToInt32(item.ref_sms_users);

                TeslimAlincaSablon.SelectedValue = Convert.ToInt32(item.ref_upon_receipt);
                SepeteEkleyinceSablon.SelectedValue = Convert.ToInt32(item.ref_new_order_sms);
                TeslimEdinceSablon.SelectedValue = Convert.ToInt32(item.ref_when_delivered);

                int _case1 = Convert.ToInt32(item.send_upon_receipt);
                switch (_case1)
                {
                    case 0:
                        teslimAlincaYok.Checked = true;
                        break;
                    case 1:
                        teslimAlincaOtomatik.Checked = true;
                        break;
                    case 2:
                        teslimAlincaManuel.Checked = true;
                        break;
                }

                int _case2 = Convert.ToInt32(item.send_new_order_sms);
                switch (_case2)
                {
                    case 0:
                        sepetEkleyinceYok.Checked = true;
                        break;
                    case 1:
                        sepetEkleyinceOtomatik.Checked = true;
                        break;
                    case 2:
                        sepetEkleyinceManuel.Checked = true;
                        break;
                }

                int _case3 = Convert.ToInt32(item.send_when_delivered);
                switch (_case3)
                {
                    case 0:
                        teslimEdinceYok.Checked = true;
                        break;
                    case 1:
                        teslimEdinceOtomatik.Checked = true;
                        break;
                    case 2:
                        teslimEdinceManuel.Checked = true;
                        break;
                }
            }
            else
            {
                SmsUyeligiCombo.SelectedValue = 0;

                TeslimAlincaSablon.SelectedValue = 0;
                SepeteEkleyinceSablon.SelectedValue = 0;
                TeslimEdinceSablon.SelectedValue = 0;

                SmsUyeligiCombo.Text = "Seçiniz";

                TeslimAlincaSablon.Text = "Seçiniz";
                SepeteEkleyinceSablon.Text = "Seçiniz";
                TeslimEdinceSablon.Text = "Seçiniz";
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
                    item.name = txtName.Text;
                    item.description = txtDescription.Text;
                    item.ref_sms_users = Convert.ToInt32(SmsUyeligiCombo.SelectedValue);
                    item.ref_user = Program._loginuser.id;
                    item.ref_upon_receipt = Convert.ToInt32(TeslimAlincaSablon.SelectedValue);
                    item.ref_new_order_sms = Convert.ToInt32(SepeteEkleyinceSablon.SelectedValue);
                    item.ref_when_delivered = Convert.ToInt32(TeslimEdinceSablon.SelectedValue);

                    if (teslimAlincaYok.Checked == true) item.send_upon_receipt = 0;
                    if (teslimAlincaOtomatik.Checked == true) item.send_upon_receipt = 1;
                    if (teslimAlincaManuel.Checked == true) item.send_upon_receipt = 2;

                    if (sepetEkleyinceYok.Checked == true) item.send_new_order_sms = 0;
                    if (sepetEkleyinceOtomatik.Checked == true) item.send_new_order_sms = 1;
                    if (sepetEkleyinceManuel.Checked == true) item.send_new_order_sms = 2;

                    if (teslimEdinceYok.Checked == true) item.send_when_delivered = 0;
                    if (teslimEdinceOtomatik.Checked == true) item.send_when_delivered = 1;
                    if (teslimEdinceManuel.Checked == true) item.send_when_delivered = 2;

                    item.active = AktifMi.Checked == true ? true : false;

                    if (varmi == false)
                    {
                        item.color = "#FFB93B";
                        db.companies.Add(item);
                    }
                    
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Firma başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Firma başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

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
                XtraMessageBox.Show("Lütfen FİRMA ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return false;
            } 

            if (Convert.ToInt32(TeslimAlincaSablon.SelectedValue) == 0)
            {
                XtraMessageBox.Show("Lütfen Şablon seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = TeslimAlincaSablon;
                return false;
            }

            if (Convert.ToInt32(SepeteEkleyinceSablon.SelectedValue) == 0)
            {
                XtraMessageBox.Show("Lütfen Şablon seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = SepeteEkleyinceSablon;
                return false;
            }

            if (Convert.ToInt32(TeslimEdinceSablon.SelectedValue) == 0)
            {
                XtraMessageBox.Show("Lütfen Şablon seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = TeslimEdinceSablon;
                return false;
            }

            if (teslimAlincaYok.Checked == false && teslimAlincaOtomatik.Checked == false && teslimAlincaManuel.Checked == false)
            {
                XtraMessageBox.Show("Lütfen TESLİM ALMA işleminden sonraki SMS tercihinizi seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                return false;
            }

            if (sepetEkleyinceYok.Checked == false && sepetEkleyinceOtomatik.Checked == false && sepetEkleyinceManuel.Checked == false)
            {
                XtraMessageBox.Show("Lütfen TESLİM ALMA işleminden sonraki SMS tercihinizi seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                return false;
            }

            if (teslimEdinceYok.Checked == false && teslimEdinceOtomatik.Checked == false && teslimEdinceManuel.Checked == false)
            {
                XtraMessageBox.Show("Lütfen TESLİM ALMA işleminden sonraki SMS tercihinizi seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void teslimAlincaYok_CheckedChanged(object sender, EventArgs e)
        {
            if(teslimAlincaYok.Checked == true)
            {
                teslimAlincaOtomatik.Checked = false;
                teslimAlincaManuel.Checked = false;
            }
        }

        private void teslimAlincaOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            if (teslimAlincaOtomatik.Checked == true)
            {
                teslimAlincaYok.Checked = false;
                teslimAlincaManuel.Checked = false;
            }
        }

        private void teslimAlincaManuel_CheckedChanged(object sender, EventArgs e)
        {
            if (teslimAlincaManuel.Checked == true)
            {
                teslimAlincaOtomatik.Checked = false;
                teslimAlincaYok.Checked = false;
            }
        }

        private void sepetEkleyinceYok_CheckedChanged(object sender, EventArgs e)
        {
            if (sepetEkleyinceYok.Checked == true)
            {
                sepetEkleyinceOtomatik.Checked = false;
                sepetEkleyinceManuel.Checked = false;
            }
        }

        private void sepetEkleyinceOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            if (sepetEkleyinceOtomatik.Checked == true)
            {
                sepetEkleyinceYok.Checked = false;
                sepetEkleyinceManuel.Checked = false;
            }
        }

        private void sepetEkleyinceManuel_CheckedChanged(object sender, EventArgs e)
        {
            if (sepetEkleyinceManuel.Checked == true)
            {
                sepetEkleyinceOtomatik.Checked = false;
                sepetEkleyinceYok.Checked = false;
            }
        }

        private void teslimEdinceYok_CheckedChanged(object sender, EventArgs e)
        {
            if (teslimEdinceYok.Checked == true)
            {
                teslimEdinceOtomatik.Checked = false;
                teslimEdinceManuel.Checked = false;
            }
        }

        private void teslimEdinceOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            if (teslimEdinceOtomatik.Checked == true)
            {
                teslimEdinceYok.Checked = false;
                teslimEdinceManuel.Checked = false;
            }
        }

        private void teslimEdinceManuel_CheckedChanged(object sender, EventArgs e)
        {
            if (teslimEdinceManuel.Checked == true)
            {
                teslimEdinceOtomatik.Checked = false;
                teslimEdinceYok.Checked = false;
            }
        }

    }
}