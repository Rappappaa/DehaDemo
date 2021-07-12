using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Deha.Properties;

namespace Deha.Forms
{
    public partial class AracSecme : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
        public int id;

        public AracSecme()
        {
            InitializeComponent();
        }

        private void AracSecme_Load(object sender, EventArgs e)
        {
            // Sms Üyelikleri Combobox Doldur
            AracCombo.DataSource = db.vehicles.Where(q => q.active == true).ToList();
            AracCombo.DisplayMember = "name";
            AracCombo.ValueMember = "id";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(AracCombo.SelectedValue);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}