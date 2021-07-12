using System;
using System.Data.SqlClient;
using Deha.Forms;
using System.Collections.Generic;
using Deha.Properties;
using System.Windows.Forms;

namespace Deha.UserControls
{
    public partial class GunOzeti : DevExpress.XtraEditors.XtraUserControl
    {
        private int i;
        public GunOzeti()
        {
            InitializeComponent();
        }

        private void GunOzeti_Load(object sender, EventArgs e)
        {
            FirstDate.DateTime = DateTime.Now;
            LastDate.DateTime = DateTime.Now;

            LoadData();

            gridView1.BestFitColumns();
            gridView2.BestFitColumns();
        }

        public void LoadData()
        {
            TeslimAlinanlar();
            TeslimEdilenler();
        }

        private void TeslimEdilenler()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT r.id as fisno, c.id as kayitno, c.name as musteriadi, c.adress as musteriadres, comp.name as firmaadi , v.name as servisadi , u.fullname as teslimedecek ,
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
	                    WHERE o.status = 1 AND o.active = 0 AND CONVERT(DATE, o.mod_date) BETWEEN @p1 AND @p2
                            GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
		                    o.amount, 
	                        o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name, u.fullname ,
                            comp.id , comp.name , comp.color , c.id, c.phone
	                    ORDER BY o.ref_date";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();
            List<TeslimEdilenlerModel> teslimedilenlist = new List<TeslimEdilenlerModel>();

            while (reader.Read())
            {

                TeslimEdilenlerModel _teslimedilenmodel = new TeslimEdilenlerModel();

                _teslimedilenmodel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _teslimedilenmodel.fisno = Convert.ToInt32(reader["fisno"].ToString());
                _teslimedilenmodel.musteriadi = reader["musteriadi"].ToString();
                _teslimedilenmodel.adres = reader["musteriadres"].ToString();
                _teslimedilenmodel.firmaadi = reader["firmaadi"].ToString();
                _teslimedilenmodel.servisadi = reader["servisadi"].ToString();
                _teslimedilenmodel.teslimedecek = reader["teslimedecek"].ToString();
                _teslimedilenmodel.adet = Convert.ToInt32(reader["adet"]);
                _teslimedilenmodel.m2 = Convert.ToDecimal(reader["m2"].ToString());
                _teslimedilenmodel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _teslimedilenmodel.iskonto = Convert.ToInt32(reader["iskonto"].ToString());
                _teslimedilenmodel.iskontotutari = Convert.ToDecimal(reader["iskontotutari"].ToString());
                _teslimedilenmodel.toplam = Convert.ToDecimal(reader["toplam"].ToString());
                _teslimedilenmodel.teslimtarihi = Convert.ToDateTime(reader["teslimtarihi"]);

                teslimedilenlist.Add(_teslimedilenmodel);
            }

            reader.Dispose();
            reader.Close();
            TeslimEdilenlerGrid.DataSource = teslimedilenlist;
        }

        private void TeslimAlinanlar()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT r.id as fisno, c.id as kayitno, c.name as musteriadi, c.adress as musteriadres, comp.name as firmaadi , v.name as servisadi , u.fullname as teslimedecek ,
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

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);

            SqlDataReader reader = cmd.ExecuteReader();
            List<TeslimAlinanlarModel> teslimalinanlist = new List<TeslimAlinanlarModel>();

            while (reader.Read())
            {

                TeslimAlinanlarModel _teslimalinanmodel = new TeslimAlinanlarModel();

                _teslimalinanmodel.kayitno = Convert.ToInt32(reader["kayitno"].ToString());
                _teslimalinanmodel.fisno = Convert.ToInt32(reader["fisno"].ToString());
                _teslimalinanmodel.musteriadi = reader["musteriadi"].ToString();
                _teslimalinanmodel.adres = reader["musteriadres"].ToString();
                _teslimalinanmodel.firmaadi = reader["firmaadi"].ToString();
                _teslimalinanmodel.servisadi = reader["servisadi"].ToString();
                _teslimalinanmodel.teslimedecek = reader["teslimedecek"].ToString();
                _teslimalinanmodel.adet = Convert.ToInt32(reader["adet"]);
                _teslimalinanmodel.m2 = Convert.ToDecimal(reader["m2"].ToString());
                _teslimalinanmodel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _teslimalinanmodel.iskonto = Convert.ToInt32(reader["iskonto"].ToString());
                _teslimalinanmodel.iskontotutari = Convert.ToDecimal(reader["iskontotutari"].ToString());
                _teslimalinanmodel.toplam = Convert.ToDecimal(reader["toplam"].ToString());
                _teslimalinanmodel.teslimtarihi = Convert.ToDateTime(reader["alindigitarih"]);

                teslimalinanlist.Add(_teslimalinanmodel);
            }

            reader.Dispose();
            reader.Close();

            TeslimAlinanlarGrid.DataSource = teslimalinanlist;
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


        private void btnYazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void TeslimAlinanlarGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                i = 1;
            }
        }

        private void TeslimEdilenlerGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                i = 2;
            }
        }

        private void müşteriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(i == 1)
            {
                var rowHandle = gridView1.FocusedRowHandle;
                int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "kayitno"));

                if(val > 0)
                {
                    MusteriKart frm = new MusteriKart(formMode.edit, val);
                    frm.ShowDialog();
                }
            }
            if (i == 2)
            {
                var rowHandle = gridView2.FocusedRowHandle;
                int val = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "kayitno"));
                if (val > 0)
                {
                    MusteriKart frm = new MusteriKart(formMode.edit, val);
                    frm.ShowDialog();
                }
            }
        }

        private void siparişiGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                var rowHandle = gridView1.FocusedRowHandle;
                int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "fisno"));
                if (val > 0)
                {
                    YikanacakKart frm = new YikanacakKart(formMode.edit, val);
                    frm.ShowDialog();
                }
            }
            if (i == 2)
            {
                var rowHandle = gridView2.FocusedRowHandle;
                int val = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "fisno"));
                if (val > 0)
                {
                    YikanacakKart frm = new YikanacakKart(formMode.edit, val);
                    frm.ShowDialog();
                }
            }
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
            public string adres { get; set; }
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
            public string adres { get; set; }
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
