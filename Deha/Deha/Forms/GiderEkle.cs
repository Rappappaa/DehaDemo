using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class GiderEkle : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        public invoice item; // işlemlerde kullanacağımız received modeli
        private bool varmi = false;

        public GiderEkle(formMode mode,int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    item = new invoice()
                    {
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now
                    };
                    
                    this.Text = "Araçlar - Kayıt Ekleme";
                    break;

                case formMode.edit:
                    item = db.invoices.FirstOrDefault(q => q.id == _id);
                    if (item == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        txtName.Text = item.note;
                        txtPrice.Text = String.Format("{0:C2}", item.total);
                        varmi = true;
                        this.Text = "Araçlar - Kayıt Düzenleme";
                    }
                    break;
            }
        }

        private void GiderEkle_Load(object sender, EventArgs e)
        {
            AktifMi.Checked = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    XtraMessageBox.Show("Lütfen GİDER ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                    ActiveControl = txtName;
                    return;
                }
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    XtraMessageBox.Show("Lütfen GİDER TUTARI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                    ActiveControl = txtPrice;
                    return;
                }
                if(AktifMi.Checked == false)
                {
                    DehaPosModel _db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                    invoice _a = _db.invoices.FirstOrDefault(q => q.id == _id);
                    _db.invoices.Remove(_a);
                    _db.SaveChanges();

                    XtraMessageBox.Show("Gider silindi.", "Gider Silindi", MessageBoxButtons.OK);
                    this.Close();
                }

                item.ref_customer = null;
                item.ref_orders = null;
                item.total = Convert.ToDecimal(txtPrice.Text);
                item.type = 1;
                item.payment_type = null;
                item.note = txtName.Text;
                item.collect = null;
                item.ref_user = Program._loginuser.id;
                item.ref_date = DateTime.Now;
                DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                if(varmi == false) db.invoices.Add(item);
                db.SaveChanges();

                XtraMessageBox.Show("Gider başarıyla eklendi.", "Gider Eklendi", MessageBoxButtons.OK);
                this.Close();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
            
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}