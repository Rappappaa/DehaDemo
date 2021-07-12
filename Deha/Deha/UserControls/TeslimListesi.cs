using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Deha.Forms;
using Deha.Properties;

namespace Deha.UserControls
{
    public partial class TeslimListesi : DevExpress.XtraEditors.XtraUserControl
    {

        private int _adet;
        private decimal _m2;
        private decimal _tutar;

        public TeslimListesi()
        {
            InitializeComponent();
        }

        private void TeslimListesi_Load(object sender, EventArgs e)
        {
            FirstDate.DateTime = DateTime.Now;
            LastDate.DateTime = DateTime.Now;

            LoadData();

            gridView1.BestFitColumns();
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "fisno"));
            return val;
        }

        public void LoadData()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT o.id, o.ranking, o.calculatedUsed, c.id as customerid , c.phone as cphone, c.name as musteriadi, 
                             u.fullname as kullaniciadi,c.countryCode, c.gsm as cgsm, c.adress as cadres, a.name areas, r.note,o.discount, o.total, o.amount, 
	                         o.ref_date, r.purchase_date, r.mod_date , r.received_date, o.mod_date, r.ref_customer, r.id receivedid, v.id ref_vehicle, a.id ref_areas,
                                comp.id company_id, comp.name company_name, comp.color company_color, SUM(od.product_number) as product_number, SUM(od.m2) as m2, v.name as servisadi
	                                FROM orders o
	                                  INNER JOIN orders_detail od ON o.id = od.ref_orders
	                                  INNER JOIN received r ON o.ref_received = r.id
	                                  INNER JOIN users u ON u.id = o.ref_user
	                                  INNER JOIN customers c ON c.id = r.ref_customer
	                                  INNER JOIN areas a ON a.id = c.ref_areas
	                                  INNER JOIN vehicle v ON v.id = r.ref_vehicle
                                      INNER JOIN company comp ON r.ref_company = comp.id 
	                              WHERE o.status = 1 AND o.active = 1 AND CONVERT(DATE, r.received_date) BETWEEN @p1 AND @p2 
                                     GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
								      o.amount, 
	                                  o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name ,
                                      comp.id , comp.name , comp.color , c.id, c.phone
	                              ORDER BY o.ref_date DESC";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
                
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();
            List<customWashModel> list = new List<customWashModel>();

            while (reader.Read())
            {

                customWashModel _model = new customWashModel();

                _model.kayitno = Convert.ToInt32(reader["customerid"].ToString());
                _model.fisno = Convert.ToInt32(reader["receivedid"].ToString());
                _model.musteriadi = reader["musteriadi"].ToString();
                _model.sira = Convert.ToInt32(reader["ranking"]);
                _model.adress = reader["cadres"].ToString();
                _model.telefon = reader["cphone"].ToString();
                _model.gsm = reader["cgsm"].ToString();
                _model.firmaadi = reader["company_name"].ToString();
                _model.servisadi = reader["servisadi"].ToString();
                _model.teslimedecek = reader["kullaniciadi"].ToString();
                _model.total = Convert.ToDecimal(reader["total"].ToString());
                _model.amount = Convert.ToDecimal(reader["amount"].ToString());
                _model.iskontoyuzdesi = Convert.ToInt32(reader["discount"].ToString());
                if (Convert.ToDecimal(reader["amount"].ToString()) != 0)
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) * Convert.ToInt32(reader["discount"].ToString()) / 100));
                }
                else
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - Convert.ToDecimal(reader["total"].ToString());
                }
                _model.product_number = Convert.ToInt32(reader["product_number"]);
                _model.m2 = Convert.ToInt32(reader["m2"].ToString());
                _model.ref_date = Convert.ToDateTime(reader["ref_date"]);
                    
                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();

            _adet = 0;
            _m2 = 0;
            _tutar = 0;

            foreach(var i in list)
            {
                _adet += i.product_number;
                _m2 += i.m2;
                _tutar += i.amount;
            }

            TeslimEdileceklerGrid.DataSource = list;

        }

        private void btnTarihFiltre_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FirstDate_EditValueChanged(object sender, EventArgs e)
        {
            LastDate.DateTime = FirstDate.DateTime;
        }

        private void LastDate_EditValueChanged(object sender, EventArgs e)
        {
            if (LastDate.DateTime < FirstDate.DateTime)
            {
                DateTime temp = FirstDate.DateTime;
                FirstDate.DateTime = LastDate.DateTime;
                LastDate.DateTime = temp;
            }
        }

        private void btnTeslimeGonder_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                int _id = RowGetir();
                if (XtraMessageBox.Show(_id.ToString() + " numaralı kayıt teslim edildi mi?", "Teslim Etme Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        order item = new order();
                        item = db.orders.FirstOrDefault(q => q.ref_received == _id);
                        if (item != null)
                        {
                            TeslimveTahsilat frm = new TeslimveTahsilat(item.id);
                            frm.ShowDialog();
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ServisSec frm = new ServisSec();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                using (frmPrint frm2 = new frmPrint("teslimedilecek"))
                {
                    frm2.PrintForm(frm.servisid);
                    frm2.ShowDialog();
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                int _id = RowGetir();
                if (XtraMessageBox.Show(_id.ToString() + " numaralı Kayıt tekrar Yıkanacaklar Listesine gönderilsin mi?", "Yıkamaya Geri Gönderme", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        order item = new order();
                        item = db.orders.FirstOrDefault(q => q.ref_received == _id);
                        {
                            item.status = false;
                            db.SaveChanges();
                            XtraMessageBox.Show("Kayıt başarıyla Yıkanacaklar Listesine gönderildi.", "İşlem Başarılı", MessageBoxButtons.OK);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }

                }

            }
        }

        private void TeslimEdileceklerGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void müşteriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "kayitno"));
            if (val == 0) return;
            MusteriKart frm = new MusteriKart(formMode.edit, val);
            frm.ShowDialog();
        }

        private void siparişiGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "fisno"));
            if (val == 0) return;
            YikanacakKart frm = new YikanacakKart(formMode.edit, val);
            frm.ShowDialog();
        }

        private void btnAracDegistir_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                try
                {
                    DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                    AracSecme frm = new AracSecme();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        int r = RowGetir();
                        received _received = db.receiveds.FirstOrDefault(q => q.id == r);
                        _received.ref_vehicle = frm.id;
                        db.SaveChanges();
                    }
                    LoadData();
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                }
            }
            
        }

        private void btnGecmisler_Click(object sender, EventArgs e)
        {
            DateTime dt =  DateTime.Now;
            string gun = dt.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT o.id, o.ranking, o.calculatedUsed, c.id as customerid , c.phone as cphone, c.name as musteriadi, 
                             u.fullname as kullaniciadi,c.countryCode, c.gsm as cgsm, c.adress as cadres, a.name areas, r.note,o.discount, o.total, o.amount, 
	                         o.ref_date, r.purchase_date, r.mod_date , r.received_date, o.mod_date, r.ref_customer, r.id receivedid, v.id ref_vehicle, a.id ref_areas,
                                comp.id company_id, comp.name company_name, comp.color company_color, SUM(od.product_number) as product_number, SUM(od.m2) as m2, v.name as servisadi
	                                FROM orders o
	                                  INNER JOIN orders_detail od ON o.id = od.ref_orders
	                                  INNER JOIN received r ON o.ref_received = r.id
	                                  INNER JOIN users u ON u.id = o.ref_user
	                                  INNER JOIN customers c ON c.id = r.ref_customer
	                                  INNER JOIN areas a ON a.id = c.ref_areas
	                                  INNER JOIN vehicle v ON v.id = r.ref_vehicle
                                      INNER JOIN company comp ON r.ref_company = comp.id 
	                              WHERE o.status = 1 AND o.active = 1 AND CONVERT(DATE, r.received_date) <= @p1
                                     GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
								      o.amount, 
	                                  o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name ,
                                      comp.id , comp.name , comp.color , c.id, c.phone
	                              ORDER BY o.ref_date DESC";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", gun);

            SqlDataReader reader = cmd.ExecuteReader();
            List<customWashModel> list = new List<customWashModel>();

            while (reader.Read())
            {

                customWashModel _model = new customWashModel();

                _model.kayitno = Convert.ToInt32(reader["customerid"].ToString());
                _model.fisno = Convert.ToInt32(reader["receivedid"].ToString());
                _model.musteriadi = reader["musteriadi"].ToString();
                _model.sira = Convert.ToInt32(reader["ranking"]);
                _model.adress = reader["cadres"].ToString();
                _model.telefon = reader["cphone"].ToString();
                _model.gsm = reader["cgsm"].ToString();
                _model.firmaadi = reader["company_name"].ToString();
                _model.servisadi = reader["servisadi"].ToString();
                _model.teslimedecek = reader["kullaniciadi"].ToString();
                _model.total = Convert.ToDecimal(reader["total"].ToString());
                _model.amount = Convert.ToDecimal(reader["amount"].ToString());
                _model.iskontoyuzdesi = Convert.ToInt32(reader["discount"].ToString());
                if (Convert.ToDecimal(reader["amount"].ToString()) != 0)
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) * Convert.ToInt32(reader["discount"].ToString()) / 100));
                }
                else
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - Convert.ToDecimal(reader["total"].ToString());
                }
                _model.product_number = Convert.ToInt32(reader["product_number"]);
                _model.m2 = Convert.ToInt32(reader["m2"].ToString());
                _model.ref_date = Convert.ToDateTime(reader["ref_date"]);

                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();

            _adet = 0;
            _m2 = 0;
            _tutar = 0;

            foreach (var i in list)
            {
                _adet += i.product_number;
                _m2 += i.m2;
                _tutar += i.amount;
            }

            TeslimEdileceklerGrid.DataSource = list;
        }

        private void btnTumu_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string gun = dt.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT o.id, o.ranking, o.calculatedUsed, c.id as customerid , c.phone as cphone, c.name as musteriadi, 
                             u.fullname as kullaniciadi,c.countryCode, c.gsm as cgsm, c.adress as cadres, a.name areas, r.note,o.discount, o.total, o.amount, 
	                         o.ref_date, r.purchase_date, r.mod_date , r.received_date, o.mod_date, r.ref_customer, r.id receivedid, v.id ref_vehicle, a.id ref_areas,
                                comp.id company_id, comp.name company_name, comp.color company_color, SUM(od.product_number) as product_number, SUM(od.m2) as m2, v.name as servisadi
	                                FROM orders o
	                                  INNER JOIN orders_detail od ON o.id = od.ref_orders
	                                  INNER JOIN received r ON o.ref_received = r.id
	                                  INNER JOIN users u ON u.id = o.ref_user
	                                  INNER JOIN customers c ON c.id = r.ref_customer
	                                  INNER JOIN areas a ON a.id = c.ref_areas
	                                  INNER JOIN vehicle v ON v.id = r.ref_vehicle
                                      INNER JOIN company comp ON r.ref_company = comp.id 
	                              WHERE o.status = 1 AND o.active = 1
                                     GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
								      o.amount, 
	                                  o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name ,
                                      comp.id , comp.name , comp.color , c.id, c.phone
	                              ORDER BY o.ref_date DESC";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            List<customWashModel> list = new List<customWashModel>();

            while (reader.Read())
            {

                customWashModel _model = new customWashModel();

                _model.kayitno = Convert.ToInt32(reader["customerid"].ToString());
                _model.fisno = Convert.ToInt32(reader["receivedid"].ToString());
                _model.musteriadi = reader["musteriadi"].ToString();
                _model.sira = Convert.ToInt32(reader["ranking"]);
                _model.adress = reader["cadres"].ToString();
                _model.telefon = reader["cphone"].ToString();
                _model.gsm = reader["cgsm"].ToString();
                _model.firmaadi = reader["company_name"].ToString();
                _model.servisadi = reader["servisadi"].ToString();
                _model.teslimedecek = reader["kullaniciadi"].ToString();
                _model.total = Convert.ToDecimal(reader["total"].ToString());
                _model.amount = Convert.ToDecimal(reader["amount"].ToString());
                _model.iskontoyuzdesi = Convert.ToInt32(reader["discount"].ToString());
                if (Convert.ToDecimal(reader["amount"].ToString()) != 0)
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) - (Convert.ToDecimal(reader["total"].ToString()) * Convert.ToInt32(reader["discount"].ToString()) / 100));
                }
                else
                {
                    _model.ek = Convert.ToDecimal(reader["amount"].ToString()) - Convert.ToDecimal(reader["total"].ToString());
                }
                _model.product_number = Convert.ToInt32(reader["product_number"]);
                _model.m2 = Convert.ToInt32(reader["m2"].ToString());
                _model.ref_date = Convert.ToDateTime(reader["ref_date"]);

                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();

            _adet = 0;
            _m2 = 0;
            _tutar = 0;

            foreach (var i in list)
            {
                _adet += i.product_number;
                _m2 += i.m2;
                _tutar += i.amount;
            }

            TeslimEdileceklerGrid.DataSource = list;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Kayıtların teslim tarihi bugün olarak değiştirilsin mi?", "Teslim Tarihi Değiştirme Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DateTime dt = DateTime.Now;
                        string gun = dt.ToString("yyyy/MM/dd");

                        string query =
                                @"SELECT o.id, o.ranking, o.calculatedUsed, c.id as customerid , c.phone as cphone, c.name as musteriadi, 
                             u.fullname as kullaniciadi,c.countryCode, c.gsm as cgsm, c.adress as cadres, a.name as areaname, r.note,o.discount, o.total, o.amount, 
	                         o.ref_date, r.purchase_date, r.mod_date , r.received_date, o.mod_date, r.ref_customer, r.id receivedid, v.id ref_vehicle, a.id ref_areas,
                                comp.id company_id, comp.name company_name, comp.color company_color, SUM(od.product_number) as product_number, SUM(od.m2) as m2, v.name as servisadi
	                                FROM orders o
	                                  INNER JOIN orders_detail od ON o.id = od.ref_orders
	                                  INNER JOIN received r ON o.ref_received = r.id
	                                  INNER JOIN users u ON u.id = o.ref_user
	                                  INNER JOIN customers c ON c.id = r.ref_customer
	                                  INNER JOIN areas a ON a.id = c.ref_areas
	                                  INNER JOIN vehicle v ON v.id = r.ref_vehicle
                                      INNER JOIN company comp ON r.ref_company = comp.id 
	                              WHERE o.status = 1 AND o.active = 1 AND CONVERT(DATE, r.received_date) <= @p1
                                     GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
								      o.amount, 
	                                  o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name ,
                                      comp.id , comp.name , comp.color , c.id, c.phone
	                              ORDER BY o.ref_date DESC";

                        string connectionString = Program.connectionstring;
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;

                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@p1", gun);

                        SqlDataReader reader = cmd.ExecuteReader();
                        List<customWashModel> list = new List<customWashModel>();

                        while (reader.Read())
                        {

                            customWashModel _model = new customWashModel(); 

                            _model.kayitno = Convert.ToInt32(reader["customerid"].ToString());
                            _model.fisno = Convert.ToInt32(reader["receivedid"].ToString());
                            _model.musteriadi = reader["musteriadi"].ToString();
                            _model.bolge = reader["areaname"].ToString();
                            _model.sira = Convert.ToInt32(reader["ranking"]);
                            _model.adress = reader["cadres"].ToString();
                            _model.telefon = reader["cphone"].ToString();
                            _model.gsm = reader["cgsm"].ToString();
                            _model.firmaadi = reader["company_name"].ToString();
                            _model.servisadi = reader["servisadi"].ToString();
                            _model.teslimedecek = reader["kullaniciadi"].ToString();
                            _model.amount = Convert.ToDecimal(reader["amount"].ToString());
                            _model.product_number = Convert.ToInt32(reader["product_number"]);
                            _model.m2 = Convert.ToInt32(reader["m2"].ToString());
                            _model.ref_date = Convert.ToDateTime(reader["ref_date"]);

                            list.Add(_model);
                        }

                        reader.Dispose();
                        reader.Close();

                        _adet = 0;
                        _m2 = 0;
                        _tutar = 0;

                        foreach (var i in list)
                        {
                            _adet += i.product_number;
                            _m2 += i.m2;
                            _tutar += i.amount;
                        }
                        try
                        {
                            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                            foreach (var i in list)
                            {
                                received _r = db.receiveds.FirstOrDefault(q => q.id == i.fisno);
                                _r.received_date = dt;
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                        }
                        XtraMessageBox.Show("Geçmiş siparişlerin teslimat tarihi bugün olarak değiştirildi.", "İşlem Başarılı", MessageBoxButtons.OK);
                        FirstDate.DateTime = DateTime.Now;
                        LastDate.DateTime = DateTime.Now;
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
        }
    }

    internal class customWashModel
    {
        public int kayitno { get; set; }
        public int fisno { get; set; }
        public string musteriadi { get; set; }
        public string bolge { get; set; }
        public int sira { get; set; }
        public string adress { get; set; }
        public string telefon { get; set; }
        public string gsm { get; set; }
        public string firmaadi { get; set; }
        public string servisadi { get; set; }
        public string teslimedecek { get; set; }
        public decimal amount { get; set; }
        public decimal total { get; set; }
        public int iskontoyuzdesi { get; set; }
        public decimal ek { get; set; }
        public int product_number { get; set; }
        public decimal m2 { get; set; }
        public DateTime ref_date { get; set; }
    }
}
