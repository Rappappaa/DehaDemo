using Deha.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Deha
{
    public partial class AlinacakKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public received item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false; // gelen id li kayıt varmı bakıcaz
        private setting _setting; // teslimata kaç gün ekleyeceğimiz db den geliyor
        private int? _customerid;

        public AlinacakKart(formMode mode, int? id, int? customerid)
        {
            InitializeComponent();

            _id = id;
            _mode = mode;
            _customerid = customerid;
            _setting = db.settings.FirstOrDefault();

            switch (_mode)
            {
                case formMode.insert:
                    item = new received()
                    {
                        status = false,
                        active = true,
                        ranking = RankGetir(),
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now,
                        mod_date = null
                    };
                    var _c = db.customers.FirstOrDefault(q => q.id == _customerid);

                    if (_c != null)
                    {
                        txtMusteriAdi.Text = _c.name;
                    }
                    this.Text = "Alınacaklar Listesi - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.receiveds.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        this.Text = "Alınacaklar Listesi - Kayıt Düzenleme";
                        txtNot.Text = item.note;
                        txtRank.Text = item.ranking;
                        _customerid = item.ref_customer;
                        varmi = true;
                    }
                    break;
            }

        }

        private void AlinacakKart_Load(object sender, EventArgs e)
        {
            ActiveControl = txtRank;

            // Firma ComboBox Doldur
            FirmaCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 0));
            foreach (var i in db.companies.Where(q => q.active == true).ToList())
            {
                FirmaCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }

            // Araç ComboBox Doldur
            AracCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 0));
            foreach (var i in db.vehicles.Where(q => q.active == true).ToList())
            {
                AracCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }

            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                AlisTarihi.DateTime = item.received_date;
                TeslimTarihi.DateTime = item.purchase_date;

                var _c = db.customers.FirstOrDefault(q => q.id == _customerid);

                if (_c != null)
                {
                    txtMusteriAdi.Text = _c.name;
                }

                FirmaCombo.SelectedIndex = (int)item.ref_company;
                AracCombo.SelectedIndex = (int)item.ref_vehicle;
            }
            // Kayıt Yoksa Default Getir
            else
            {
                txtRank.Text = item.ranking;
                AlisTarihi.DateTime = DateTime.Now;
                TeslimTarihi.DateTime = DateTime.Now.AddDays(Convert.ToDouble(_setting.howmanyday_process));
                if (db.companies.Where(q => q.active == true).Count() == 1)
                {
                    FirmaCombo.SelectedIndex = 1;
                }
                else
                {
                    FirmaCombo.SelectedIndex = 0;
                }

                if (db.vehicles.Where(q => q.active == true).Count() == 1)
                {
                    AracCombo.SelectedIndex = 1;
                }
                else
                {
                    AracCombo.SelectedIndex = 0;
                }


            }

            // Aktiflik durumu item daki değere göre atanıyor
            AktifMi.Checked = item.active == true ? true : false;
        }

        private string RankGetir()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            string maxRank = db.receiveds.Max(p => p.ranking);
            int _maxRank = Convert.ToInt32(maxRank);
            _maxRank++;
            maxRank = Convert.ToString(_maxRank);
            return maxRank;
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {
            MusteriListesi frm = new MusteriListesi();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {

                var _c = db.customers.FirstOrDefault(q => q.id == frm.musteriid);

                if (_c != null)
                {
                    _customerid = _c.id;
                    txtMusteriAdi.Text = _c.name;
                }

            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                try
                {
                    item.ranking = txtRank.Text;
                    item.purchase_date = AlisTarihi.DateTime;
                    item.received_date = TeslimTarihi.DateTime;
                    item.ref_customer = (int)_customerid;
                    item.note = txtNot.Text;
                    item.ref_vehicle = AracCombo.SelectedIndex;
                    item.ref_company = FirmaCombo.SelectedIndex;
                    item.active = AktifMi.Checked == true ? true : false;
                    if (varmi == false) db.receiveds.Add(item);
                    db.SaveChanges();
                    customer _customer = db.customers.FirstOrDefault(q => q.id == item.ref_customer);
                    
                    if(_customer != null)
                    {
                        order _order = db.orders.FirstOrDefault(q => q.ref_received == item.id);
                        company _company = db.companies.FirstOrDefault(q => q.active == true);

                        //SmsTypeEnum.UponReceipt, (int)item.ref_company, _customer , (DateTime)item.ref_date, item.id,_customer.name,item.received_date,a, _order, _received
                        //SmsApisi.SendSms(SmsTypeEnum.UponReceipt, _company.id, _customer, (DateTime)item.ref_date,
                          //  (int)item.id, _customer.name, item.received_date, Convert.ToString(_order.amount), _order, item);
                    }
                    
                    if (formMode.insert == _mode) XtraMessageBox.Show("Kayıt Başarıyla Tamamlandı.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Kayıt Başarıyla Güncellendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

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
            if (_customerid == null)
            {
                XtraMessageBox.Show("Lütfen Müşteri Seçiniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = btnMusteriBul;
                return false;
            }

            // FirmaComboBox kontrolü
            if (FirmaCombo.SelectedIndex == 0)
            {
                XtraMessageBox.Show("Lütfen Firma Seçiniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = FirmaCombo;
                return false;
            }

            // AraçComboBox kontrolü
            if (AracCombo.SelectedIndex == 0)
            {
                XtraMessageBox.Show("Lütfen Araç Seçiniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = AracCombo;
                return false;
            }

            // Herşey tamamsa return true
            return true;
        }

        private void TeslimTarihi_EditValueChanged(object sender, EventArgs e)
        {
            // Teslim Tarihi Alış Tarihinden küçük olamayacağı için replace
            if (TeslimTarihi.DateTime < AlisTarihi.DateTime)
            {
                DateTime temp = AlisTarihi.DateTime;
                AlisTarihi.DateTime = TeslimTarihi.DateTime;
                TeslimTarihi.DateTime = temp;
            }
        }

        private void txtRank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Fisler frm = new Fisler();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {

                var _c = db.customers.FirstOrDefault(q => q.id == frm.musteriid);

                if (_c != null)
                {
                    _customerid = _c.id;
                    txtMusteriAdi.Text = _c.name;
                }

            }
        }
    }
}