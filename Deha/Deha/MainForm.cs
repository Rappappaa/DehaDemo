using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Deha.Forms;
using Deha.UserControls;
using DevExpress.XtraEditors;
using Deha.Properties;
using System.Net.Http;

namespace Deha
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        DehaPosModel db = new DehaPosModel(Settings.Default["_connectionstring"].ToString());

        static MainForm _obj;

        public static MainForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainForm();
                }
                return _obj;
            }
        }

        public Panel PnlContainter
        {
            get { return UserControlPanel; }
            set { UserControlPanel = value; }
        }

        public MainForm()
        {
            Program.AlinacakGuncelle();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setting _setting = db.settings.FirstOrDefault();
            user _user = db.users.FirstOrDefault(q => q.id == 2);
            int _customernumber = db.customers.Where(q => q.active == true).Count();

            lblFirmaAdi.Text = _setting.business_name;
            lblUserName.Text = _user.fullname;
            lblMusteri.Text = Convert.ToString(_customernumber);
            
            _obj = this;
            AnaSayfa UCAnaSayfa = new AnaSayfa();
            UCAnaSayfa.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCAnaSayfa);
            this.Text = "DehaPos Halı Takip Yazılımı - Ana Sayfa";

        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            AnaSayfa UCAnaSayfa = new AnaSayfa();
            UCAnaSayfa.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCAnaSayfa);
            this.Text = "DehaPos Halı Takip Yazılımı - Ana Sayfa";
        }

        private void alınacaklarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            AlinacaklarListesi UCAlinacaklarListesi = new AlinacaklarListesi();
            UCAlinacaklarListesi.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCAlinacaklarListesi);
            this.Text = "DehaPos Halı Takip Yazılımı - Alınacaklar Listesi";
        }

        private void yıkamadaOlanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            YikanacaklarListesi UCYikanacaklarListesi = new YikanacaklarListesi();
            UCYikanacaklarListesi.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCYikanacaklarListesi);
            this.Text = "DehaPos Halı Takip Yazılımı - Yıkamada Olanlar";
        }

        private void teslimEdileceklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            TeslimListesi UCTeslimListesi = new TeslimListesi();
            UCTeslimListesi.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCTeslimListesi);
            this.Text = "DehaPos Halı Takip Yazılımı - Teslim Edilecekler";
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void müşterilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            Musteriler UCMusteriler = new Musteriler();
            UCMusteriler.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCMusteriler);
            this.Text = "DehaPos Halı Takip Yazılımı - Müşteriler";
        }

        private void günÖzetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            GunOzeti UCGunOzeti = new GunOzeti();
            UCGunOzeti.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCGunOzeti);
            this.Text = "DehaPos Halı Takip Yazılımı - Gün Özeti";
        }

        private void hizmetRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program._loginuser.auth_report == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                HizmetRaporlari UCHizmetRaporlari = new HizmetRaporlari();
                UCHizmetRaporlari.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCHizmetRaporlari);
                this.Text = "DehaPos Halı Takip Yazılımı - Hizmet Raporları";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ürünSatışRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_report == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                UrunSatisRaporlari UCUrunSatisRaporlari = new UrunSatisRaporlari();
                UCUrunSatisRaporlari.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCUrunSatisRaporlari);
                this.Text = "DehaPos Halı Takip Yazılımı - Ürün Satış Raporları";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void genelRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_report == true || Program._loginuser.admin == true)
            {
                _obj = null;
            UserControlPanel.Controls.Clear();
            GenelRapor UCGenelRapor = new GenelRapor();
            UCGenelRapor.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCGenelRapor);
            this.Text = "DehaPos Halı Takip Yazılımı - Genel Raporlar";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void smsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Text = "DehaPos Halı Takip Yazılımı - Sms";
        }

        private void direktSatılToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program._loginuser.auth_direct_sale == true || Program._loginuser.admin == true)
            {
                DirekSatis frm = new DirekSatis(formMode.insert, null);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            Musteriler UCMusteriler = new Musteriler();
            UCMusteriler.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCMusteriler);
            this.Text = "DehaPos Halı Takip Yazılımı - Müşteriler";
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_product == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                Urunler UCUrunler = new Urunler();
                UCUrunler.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCUrunler);
                this.Text = "DehaPos Halı Takip Yazılımı - Ürünler";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_vehicle == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                Araclar UCAraclar = new Araclar();
                UCAraclar.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCAraclar);
                this.Text = "DehaPos Halı Takip Yazılımı - Araçlar";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bölgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_area == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                Bolgeler UCBolgeler = new Bolgeler();
                UCBolgeler.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCBolgeler);
                this.Text = "DehaPos Halı Takip Yazılımı - Bölgeler";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void firmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_company == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                Firmalar UCFirmalar = new Firmalar();
                UCFirmalar.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCFirmalar);
                this.Text = "DehaPos Halı Takip Yazılımı - Firmalar";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void smsÜyelikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_sms_user == true || Program._loginuser.admin == true)
            {
                _obj = null;
                UserControlPanel.Controls.Clear();
                SmsUyelikleri UCSmsUyelikleri = new SmsUyelikleri();
                UCSmsUyelikleri.Dock = DockStyle.Fill;
                UserControlPanel.Controls.Add(UCSmsUyelikleri);
                this.Text = "DehaPos Halı Takip Yazılımı - Sms Üyelikleri";
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void smsŞablonlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            SmsSablonlari UCSmsSablonlari = new SmsSablonlari();
            UCSmsSablonlari.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCSmsSablonlari);
            this.Text = "DehaPos Halı Takip Yazılımı - Sms Şablonları";
        }

        private void smsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            Sms UCSms = new Sms();
            UCSms.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCSms);
            this.Text = "DehaPos Halı Takip Yazılımı - Sms";
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            Ayarlar UCAyarlar = new Ayarlar();
            UCAyarlar.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCAyarlar);
            this.Text = "DehaPos Halı Takip Yazılımı - Ayarlar";
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "DehaPos Halı Takip Yazılımı - Hakkında";
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            Kullanicilar UCKullanicilar = new Kullanicilar();
            UCKullanicilar.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCKullanicilar);
            this.Text = "DehaPos Halı Takip Yazılımı - Kullanıcılar";
        }

        private void btnGunOzeti_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            GunOzeti UCGunOzeti = new GunOzeti();
            UCGunOzeti.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCGunOzeti);
            this.Text = "DehaPos Halı Takip Yazılımı - Gün Özeti";
        }

        private void sistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SistemAyarlari frm = new SistemAyarlari();
            frm.ShowDialog();
        }

        private void alacakEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlacakEkle frm = new AlacakEkle(formMode.insert, null);
            frm.ShowDialog();
        }

        private void tahsilatYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TahsilatYap frm = new TahsilatYap(formMode.insert, null);
            frm.ShowDialog();
        }

        private void iptalEdilenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _obj = null;
            UserControlPanel.Controls.Clear();
            IptalEdilenler UCIptalEdilenler = new IptalEdilenler();
            UCIptalEdilenler.Dock = DockStyle.Fill;
            UserControlPanel.Controls.Add(UCIptalEdilenler);
            this.Text = "DehaPos Halı Takip Yazılımı - İptal Edilenler";
        }

        private void çıkışYapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default["_asked"] = "false";
                Settings.Default.Save();

                Application.Exit();
                Process.Start(Application.ExecutablePath);
            }
        }

        private void ayarlarıSıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Program ayarlarını sıfırlamak istediğinize emin misiniz?", "Programı Sıfırla", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default["_adetlimi"] = "false";
                Settings.Default["_asked"] = "false";
                Settings.Default["_businessname"] = "bos";
                Settings.Default["_firstlogin"] = "true";
                Settings.Default.Save();

                Application.Exit();
                Process.Start(Application.ExecutablePath);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Program._loginuser.auth_expense_add == true || Program._loginuser.admin == true)
            {
                GiderEkle frm = new GiderEkle(formMode.insert, null);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Bu sayfa için erişim yetkiniz bulunmamaktadır.", "Erişim Kısıtlaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void anydeskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://download.anydesk.com/AnyDesk.exe?_ga=2.169798497.1900032933.1608993545-136653239.1608762610");
        }

        private void alpemixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.alpemix.com/site/Alpemix.exe");
        }

        private void teamviewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://download.teamviewer.com/download/TeamViewer_Setup.exe");
        }

        private void webSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://dehapos.com/");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UClIUdtldwbi6jWw-cDiOnMQ");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/dehaposyazilim/");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr-tr.facebook.com/dehaposyazilim");
        }

        private void whatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.whatsapp.com/send?phone=905394451615&text=");
        }
    }
}