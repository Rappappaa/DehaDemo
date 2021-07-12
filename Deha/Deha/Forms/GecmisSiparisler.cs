using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;
using System.Data.SqlClient;

namespace Deha.Forms
{
    public partial class GecmisSiparisler : DevExpress.XtraEditors.XtraForm
    {
        private int? _id;
        private customer _customer;

        public GecmisSiparisler(int? id)
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            InitializeComponent();
            _id = id;
            _customer = db.customers.FirstOrDefault(q => q.id == _id);
            if(_customer == null)
            {
                XtraMessageBox.Show(_id + " numaralı kayıt bulunamadı.", "Kayıt Bulunamadı.", MessageBoxButtons.OK);
                this.Close();
            }

            txtAdSoyad.Text = _customer.name;
            txtGsm.Text = _customer.gsm;
            txtTelefon.Text = _customer.phone;
            txtAdres.Text = _customer.adress;
            var _area = db.areas.FirstOrDefault(q => q.id == _customer.ref_areas);
            txtBolge.Text = _area.name;

            string query =
                    @"SELECT TOP 250 c.id c_id, r.ref_date as alinacaklaraeklenmetarihi,
                                    r.mod_date yikanmayaeklenmetarihi,o.mod_date urunteslimtarihi,
                         v.name vehiclename, u.fullname usersname,SUM(o.total) total, SUM(o.amount) amount, o.id, i.payment_type,o.discount,  comp.name as company_name
	                        FROM received r
                        INNER JOIN vehicle v ON v.id = r.ref_vehicle
                        INNER JOIN users u ON u.id = r.ref_user
                        INNER JOIN orders o ON o.ref_received = r.id
                        INNER JOIN customers c ON c.id = r.ref_customer
                        INNER JOIN company comp ON comp.id = r.ref_company
			            INNER JOIN invoice i ON i.ref_orders = o.id
                            WHERE r.ref_customer = @p0 AND r.status = 1 AND r.active = 1 AND o.active = 0  GROUP BY c.id, c.name, comp.name,
                                  r.ref_date,v.name,u.fullname,o.id,r.mod_date,o.mod_date,i.payment_type,o.discount
                         ORDER BY r.ref_date DESc ";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<customCustomerHistoryModel> list = new List<customCustomerHistoryModel>();

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@p0", _customer.id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customCustomerHistoryModel _model = new customCustomerHistoryModel();
                _model.id = Convert.ToInt32(reader["id"]);
                _model.ref_customer = Convert.ToInt32(reader["c_id"]);
                _model.alinacaklaraeklenmetarihi = Convert.ToDateTime(reader["alinacaklaraeklenmetarihi"]);
                _model.yikanmayaeklenmetarihi = Convert.ToDateTime(reader["yikanmayaeklenmetarihi"]);
                _model.urunteslimtarihi = Convert.ToDateTime(reader["urunteslimtarihi"]);
                _model.vehiclename = reader["vehiclename"].ToString();
                _model.usersname = reader["usersname"].ToString();
                _model.total = Convert.ToDecimal(reader["total"]);
                _model.amount = Convert.ToDecimal(reader["amount"]);
                if(Convert.ToInt32(reader["payment_type"]) == 0) _model.odeme_turu = "Nakit";
                if(Convert.ToInt32(reader["payment_type"]) == 1) _model.odeme_turu = "Kredi Kartı";
                if(Convert.ToInt32(reader["payment_type"]) == 2) _model.odeme_turu = "Diğer";
                _model.discount = Convert.ToInt32(reader["discount"]);
                _model.company_name = Convert.ToString(reader["company_name"]);
                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();
            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
            this.Text = _customer.name + " - Sipariş Geçmişi";

        }
        internal class customCustomerHistoryModel
        {
            public int id { get; set; }
            public int ref_customer { get; set; }
            public DateTime alinacaklaraeklenmetarihi { get; set; }
            public DateTime yikanmayaeklenmetarihi { get; set; }
            public DateTime urunteslimtarihi { get; set; }
            public string vehiclename { get; set; }
            public string usersname { get; set; }
            public decimal total { get; set; }
            public decimal amount { get; set; }
            public string odeme_turu { get; set; }
            public decimal discount { get; set; }
            public string company_name { get; set; }

        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void siparişGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            var siparisid = db.orders.FirstOrDefault(q => q.id == val);
            if (val > 0)
            {
                YikanacakKart frm = new YikanacakKart(formMode.edit,siparisid.ref_received);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }
    }
}