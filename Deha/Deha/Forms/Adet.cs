using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Deha.Forms
{
    public partial class Adet : DevExpress.XtraEditors.XtraForm
    {
        public int adet;

        public Adet()
        {
            InitializeComponent();
        }

        private void Adet_Load(object sender, EventArgs e)
        {
            ActiveControl = txtAdet;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAdet.Text))
            {
                XtraMessageBox.Show("Lütfen ADET bilgisi giriniz.", "Eksik veri girişi", MessageBoxButtons.OK);
                ActiveControl = txtAdet;
            }
            else
            {
                adet = Convert.ToInt32(txtAdet.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}