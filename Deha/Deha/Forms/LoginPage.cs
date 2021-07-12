using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Deha.Properties;

namespace Deha.Forms
{
    public partial class LoginPage : DevExpress.XtraEditors.XtraForm
    {
        private haliposmain _haliposman;

        public LoginPage()
        {
            InitializeComponent();
            ActiveControl = txtUserName;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            ActiveControl = txtUserName;
            
            if(!String.IsNullOrWhiteSpace(Settings.Default["_businessname"].ToString()))
            {
                txtIsletmeAdi.Text = Settings.Default["_businessname"].ToString();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            MainModel db = new MainModel();
            _haliposman = db.haliposmains.Where(q => q.active == true).Where(q => q.businesscode == txtIsletmeAdi.Text).FirstOrDefault();
            if(_haliposman == null)
            {
                XtraMessageBox.Show("Sistemde kayıtlı firma bulunamadı.","Hatalı Giriş");
                return;
            }
            else
            {
                string ConnectionString = string.Format("data source=89.252.184.167\\MSSQLSERVER2017;initial catalog={0};persist security info=True;user id=sa;password=dehapos@1.;multipleactiveresultsets=True;application name=EntityFramework", _haliposman.dbname);
                try
                {
                        Settings.Default["_businessname"] = txtIsletmeAdi.Text;
                        Settings.Default.Save();

                        DehaPosModel _db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());
                        Program._loginuser = _db.users.Where(q => q.username == txtUserName.Text).Where(q => q.password == txtPassword.Text).FirstOrDefault();
                        if (Program._loginuser != null)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            XtraMessageBox.Show("Kullanıcı adı veya Şifreniz hatalı.", "Hatalı Giriş");
                        }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "Veritabanı sunucusuna bağlanılamadı");
                    Application.Exit();
                }
            }
        }
    }
}