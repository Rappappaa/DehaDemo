using Deha.Forms;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deha
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        private string _tur;
        public frmPrint(string tur)
        {
            InitializeComponent();
            _tur = tur;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {

        }

        public void PrintForm(int id)
        {
            if(_tur == "teslimedilecek")
            {
                PrintTeslimEdilecekler frm = new PrintTeslimEdilecekler();
                foreach (DevExpress.XtraReports.Parameters.Parameter p in frm.Parameters) p.Visible = false;
                frm.InitData(id);
                documentViewer1.DocumentSource = frm;
                frm.CreateDocument();
            }
            if(_tur == "alinacak")
            {
                PrintTeslimAlinacaklar frm = new PrintTeslimAlinacaklar();
                foreach (DevExpress.XtraReports.Parameters.Parameter p in frm.Parameters) p.Visible = false;
                frm.InitData(id);
                documentViewer1.DocumentSource = frm;
                frm.CreateDocument();
            }
        }
    }
}