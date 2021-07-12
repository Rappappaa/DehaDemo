using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.SqlClient;
using Deha.Forms;
using Deha.Properties;

namespace Deha.UserControls
{
    public partial class GenelRapor : DevExpress.XtraEditors.XtraUserControl
    {
        private decimal toplam = 0, nakit = 0, kredikarti = 0, diger = 0, gider = 0, tamamlanmis = 0, m2 = 0;
        public GenelRapor()
        {
            InitializeComponent();
        }

        private void GenelRapor_Load(object sender, EventArgs e)
        {
            FirstDate.DateTime = DateTime.Now;
            LastDate.DateTime = DateTime.Now;
            LoadData();

            
        }

        private void LoadData()
        {
            GelirToplam();

            GelirNakit();

            GelirKrediKarti();

            GelirDiger();

            Gider();

            Tamamlanmis();

            MetreKare();

            gridView1.BestFitColumns();
            gridView2.BestFitColumns();
            gridView3.BestFitColumns();
            gridView4.BestFitColumns();
            gridView5.BestFitColumns();
            gridView6.BestFitColumns();
            gridView7.BestFitColumns();

        }

        private void GelirToplam()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            toplam = 0;
            toplam = Convert.ToDecimal(
                db.invoices.SqlQuery(
                    "SELECT * FROM invoice WHERE type = 0 AND CONVERT(DATE,ref_date) BETWEEN @p1 AND @p2",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).Sum(q => q.collect)
                    );

            string query =
                    @"SELECT invoice.id as kayitno, invoice.payment_type as odemeturu ,invoice.ref_date as tarih, invoice.collect as tutar, orders.id as fisno
                    FROM invoice
                    JOIN orders ON orders.id = invoice.ref_orders
                    WHERE invoice.type = 0 AND CONVERT(DATE,invoice.ref_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<GelirToplamList> _GelirToplamList = new List<GelirToplamList>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GelirToplamList _GelirToplamListModel = new GelirToplamList();

                _GelirToplamListModel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _GelirToplamListModel.fisno = Convert.ToInt32(reader["fisno"].ToString());

                int _tur = Convert.ToInt32(reader["odemeturu"]);
                if (_tur == 0)
                {
                    _GelirToplamListModel.odemeturu = "Nakit";
                }
                if (_tur == 1)
                {
                    _GelirToplamListModel.odemeturu = "Kredi Kartı";
                }
                if (_tur == 2)
                {
                    _GelirToplamListModel.odemeturu = "Diğer";
                }

                _GelirToplamListModel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _GelirToplamListModel.tarih = Convert.ToDateTime(reader["tarih"].ToString());

                _GelirToplamList.Add(_GelirToplamListModel);

            }

            GelirToplamGrid.DataSource = _GelirToplamList;
            reader.Dispose();
            reader.Close();
            connection.Close();
            lbltoplam.Text = String.Format("{0:C}", toplam);
        }

        private void GelirNakit()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            nakit = 0;
            nakit = Convert.ToDecimal(
                db.invoices.SqlQuery(
                    "SELECT * FROM invoice WHERE type = 0 AND payment_type = 0 AND CONVERT(DATE,ref_date) BETWEEN @p1 AND @p2",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).Sum(q => q.collect)
                    );

            string query =
                    @"SELECT invoice.id as kayitno, invoice.payment_type as odemeturu ,invoice.ref_date as tarih, invoice.collect as tutar, orders.id as fisno
                    FROM invoice
                    JOIN orders ON orders.id = invoice.ref_orders
                    WHERE invoice.type = 0 AND invoice.payment_type = 0 AND CONVERT(DATE,invoice.ref_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<GelirToplamList> _GelirNakitList = new List<GelirToplamList>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GelirToplamList _GelirToplamListModel = new GelirToplamList();

                _GelirToplamListModel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _GelirToplamListModel.fisno = Convert.ToInt32(reader["fisno"].ToString());

                int _tur = Convert.ToInt32(reader["odemeturu"]);
                if (_tur == 0)
                {
                    _GelirToplamListModel.odemeturu = "Nakit";
                }
                if (_tur == 1)
                {
                    _GelirToplamListModel.odemeturu = "Kredi Kartı";
                }
                if (_tur == 2)
                {
                    _GelirToplamListModel.odemeturu = "Diğer";
                }

                _GelirToplamListModel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _GelirToplamListModel.tarih = Convert.ToDateTime(reader["tarih"].ToString());

                _GelirNakitList.Add(_GelirToplamListModel);

            }

            GelirNakitGrid.DataSource = _GelirNakitList;
            reader.Dispose();
            reader.Close();
            connection.Close();

            lblnakit.Text = String.Format("{0:C}", nakit);
        }

        private void GelirKrediKarti()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            kredikarti = 0;
            kredikarti = Convert.ToDecimal(
                db.invoices.SqlQuery(
                    "SELECT * FROM invoice WHERE type = 0 AND payment_type = 1 AND CONVERT(DATE,ref_date) BETWEEN @p1 AND @p2",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).Sum(q => q.collect)
                    );
            string query =
                    @"SELECT invoice.id as kayitno, invoice.payment_type as odemeturu ,invoice.ref_date as tarih, invoice.collect as tutar, orders.id as fisno
                    FROM invoice
                    JOIN orders ON orders.id = invoice.ref_orders
                    WHERE invoice.type = 0 AND invoice.payment_type = 1 AND CONVERT(DATE,invoice.ref_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<GelirToplamList> _GelirKrediKartiList = new List<GelirToplamList>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GelirToplamList _GelirToplamListModel = new GelirToplamList();

                _GelirToplamListModel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _GelirToplamListModel.fisno = Convert.ToInt32(reader["fisno"].ToString());

                int _tur = Convert.ToInt32(reader["odemeturu"]);
                if (_tur == 0)
                {
                    _GelirToplamListModel.odemeturu = "Nakit";
                }
                if (_tur == 1)
                {
                    _GelirToplamListModel.odemeturu = "Kredi Kartı";
                }
                if (_tur == 2)
                {
                    _GelirToplamListModel.odemeturu = "Diğer";
                }

                _GelirToplamListModel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _GelirToplamListModel.tarih = Convert.ToDateTime(reader["tarih"].ToString());

                _GelirKrediKartiList.Add(_GelirToplamListModel);

            }

            GelirKrediKartiGrid.DataSource = _GelirKrediKartiList;
            reader.Dispose();
            reader.Close();
            connection.Close();

            lblkredikarti.Text = String.Format("{0:C}", kredikarti);
        }

        private void GelirDiger()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            diger = 0;
            diger = Convert.ToDecimal(
                db.invoices.SqlQuery(
                    "SELECT * FROM invoice WHERE type = 0 AND payment_type = 2 AND CONVERT(DATE,ref_date) BETWEEN @p1 AND @p2",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).Sum(q => q.collect)
                    );
            string query =
                    @"SELECT invoice.id as kayitno, invoice.payment_type as odemeturu ,invoice.ref_date as tarih, invoice.collect as tutar, orders.id as fisno
                    FROM invoice
                    JOIN orders ON orders.id = invoice.ref_orders
                    WHERE invoice.type = 0 AND invoice.payment_type = 2 AND CONVERT(DATE,invoice.ref_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<GelirToplamList> _GelirKrediKartiList = new List<GelirToplamList>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GelirToplamList _GelirToplamListModel = new GelirToplamList();

                _GelirToplamListModel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _GelirToplamListModel.fisno = Convert.ToInt32(reader["fisno"].ToString());

                int _tur = Convert.ToInt32(reader["odemeturu"]);
                if (_tur == 0)
                {
                    _GelirToplamListModel.odemeturu = "Nakit";
                }
                if (_tur == 1)
                {
                    _GelirToplamListModel.odemeturu = "Kredi Kartı";
                }
                if (_tur == 2)
                {
                    _GelirToplamListModel.odemeturu = "Diğer";
                }

                _GelirToplamListModel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _GelirToplamListModel.tarih = Convert.ToDateTime(reader["tarih"].ToString());

                _GelirKrediKartiList.Add(_GelirToplamListModel);

            }

            GelirDigerGrid.DataSource = _GelirKrediKartiList;
            reader.Dispose();
            reader.Close();
            connection.Close();

            lbldiger.Text = String.Format("{0:C}", diger);
        }

        private void Gider()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            gider = 0;
            gider = Convert.ToDecimal(
                db.invoices.SqlQuery(
                    "SELECT * FROM invoice WHERE type = 1 AND CONVERT(DATE,ref_date) BETWEEN @p1 AND @p2",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).Sum(q => q.total)
                    );
            string query =
                    @"SELECT invoice.id as kayitno, invoice.payment_type as odemeturu ,invoice.ref_date as tarih, invoice.total as tutar, invoice.note as nott
                    FROM invoice
                    WHERE invoice.type = 1 AND CONVERT(DATE,invoice.ref_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<GelirToplamList> _GelirKrediKartiList = new List<GelirToplamList>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GelirToplamList _GelirToplamListModel = new GelirToplamList();

                _GelirToplamListModel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _GelirToplamListModel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _GelirToplamListModel.tarih = Convert.ToDateTime(reader["tarih"].ToString());
                _GelirToplamListModel.siparisnotu = reader["nott"].ToString();

                _GelirKrediKartiList.Add(_GelirToplamListModel);

            }

            GiderGrid.DataSource = _GelirKrediKartiList;
            reader.Dispose();
            reader.Close();
            connection.Close();

            lblgider.Text = String.Format("{0:C}", gider);
        }

        private void Tamamlanmis()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            tamamlanmis = 0;

            string query =
                    @"SELECT orders.id FROM orders WHERE active = 1 AND CONVERT(DATE,mod_date) BETWEEN @p1 AND @p2 ";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tamamlanmis++;
            }
            reader.Dispose();
            reader.Close();
            connection.Close();

            string query2 =
                    @"SELECT r.id as fisno, c.id as kayitno, c.name as musteriadi, comp.name as firmaadi , v.name as servisadi , u.fullname as teslimedecek ,
	                    SUM(od.product_number) as adet, SUM(od.m2) as m2, o.total, o.discount as iskonto, o.total as tutar , (o.total * o.discount / 100) as iskontotutari , o.amount as toplam, o.mod_date as teslimtarihi,
	                    r.mod_date as alindigitarih
	                    FROM orders o
	                        INNER JOIN orders_detail od ON o.id = od.ref_orders
	                        INNER JOIN received r ON o.ref_received = r.id
	                        INNER JOIN users u ON u.id = o.ref_user
	                        INNER JOIN customers c ON c.id = r.ref_customer
	                        INNER JOIN areas a ON a.id = c.ref_areas
	                        INNER JOIN vehicle v ON v.id = r.ref_vehicle
                            INNER JOIN company comp ON r.ref_company = comp.id 
	                    WHERE o.status = 1 AND o.active = 1 AND CONVERT(DATE, o.mod_date) BETWEEN @p1 AND @p2
                            GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
		                    o.amount, 
	                        o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name, u.fullname ,
                            comp.id , comp.name , comp.color , c.id, c.phone
	                    ORDER BY o.ref_date";
            SqlConnection connection2 = new SqlConnection();
            connection2.ConnectionString = connectionString;

            connection2.Open();

            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            cmd2.Parameters.AddWithValue("@p1", ilkgun);
            cmd2.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            List<TeslimEdilenlerModel> teslimedilenlist = new List<TeslimEdilenlerModel>();

            while (reader2.Read())
            {

                TeslimEdilenlerModel _teslimedilenmodel = new TeslimEdilenlerModel();

                _teslimedilenmodel.kayitno = Convert.ToInt32(reader2["kayitno"].ToString());
                _teslimedilenmodel.fisno = Convert.ToInt32(reader2["fisno"].ToString());
                _teslimedilenmodel.musteriadi = reader2["musteriadi"].ToString();
                _teslimedilenmodel.firmaadi = reader2["firmaadi"].ToString();
                _teslimedilenmodel.servisadi = reader2["servisadi"].ToString();
                _teslimedilenmodel.teslimedecek = reader2["teslimedecek"].ToString();
                _teslimedilenmodel.adet = Convert.ToInt32(reader2["adet"]);
                _teslimedilenmodel.m2 = Convert.ToInt32(reader2["m2"].ToString());
                _teslimedilenmodel.tutar = Convert.ToDecimal(reader2["tutar"].ToString());
                _teslimedilenmodel.iskonto = Convert.ToInt32(reader2["iskonto"].ToString());
                _teslimedilenmodel.iskontotutari = Convert.ToDecimal(reader2["iskontotutari"].ToString());
                _teslimedilenmodel.toplam = Convert.ToDecimal(reader2["toplam"].ToString());
                _teslimedilenmodel.teslimtarihi = Convert.ToDateTime(reader2["teslimtarihi"]);

                teslimedilenlist.Add(_teslimedilenmodel);
            }
            reader.Dispose();
            reader.Close();
            connection2.Close();

            TamamlanmislarGrid.DataSource = teslimedilenlist;
            
            lblsiparis.Text = tamamlanmis + " ADET";
        }

        private void MetreKare()
        {
            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            m2 = 0;
            string query =
                    @"SELECT orders_detail.m2 as m2
						FROM orders_detail
						JOIN orders ON orders.id =  orders_detail.ref_orders
						JOIN received ON received.id = orders.ref_received
						WHERE CONVERT(DATE,received.purchase_date) BETWEEN @p1 AND @p2";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                m2 += Convert.ToDecimal(reader["m2"]);
            }

            reader.Dispose();
            reader.Close();
            connection.Close();

            string query2 =
                    @"SELECT r.id as fisno, c.id as kayitno, c.name as musteriadi, comp.name as firmaadi , v.name as servisadi , u.fullname as teslimedecek ,
	                    SUM(od.product_number) as adet, SUM(od.m2) as m2, o.total, o.discount as iskonto, o.total as tutar , (o.total * o.discount / 100) as iskontotutari , o.amount as toplam, o.mod_date as teslimtarihi,
	                    r.mod_date as alindigitarih
	                    FROM received r
		                    INNER JOIN orders o ON o.ref_received = r.id
	                        INNER JOIN orders_detail od ON o.id = od.ref_orders
	                        INNER JOIN users u ON u.id = o.ref_user
	                        INNER JOIN customers c ON c.id = r.ref_customer
	                        INNER JOIN areas a ON a.id = c.ref_areas
	                        INNER JOIN vehicle v ON v.id = r.ref_vehicle
                            INNER JOIN company comp ON r.ref_company = comp.id 
	                    WHERE r.status = 1 AND r.active = 1 AND CONVERT(DATE, r.mod_date) BETWEEN @p1 AND @p2
                            GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
		                    o.amount, 
	                        o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name, u.fullname ,
                            comp.id , comp.name , comp.color , c.id, c.phone
	                    ORDER BY o.ref_date";

            SqlConnection connection2 = new SqlConnection();
            connection2.ConnectionString = connectionString;

            connection2.Open();
            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            cmd2.Parameters.AddWithValue("@p1", ilkgun);
            cmd2.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            List<TeslimAlinanlarModel> teslimalinanlist = new List<TeslimAlinanlarModel>();

            while (reader2.Read())
            {

                TeslimAlinanlarModel _teslimalinanmodel = new TeslimAlinanlarModel();

                _teslimalinanmodel.kayitno = Convert.ToInt32(reader2["kayitno"].ToString());
                _teslimalinanmodel.fisno = Convert.ToInt32(reader2["fisno"].ToString());
                _teslimalinanmodel.musteriadi = reader2["musteriadi"].ToString();
                _teslimalinanmodel.firmaadi = reader2["firmaadi"].ToString();
                _teslimalinanmodel.servisadi = reader2["servisadi"].ToString();
                _teslimalinanmodel.teslimedecek = reader2["teslimedecek"].ToString();
                _teslimalinanmodel.adet = Convert.ToInt32(reader2["adet"]);
                _teslimalinanmodel.m2 = Convert.ToDecimal(reader2["m2"].ToString());
                _teslimalinanmodel.tutar = Convert.ToDecimal(reader2["tutar"].ToString());
                _teslimalinanmodel.iskonto = Convert.ToInt32(reader2["iskonto"].ToString());
                _teslimalinanmodel.iskontotutari = Convert.ToDecimal(reader2["iskontotutari"].ToString());
                _teslimalinanmodel.toplam = Convert.ToDecimal(reader2["toplam"].ToString());
                _teslimalinanmodel.teslimtarihi = Convert.ToDateTime(reader2["alindigitarih"]);

                teslimalinanlist.Add(_teslimalinanmodel);
            }

            reader.Dispose();
            reader.Close();

            AlinanSiparislerGrid.DataSource = teslimalinanlist;

            lblm2.Text = m2 + "²";
        }

        private void btnTarihFiltre_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void GelirToplamGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "fisno"));
            DirekSatis frm = new DirekSatis(formMode.edit, val);
            frm.ShowDialog();
            LoadData();
        }

        private void GelirNakitGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView2.FocusedRowHandle;
            int val = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "fisno"));
            DirekSatis frm = new DirekSatis(formMode.edit, val);
            frm.ShowDialog();
            LoadData();
        }

        private void GelirKrediKartiGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView3.FocusedRowHandle;
            int val = Convert.ToInt32(gridView3.GetRowCellValue(rowHandle, "fisno"));
            DirekSatis frm = new DirekSatis(formMode.edit, val);
            frm.ShowDialog();
            LoadData();
        }

        private void GelirDigerGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView4.FocusedRowHandle;
            int val = Convert.ToInt32(gridView4.GetRowCellValue(rowHandle, "fisno"));
            DirekSatis frm = new DirekSatis(formMode.edit, val);
            frm.ShowDialog();
            LoadData();
        }

        private void GiderGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView5.FocusedRowHandle;
            int val = Convert.ToInt32(gridView5.GetRowCellValue(rowHandle, "kayitno"));
            GiderEkle frm = new GiderEkle(formMode.edit, val);
            frm.ShowDialog();
            LoadData();
        }

        private void TamamlanmislarGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView6.FocusedRowHandle;
            int val = Convert.ToInt32(gridView6.GetRowCellValue(rowHandle, "kayitno"));
            TeslimveTahsilat frm = new TeslimveTahsilat(val);
            frm.ShowDialog();
            LoadData();
        }

        private void AlinanSiparislerGrid_DoubleClick(object sender, EventArgs e)
        {
            var rowHandle = gridView7.FocusedRowHandle;
            int val = Convert.ToInt32(gridView7.GetRowCellValue(rowHandle, "kayitno"));
            YikanacakKart frm = new YikanacakKart(formMode.edit, val);
            frm.ShowDialog();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            GenelRaporDisaAktar frm = new GenelRaporDisaAktar();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                if (frm._gelirtoplam == true)
                {
                    try
                    {
                        GelirToplamGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " TOPLAM GELİR.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
                if (frm._gelirnakit == true)
                {
                    try
                    {
                        GelirNakitGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " NAKİT GELİR.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
                if (frm._gelirkredikarti == true)
                {
                    try
                    {
                        GelirKrediKartiGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " KREDİ KARTI GELİR.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
                if (frm._gelirdiger == true)
                {
                    try
                    {
                        GelirDigerGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " DİGER GELİR.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
                if (frm._gider == true)
                {
                    try
                    {
                        GiderGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " GİDER.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
                if (frm._tamamlanmissiparisler == true)
                {
                    try
                    {
                        TamamlanmislarGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " TAMAMLANMIŞ SİPARİŞLER.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }

                if (frm._alinansiparisler == true)
                {
                    try
                    {
                        AlinanSiparislerGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " ALINMIŞ SİPARİŞLER.xls");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
            }
            
        }

        internal class GelirToplamList
        {
            public int fisno { get; set; }
            public int kayitno { get; set; }
            public string odemeturu { get; set; }
            public string siparisnotu { get; set; }
            public decimal tutar { get; set; }
            public DateTime tarih { get; set; }

        }

        internal class TeslimEdilenlerModel
        {
            private void iskontohesapla()
            {
                this.iskontotutari = this.tutar * this.iskonto / 100;
            }
            public int kayitno { get; set; }
            public int fisno { get; set; }
            public string musteriadi { get; set; }
            public string firmaadi { get; set; }
            public string servisadi { get; set; }
            public string teslimedecek { get; set; }
            public int adet { get; set; }
            public decimal m2 { get; set; }
            private decimal _tutar;
            public decimal tutar
            {
                get { return _tutar; }
                set
                {
                    this._tutar = value;
                    this.iskontohesapla();
                }
            }
            private int _iskonto;
            public int iskonto
            {

                get { return _iskonto; }
                set
                {
                    this._iskonto = value;
                    this.iskontohesapla();
                }
            }
            public decimal iskontotutari
            {
                get; set;
            }
            public decimal toplam { get; set; }
            public DateTime teslimtarihi { get; set; }

        }

        internal class TeslimAlinanlarModel
        {
            private void iskontohesapla()
            {
                this.iskontotutari = this.tutar * this.iskonto / 100;
            }
            public int kayitno { get; set; }
            public int fisno { get; set; }
            public string musteriadi { get; set; }
            public string firmaadi { get; set; }
            public string servisadi { get; set; }
            public string teslimedecek { get; set; }
            public int adet { get; set; }
            public decimal m2 { get; set; }
            private decimal _tutar;
            public decimal tutar
            {
                get { return _tutar; }
                set
                {
                    this._tutar = value;
                    this.iskontohesapla();
                }
            }
            private int _iskonto;
            public int iskonto
            {

                get { return _iskonto; }
                set
                {
                    this._iskonto = value;
                    this.iskontohesapla();
                }
            }
            public decimal iskontotutari
            {
                get; set;
            }
            public decimal toplam { get; set; }
            public DateTime teslimtarihi { get; set; }

        }
    }
}
