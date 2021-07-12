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
    public partial class UrunSatisRaporlari : DevExpress.XtraEditors.XtraUserControl
    {
        private decimal nakit = 0, kredi = 0, toplam = 0, diger = 0;
        public UrunSatisRaporlari()
        {
            InitializeComponent();
        }

        private void UrunSatisRaporlari_Load(object sender, EventArgs e)
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

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            string query =
                    @"SELECT orders_detail.name as urunadi, orders_detail.product_number as adet , orders.total as tutar, orders.amount as toplam , invoice.payment_type as odemeturu
						FROM orders
						JOIN orders_detail ON orders_detail.ref_orders = orders.id
						JOIN invoice ON invoice.ref_orders = orders.id
						WHERE orders.ref_received is null AND CONVERT(DATE,orders.ref_date) BETWEEN @p1 AND @p2";

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

                _teslimedilenmodel.urunadi = reader["urunadi"].ToString();
                _teslimedilenmodel.adet = Convert.ToInt32(reader["adet"]);
                _teslimedilenmodel.tutar = Convert.ToDecimal(reader["tutar"].ToString());
                _teslimedilenmodel.toplam = Convert.ToDecimal(reader["toplam"].ToString());
                _teslimedilenmodel.tip = Convert.ToInt32(reader["odemeturu"].ToString());

                teslimedilenlist.Add(_teslimedilenmodel);
            }

            reader.Dispose();
            reader.Close();



            List<deneme> _deneme = new List<deneme>();

            foreach (var i in db.products.Where(q => q.type == 2).ToList())
            {
                deneme _liste = new deneme();
                _liste.urunadi = i.name;

                foreach (var j in teslimedilenlist)
                {
                    if (i.name == j.urunadi)
                    {
                        _liste.adet += j.adet;
                        _liste.toplam += j.toplam;
                    }
                }

                _deneme.Add(_liste);

            }

            UrunSatisRaporlariGrid.DataSource = _deneme;

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
                if(i.tip == 2)
                {
                    diger += i.toplam;
                }

            }

            toplam = nakit + kredi + diger;
            lblnakit.Text = String.Format("{0:C}", nakit);
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
            try
            {
                UrunSatisRaporlariGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\" + FirstDate.DateTime.ToString("dd-MM-yyyy") + " - " + LastDate.DateTime.ToString("dd-MM-yyyy") + " ÜRÜN SATIŞ RAPORU.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
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
