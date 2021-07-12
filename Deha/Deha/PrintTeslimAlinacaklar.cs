using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Deha.Forms
{
    public partial class PrintTeslimAlinacaklar : DevExpress.XtraReports.UI.XtraReport
    {
        private int _id;

        public PrintTeslimAlinacaklar()
        {
            InitializeComponent();
        }

        public void InitData(int id)
        {
            _id = id;

            string ilkgun = DateTime.Now.ToString("yyyy/MM/dd");
            string ikincigun = DateTime.Now.ToString("yyyy/MM/dd");


            string query =
                    @"SELECT received.id as fisno, received.ranking as sirano, received.received_date as ref_date, customers.name as cname, customers.adress as adres,
                        customers.phone as cphone, customers.gsm as cgsm,
                        customers.balance as balance, vehicle.name as servisadi , company.name as firmadi , users.fullname as teslimalacak, areas.name as bolgeadi
                        FROM received
                        JOIN customers ON customers.id = received.ref_customer
                        JOIN vehicle ON vehicle.id = received.ref_vehicle
                        JOIN company ON company.id = received.ref_company
                        JOIN users ON users.id = received.ref_user
                        JOIN areas ON areas.id = customers.ref_areas
                        WHERE received.status = 0 AND received.active = 1
                        AND vehicle.id = @p0 AND
                        CONVERT(DATE,received.purchase_date) BETWEEN @p1 AND @p2
                        ORDER BY received.ranking ";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p1", ilkgun);
            cmd.Parameters.AddWithValue("@p2", ikincigun);
            cmd.Parameters.AddWithValue("@p0", _id);

            SqlDataReader reader = cmd.ExecuteReader();
            List<AlinacakModeli> list = new List<AlinacakModeli>();

            while (reader.Read())
            {

                AlinacakModeli _model = new AlinacakModeli();

                _model.fisno = Convert.ToInt32(reader["fisno"].ToString());
                _model.musteriadi = reader["cname"].ToString();
                _model.bolge = reader["bolgeadi"].ToString();
                _model.sira = Convert.ToInt32(reader["sirano"]);
                _model.adress = reader["adres"].ToString();
                _model.telefon = reader["cphone"].ToString();
                _model.gsm = reader["cgsm"].ToString();
                _model.firmaadi = reader["firmadi"].ToString();
                _model.servisadi = reader["servisadi"].ToString();
                _model.teslimedecek = reader["teslimalacak"].ToString();
                _model.bakiye = Convert.ToDecimal(reader["balance"]);
                _model.ref_date = reader["ref_date"].ToString();

                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();

            objectDataSource1.DataSource = list;

            if(list.Count < 1)
            {
                XtraMessageBox.Show("Seçili servise ait kayıt bulunamamıştır.", "Teslim Listesi Yazdırma");
                this.ClosePreview();
            }
        }

        internal class AlinacakModeli
        {
            public int sira { get; set; }
            public int fisno { get; set; }
            public string musteriadi { get; set; }
            public string bolge { get; set; }
            public string adress { get; set; }
            public string telefon { get; set; }
            public string gsm { get; set; }
            public string firmaadi { get; set; }
            public string servisadi { get; set; }
            public string teslimedecek { get; set; }
            public decimal bakiye { get; set; }
            public string ref_date { get; set; }
        }

    }
}
