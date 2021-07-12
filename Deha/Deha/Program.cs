using Deha.Forms;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Deha.Properties;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Deha
{
    static class Program
    {
        
        
        public static string MachineName = Environment.UserName;
        public static string connectionstring = Settings.Default["_connectionstring"].ToString();
        public static bool adetlimi = false;
        public static user _loginuser;


        public enum SmsTemplateType : byte
        {
            //sipariş oluşturunca
            NewReceived = 0,
            //gider
            NewOrders = 1,
            // borç
            Delivery = 2,
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string yol = @AppDomain.CurrentDomain.BaseDirectory + "donottouch.txt";
            if (!File.Exists(yol))
            {
                Settings.Default["_adetlimi"] = "false";
                Settings.Default["_firstlogin"] = "true";
                Settings.Default["_businessname"] = "bos";
                Settings.Default["_asked"] = "false";
                Settings.Default["halipos_testConnectionString"] = "";
                Settings.Default.Save();

                FileStream fs = new FileStream("donottouch.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("DehaPosYazilim");
                sw.Close();
                
                Application.Exit();
                Process.Start(Application.ExecutablePath);
            }
            

            Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default["_firstlogin"].ToString() == "true")
            {
                FirmaAdiSor frm = new FirmaAdiSor();
                frm.ShowDialog();
            }
            if (Settings.Default["_firstlogin"].ToString() == "false")
            {
                LoginPage frm = new LoginPage();
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.OK)
                {
                    if(Settings.Default["_asked"].ToString() == "false")
                    {
                        AdetSor();
                    }
                    Application.Run(new MainForm());
                }
            }
        }

        public static void AlinacakGuncelle()
        {
            DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

            foreach(var i in db.receiveds.Where(q => q.mod_date == null).Where(q => q.status == false).Where(q => q.purchase_date < DateTime.Now).ToList())
            {
                i.purchase_date = DateTime.Now;
                db.SaveChanges();
            }
        }

        public static void AdetSor()
        {
            if(Settings.Default["_asked"].ToString() == "false")
            {
                if (XtraMessageBox.Show("Sepete eklenecek ürünlerde adet hesaplansın mı?", "Adet Hesaplama Onayı", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    adetlimi = true;
                    Settings.Default["_adetlimi"] = "true";
                }
                else
                {
                    adetlimi = false;
                    Settings.Default["_adetlimi"] = "false";
                }
                
            }
            else
            {
                if (Settings.Default["_adetlimi"].ToString() == "false")
                {
                    adetlimi = false;
                }
                else
                {
                    adetlimi = true;
                }
            }
            Settings.Default["_asked"] = "true";
            Settings.Default.Save();
        }
    }


    // Form Modlarının Enum Tanımı
    public enum formMode : byte
    {
        insert = 0,
        edit = 1,
        print = 2,
        view = 3,
        export = 4
    }

    public enum SmsTypeEnum : byte
    {
        // alınacaklar listesi
        UponReceipt = 0,
        // yeni sipariş
        NewOrders = 1,
        // teslim edilecek
        WhenDelivered = 2
        //teslim edilecekler listesi
    }


}
