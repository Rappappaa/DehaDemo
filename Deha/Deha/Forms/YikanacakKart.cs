using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DevExpress.XtraRichEdit.Layout.Engine;
using DevExpress.XtraGrid;
using Deha.Properties;

namespace Deha.Forms
{
    public partial class YikanacakKart : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private formMode _mode; // formdan gönderilmiş mod
        public int? _id; // formdan gönderilmiş id

        public received _receiveditem;
        public order _order;
        public orders_detail _detail;
        private List<orders_detail> orglist;
        private BindingList<orders_detail> newlist;

        private int _productid;
        private int _quantity;

        private decimal ek = 0, tutar = 0, toplam = 0, iskontotutari = 0, ekhesap = 0, _m2 = 0;
        private int iskonto = 0;

        GridControl gc = new GridControl();

        public YikanacakKart(formMode mode, int? id)
        {
            InitializeComponent();
            _id = id;
            _mode = mode;
            switch (_mode)
            {
                case formMode.insert:
                    orglist = new List<orders_detail>();
                    newlist = new BindingList<orders_detail>();

                    _receiveditem = db.receiveds.Where(q => q.id == _id).Include(q => q.user).Include(q => q.company).Include(q => q.vehicle).Include(q => q.customer).First();
                    _order = new order()
                    {
                        status = false,
                        active = false,
                        ranking = Convert.ToInt32(_receiveditem.ranking),
                        ref_user = Program._loginuser.id,
                        ref_date = DateTime.Now,
                        mod_date = null
                    };
                    Iskonto.Text = "0";
                    Ek.Text = "0";
                    this.Text = "Yıkamaya Gönder - Kayıt Ekleme";
                    break;
                
                case formMode.edit:
                    _receiveditem = db.receiveds.Where(q => q.id == _id).Include(q => q.user).Include(q => q.company).Include(q => q.vehicle).Include(q => q.customer).FirstOrDefault();
                    _order = db.orders.FirstOrDefault(q => q.ref_received == _receiveditem.id);
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
                        Iskonto.Text = _order.discount.ToString();
                        if(_order.discount != 0)
                        {
                            ekhesap = _order.amount - (_order.total - (_order.total * _order.discount / 100));
                        }
                        else {
                            ekhesap = _order.amount - _order.total;
                        }

                        txtAlisTarihi.DateTime = _receiveditem.purchase_date;
                        txtTeslimTarihi.DateTime = _receiveditem.received_date;

                        Ek.Text = Convert.ToString(ekhesap);
                        this.Text = "Yıkamaya Gönder - Kayıt Düzenleme";
                    }
                    break;
            }
            SepetGridAdetli.Visible = false;
            SepetGridAdetsiz.Visible = false;

            if(Program.adetlimi == true)
            {
                if(_order.calculatedUsed == null || _order.calculatedUsed == true)
                {
                    gc = SepetGridAdetli;
                }

                if (_order.calculatedUsed == false)
                {
                    gc = SepetGridAdetsiz;
                }
            }

            if (Program.adetlimi == false)
            {
                if (_order.calculatedUsed == null || _order.calculatedUsed == false)
                {
                    gc = SepetGridAdetsiz;
                }

                if (_order.calculatedUsed == true)
                {
                    gc = SepetGridAdetli;
                }
            }

            gc.Visible = true;

            var bolge = db.areas.FirstOrDefault(q => q.id == _receiveditem.customer.ref_areas);
            // Sipariş Bilgileri
            txtRank.Text = _receiveditem.ranking;
            txtAlisTarihi.DateTime = _receiveditem.purchase_date;
            txtTeslimTarihi.DateTime = _receiveditem.received_date;
            txtFirma.Text = _receiveditem.company.name;
            txtArac.Text = _receiveditem.vehicle.name;
            txtNot.Text = _receiveditem.note == null ? "Siparişe ait not bulunmamaktadır." : _receiveditem.note;
            // Müşteri Bilgileri
            txtAdSoyad.Text = _receiveditem.customer.name;
            txtTelefon.Text = _receiveditem.customer.phone;
            txtGsm.Text = _receiveditem.customer.gsm;
            txtBolge.Text = bolge.name;
            txtAdres.Text = _receiveditem.customer.adress;
            toplamhesapla();
        }

        private void LoadData()
        {
            gc.DataSource = null;
            gc.DataSource = newlist;

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            UrunGrid.DataSource = db.products.Where(q => q.active == true).Where(q => q.type == 1).ToList();
            toplamhesapla();
        }

        private void toplamhesapla()
        {
            lblTutar.Text = string.Empty;
            lblKalan.Text = string.Empty;
            if (String.IsNullOrWhiteSpace(Iskonto.Text)) iskonto = 0;
            if (!String.IsNullOrWhiteSpace(Iskonto.Text)) iskonto = Convert.ToInt32(Iskonto.Text);

            if (String.IsNullOrWhiteSpace(Ek.Text)) ek = 0;
            if (!String.IsNullOrWhiteSpace(Ek.Text)) ek = Convert.ToDecimal(Ek.Text);

            tutar = 0;
            toplam = 0;
            iskontotutari = 0;

            foreach (var line in newlist.ToList())
            {
                if(_order.calculatedUsed == null)
                {
                    if (Program.adetlimi == true)
                    {
                        if (_order != null)
                        {
                            tutar += line.product_number * line.price * Convert.ToDecimal(line.m2);
                        }
                        else
                        {
                            tutar += line.product_number * line.price * _m2;
                        }

                    }
                    else
                    {
                        if (_order != null)
                        {
                            tutar += line.price * Convert.ToDecimal(line.m2);
                        }
                        else
                        {
                            tutar += _m2 * line.price;
                        }
                    }
                }
                else
                {
                    if (_order.calculatedUsed == true)
                    {
                        if (_order != null)
                        {
                            tutar += line.product_number * line.price * Convert.ToDecimal(line.m2);
                        }
                        else
                        {
                            tutar += line.product_number * line.price * _m2;
                        }

                    }
                    else
                    {
                        if (_order != null)
                        {
                            tutar += line.price * Convert.ToDecimal(line.m2);
                        }
                        else
                        {
                            tutar += _m2 * line.price;
                        }
                    }
                }
                
            }
            
            if (iskonto > 0)
            {
                iskontotutari = tutar * iskonto / 100;
                toplam += (tutar - iskontotutari) + ek;
            }
            else
            {
                toplam += ek + tutar;
            }

            Iskonto.Text = iskonto.ToString();
            Ek.Text = ek.ToString();
            lblTutar.Text = String.Format("{0:C}", tutar);
            lblKalan.Text = String.Format("{0:C}", toplam);

        }

        private int RowGetir()
        {
            if(SepetGridAdetli.Visible == true)
            {
                var rowHandle = adetliView.FocusedRowHandle;
                int val = Convert.ToInt32(adetliView.GetRowCellValue(rowHandle, "id"));
                return val;
            }
            else
            {
                var rowHandle = adetsizView.FocusedRowHandle;
                int val = Convert.ToInt32(adetsizView.GetRowCellValue(rowHandle, "id"));
                return val;
            }
            
        }

        private void YikanacakKart_Load(object sender, EventArgs e)
        {
            LoadData();
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
                if (String.IsNullOrWhiteSpace(txtAdet.Text) || String.IsNullOrWhiteSpace(txtM2.Text)) return;

                _productid = UrunIdGetir();
                _m2 = Convert.ToDecimal(txtM2.Text);
                _quantity = Convert.ToInt32(txtAdet.Text);

                var product = db.products.FirstOrDefault(q => q.id == _productid);

                if (product != null)
                {
                    newlist.Add(new orders_detail
                    {
                        name = product.name,
                        m2 = Convert.ToDouble(_m2),
                        product_number = _quantity,
                        price = product.price
                    });
                }
                
                    toplamhesapla();
                
                LoadData();
                txtAdet.Text = string.Empty;
                txtM2.Text = string.Empty;
                txtEn.Text = string.Empty;
                txtBoy.Text = string.Empty;
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
                catch(Exception ex)
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
                    _receiveditem.status = true;
                    _receiveditem.ranking = txtRank.Text;
                    _receiveditem.mod_date = DateTime.Now;
                    _receiveditem.purchase_date = txtAlisTarihi.DateTime;
                    _receiveditem.received_date = txtTeslimTarihi.DateTime;

                    _order.ref_received = _receiveditem.id;
                    _order.total = tutar;
                    _order.discount = iskonto;
                    _order.amount = toplam;
                    _order.calculatedUsed = Program.adetlimi;

                    if(formMode.insert == _mode) db.orders.Add(_order);

                    db.SaveChanges();

                    foreach (var line in orglist)
                    {
                        var newline = newlist.FirstOrDefault(q => q.name == line.name);
                        if (newline != null)
                        {
                            line.ref_orders = newline.ref_orders;
                            line.name = newline.name;
                            line.m2 = newline.m2;
                            line.price = newline.price;
                            line.product_number = newline.product_number;
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
                    if (formMode.insert == _mode) XtraMessageBox.Show("Sipariş yıkamaya gönderildi", "İşlem Tamamlandı", MessageBoxButtons.OK);
                    if (formMode.edit == _mode) XtraMessageBox.Show("Sipariş düzenlendi", "İşlem Tamamlandı", MessageBoxButtons.OK);
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

        private void Iskonto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEn_EditValueChanged(object sender, EventArgs e)
        {
            /*
            if (!String.IsNullOrEmpty(txtEn.Text) && !String.IsNullOrEmpty(txtBoy.Text))
            {
                _m2 = Convert.ToInt32(txtEn.Text) * Convert.ToInt32(txtBoy.Text);
                txtM2.Text = _m2.ToString();
            }
            */
        }

        private void txtBoy_EditValueChanged(object sender, EventArgs e)
        {
            /*
            if (!String.IsNullOrEmpty(txtEn.Text) && !String.IsNullOrEmpty(txtBoy.Text))
            {
                _m2 = Convert.ToInt32(txtEn.Text) * Convert.ToInt32(txtBoy.Text);
                txtM2.Text = _m2.ToString();
            }
            */
        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            */
        }

        private void txtBoy_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            */
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEn.Text) || string.IsNullOrWhiteSpace(txtBoy.Text)) return;
            _m2 = Convert.ToDecimal(txtEn.Text) * Convert.ToDecimal(txtBoy.Text);
            txtM2.Text = _m2.ToString();
        }

        private void txtM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            */
        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Ek_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Ek_Leave(object sender, EventArgs e)
        {
            toplamhesapla();
        }
    }
}