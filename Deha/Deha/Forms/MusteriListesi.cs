using Deha.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Deha.Forms
{
    public partial class MusteriListesi : DevExpress.XtraEditors.XtraForm
    {
        public int musteriid;

        public MusteriListesi()
        {
            InitializeComponent();
            gridView1.BestFitColumns();
        }

        private void MusteriListesi_Load(object sender, EventArgs e)
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            var data = db.customers.SqlQuery(
                    "SELECT * FROM customers WHERE active = 1").ToList();
            MusterilerGrid.DataSource = data;
        }

        private void MusterilerGrid_DoubleClick(object sender, EventArgs e)
        {
            musteriid = RowGetir();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            return val;
        }
    }
}