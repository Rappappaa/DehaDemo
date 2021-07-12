using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class AdetveM2 : DevExpress.XtraEditors.XtraForm
    {
        public int adet;
        public int m2;

        public AdetveM2()
        {
            InitializeComponent();
        }

        private void AdetveM2_Load(object sender, EventArgs e)
        {
            ActiveControl = txtAdet;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                m2 = Convert.ToInt32(txtM2.Text);
                adet = Convert.ToInt32(txtAdet.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private bool CheckField()
        {
            if (String.IsNullOrWhiteSpace(txtAdet.Text))
            {
                XtraMessageBox.Show("Lütfen ADET bilgisi giriniz.","Eksik veri girişi",MessageBoxButtons.OK);
                ActiveControl = txtAdet;
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtM2.Text))
            {
                XtraMessageBox.Show("Lütfen M² bilgisi giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtM2;
                return false;
            }
            return true;
        }

        private void txtEn_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEn.Text) && !String.IsNullOrEmpty(txtBoy.Text))
            {
                m2 = Convert.ToInt32(txtEn.Text) * Convert.ToInt32(txtBoy.Text);
                txtM2.Text = m2.ToString();
            }
        }

        private void txtBoy_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEn.Text) && !String.IsNullOrEmpty(txtBoy.Text))
            {
                m2 = Convert.ToInt32(txtEn.Text) * Convert.ToInt32(txtBoy.Text);
                txtM2.Text = m2.ToString();
            }
        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtBoy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

    }
}