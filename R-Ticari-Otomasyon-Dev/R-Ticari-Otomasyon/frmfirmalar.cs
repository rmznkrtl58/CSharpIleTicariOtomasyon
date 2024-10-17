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
    public partial class frmfirmalar : Form
    {
        public frmfirmalar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void firmalistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblfirmalar",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtfirmaId.Text = "";
            txtfirmaad.Text = "";
            txtfirmasektör.Text = "";
            txtyetkiliad.Text = "";
            txtyetkiligörev.Text = "";
            mskyetkilitc.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            mskfax.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            txtveridairesi.Text = "";
            rchadres.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
        }
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
        private void frmfirmalar_Load(object sender, EventArgs e)
        {
            firmalistele();
            temizle();
            cmbiller();
            kodanlamları();
        }
        void kodanlamları()
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select FirmaKod1 from tblkodlar ",bgl.baglanti());
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read()) 
            { 
            rchkod1.Text= dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
       


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {   txtfirmaId.Text = dr[0].ToString();
                txtfirmaad.Text = dr[1].ToString();
                txtfirmasektör.Text = dr[2].ToString();
                txtyetkiliad.Text = dr[3].ToString();
                txtyetkiligörev.Text = dr[5].ToString();
                mskyetkilitc.Text = dr[4].ToString();
                msktel1.Text = dr[6].ToString();
                msktel2.Text = dr[7].ToString();
                mskfax.Text = dr[9].ToString();
                txtmail.Text = dr[8].ToString();
                cmbil.Text = dr[10].ToString();
               cmbilçe.Text = dr[11].ToString();
               txtveridairesi.Text = dr[12].ToString();
                rchadres.Text = dr[13].ToString();
                txtkod1.Text = dr[14].ToString();
                txtkod2.Text = dr[15].ToString();
                txtkod3.Text = dr[16].ToString();



            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("insert into tblfirmalar (Ad,Sektör,YetkiliAdSoyad,YetkiliTc,YetkiliStatü,Telefon1,Telefon2,Mail,Fax,İl,İlçe,VergiDaire,Adres,ÖzelKod,ÖzelKod2,ÖzelKod3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtfirmaad.Text);
            sorgu.Parameters.AddWithValue("@p2", txtfirmasektör.Text);
            sorgu.Parameters.AddWithValue("@p3", txtyetkiliad.Text);
            sorgu.Parameters.AddWithValue("@p4", mskyetkilitc.Text);
            sorgu.Parameters.AddWithValue("@p5", txtyetkiligörev.Text);
            sorgu.Parameters.AddWithValue("@p6", msktel1.Text);
            sorgu.Parameters.AddWithValue("@p7", msktel2.Text);
            sorgu.Parameters.AddWithValue("@p8", txtmail.Text);
            sorgu.Parameters.AddWithValue("@p9", mskfax.Text);
            sorgu.Parameters.AddWithValue("@p10", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p11", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p12", txtveridairesi.Text);
            sorgu.Parameters.AddWithValue("@p13", rchadres.Text);
            sorgu.Parameters.AddWithValue("@p14", txtkod1.Text);
            sorgu.Parameters.AddWithValue("@p15", txtkod2.Text);
            sorgu.Parameters.AddWithValue("@p16", txtkod3.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firmalar Sisteme Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistele();
            temizle();

        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {   cmbilçe.Properties.Items.Clear();
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select İlce from tblİlceler where Sehir=@p1", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",cmbil.SelectedIndex+1);
            SqlDataReader dr=sorgu.ExecuteReader();
            while (dr.Read()) 
            {
                cmbilçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblfirmalar where Id=@p1", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtfirmaId.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firmalar Sistemden Silindi...", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            firmalistele();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblfirmalar set Ad=@p2,Sektör=@p3,YetkiliAdSoyad=@p4,YetkiliTc=@p5,YetkiliStatü=@p6,Telefon1=@p7,Telefon2=@p8,Mail=@p9,Fax=@p10,İl=@p11,İlçe=@p12,VergiDaire=@p13,Adres=@p14,ÖzelKod=@p15,ÖzelKod2=@p16,ÖzelKod3=@p17 where Id=@p1", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtfirmaId.Text);
            sorgu.Parameters.AddWithValue("@p2", txtfirmaad.Text);
            sorgu.Parameters.AddWithValue("@p3", txtfirmasektör.Text);
            sorgu.Parameters.AddWithValue("@p4", txtyetkiliad.Text);
            sorgu.Parameters.AddWithValue("@p5", mskyetkilitc.Text);
            sorgu.Parameters.AddWithValue("@p6", txtyetkiligörev.Text);
            sorgu.Parameters.AddWithValue("@p7", msktel1.Text);
            sorgu.Parameters.AddWithValue("@p8", msktel2.Text);
            sorgu.Parameters.AddWithValue("@p9", txtmail.Text);
            sorgu.Parameters.AddWithValue("@p10", mskfax.Text);
            sorgu.Parameters.AddWithValue("@p11", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p12", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p13", txtveridairesi.Text);
            sorgu.Parameters.AddWithValue("@p14", rchadres.Text);
            sorgu.Parameters.AddWithValue("@p15", txtkod1.Text);
            sorgu.Parameters.AddWithValue("@p16", txtkod2.Text);
            sorgu.Parameters.AddWithValue("@p17", txtkod3.Text);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Firmalar Sistemden Güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmalistele();

        }
    }
}
