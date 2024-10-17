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
    public partial class frmfaturaüründüzenleme : Form
    {
        public frmfaturaüründüzenleme()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        public string Faturaürünid;
        void faturaürünbilgileri()
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("select * from tblfaturadetay where FaturaÜrünId="+Faturaürünid,bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read()) 
            {
                txtürünadı.Text = dr[1].ToString();
                txtürünmiktarı.Text = dr[2].ToString();
                txtürünfiyat.Text = dr[3].ToString();
                txttoplamtutar.Text = dr[4].ToString();

            }
            bgl.baglanti().Close();
        }
        private void frmfaturaüründüzenleme_Load(object sender, EventArgs e)
        {
            txtürünid.Text = Faturaürünid;
            faturaürünbilgileri();

        }

        private void btngüncelle2_Click(object sender, EventArgs e)
        {
            int adet;
            double fiyat, tutar;
            adet = Convert.ToInt16(txtürünmiktarı.Text);
            fiyat = Convert.ToDouble(txtürünfiyat.Text);
            tutar = adet * fiyat;
            txttoplamtutar.Text = tutar.ToString();
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblfaturadetay set ÜrünAd=@p1,Miktar=@p2,Fiyat=@p3,Tutar=@p4 where FaturaÜrünId="+Faturaürünid,bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtürünadı.Text);
            sorgu.Parameters.AddWithValue("@p2", int.Parse(txtürünmiktarı.Text));
            sorgu.Parameters.AddWithValue("@p3", decimal.Parse(txtürünfiyat.Text));
            sorgu.Parameters.AddWithValue("@p4", decimal.Parse(txttoplamtutar.Text));
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Faturanın Ürün Bilgileri Güncellenmiştir...","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnsil2_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblfaturadetay where FaturaÜrünId="+Faturaürünid,bgl.baglanti());
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Faturadaki Ürünün Sildiniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
