using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Deha.Properties;

namespace Deha.UserControls
{
    public partial class HizmetRaporlari : DevExpress.XtraEditors.XtraUserControl
    {
        private decimal nakit = 0, kredi = 0, toplam = 0, diger = 0;
        public HizmetRaporlari()
        {
            InitializeComponent();
        }

        private void HizmetRaporlari_Load(object sender, EventArgs e)
        {
            FirstDate.DateTime = DateTime.Now;
            LastDate.DateTime = DateTime.Now;

            LoadData();

            gridView1.BestFitColumns();
        }

        private void LoadData()
        {
            toplam = 0;
            nakit = 0;
            kredi = 0;
            diger = 0;

            DehaPosModel db = new DehaPosModel(nameOrConnectionString: Settings.Default["_connectionstring"].ToString());

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");
            /*
            string query =
                    @"SELECT r.id as fisno, c.id as kayitno, c.name as musteriadi, comp.name as firmaadi , v.name as servisadi , u.fullname as teslimedecek ,
	                    SUM(od.product_number) as adet, SUM(od.m2) as m2, o.total, o.discount as iskonto, o.total as tutar , (o.total * o.discount / 100) as iskontotutari , o.amount as toplam, o.mod_date as teslimtarihi,
	                    r.mod_date as alindigitarih, od.name as urunadi, toplam =
						CASE
	                                WHEN o.calculatedUsed = 1 THEN SUM((od.m2 * od.price) * od.product_number) 
	                                WHEN o.calculatedUsed = 0 THEN SUM((od.m2 * od.price)) 
                                END
								, i.payment_type as odemeturu
	                    FROM orders o
	                        INNER JOIN orders_detail od ON o.id = od.ref_orders
	                        INNER JOIN received r ON o.ref_received = r.id
	                        INNER JOIN users u ON u.id = o.ref_user
	                        INNER JOIN customers c ON c.id = r.ref_customer
	                        INNER JOIN areas a ON a.id = c.ref_areas
	                        INNER JOIN vehicle v ON v.id = r.ref_vehicle
                            INNER JOIN company comp ON r.ref_company = comp.id
                            INNER JOIN invoice i ON i.ref_orders = o.id
	                    WHERE CONVERT(DATE, o.mod_date) BETWEEN @p1 AND @p2
                            GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
		                    o.amount, 
	                        o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id , v.name, u.fullname ,
                            comp.id , comp.name , comp.color , c.id, c.phone, od.name , i.total , i.payment_type
	                    ORDER BY o.ref_date";
            */
            string query = @"SELECT [name], SUM(od.m2) m2, SUM(od.product_number) number,i.type as tip, 'totalPrice' = 
                                CASE
	                                WHEN o.calculatedUsed = 1 THEN SUM((od.m2 * od.price) * od.product_number) 
	                                WHEN o.calculatedUsed = 0 THEN SUM((od.m2 * od.price)) 
                                END
	                            FROM invoice i
		                            INNER JOIN orders_detail od ON od.ref_orders = i.ref_orders
		                            INNER JOIN orders o ON i.ref_orders = o.id
	                            WHERE i.type = 0 AND i.ref_date BETWEEN @p1 AND @p2 AND o.type=1 GROUP BY od.name,o.calculatedUsed,i.type ";
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
                /*
                _teslimedilenmodel.urunadi = reader["urunadi"].ToString();
                _teslimedilenmodel.adet = Convert.ToInt32(reader["adet"]);
                _teslimedilenmodel.m2 = Convert.ToInt32(reader["m2"].ToString());
                _teslimedilenmodel.toplam = Convert.ToDecimal(reader["toplam"].ToString());
                _teslimedilenmodel.tip = Convert.ToInt32(reader["odemeturu"].ToString());
                */
                _teslimedilenmodel.urunadi = reader["name"].ToString();
                _teslimedilenmodel.adet = Convert.ToInt32(reader["number"]);
                _teslimedilenmodel.m2 = Convert.ToInt32(reader["m2"].ToString());
                _teslimedilenmodel.toplam = Convert.ToDecimal(reader["totalPrice"].ToString());
                _teslimedilenmodel.tip = Convert.ToInt32(reader["tip"].ToString());
                teslimedilenlist.Add(_teslimedilenmodel);
            }

            reader.Dispose();
            reader.Close();
            HizmetRaporlariGrid.DataSource = teslimedilenlist;

            
            List<deneme> _deneme = new List<deneme>();

            foreach (var i in db.products.Where(q => q.type == 1).ToList())
            {
                deneme _liste = new deneme();
                _liste.urunadi = i.name;

                foreach(var j in teslimedilenlist)
                {
                    if(i.name == j.urunadi)
                    {
                        _liste.adet += j.adet;
                        _liste.m2 += j.m2;
                        _liste.toplam += j.toplam;
                    }
                }

                _deneme.Add(_liste);

            }

            //HizmetRaporlariGrid.DataSource = _deneme;
            /*
            foreach (var i in teslimedilenlist)
            {
                if (i.tip == 0)
                {
                    nakit += i.toplam;
                }
                if (i.tip == 1)
                {
                    kredi += i.toplam;
                }
                if (i.tip == 2)
                {
                    diger += i.toplam;
                }
            }
            */
            string queryAllCreditCard = @"SELECT SUM(collect) as creditCard FROM invoice i
                                                    INNER JOIN orders o ON i.ref_orders = o.id
                                                WHERE i.type = 0 AND payment_type = 1 AND i.ref_date BETWEEN @p1 AND @p2 AND o.type = 1";

            var cmdAllCreditCard = new SqlCommand(queryAllCreditCard, connection);

            cmdAllCreditCard.Parameters.AddWithValue("@p1", ilkgun);
            cmdAllCreditCard.Parameters.AddWithValue("@p2", ikincigun);
            var readerAllCreditCard = cmdAllCreditCard.ExecuteReader();

            while (readerAllCreditCard.Read()) kredi = readerAllCreditCard.IsDBNull(0) ? 0 : Convert.ToDecimal(readerAllCreditCard["creditCard"]);
            readerAllCreditCard.Dispose();
            readerAllCreditCard.Close();

            var queryAllCash = @"SELECT SUM(collect) as cash FROM invoice i
			                                INNER JOIN orders o ON i.ref_orders = o.id
                                        WHERE i.type = 0 AND payment_type = 0 AND i.ref_date BETWEEN @p1 AND @p2  AND o.type = 1";
            var cmdAllCash = new SqlCommand(queryAllCash, connection);

            cmdAllCash.Parameters.AddWithValue("@p1", ilkgun);
            cmdAllCash.Parameters.AddWithValue("@p2", ikincigun);
            var readerAllCash = cmdAllCash.ExecuteReader();

            while (readerAllCash.Read()) nakit = readerAllCash.IsDBNull(0) ? 0 : Convert.ToDecimal(readerAllCash["cash"]);
            readerAllCash.Dispose();
            readerAllCash.Close();

            connection.Close();


            toplam = nakit + kredi;
            lblnakit.Text = String.Format("{0:C}",nakit);
            lblkredikarti.Text = String.Format("{0:C}", kredi);
            lbldiger.Text = String.Format("{0:C}", diger);
            lbltoplam.Text = String.Format("{0:C}", toplam);
        }

        private void btnTarihFiltre_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FirstDate_EditValueChanged(object sender, EventArgs e)
        {
            LastDate.DateTime = FirstDate.DateTime;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                HizmetRaporlariGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " HİZMET RAPORU.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
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

        internal class deneme
        {
            public string urunadi { get; set; }
            public int adet { get; set; }
            public decimal m2 { get; set; }
            public decimal tutar { get; set; }
            public decimal toplam { get; set; }
            public int tip { get; set; }

        }

        internal class TeslimEdilenlerModel
        {
            public string urunadi { get; set; }
            public int adet { get; set; }
            public decimal m2 { get; set; }
            public decimal tutar { get; set; }
            public decimal toplam { get; set; }
            public int tip { get; set; }

        }
    }
}
