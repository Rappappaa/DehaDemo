using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.Forms
{
    public partial class SmsSablonKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public sms_template item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public SmsSablonKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new sms_template()
                    {
                        active = true,
                        ref_date = DateTime.Now
                    };
                    this.Text = "Sms Şablonları - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.sms_template.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Sms Şablonları - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void SmsSablonKart_Load(object sender, EventArgs e)
        {
            
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Teslim Alınca",0));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Sepete Ekleyince",1));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Teslim Edince",2));
            TurCombo.Properties.Items.Add(new ImageComboBoxItem("Seçiniz", 3));

            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtTitle.Text = item.title;
                txtMessage.Text = item.message;
                TurCombo.SelectedIndex = item.type;
            }
            else
            {
                TurCombo.SelectedIndex = 3;
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
                    item.title = txtTitle.Text;
                    item.message = txtMessage.Text;
                    item.type = Convert.ToByte(TurCombo.SelectedIndex);
                    item.active = AktifMi.Checked == true ? true : false;
                    item.ref_user = Program._loginuser.id;
                    if (varmi == false) db.sms_template.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Sms Şablonu başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Sms Şablonu başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        private bool CheckField()
        {
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                XtraMessageBox.Show("Lütfen BAŞLIK giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtTitle;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtMessage.Text))
            {
                XtraMessageBox.Show("Lütfen MESAJ giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtMessage;
                return false;
            }
            if (TurCombo.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Lütfen MESAJ TÜRÜ seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = TurCombo;
                return false;
            }
            return true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}