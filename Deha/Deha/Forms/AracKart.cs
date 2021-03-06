using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class AracKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public vehicle item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public AracKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new vehicle()
                    {
                        active = true
                    };
                    this.Text = "Araçlar - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.vehicles.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        varmi = true;
                        this.Text = "Araçlar - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void AracKart_Load(object sender, EventArgs e)
        {
            ActiveControl = txtName;
            // Kayıt Varsa Atamaları Yap
            if (varmi == true)
            {
                txtName.Text = item.name;
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
                    item.active = AktifMi.Checked == true ? true : false;
                    item.ref_user = Program._loginuser.id;
                    item.ref_date = DateTime.Now;
                    if (varmi == false) db.vehicles.Add(item);
                    db.SaveChanges();

                    if (formMode.insert == _mode) XtraMessageBox.Show("Araç başarıyla eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Araç başarıyla düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

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
                XtraMessageBox.Show("Lütfen ARAÇ ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtName;
                return false;
            }
            return true;
        }
    }
}