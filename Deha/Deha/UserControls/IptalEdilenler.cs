using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using Deha.Forms;

namespace Deha.UserControls
{
    public partial class IptalEdilenler : DevExpress.XtraEditors.XtraUserControl
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

        public IptalEdilenler()
        {
            InitializeComponent();
        }

        private void IptalEdilenler_Load(object sender, EventArgs e)
        {
            LoadData();

            gridView1.BestFitColumns();
        }

        private int RowGetir()
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));
            return val;
        }

        public void LoadData()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                var query = @"SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* 
                    FROM received 
                    INNER JOIN customers ON customers.id = received.ref_customer 
                    INNER JOIN vehicle ON vehicle.id = received.ref_vehicle 
                    INNER JOIN company ON company.id = received.ref_company 
                    INNER JOIN users ON users.id = received.ref_user 
                    LEFT JOIN areas ON areas.id = customers.ref_areas 
                    WHERE received.status = 0 AND received.active = 0 
                    ORDER BY received.ranking";

                var data = db.receiveds.SqlQuery(query).ToList();
                AlinacaklarGrid.DataSource = data;
        }

        private void btnTarihFiltre_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                int _id = RowGetir();
                if (XtraMessageBox.Show(_id.ToString() + " numaralı kaydı aktifleştirmek istiyor musunuz?", "Aktifleştirme Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        received item = new received();
                        item = db.receiveds.FirstOrDefault(q => q.id == _id);
                        if (item != null)
                        {
                            item.active = true;
                            item.mod_date = DateTime.Now;
                            db.SaveChanges();
                            XtraMessageBox.Show(_id + " numaralı kayıt aktifleştirildi.", "Kayıt Aktif Edildi", MessageBoxButtons.OK);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                AlinacakKart frm = new AlinacakKart(formMode.edit, RowGetir(), null);
                frm.ShowDialog();
                LoadData();
            }
        }


        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                AlinacaklarGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\İPTAL EDİLENLER.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        private void AlinacaklarGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void müşteriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "customer.id"));
            if (val > 0)
            {
                MusteriKart frm = new MusteriKart(formMode.edit, val);
                frm.ShowDialog();
            }
        }
    }
}
