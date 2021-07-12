using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using Deha.Forms;
using Deha.Properties;

namespace Deha.UserControls
{
    public partial class Firmalar : DevExpress.XtraEditors.XtraUserControl
    {
        public Firmalar()
        {
            InitializeComponent();
        }

        private void Firmalar_Load(object sender, EventArgs e)
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

        private void LoadData()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            string _statu = Convert.ToString(StatuCombo.SelectedIndex);

            if (StatuCombo.SelectedIndex == 1 || StatuCombo.SelectedIndex == 0)
            {
                var data = db.companies.SqlQuery(
                    "SELECT * FROM company " +
                    "WHERE company.active = @p0 ", new SqlParameter("@p0", _statu)).ToList();
                FirmalarGrid.DataSource = data;
            }
            if (StatuCombo.SelectedIndex == 2)
            {
                var data = db.companies.SqlQuery("SELECT * FROM company").ToList();
                FirmalarGrid.DataSource = data;
            }
        }

        private void StatuCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FirmaKart frm = new FirmaKart(formMode.insert, null);
            frm.ShowDialog();
            LoadData();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (RowGetir() > 0)
            {
                FirmaKart frm = new FirmaKart(formMode.edit, RowGetir());
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
                if (XtraMessageBox.Show(_id.ToString() + " numaralı kaydı silmek istiyor musunuz?", "İptal Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        company item = new company();
                        item = db.companies.FirstOrDefault(q => q.id == _id);
                        if (item != null)
                        {
                            item.active = false;
                            db.SaveChanges();
                            XtraMessageBox.Show(_id + " numaralı kayıt silindi.", "Kayıt Silindi", MessageBoxButtons.OK);
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
                FirmalarGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\FİRMALAR LİSTESİ.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

    }
}
