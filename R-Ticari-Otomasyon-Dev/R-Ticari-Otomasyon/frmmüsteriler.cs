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
    public partial class frmmüsteriler : Form
    {
        public frmmüsteriler()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
       void müsterilistele() 
        {
          SqlDataAdapter da=new SqlDataAdapter("select * from tblmüşteriler",bgl.baglanti());
          DataTable dt=new DataTable();
           da.Fill(dt);
           gridControl1.DataSource = dt;
        }
        void cmbiller() 
        {//comboboxa illeri getirme
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("select * from tbliller",bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
                //comboedit kullandığım için properties eklemesi yaptım
            }
            bgl.baglanti().Close();
        
        }
        void temizle()
        {
            txtId.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            msktc.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            rchadres.Text = "";
            txtveridairesi.Text = "";
        }
        
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("insert into tblmüşteriler (Ad,Soyad,Telefon,Telefon2,TC,Mail,İl,İlçe,Adres,VergiDaire) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtad.Text);
            sorgu.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sorgu.Parameters.AddWithValue("@p3", msktel1.Text);
            sorgu.Parameters.AddWithValue("@p4", msktel2.Text);
            sorgu.Parameters.AddWithValue("@p5", msktc.Text);
            sorgu.Parameters.AddWithValue("@p6", txtmail.Text);
            sorgu.Parameters.AddWithValue("@p7", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p8", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p9", rchadres.Text);
            sorgu.Parameters.AddWithValue("@p10", txtveridairesi.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteriler Sisteme Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            müsterilistele();
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        { //veri silme ve güncelleme işlemleri çok önemlidir oyuzden dikkat etmek gerekir.
          if(MessageBox.Show("Müşteriyi Silmek İstiyormusun?","Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
            {
                bgl.baglanti();
                SqlCommand sorgu = new SqlCommand("delete from tblmüşteriler where Id=@p1",bgl.baglanti());
                sorgu.Parameters.AddWithValue("@p1",txtId.Text);
                sorgu.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteriler Sistemden Silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               

            }
            müsterilistele();
            temizle();


        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {   
            if(MessageBox.Show("Müşteri Güncellensin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
            {
                bgl.baglanti();
                SqlCommand sorgu = new SqlCommand("update tblmüşteriler set Ad=@p2,Soyad=@p3,Telefon=@p4,Telefon2=@p5,Tc=@p6,Mail=@p7,İl=@p8,İlçe=@p9,Adres=@p10,VergiDaire=@p11 where Id=@p1");
                sorgu.Parameters.AddWithValue("@p1", txtId.Text);
                sorgu.Parameters.AddWithValue("@p2", txtad.Text);
                sorgu.Parameters.AddWithValue("@p3", txtsoyad.Text);
                sorgu.Parameters.AddWithValue("@p4", msktel1.Text);
                sorgu.Parameters.AddWithValue("@p5", msktel2.Text);
                sorgu.Parameters.AddWithValue("@p6", msktc.Text);
                sorgu.Parameters.AddWithValue("@p7", txtmail.Text);
                sorgu.Parameters.AddWithValue("@p8", cmbil.Text);
                sorgu.Parameters.AddWithValue("@p9", cmbilçe.Text);
                sorgu.Parameters.AddWithValue("@p10", rchadres.Text);
                sorgu.Parameters.AddWithValue("@p10", txtveridairesi.Text);
                sorgu.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                


            }
            müsterilistele();
            temizle();
        }

        private void frmmüsteriler_Load(object sender, EventArgs e)
        {
            müsterilistele();
            cmbiller();
            temizle();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {   cmbilçe.Properties.Items.Clear();
            cmbilçe.Text = "";
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select İlce from tblilceler where Sehir=@p1",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",cmbil.SelectedIndex+1);
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read()) 
            {
             cmbilçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {  
           
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //focus row handle->imleci ilgili satıra getirdiğimiz anda o satırı seç ve verileri al.
           if (dr != null)//seçilen satırın ve alınan veriler arasında boş olmayan verileri seç ve işlemleri yap.
            {
              
                txtId.Text = dr["Id"].ToString();
                txtad.Text = dr["Ad"].ToString();
                txtsoyad.Text = dr["Soyad"].ToString();
                msktel1.Text = dr["Telefon"].ToString();
                msktel2.Text = dr["Telefon2"].ToString();
                msktc.Text = dr["TC"].ToString();
                txtmail.Text = dr["Mail"].ToString();
                cmbil.Text = dr["İl"].ToString();
                cmbilçe.Text = dr["İlçe"].ToString();
                rchadres.Text = dr["Adres"].ToString();
                txtveridairesi.Text = dr["VergiDaire"].ToString();
            }
           
        }
    }
}
