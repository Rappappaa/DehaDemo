using System;
using System.Windows.Forms;

namespace Deha.Forms
{
    public partial class GenelRaporDisaAktar : DevExpress.XtraEditors.XtraForm
    {
        public bool _gelirtoplam = false;
        public bool _gelirnakit = false;
        public bool _gelirkredikarti = false;
        public bool _gelirdiger = false;
        public bool _gider = false;
        public bool _tamamlanmissiparisler = false;
        public bool _alinansiparisler = false;

        public GenelRaporDisaAktar()
        {
            InitializeComponent();
        }

        private void GenelRaporDisaAktar_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
             _gelirtoplam = gelirtoplam.Checked == true ? true : false ;
            _gelirnakit = gelirnakit.Checked == true ? true : false;
            _gelirkredikarti = gelirkredikarti.Checked == true ? true : false;
            _gelirdiger = gelirdiger.Checked == true ? true : false;
            _gider = gider.Checked == true ? true : false;
            _tamamlanmissiparisler = tamamlanmissiparisler.Checked == true ? true : false;
            _alinansiparisler = alinansiparisler.Checked == true ? true : false;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}