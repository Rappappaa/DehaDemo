using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;

namespace Deha.Forms
{
    public partial class PrintTeslimEdilecekler : DevExpress.XtraReports.UI.XtraReport
    {
        private int _id;
        private int _adet;
        private decimal _m2;
        private decimal _tutar;

        public PrintTeslimEdilecekler()
        {
            InitializeComponent();
        }

        public void InitData(int id)
        {
            _id = id;

            string ilkgun = DateTime.Now.ToString("yyyy/MM/dd");
            string ikincigun = DateTime.Now.ToString("yyyy/MM/dd");

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
	                              WHERE o.status = 1 AND v.id = @p3 AND o.active = 1 AND CONVERT(DATE, r.received_date) BETWEEN @p1 AND @p2 
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
            cmd.Parameters.AddWithValue("@p3", _id);

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
            objectDataSource1.DataSource = list;

            if(list.Count < 1)
            {
                XtraMessageBox.Show("Seçili servise ait kayıt bulunamamıştır.", "Teslim Listesi Yazdırma");
                this.ClosePreview();
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
}
