using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Deha.Forms;
using Deha.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Deha.UserControls
{
    public partial class Musteriler : DevExpress.XtraEditors.XtraUserControl
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {

            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Pasif Müşteriler", 0));
            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Aktif Müşteriler", 1));
            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Müşteriler", 2));
            StatuCombo.SelectedIndex = 1;

            BorcCombo.Properties.Items.Add(new ImageComboBoxItem("Borçlu Müşteriler", 0));
            BorcCombo.Properties.Items.Add(new ImageComboBoxItem("Alacaklı Müşteriler", 1));
            BorcCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Müşteriler", 2));
            BorcCombo.SelectedIndex = 2;

            LoadData();

            MusterilerView.BestFitColumns();
        }

        private int RowGetir()
        {
            var rowHandle = MusterilerView.FocusedRowHandle;
            int val = Convert.ToInt32(MusterilerView.GetRowCellValue(rowHandle, "id"));
            return val;
        }

        public void LoadData()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string _statu = Convert.ToString(StatuCombo.SelectedIndex);

            if ((StatuCombo.SelectedIndex == 1 || StatuCombo.SelectedIndex == 0) && BorcCombo.SelectedIndex == 0)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers " +
                    "WHERE customers.active = @p0 AND customers.balance < 0", new SqlParameter("@p0", _statu)).ToList();
                MusterilerGrid.DataSource = data;
            }

            if ((StatuCombo.SelectedIndex == 1 || StatuCombo.SelectedIndex == 0) && BorcCombo.SelectedIndex == 1)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers " +
                    "WHERE customers.active = @p0 AND customers.balance > 0", new SqlParameter("@p0", _statu)).ToList();
                MusterilerGrid.DataSource = data;
            }

            if ((StatuCombo.SelectedIndex == 1 || StatuCombo.SelectedIndex == 0) && BorcCombo.SelectedIndex == 2)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers " +
                    "WHERE customers.active = @p0", new SqlParameter("@p0", _statu)).ToList();
                MusterilerGrid.DataSource = data;
            }

            if (StatuCombo.SelectedIndex == 2 && BorcCombo.SelectedIndex == 0)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers WHERE customers.balance < 0 ").ToList();
                MusterilerGrid.DataSource = data;
            }

            if (StatuCombo.SelectedIndex == 2 && BorcCombo.SelectedIndex == 1)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers WHERE customers.balance > 0").ToList();
                MusterilerGrid.DataSource = data;
            }

            if (StatuCombo.SelectedIndex == 2 && BorcCombo.SelectedIndex == 2)
            {
                var data = db.customers.SqlQuery(
                    "SELECT customers.* " +
                    "FROM customers ").ToList();
                MusterilerGrid.DataSource = data;
            }

        }
        private void StatuCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            MusteriKart frm = new MusteriKart(formMode.insert, null);
            frm.ShowDialog();
            LoadData();
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            if(Program._loginuser.auth_customer_change == true || Program._loginuser.admin == true)
            {
                if (RowGetir() > 0)
                {
                    MusteriKart frm = new MusteriKart(formMode.edit, RowGetir());
                    frm.ShowDialog();
                    LoadData();
                }
                
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        customer item = new customer();
                        item = db.customers.FirstOrDefault(q => q.id == _id);
                        if (item != null)
                        {
                            item.active = false;
                            db.SaveChanges();
                            XtraMessageBox.Show(_id + " numaralı kayıt iptal edildi.", "Kayıt İptal Edildi", MessageBoxButtons.OK);
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

        private void btnYazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                MusterilerGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\MÜŞTERİLER LİSTESİ.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

        
        private void MusterilerGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MusteriRightClick.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void alınacakEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var rowHandle = MusterilerView.FocusedRowHandle;
            int val = Convert.ToInt32(MusterilerView.GetRowCellValue(rowHandle, "id"));
            if (val > 0)
            {
                AlinacakKart frm = new AlinacakKart(formMode.insert, null, val);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }
        private void müşteriyiGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var rowHandle = MusterilerView.FocusedRowHandle;
            int val = Convert.ToInt32(MusterilerView.GetRowCellValue(rowHandle, "id"));
            if (val > 0)
            {
                MusteriKart frm = new MusteriKart(formMode.edit, val);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void geçmişSiparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowHandle = MusterilerView.FocusedRowHandle;
            int val = Convert.ToInt32(MusterilerView.GetRowCellValue(rowHandle, "id"));
            if (val > 0)
            {
                GecmisSiparisler frm = new GecmisSiparisler(val);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void BorcCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnBorcEkle_Click(object sender, EventArgs e)
        {
            AlacakEkle frm = new AlacakEkle(formMode.insert, RowGetir());
            frm.ShowDialog();
            LoadData();
        }

        private void btnTahsilatYap_Click(object sender, EventArgs e)
        {
            TahsilatYap frm = new TahsilatYap(formMode.insert, RowGetir());
            frm.ShowDialog();
            LoadData();
        }

    }
}
