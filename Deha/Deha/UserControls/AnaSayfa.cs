using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Deha.Forms;

namespace Deha.UserControls
{
    public partial class AnaSayfa : UserControl
    {
        private int width;
        private string ilkgun = DateTime.Now.ToString("yyyy/MM/dd");
        private string ikincigun = DateTime.Now.ToString("yyyy/MM/dd");

        public AnaSayfa()
        {
            InitializeComponent();

        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            width = this.Size.Width;

            tabPage1.Controls.Clear();
            AlinacaklarListesi UCAlinacaklarListesi = new AlinacaklarListesi();
            UCAlinacaklarListesi.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(UCAlinacaklarListesi);

            tabPage2.Controls.Clear();
            YikanacaklarListesi UCYikanacaklarListesi = new YikanacaklarListesi();
            UCYikanacaklarListesi.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(UCYikanacaklarListesi);

            tabPage3.Controls.Clear();
            TeslimListesi UCTeslimListesi = new TeslimListesi();
            UCTeslimListesi.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(UCTeslimListesi);

            tabPage4.Controls.Clear();
            IptalEdilenler UCIptalEdilenler = new IptalEdilenler();
            UCIptalEdilenler.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(UCIptalEdilenler);

            tabPage5.Controls.Clear();
            Musteriler UCMusteriler = new Musteriler();
            UCMusteriler.Dock = DockStyle.Fill;
            tabPage5.Controls.Add(UCMusteriler);

        }
        /*
        private void AlinacaklarListesi()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "WHERE received.status = 0 AND received.active = 1 " +
                    "AND CONVERT(DATE,received.purchase_date) BETWEEN @p1 AND @p2 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p1", ilkgun),
                    new SqlParameter("@p2", ikincigun)
                    ).ToList();
            AlinacaklarGrid.DataSource = data;
        }

        private void TeslimEdileceklerListesi()
        {
            string query =
                    @"SELECT o.id, o.ranking, o.calculatedUsed, c.id as customerid , c.phone as cphone, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name areas, r.note,o.discount, o.total, o.amount, 
	                             o.ref_date, r.purchase_date, r.mod_date , r.received_date, o.mod_date, r.ref_customer, r.id receivedid, v.id ref_vehicle, a.id ref_areas,
                                comp.id company_id, comp.name company_name, comp.color company_color, SUM(od.product_number) as product_number, SUM(od.m2) as m2
	                                FROM orders o
	                                  INNER JOIN orders_detail od ON o.id = od.ref_orders
	                                  INNER JOIN received r ON o.ref_received = r.id
	                                  INNER JOIN users u ON u.id = o.ref_user
	                                  INNER JOIN customers c ON c.id = r.ref_customer
	                                  INNER JOIN areas a ON a.id = c.ref_areas
	                                  INNER JOIN vehicle v ON v.id = r.ref_vehicle
                                      INNER JOIN company comp ON r.ref_company = comp.id 
	                              WHERE o.status = 1 AND o.active = 0 AND CONVERT(DATE, r.mod_date) BETWEEN @p1 AND @p2 
                                     GROUP BY o.id, o.ranking, o.calculatedUsed, c.name, u.fullname,c.countryCode, c.gsm, c.adress, a.name, r.note,o.discount, o.total,
								      o.amount, 
	                                  o.ref_date, r.mod_date , r.purchase_date, r.received_date, o.mod_date, r.ref_customer, r.id, v.id, a.id ,
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
                _model.musteriadi = reader["name"].ToString();
                _model.sira = Convert.ToInt32(reader["ranking"]);
                _model.adress = reader["adress"].ToString();
                _model.telefon = reader["cphone"].ToString();
                _model.gsm = reader["gsm"].ToString();
                _model.firmaadi = reader["name"].ToString();
                _model.servisadi = reader["name"].ToString();
                _model.teslimedecek = reader["fullname"].ToString();
                _model.amount = Convert.ToDecimal(reader["amount"].ToString());
                _model.product_number = Convert.ToInt32(reader["product_number"]);
                _model.m2 = Convert.ToInt32(reader["m2"].ToString());
                _model.ref_date = Convert.ToDateTime(reader["ref_date"]);

                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();

            TeslimEdileceklerGrid.DataSource = list;
        }

        private void MusteriListesi()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers " +
                    "WHERE customers.active = 1 ").ToList();
            MusterilerGrid.DataSource = data;
        }
        */
        
        private void AnaSayfa_Resize(object sender, EventArgs e)
        {
            width = this.Size.Width;
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
            public int product_number { get; set; }
            public decimal m2 { get; set; }
            public DateTime ref_date { get; set; }
        }
    }
}
