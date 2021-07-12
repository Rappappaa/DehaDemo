using Deha.Properties;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Deha.Forms
{
    public partial class UrunListesi : DevExpress.XtraEditors.XtraForm
    {
        public int productid;
        public decimal m2;
        public int quantity;
        private int? _id;

        public UrunListesi(int? id)
        {
            InitializeComponent();
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
            _id = id;
            UrunGrid.DataSource = db.products.Where(q => q.active == true).Where(q => q.type == _id).ToList();
            gridView1.BestFitColumns();

        }

        private void UrunGrid_DoubleClick(object sender, EventArgs e)
        {
            if(_id == 1)
            {
                productid = RowGetir();
                AdetveM2 frm = new AdetveM2();
                DialogResult result = DialogResult.OK;
                if (result == frm.ShowDialog())
                {
                    m2 = frm.m2;
                    quantity = frm.adet;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if(_id == 2)
            {
                productid = RowGetir();
                Adet frm = new Adet();
                DialogResult result = DialogResult.OK;
                if (result == frm.ShowDialog())
                {
                    quantity = frm.adet;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            return val;
        }
    }
}