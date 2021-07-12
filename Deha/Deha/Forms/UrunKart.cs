using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.Forms
{
    public partial class UrunKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public product item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public UrunKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new product()
                    {
                        active = true
                    };
                    this.Text = "Ürünler - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.products.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Ürünler - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void UrunKart_Load(object sender, EventArgs e)
        {
            // Müşteri Combobox Doldur
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Tümü", 0));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Hizmet", 1));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Satılacak Ürün", 2));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 3));


            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtName.Text = item.name;
                txtPrice.Text = item.price.ToString();
                TurCombo.SelectedIndex = item.type;
            }
            // Kayıt Yoksa Default Getir
            else
            {
                TurCombo.SelectedIndex = 3;
            }

            // Aktiflik durumu item daki değere göre atanıyor
            AktifMi.Checked = item.active == true ? true : false;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckField())
                {
                    item.name = txtName.Text;
                    item.price = Convert.ToDecimal(txtPrice.Text);
                    item.type = TurCombo.SelectedIndex;
                    item.active = AktifMi.Checked == true ? true : false;
                    item.ref_user = Program._loginuser.id;
                    item.ref_date = DateTime.Now;
                    if (varmi == false) db.products.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Ürün başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Ürün başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

                    this.Close();
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        private bool CheckField()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Lütfen ÜRÜN ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtPrice.Text))
            {
                XtraMessageBox.Show("Lütfen FİYAT giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtPrice;
                return false;
            }
            return true;
        }
    }
}