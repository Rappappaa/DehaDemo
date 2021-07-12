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
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using Deha.Forms;
using Deha.Properties;

namespace Deha.UserControls
{
    public partial class Kullanicilar : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _f = true;
        public Kullanicilar()
        {
            InitializeComponent();
        }

        private void Kullanicilar_Load(object sender, EventArgs e)
        {

            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Pasif Kayıtlar", 0));
            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Aktif Kayıtlar", 1));
            StatuCombo.Properties.Items.Add(new ImageComboBoxItem("Tüm Kayıtlar", 2));
            StatuCombo.SelectedIndex = 1;

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

            string _statu = Convert.ToString(StatuCombo.SelectedIndex);

            if (StatuCombo.SelectedIndex == 1 || StatuCombo.SelectedIndex == 0)
            {
                if (StatuCombo.SelectedIndex == 0)
                {
                    _f = false;
                }
                if (StatuCombo.SelectedIndex == 1)
                {
                    _f = true;
                }

                var data = db.users.Where(q => q.active == _f).ToList();
                KullanicilarGrid.DataSource = data;
            }
            if (StatuCombo.SelectedIndex == 2)
            {
                var data = db.users.Where(q => q.id > 0).ToList();
                KullanicilarGrid.DataSource = data;
            }

        }

        private void StatuCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KullaniciKart frm = new KullaniciKart(formMode.insert, null);
            frm.ShowDialog();
            LoadData();
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            KullaniciKart frm = new KullaniciKart(formMode.edit, RowGetir());
            frm.ShowDialog();
            LoadData();
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
                        user item = new user();
                        item = db.users.FirstOrDefault(q => q.id == _id);
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

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                KullanicilarGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\KULLANICILAR LİSTESİ.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

    }
}
