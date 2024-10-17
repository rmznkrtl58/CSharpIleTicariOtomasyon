using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Ticari_Otomasyon
{
    public partial class frmkasa : Form
    {
        public frmkasa()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }
        public string kullaniciadi;
        void müşterihareketler()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("exec firmahareketleri",bgl.baglanti());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            gridControl3.DataSource = dataTable;
        }
        void firmahareketler()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("exec müşterihareketleri", bgl.baglanti());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void toplamtutar()
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("select sum(Tutar) from tblfaturadetay ",bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read())
            {
                lbltoplamtutar.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void ödemeler()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select (Elektirik+Su+Doğalgaz+İnternet+Ekstra) from tblgiderler order by Id asc ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblödemeler.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void personelmaaş()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select Maaslar from tblgiderler order by Id asc ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblpersonelmaaşları.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void MüşteriSayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select count(*) from tblmüşteriler  ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblmüşterisayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void Firmasayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select count(*) from tblfirmalar ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblfirmasayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void Firmaşehirsayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select count(distinct(İl)) from tblfirmalar ", bgl.baglanti());
            //distinct tekrarsız bir şekilde say anlamında
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblfşehirsayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void müşterişehirsayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select count(distinct(İl)) from tblmüşteriler ", bgl.baglanti());
            //distinct tekrarsız bir şekilde say anlamında
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblmşehirsayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void personelsayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select count(*) from tblpersoneller ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblpersonelsayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        void stoksayısı()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select sum(adet) from tblürünler ", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                lblstoksayısı.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        private void frmkasa_Load(object sender, EventArgs e)
        {
            firmahareketler(); müşterihareketler();
            toplamtutar(); ödemeler(); personelmaaş(); MüşteriSayısı(); Firmasayısı();
            Firmaşehirsayısı(); müşterişehirsayısı(); personelsayısı(); stoksayısı();
            //admin formumdaki kullanici adını çekme
            //lblaktifkullanıcı.Text = kullaniciadi.ToString();
         
   

        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bgl.baglanti();
            sayac++;

            //charta elektiriği zamanlayıcıyla getirme
            if(sayac>0 && sayac <= 7)
            {
                groupControl2.Text = "Elektirik";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,Elektirik  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr=sorgu.ExecuteReader();
                while (dr.Read()) 
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }
               
            }
            if (sayac > 8 && sayac <= 15)
            {
                groupControl2.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,Su  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr = sorgu.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }

            }
            if (sayac > 15 && sayac <= 22)
            {
                groupControl2.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,Doğalgaz  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr = sorgu.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }

            }

            if (sayac > 22 && sayac <= 29)
            {
                groupControl2.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,İnternet  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr = sorgu.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }

            }
            if (sayac > 29 && sayac <= 36)
            {
                groupControl2.Text = "Maaşlar";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,Maaslar  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr = sorgu.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }

            }

            if (sayac > 36 && sayac <= 43)
            {
                groupControl2.Text = "Ekstralar";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand sorgu = new SqlCommand("select top 4 Ay,Ekstra  from tblgiderler order by Id desc", bgl.baglanti());
                //son 4 ayı getirmemiz gerekiyor
                SqlDataReader dr = sorgu.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    //Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]))-->ekstra nokta belirleyici.
                }

            }
            if (sayac == 43)
            {
                sayac = 0;
            }
            bgl.baglanti().Close();










        }
    }
}
