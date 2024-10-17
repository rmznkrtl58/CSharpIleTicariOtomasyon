using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Ticari_Otomasyon
{
    public partial class fmanasayfa : Form
    {
        public fmanasayfa()
        {
            InitializeComponent();
        }
       Sqlbaglantisi bgl=new Sqlbaglantisi();
        void azalanstoklar()
        {   //15 ve 15den aşağı stokları gridde gösterir.
            SqlDataAdapter da=new SqlDataAdapter("select ÜrünAd,sum(Adet) as 'Adet' from tblürünler group by ÜrünAd\r\nhaving sum(Adet)<=15 order by Sum(Adet)", bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            datagridazalanstoklar.DataSource= dt;
        }
        void NOTLAR()
        {   //son 3 notların başlıklarını getirir.
            SqlDataAdapter da = new SqlDataAdapter("select top 3 Tarih,Saat,Başlık from tblnotlar order by Id desc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void firmalar()
        {   //son 3 notların başlıklarını getirir.
            SqlDataAdapter da = new SqlDataAdapter("exec firmahareketleri2", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void İletişimbilgileri()
        {   //Firmaların İletişim Bilgilerini getirir.
            SqlDataAdapter da = new SqlDataAdapter("select Ad,Telefon1,Fax,Mail from tblfirmalar", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }
        private void fmanasayfa_Load(object sender, EventArgs e)
        {
            azalanstoklar();NOTLAR(); firmalar();
            İletişimbilgileri();
            //Döviz Kurları:
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            //Haberler:


        }
    }
}
