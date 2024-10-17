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
    public partial class Frmfaturalar : Form
    {
        public Frmfaturalar()
        {
            InitializeComponent();
        }
        
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void faturalistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblfaturabilgi",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtfaturaid.Text = "";
            txtserino.Text = "";
            txtsırano.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            txtvergidaire.Text = "";
            txtalıcı.Text = "";
            txtteslimeden.Text = "";
            txtteslimalan.Text = "";
        }
      private void Frmfaturalar_Load(object sender, EventArgs e)
        {
            
            faturalistele();
            temizle();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturabilgiid.Text == "") 
            {
                bgl.baglanti();
                SqlCommand sorgu = new SqlCommand("insert into tblfaturabilgi (Seri,SıraNo,Tarih,Saat,VergiDaire,Alıcı,TeslimEden,TeslimAlan) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
                sorgu.Parameters.AddWithValue("@p1",txtserino.Text);
                sorgu.Parameters.AddWithValue("@p2", txtsırano.Text);
                sorgu.Parameters.AddWithValue("@p3", msktarih.Text);
                sorgu.Parameters.AddWithValue("@p4", msksaat.Text);
                sorgu.Parameters.AddWithValue("@p5", txtvergidaire.Text);
                sorgu.Parameters.AddWithValue("@p6", txtalıcı.Text);
                sorgu.Parameters.AddWithValue("@p7", txtteslimeden.Text);
                sorgu.Parameters.AddWithValue("@p8", txtteslimalan.Text);
                sorgu.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Eklenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                faturalistele();
                temizle();
            }
            if (txtfaturabilgiid.Text != "" && comboBox1.Text=="Firma")//txtfaturabilgiid boş değil aşağıdaki işlemleri yap
            {
                double fiyat,  tutar;
                int adet;
                fiyat = Convert.ToDouble(txtürünfiyat.Text);
                adet = Convert.ToInt32(txtürünmiktarı.Text);
                tutar = fiyat * adet;
                txttoplamtutar.Text = tutar.ToString();
                bgl.baglanti();
                SqlCommand sorgu = new SqlCommand("insert into tblfaturadetay (ÜrünAd,Miktar,Fiyat,Tutar,FaturaId) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
                sorgu.Parameters.AddWithValue("@p1",txtürünadı.Text);
                sorgu.Parameters.AddWithValue("@p2", txtürünmiktarı.Text);
                sorgu.Parameters.AddWithValue("@p3", decimal.Parse(txtürünfiyat.Text));
                sorgu.Parameters.AddWithValue("@p4", decimal.Parse(txttoplamtutar.Text));
                sorgu.Parameters.AddWithValue("@p5", txtfaturabilgiid.Text);
                sorgu.ExecuteNonQuery();
                //hareket tablosuna veri Girişi
                SqlCommand sorgu2 = new SqlCommand("insert into tblfirmahareketleri (ÜrünId,Adet,Personel,Firma,Fiyat,Toplam,faturaId,Tarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
                sorgu2.Parameters.AddWithValue("@p1",txtürünid.Text);
                sorgu2.Parameters.AddWithValue("@p2", txtürünmiktarı.Text);
                sorgu2.Parameters.AddWithValue("@p3", txtpersonel.Text);
                sorgu2.Parameters.AddWithValue("@p4", txtfirma.Text);
                sorgu2.Parameters.AddWithValue("@p5", decimal.Parse(txtürünfiyat.Text));
                sorgu2.Parameters.AddWithValue("@p6", decimal.Parse(txttoplamtutar.Text));
                sorgu2.Parameters.AddWithValue("@p7", txtfaturabilgiid.Text);
                sorgu2.Parameters.AddWithValue("@p8", msktarih.Text);
                sorgu2.ExecuteNonQuery();

                //Stoklardan azaltma 
                SqlCommand sorgu3 = new SqlCommand("update tblürünler set Adet=Adet-@p1 where Id="+txtürünid.Text,bgl.baglanti());
                sorgu3.Parameters.AddWithValue("@p1",txtürünmiktarı.Text);
                sorgu3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                
            }
            if (txtfaturabilgiid.Text != "" && comboBox1.Text == "Müşteri")//txtfaturabilgiid boş değil aşağıdaki işlemleri yap
            {
                double fiyat, tutar;
                int adet;
                fiyat = Convert.ToDouble(txtürünfiyat.Text);
                adet = Convert.ToInt32(txtürünmiktarı.Text);
                tutar = fiyat * adet;
                txttoplamtutar.Text = tutar.ToString();
                bgl.baglanti();
                SqlCommand sorgu = new SqlCommand("insert into tblfaturadetay (ÜrünAd,Miktar,Fiyat,Tutar,FaturaId) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                sorgu.Parameters.AddWithValue("@p1", txtürünadı.Text);
                sorgu.Parameters.AddWithValue("@p2", txtürünmiktarı.Text);
                sorgu.Parameters.AddWithValue("@p3", decimal.Parse(txtürünfiyat.Text));
                sorgu.Parameters.AddWithValue("@p4", decimal.Parse(txttoplamtutar.Text));
                sorgu.Parameters.AddWithValue("@p5", txtfaturabilgiid.Text);
                sorgu.ExecuteNonQuery();
                //hareket tablosuna veri Girişi
                SqlCommand sorgu2 = new SqlCommand("insert into tblMüşterihareketleri (ÜrünId,Adet,Personel,Müşteri,Fiyat,Toplam,faturaId,Tarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                sorgu2.Parameters.AddWithValue("@p1", txtürünid.Text);
                sorgu2.Parameters.AddWithValue("@p2", txtürünmiktarı.Text);
                sorgu2.Parameters.AddWithValue("@p3", txtpersonel.Text);
                sorgu2.Parameters.AddWithValue("@p4", txtmüşteri.Text);
                sorgu2.Parameters.AddWithValue("@p5", decimal.Parse(txtürünfiyat.Text));
                sorgu2.Parameters.AddWithValue("@p6", decimal.Parse(txttoplamtutar.Text));
                sorgu2.Parameters.AddWithValue("@p7", txtfaturabilgiid.Text);
                sorgu2.Parameters.AddWithValue("@p8", msktarih.Text);
                sorgu2.ExecuteNonQuery();

                //Stoklardan azaltma 
                SqlCommand sorgu3 = new SqlCommand("update tblürünler set Adet=Adet-@p1 where Id=" + txtürünid.Text, bgl.baglanti());
                sorgu3.Parameters.AddWithValue("@p1", txtürünmiktarı.Text);
                sorgu3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                txtfaturaid.Text = dr["FaturaBilgiId"].ToString();
               txtserino.Text = dr["Seri"].ToString();
                txtsırano.Text = dr["SıraNo"].ToString();
                msktarih.Text = dr["Tarih"].ToString();
                msksaat.Text = dr["Saat"].ToString();
                txtvergidaire.Text = dr["VergiDaire"].ToString();
                txtalıcı.Text = dr["Alıcı"].ToString();
                txtteslimeden.Text = dr["TeslimEden"].ToString();
                txtteslimalan.Text = dr["TeslimAlan"].ToString();

            }
        }

     

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblFaturaBilgi where FaturaBilgiId=" + txtfaturaid.Text, bgl.baglanti());
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
            faturalistele();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblfaturabilgi set Seri=@p1,SıraNo=@p2,Tarih=@p3,Saat=@p4,VergiDaire=@p5,Alıcı=@p6,TeslimEden=@p7,TeslimAlan=@p8 where FaturaBilgiId=" + txtfaturaid.Text, bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1", txtserino.Text);
            sorgu.Parameters.AddWithValue("@p2", txtsırano.Text);
            sorgu.Parameters.AddWithValue("@p3", msktarih.Text);
            sorgu.Parameters.AddWithValue("@p4", msksaat.Text);
            sorgu.Parameters.AddWithValue("@p5", txtvergidaire.Text);
            sorgu.Parameters.AddWithValue("@p6", txtalıcı.Text);
            sorgu.Parameters.AddWithValue("@p7", txtteslimeden.Text);
            sorgu.Parameters.AddWithValue("@p8", txtteslimalan.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturalistele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmfaturaüründetaylar frm=new frmfaturaüründetaylar();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                frm.id = dr["FaturaBilgiId"].ToString();
                frm.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu= new SqlCommand("select ÜrünAd,SatışFiyat from tblürünler where Id="+txtürünid.Text,bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read())
            {
                txtürünadı.Text = dr[0].ToString();
                txtürünfiyat.Text=dr[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
