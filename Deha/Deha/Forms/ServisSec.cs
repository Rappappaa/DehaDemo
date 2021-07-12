using Deha.Properties;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deha.Forms
{
    public partial class ServisSec : DevExpress.XtraEditors.XtraForm
    {
        public int servisid;

        public ServisSec()
        {
            InitializeComponent();
        }

        private void ServisSec_Load(object sender, EventArgs e)
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            var data = db.vehicles.SqlQuery("SELECT * FROM vehicle").ToList();
            AraclarGrid.DataSource = data;
        }
        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            return val;
        }

        private void AraclarGrid_DoubleClick(object sender, EventArgs e)
        {
            servisid = RowGetir();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}