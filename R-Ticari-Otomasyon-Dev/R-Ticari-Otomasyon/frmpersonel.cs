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
    public partial class frmpersonel : Form
    {
        public frmpersonel()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void cmbiller()
        {//comboboxa illeri getirme
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select * from tbliller", bgl.baglanti());
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
                //comboedit kullandığım için properties eklemesi yaptım
            }
            bgl.baglanti().Close();

        }
        void temizle() 
        {
            txtad.Text = "";
            txtId.Text = "";
            txtsoyad.Text = "";
            msktel1.Text = "";
            msktc.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            rchadres.Text = "";
            txtgörev.Text = "";

        }
        void personellistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblpersoneller",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void frmpersonel_Load(object sender, EventArgs e)
        {
            cmbiller();
            personellistele();
            temizle();

        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {   cmbilçe.Properties.Items.Clear();
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

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("insert into tblpersoneller (Ad,Soyad,Telefon,TC,Mail,İl,İlçe,Adres,Gorev) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtad.Text);
            sorgu.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sorgu.Parameters.AddWithValue("@p3", msktel1.Text);
            sorgu.Parameters.AddWithValue("@p4", msktc.Text);
            sorgu.Parameters.AddWithValue("@p5", txtmail.Text);
            sorgu.Parameters.AddWithValue("@p6", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p7", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p8", rchadres.Text);
            sorgu.Parameters.AddWithValue("@p9", txtgörev.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personellistele();
            temizle();


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtad.Text = dr["Ad"].ToString();
               txtId.Text = dr["Id"].ToString();
                txtsoyad.Text = dr["Soyad"].ToString();
                msktel1.Text = dr["Telefon"].ToString();
                msktc.Text = dr["TC"].ToString();
                txtmail.Text = dr["Mail"].ToString();
                cmbil.Text = dr["İl"].ToString();
                cmbilçe.Text = dr["İlçe"].ToString();
                rchadres.Text = dr["Adres"].ToString();
                txtgörev.Text = dr["Gorev"].ToString();



            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblpersoneller where Id=@p1",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtId.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            personellistele();
            temizle();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblpersoneller set Ad=@p1,Soyad=@p2,Telefon=@p3,TC=@p4,Mail=@p5,İl=@p6,İlçe=@p7,Adres=@p8,Gorev=@p9 where Id=@p10", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtad.Text);
            sorgu.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sorgu.Parameters.AddWithValue("@p3", msktel1.Text);
            sorgu.Parameters.AddWithValue("@p4", msktc.Text);
            sorgu.Parameters.AddWithValue("@p5", txtmail.Text);
            sorgu.Parameters.AddWithValue("@p6", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p7", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p8", rchadres.Text);
            sorgu.Parameters.AddWithValue("@p9", txtgörev.Text);
            sorgu.Parameters.AddWithValue("@p10", txtId.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personellistele();
            temizle();

        }
    }
}
