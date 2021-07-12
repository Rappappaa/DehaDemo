using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class TeslimveTahsilat : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        public int? _id; // formdan gönderilmiş id
        public formMode _mode;

        public received _receiveditem;
        public order _order;
        public area _area;
        public orders_detail _detail;
        private List<orders_detail> orglist;
        private BindingList<orders_detail> newlist;

        private int toplam = 0,adet = 0;

        public TeslimveTahsilat(int? id)
        {
            InitializeComponent();
            _id = id;

            _order = db.orders.FirstOrDefault(q => q.id == _id);
            _receiveditem = db.receiveds.FirstOrDefault(q => q.id == _order.ref_received);
            _area = db.areas.FirstOrDefault(q => q.id == _receiveditem.customer.ref_areas);

        }

        private void TeslimveTahsilat_Load(object sender, EventArgs e)
        {
            if (_order == null)
            {
                XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı", "Kayıt Bulunamadı", MessageBoxButtons.OK);
                DialogResult = DialogResult.No;
                this.Close();
            }
            else
            {
                // eski faturadetay kayıtlarını çek
                orglist = new List<orders_detail>();
                newlist = new BindingList<orders_detail>();
                orglist = db.orders_detail.Where(q => q.ref_orders == _order.id).ToList();
                foreach (var line in orglist)
                {
                    newlist.Add(new orders_detail
                    {
                        id = line.id,
                        ref_orders = line.ref_orders,
                        name = line.name,
                        m2 = line.m2,
                        product_number = line.product_number,
                        price = line.price
                    });
                }
            }

            foreach (var line in newlist.ToList())
            {
                adet += line.product_number;
                toplam += Convert.ToInt32(line.m2);
            }

            
            // Sipariş Bilgileri
            txtNot.Text = _receiveditem.note == null ? "Siparişe ait not bulunmamaktadır." : _receiveditem.note;
            txtTutar.Text = String.Format("{0:C}", _order.amount);
            txtUrunAdeti.Text = adet.ToString();
            txtToplamm2.Text = toplam.ToString() + "²";
            // Müşteri Bilgileri
            txtAdSoyad.Text = _receiveditem.customer.name;
            txtTelefon.Text = _receiveditem.customer.phone;
            txtGsm.Text = _receiveditem.customer.gsm;
            txtBolge.Text = _area.name;
            txtAdres.Text = _receiveditem.customer.adress;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTahsilEdilen.Text))
            {
                XtraMessageBox.Show("Lütfen Tahsil Edilen Tutarı Giriniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                ActiveControl = txtTahsilEdilen;
                return;
            }
            else
            {
                if (Nakit.Checked == false && KrediKarti.Checked == false)
                {
                    XtraMessageBox.Show("Lütfen Ödeme Türü Seçiniz", "Hatalı Veri Girişi", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    try
                    {

                        _order.active = false;
                        _order.mod_date = DateTime.Now;

                        invoice _invoice = new invoice()
                        {
                            ref_customer = _receiveditem.ref_customer,
                            ref_orders = _order.id,
                            total = _order.total,
                            collect = Convert.ToDecimal(txtTahsilEdilen.Text),
                            type = 0,
                            payment_type = Nakit.Checked == true ? 0 : 1,
                            ref_user = Program._loginuser.id,
                            note = txtNot.Text,
                            ref_date = DateTime.Now
                        };

                        db.invoices.Add(_invoice);
                        db.SaveChanges();
                        customer _customer = new customer();
                        _customer = db.customers.FirstOrDefault(q => q.id == _receiveditem.ref_customer);

                        if(_customer != null)
                        {
                            if(_invoice.total > _invoice.collect)
                            {
                                _customer.balance += _invoice.total - _invoice.collect;
                            }
                            else
                            {
                                _customer.balance -= _invoice.collect - _invoice.total;
                            }
                        }

                        db.SaveChanges();
                        
                        XtraMessageBox.Show("Teslim ve Tahsilat işlemi başarıyla kayıt edildi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "Başarısız", MessageBoxButtons.OK);
                    }
                }
            }
            
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TumunuAl_CheckStateChanged(object sender, EventArgs e)
        {
            if(TumunuAl.Checked == true)
            {
                txtTahsilEdilen.Text = _order.amount.ToString();
            }
            else
            {
                txtTahsilEdilen.Text = "0";
            }
        }

        private void Nakit_CheckedChanged(object sender, EventArgs e)
        {
            if (Nakit.Checked == true ) KrediKarti.Checked = false;
        }

        private void KrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            if (KrediKarti.Checked == true) Nakit.Checked = false;
        }

    }
}