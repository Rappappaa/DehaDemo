using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;
using System.Data.SqlClient;

namespace Deha.Forms
{
    public partial class Fisler : DevExpress.XtraEditors.XtraForm
    {
        public int musteriid;
        public Fisler()
        {
            InitializeComponent();
            gridView1.BestFitColumns();
        }

        private void FislerGrid_DoubleClick(object sender, EventArgs e)
        {
            musteriid = RowGetir();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Fisler_Load(object sender, EventArgs e)
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string query =
                    @"SELECT received.id as fisno, customers.id as kayitno, customers.name as musteriadi, customers.balance as bakiye
                    FROM received
                    JOIN customers ON customers.id = received.ref_customer";

            string connectionString = Program.connectionstring;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            List<FislerModel> list = new List<FislerModel>();

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FislerModel _model = new FislerModel();
                _model.fisno = Convert.ToInt32(reader["fisno"]);
                _model.kayitno = Convert.ToInt32(reader["kayitno"]);
                _model.bakiye = Convert.ToDecimal(reader["bakiye"]);
                _model.musteriadi = reader["musteriadi"].ToString();
                list.Add(_model);
            }

            reader.Dispose();
            reader.Close();
            FislerGrid.DataSource = list;
            gridView1.BestFitColumns();
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "kayitno"));
            return val;
        }
        internal class FislerModel
        {
            public int fisno { get; set; }
            public int kayitno { get; set; }
            public decimal bakiye { get; set; }
            public string musteriadi { get; set; }

        }
    }
}