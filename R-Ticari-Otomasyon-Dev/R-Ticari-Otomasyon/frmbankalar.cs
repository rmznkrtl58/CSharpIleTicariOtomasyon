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
    public partial class frmbankalar : Form
    {
        public frmbankalar()
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
        void lkpeditfirma()
        { 
            //look up edit'e firmaları getirme
            SqlDataAdapter da = new SqlDataAdapter("select Id,Ad from tblfirmalar", bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            lkpeditfirmalar.Properties.NullText = "Bir Firma Seçiniz";
            lkpeditfirmalar.Properties.ValueMember = "Id";
            lkpeditfirmalar.Properties.DisplayMember = "Ad";
            lkpeditfirmalar.Properties.DataSource= dt;
            

        }
        void temizleme()
        {
            txtId.Text = "";
            txtbankatad.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            txtbankaşube.Text = "";
            txtbankahesapno.Text = "";
            txtbankayetkili.Text = "";
            txttelefon.Text = "";
            txttarih.Text = "";
            txtbankahesaptürü.Text = "";
            lkpeditfirmalar.Text = "";
            txtiban.Text = "";
        }



        void bankalistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("exec bankabilgisi", bgl.baglanti());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        private void frmbankalar_Load(object sender, EventArgs e)
        { 
            cmbiller();
            bankalistele();
            lkpeditfirma();
            temizleme();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {   cmbilçe.Properties.Items.Clear();
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("select İlce From tblİlceler where Sehir=@p1", bgl.baglanti());
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
            SqlCommand sorgu = new SqlCommand("insert into tblbankalar (BankaAdı,İl,İlçe,Şube,İban,HesapNo,Yetkili,Telefon,Tarih,HesapTürü,FirmaId) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtbankatad.Text);
            sorgu.Parameters.AddWithValue("@p2",cmbil.Text);
            sorgu.Parameters.AddWithValue("@p3", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p4", txtbankaşube.Text);
            sorgu.Parameters.AddWithValue("@p5", txtiban.Text);
            sorgu.Parameters.AddWithValue("@p6", txtbankahesapno.Text);
            sorgu.Parameters.AddWithValue("@p7", txtbankayetkili.Text);
            sorgu.Parameters.AddWithValue("@p8", txttelefon.Text);
            sorgu.Parameters.AddWithValue("@p9", txttarih.Text);
            sorgu.Parameters.AddWithValue("@p10", txtbankahesaptürü.Text);
           sorgu.Parameters.AddWithValue("@p11", lkpeditfirmalar.EditValue);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Sisteme Eklenmiştir...","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bankalistele();
            temizleme();



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr[0].ToString();
                txtbankatad.Text = dr[1].ToString();
                cmbil.Text = dr[2].ToString();
                cmbilçe.Text = dr[3].ToString();
                txtbankaşube.Text = dr[4].ToString();
                txtbankahesapno.Text = dr[6].ToString();
                txtbankayetkili.Text = dr[7].ToString();
                txttelefon.Text = dr[8].ToString();
                txttarih.Text = dr[9].ToString();
                txtbankahesaptürü.Text = dr[10].ToString();
                lkpeditfirmalar.Text = dr[11].ToString();
                txtiban.Text= dr[5].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblbankalar where Id="+txtId.Text,bgl.baglanti());
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Sistemden Silinmiştir....", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bankalistele();
            temizleme();


        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblbankalar set BankaAdı=@p2,İl=@p3,İlçe=@p4,Şube=@p5,İban=@p6,HesapNo=@p7,Yetkili=@p8,Telefon=@p9,Tarih=@p10,HesapTürü=@p11,FirmaId=@p12 where Id=@p1", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtId.Text);
            sorgu.Parameters.AddWithValue("@p2", txtbankatad.Text);
            sorgu.Parameters.AddWithValue("@p3", cmbil.Text);
            sorgu.Parameters.AddWithValue("@p4", cmbilçe.Text);
            sorgu.Parameters.AddWithValue("@p5", txtbankaşube.Text);
            sorgu.Parameters.AddWithValue("@p6", txtiban.Text);
            sorgu.Parameters.AddWithValue("@p7", txtbankahesapno.Text);
            sorgu.Parameters.AddWithValue("@p8", txtbankayetkili.Text);
            sorgu.Parameters.AddWithValue("@p9", txttelefon.Text);
            sorgu.Parameters.AddWithValue("@p10", txttarih.Text);
            sorgu.Parameters.AddWithValue("@p11", txtbankahesaptürü.Text);
            sorgu.Parameters.AddWithValue("@p12", lkpeditfirmalar.EditValue);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Banka Sistemden Güncellenmiştir....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bankalistele();
            temizleme();


        }
    }
}
