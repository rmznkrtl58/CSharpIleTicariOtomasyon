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
using System.Xml.Linq;

namespace R_Ticari_Otomasyon
{
    public partial class frmstoklar : Form
    {
        public frmstoklar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void ürünlisteleme()
        {
            SqlDataAdapter da=new SqlDataAdapter("select ÜrünAd,sum(Adet) as 'Adet' from tblürünler group by ÜrünAd", bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmasehirlistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select İl,count(*) from tblfirmalar group by İl", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void ürüngrafik()
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("select ÜrünAd,sum(Adet) as 'Adet' from tblürünler group by ÜrünAd", bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read()) 
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse (dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }
        void firmailgrafik()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select İl,count(*) from tblfirmalar group by İl", bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1]));
            }
            bgl.baglanti();
        }
        private void frmstoklar_Load(object sender, EventArgs e)
        {
            ürünlisteleme();
            ürüngrafik();
            firmailgrafik();
            firmasehirlistele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {    frmstokdetay fr=new frmstokdetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {    
                fr.üad = dr["ÜrünAd"].ToString();
            }
            fr.Show();
        }
    }
}
