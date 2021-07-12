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
    public partial class DirekSatis : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id

        public invoice _invoice;
        public order _order;
        public orders_detail _detail;
        private List<orders_detail> orglist;
        private BindingList<orders_detail> newlist;

        private int _productid;
        private int _quantity;

        private decimal  tutar = 0,toplam = 0;
        private int iskonto = 0;

        public DirekSatis(formMode mode, int? id)
        {
            InitializeComponent();

            _id = id;
            _mode = mode;

            switch (_mode)
            {
                case formMode.insert:
                    orglist = new List<orders_detail>();
                    newlist = new BindingList<orders_detail>();

                    _order = new order()
                    {
                        ref_received = null,
                        total = 0,
                        discount = 0,
                        amount = 0,
                        status = true,
                        active = true,
                        type = 2,
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now
                    };

                    _invoice = new invoice()
                    {
                        type = 0,
                        ref_date = DateTime.Now
                    };

                    Iskonto.Text = "0";
                    this.Text = "Direk Satış - Yeni Satış";
                    break;

                case formMode.edit:
                    _order = db.orders.FirstOrDefault(q => q.id == _id);
                    _invoice = db.invoices.FirstOrDefault(q => q.ref_orders == _order.id);

                    if (_order == null || _invoice == null)
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
                                name = line.name,
                                product_number = line.product_number,
                                price = line.price
                            });
                        }

                        Iskonto.Text = _order.discount.ToString();

                        this.Text = "Direk Satış - Satış Düzenleme";
                    }
                    break;
            }

            toplamhesapla();
        }

        private void DirekSatis_Load(object sender, EventArgs e)
        {
            if(_invoice != null)
            {
                Nakit.Checked = _invoice.payment_type == 0 ? true : false;
                KrediKarti.Checked = _invoice.payment_type == 1 ? true : false;
                Diger.Checked = _invoice.payment_type == 1 ? true : false;
                Iskonto.Text = Convert.ToString(_order.discount);
                txtNot.Text = _invoice.note;
            }

            LoadData();

            gridView1.BestFitColumns();
            gridView2.BestFitColumns();

        }

        private void LoadData()
        {
            DirekSatisGrid.DataSource = null;
            DirekSatisGrid.DataSource = newlist;

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            UrunGrid.DataSource = db.products.Where(q => q.active == true).Where(q => q.type == 2).ToList();

        }

        private void toplamhesapla()
        {
            lblTutar.Text = string.Empty;

            iskonto = Convert.ToInt32(Iskonto.Text);

            tutar = 0;
            toplam = 0;

            foreach (var line in newlist.ToList())
            {

                tutar += line.price * line.product_number;
            }

            toplam = tutar;

            if (iskonto > 0) toplam = tutar - ((tutar * iskonto) / 100);

            Iskonto.Text = iskonto.ToString();
            lblTutar.Text = String.Format("{0:C}", tutar);
        }

        private int RowGetir()
        {
                var rowHandle = gridView1.FocusedRowHandle;
                int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
                return val;
        }

        private int UrunIdGetir()
        {
            var rowHandle = gridView2.FocusedRowHandle;
            int val = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "id"));
            return val;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtAdet.Text))
                {
                    XtraMessageBox.Show("Lütfen ADET giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                    ActiveControl = txtAdet;
                    return; 
                }
                _productid = UrunIdGetir();
                _quantity = Convert.ToInt32(txtAdet.Text);

                var product = db.products.FirstOrDefault(q => q.id == _productid);

                if (product != null)
                {
                    newlist.Add(new orders_detail
                    {
                        name = product.name,
                        m2 = 0,
                        product_number = _quantity,
                        price = product.price
                    });
                }

                toplamhesapla();

                LoadData();
                txtAdet.Text = string.Empty;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecek = newlist.FirstOrDefault(q => q.id == RowGetir());
            if (silinecek == null)
            {
                XtraMessageBox.Show("Silinecek kayıt bulunamadı.", "Eksik veri girişi", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    newlist.Remove(silinecek);
                    toplamhesapla();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (newlist.Count > 0)
                {
                    if(Nakit.Checked == false && KrediKarti.Checked == false && Diger.Checked == false)
                    {
                        XtraMessageBox.Show("Ödeme Türü Seçiniz", "Eksik veri girişi", MessageBoxButtons.OK);
                        return;
                    }

                    _order.total = tutar;
                    _order.discount = iskonto;
                    _order.amount = toplam;
                    

                    if (formMode.insert == _mode) db.orders.Add(_order);

                    if(formMode.edit == _mode)
                    {
                        _order.mod_date = DateTime.Now;
                        _order.ref_user = Program._loginuser.id;
                    }

                    db.SaveChanges();

                    foreach (var line in orglist)
                    {
                        var newline = newlist.FirstOrDefault(q => q.name == line.name);
                        if (newline != null)
                        {
                            line.ref_orders = newline.ref_orders;
                            line.name = newline.name;
                            line.product_number = newline.product_number;
                            line.price = newline.price;
                        }
                        else
                        {
                            db.orders_detail.Remove(line);
                        }
                    }

                    foreach (var line in newlist.Where(q => q.id == 0))
                    {
                        line.ref_orders = _order.id;
                        db.orders_detail.Add(line);
                    }

                    db.SaveChanges();

                    _invoice.ref_orders = _order.id;
                    _invoice.total = toplam;
                    _invoice.collect = toplam;
                    _invoice.note = txtNot.Text;
                    _invoice.ref_date = DateTime.Now;
                    _invoice.ref_user = Program._loginuser.id;

                    if (Nakit.Checked == true) _invoice.payment_type = 0;
                    if (KrediKarti.Checked == true) _invoice.payment_type = 1;
                    if (Diger.Checked == true) _invoice.payment_type = 2;

                    if (formMode.insert == _mode) db.invoices.Add(_invoice);

                    db.SaveChanges();


                    if (formMode.insert == _mode) XtraMessageBox.Show("Satış kayıt edildi.", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Satış düzenlendi.", "İşlem Tamamlandı", MessageBoxButtons.OK);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Sepette ürün bulunmuyor", "Eksik veri girişi", MessageBoxButtons.OK);
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

        private void Nakit_CheckedChanged(object sender, EventArgs e)
        {
            if (Nakit.Checked == true)
            {
                KrediKarti.Checked = false;
                Diger.Checked = false;
            }
        }

        private void KrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            if (KrediKarti.Checked == true)
            {
                Nakit.Checked = false;
                Diger.Checked = false;
            }
        }

        private void Diger_CheckedChanged(object sender, EventArgs e)
        {
            if (Diger.Checked == true)
            {
                Nakit.Checked = false;
                KrediKarti.Checked = false;
            }
        }

        private void Iskonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Iskonto_Leave(object sender, EventArgs e)
        {
            toplamhesapla();
        }

    }
}