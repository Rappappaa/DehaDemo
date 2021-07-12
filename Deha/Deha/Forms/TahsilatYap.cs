using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;

namespace Deha.Forms
{
    public partial class TahsilatYap : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id
        private invoice item;
        private customer _customeritem;
        private int? _customerid;

        public TahsilatYap(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;
            
            switch (_mode)
            {
                case formMode.insert:
                    _customeritem = db.customers.FirstOrDefault(q => q.id == _id);
                    if (_customeritem == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    _customerid = _customeritem.id;
                    txtMusteriAdi.Text = _customeritem.name;
                    item = new invoice()
                    {
                        ref_customer = null,
                        ref_orders = null,
                        total = 0,
                        collect = 0,
                        type = 3,
                        payment_type = null,
                        note = null,
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now
                    };
                    break;

                case formMode.edit:
                    item = db.invoices.FirstOrDefault(q => q.id == _id);
                    _customeritem = db.customers.FirstOrDefault(q => q.id == _id);
                    if (item == null || _customeritem == null)
                    {
                        XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        _customeritem = db.customers.FirstOrDefault(q => q.id == item.ref_customer);
                        _customerid = _customeritem.id;
                        txtMusteriAdi.Text = _customeritem.name;
                        txtTutar.Text = Convert.ToString(item.collect);
                        txtNot.Text = item.note;
                        if (item.payment_type == 0) Nakit.Checked = true;
                        if (item.payment_type == 1) KrediKarti.Checked = true;
                    }
                    break;
            }
        }

        private void TahsilatYap_Load(object sender, EventArgs e)
        {

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

        private void btnFisBul_Click(object sender, EventArgs e)
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

        private void Nakit_CheckedChanged(object sender, EventArgs e)
        {
            if (Nakit.Checked == true) KrediKarti.Checked = false;
        }

        private void KrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            if (KrediKarti.Checked == true) Nakit.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                try
                {
                    item.ref_customer = _customerid;
                    item.ref_orders = null;
                    item.total = Convert.ToDecimal(txtTutar.Text);
                    item.collect = Convert.ToDecimal(txtTutar.Text);
                    item.type = 3;
                    if (Nakit.Checked == true) item.payment_type = 0;
                    if (KrediKarti.Checked == true) item.payment_type = 1;
                    item.note = txtNot.Text;
                    item.ref_user = Program._loginuser.id;
                    item.ref_date = DateTime.Now;

                    if (formMode.insert == _mode)
                    {
                        _customeritem = db.customers.FirstOrDefault(q => q.id == _customerid);
                        _customeritem.balance += Convert.ToDecimal(txtTutar.Text);
                        db.invoices.Add(item);
                    }
                    else
                    {
                        _customeritem.balance += Convert.ToDecimal(txtTutar.Text);
                    }

                    db.SaveChanges();



                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckField()
        {
            if (String.IsNullOrWhiteSpace(txtMusteriAdi.Text))
            {
                XtraMessageBox.Show("Lütfen BÖLGE ADI giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtMusteriAdi;
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtTutar.Text))
            {
                XtraMessageBox.Show("Lütfen TUTAR giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtTutar;
                return false;
            }
            if (Nakit.Checked == false && KrediKarti.Checked == false)
            {
                XtraMessageBox.Show("Lütfen ÖDEME TÜRÜ seçiniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}