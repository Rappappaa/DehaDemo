using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Deha.Forms;
using DevExpress.XtraEditors.Controls;
using Deha.Properties;
using System.Collections.Generic;
using DevExpress.Utils.Extensions;

namespace Deha.UserControls
{
    public partial class YikanacaklarListesi : DevExpress.XtraEditors.XtraUserControl
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        private received _received;
        private int _aracid;

        public YikanacaklarListesi()
        {
            InitializeComponent();
        }

        private void YikanacaklarListesi_Load(object sender, EventArgs e)
        {

            AraclarCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Araçlar", 0));
            foreach (var i in db.vehicles.Where(q => q.active == true).ToList())
            {
                AraclarCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }
            AraclarCombo.SelectedIndex = 0;

            BolgelerCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Bölgeler", 0));
            foreach (var i in db.areas.Where(q => q.active == true).ToList())
            {
                BolgelerCombo.Properties.Items.Add(new ImageComboBoxItem(i.name, i.id));
            }
            BolgelerCombo.SelectedIndex = 0;

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

            string _arac = Convert.ToString(AraclarCombo.SelectedIndex);
            string _bolge = Convert.ToString(BolgelerCombo.SelectedIndex);


            // Tüm Araçlar ve Bölgeler
            if (AraclarCombo.SelectedIndex == 0 && BolgelerCombo.SelectedIndex == 0)
            {
                var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "JOIN orders ON orders.ref_received = received.id " +
                    "WHERE received.status = 1 AND orders.status = 0 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge)
                    ).ToList();
                YikanacaklarGrid.DataSource = data;
            }

            // Tüm Araçlar Belirli Bölgeler
            if (AraclarCombo.SelectedIndex == 0 && BolgelerCombo.SelectedIndex != 0)
            {
                if(BolgelerCombo.SelectedIndex == -1)
                {
                    var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "JOIN orders ON orders.ref_received = received.id " +
                    "WHERE received.status = 1 AND orders.status = 0 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge)
                    ).ToList();
                    YikanacaklarGrid.DataSource = data;
                }
                else
                {
                    var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "JOIN orders ON orders.ref_received = received.id " +
                    "WHERE received.status = 1 AND orders.status = 0 " +
                    "AND areas.id = @p1 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge)
                    ).ToList();
                    YikanacaklarGrid.DataSource = data;
                }
                
            }

            // Belirli Araçlar Tüm Bölgeler
            if (AraclarCombo.SelectedIndex != 0 && BolgelerCombo.SelectedIndex == 0)
            {
                var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "JOIN orders ON orders.ref_received = received.id " +
                    "WHERE received.status = 1 AND orders.status = 0" +
                    "AND vehicle.id = @p0 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge)
                    ).ToList();
                YikanacaklarGrid.DataSource = data;
            }

            // Belirli Araçlar Belirli Bölgeler
            if (AraclarCombo.SelectedIndex != 0 && BolgelerCombo.SelectedIndex != 0)
            {
                var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "JOIN orders ON orders.ref_received = received.id " +
                    "WHERE received.status = 1 AND orders.status = 0 " +
                    "AND vehicle.id = @p0 " +
                    "AND areas.id = @p1 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge)
                    ).ToList();
                YikanacaklarGrid.DataSource = data;
            }

        }

        private void btnTeslimeGonder_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                if (XtraMessageBox.Show("Kaydı teslim edilecekler listesine eklemek istiyor musunuz?", "Teslime Gönderme Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        List<int> rows = gridView1.GetSelectedRows().ToList();

                        AracSecme frm = new AracSecme();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _aracid = frm.id;

                            order item = new order();

                            foreach (var i in rows)
                            {
                                var rowHandle = i;
                                int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));

                                _received = db.receiveds.FirstOrDefault(q => q.id == val);
                                _received.ref_vehicle = _aracid;
                                db.SaveChanges();
                                

                                item = db.orders.FirstOrDefault(q => q.ref_received == val);

                                if (item != null)
                                {
                                    item.status = true;
                                    item.active = true;
                                    item.mod_date = DateTime.Now;
                                    db.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            order item = new order();

                            foreach (var i in rows)
                            {
                                var rowHandle = i;
                                int val = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));

                                item = db.orders.FirstOrDefault(q => q.ref_received == val);

                                if (item != null)
                                {
                                    item.status = true;
                                    item.active = true;
                                    item.mod_date = DateTime.Now;
                                    db.SaveChanges();
                         
                                }
                            }
                        }
                        XtraMessageBox.Show("Kayıtlar teslim edilecekler listesine eklendi.", "Kayıt Teslimata Gönderildi", MessageBoxButtons.OK);
                        LoadData();

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }

                }

            }
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                YikanacakKart frm = new YikanacakKart(formMode.edit, RowGetir());
                frm.Show();
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
                YikanacaklarGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\YIKANACAKLAR LİSTESİ.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        private void AraclarCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BolgelerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void YikanacaklarGrid_MouseDown(object sender, MouseEventArgs e)
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
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }
    }
}
