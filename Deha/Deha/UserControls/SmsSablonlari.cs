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
    public partial class SmsSablonlari : DevExpress.XtraEditors.XtraUserControl
    {
        public SmsSablonlari()
        {
            InitializeComponent();
        }

        private void SmsSablonlari_Load(object sender, EventArgs e)
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
                var data = db.sms_template.SqlQuery(
                    "SELECT sms_template.* " +
                    "FROM sms_template " +
                    "WHERE sms_template.active = @p0 ", new SqlParameter("@p0", _statu)).ToList();
                SmsSablonlariGrid.DataSource = data;
            }
            if (StatuCombo.SelectedIndex == 2)
            {
                var data = db.sms_template.SqlQuery(
                    "SELECT * FROM sms_template ").ToList();
                SmsSablonlariGrid.DataSource = data;
            }

        }

        private void StatuCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SmsSablonKart frm = new SmsSablonKart(formMode.insert, null);
            frm.ShowDialog();
            LoadData();
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            SmsSablonKart frm = new SmsSablonKart(formMode.edit, RowGetir());
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
                        sms_template item = new sms_template();
                        item = db.sms_template.FirstOrDefault(q => q.id == _id);
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
                SmsSablonlariGrid.ExportToXls("C:\\Users\\" + Program.MachineName + "\\Desktop\\SMS ÜYELİKLERİ LİSTESİ.xls");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "İşlem Başarısız", MessageBoxButtons.OK);
            }
        }

    }
}
