using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Deha.Forms;
using Deha.Properties;

namespace Deha
{
    public partial class AlinacaklarListesi : UserControl
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

        public AlinacaklarListesi()
        {
            InitializeComponent();
        }

        private void AlinacaklarListesi_Load(object sender, EventArgs e)
        {
            FirstDate.DateTime = DateTime.Now;
            LastDate.DateTime = DateTime.Now;


            AraclarCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Araçlar", 0));
            foreach(var i in db.vehicles.Where(q => q.active == true).ToList())
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

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            // Tüm Araçlar ve Bölgeler
            if(AraclarCombo.SelectedIndex == 0 && BolgelerCombo.SelectedIndex == 0)
            {
                var query = @"SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* 
                    FROM received 
                    INNER JOIN customers ON customers.id = received.ref_customer 
                    INNER JOIN vehicle ON vehicle.id = received.ref_vehicle 
                    INNER JOIN company ON company.id = received.ref_company 
                    INNER JOIN users ON users.id = received.ref_user 
                    LEFT JOIN areas ON areas.id = customers.ref_areas 
                    WHERE received.status = 0 AND received.active = 1 AND 
                    CONVERT(DATE,received.purchase_date) BETWEEN @p98 AND @p99 
                    ORDER BY received.ranking";

                var data = db.receiveds.SqlQuery(query,
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge),
                    new SqlParameter("@p98", ilkgun),
                    new SqlParameter("@p99", ikincigun)
                    ).ToList();
                AlinacaklarGrid.DataSource = data;
            }

            // Tüm Araçlar Belirli Bölgeler
            if (AraclarCombo.SelectedIndex == 0 && BolgelerCombo.SelectedIndex != 0)
            {
                var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "WHERE received.status = 0 AND received.active = 1 " +
                    "AND areas.id = @p1 AND " +
                    "CONVERT(DATE,received.purchase_date) BETWEEN @p98 AND @p99 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge),
                    new SqlParameter("@p98", ilkgun),
                    new SqlParameter("@p99", ikincigun)
                    ).ToList();
                AlinacaklarGrid.DataSource = data;
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
                    "WHERE received.status = 0 AND received.active = 1 " +
                    "AND vehicle.id = @p0 AND " +
                    "CONVERT(DATE,received.purchase_date) BETWEEN @p98 AND @p99 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge),
                    new SqlParameter("@p98", ilkgun),
                    new SqlParameter("@p99", ikincigun)
                    ).ToList();
                AlinacaklarGrid.DataSource = data;
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
                    "WHERE received.status = 0 AND received.active = 1 " +
                    "AND vehicle.id = @p0 " +
                    "AND areas.id = @p1 AND " +
                    "CONVERT(DATE,received.purchase_date) BETWEEN @p98 AND @p99 " +
                    "ORDER BY received.ranking ",
                    new SqlParameter("@p0", _arac),
                    new SqlParameter("@p1", _bolge),
                    new SqlParameter("@p98", ilkgun),
                    new SqlParameter("@p99", ikincigun)
                    ).ToList();
                AlinacaklarGrid.DataSource = data;
            }

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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(Program._loginuser.auth_order == true || Program._loginuser.admin == true)
            {
                AlinacakKart frm = new AlinacakKart(formMode.insert, null, null);
                frm.ShowDialog();
                LoadData();
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                YikanacakKart frm = new YikanacakKart(formMode.insert, RowGetir());
                frm.ShowDialog();
                LoadData();
            }
            else
            {
                XtraMessageBox.Show("Lütfen bir kayıt seçiniz.", "Hatalı İşlem", MessageBoxButtons.OK);
            }
            
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                int _id = RowGetir();
                if (XtraMessageBox.Show(_id.ToString() + " numaralı kaydı iptal etmek istiyor musunuz?", "İptal Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        received item = new received();
                        item = db.receiveds.FirstOrDefault(q => q.id == _id);
                        if (item != null)
                        {
                            item.active = false;
                            item.mod_date = DateTime.Now;
                            db.SaveChanges();
                            XtraMessageBox.Show(_id + " numaralı kayıt iptal edildi.", "Kayıt İptal Edildi", MessageBoxButtons.OK);
                            LoadData();
                        }
                    }catch(Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (RowGetir()> 0)
            {
                AlinacakKart frm = new AlinacakKart(formMode.edit, RowGetir(), null);
                frm.ShowDialog();
                LoadData();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ServisSec frm = new ServisSec();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                using (frmPrint frm2 = new frmPrint("alinacak"))
                {
                    frm2.PrintForm(frm.servisid);
                    frm2.ShowDialog();
                }
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

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            AraclarCombo.SelectedIndex = 0;
            BolgelerCombo.SelectedIndex = 0;

            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string _arac = Convert.ToString(AraclarCombo.SelectedIndex);
            string _bolge = Convert.ToString(BolgelerCombo.SelectedIndex);

            string ilkgun = FirstDate.DateTime.ToString("yyyy/MM/dd");
            string ikincigun = LastDate.DateTime.ToString("yyyy/MM/dd");

            var data = db.receiveds.SqlQuery(
                    "SELECT received.* , customers.* , vehicle.* , company.* , users.*, areas.* " +
                    "FROM received " +
                    "JOIN customers ON customers.id = received.ref_customer " +
                    "JOIN vehicle ON vehicle.id = received.ref_vehicle " +
                    "JOIN company ON company.id = received.ref_company " +
                    "JOIN users ON users.id = received.ref_user " +
                    "JOIN areas ON areas.id = customers.ref_areas " +
                    "WHERE received.status = 0 AND received.active = 1 " +
                    "ORDER BY received.ranking"
                    ).ToList();
            AlinacaklarGrid.DataSource = data;
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
            if(val > 0)
            {
                MusteriKart frm = new MusteriKart(formMode.edit, val);
                frm.ShowDialog();
            }
        }


    }
}
