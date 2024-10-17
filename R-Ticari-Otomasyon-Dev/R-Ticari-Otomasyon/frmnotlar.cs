using DevExpress.Data.Summary;
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
    public partial class frmnotlar : Form
    {
        public frmnotlar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi  bgl=new Sqlbaglantisi();
        void notlarılistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblnotlar ",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtId.Text = "";
            txtbaşlık.Text = "";
            txthitap.Text = "";
            txtoluşturan.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            rchdetay.Text = "";
        }
        private void frmnotlar_Load(object sender, EventArgs e)
        {
            notlarılistele();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("insert into tblnotlar (Tarih,Saat,Başlık,Detay,Oluşturan,Hitap) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",msktarih.Text);
            sorgu.Parameters.AddWithValue("@p2", msksaat.Text);
            sorgu.Parameters.AddWithValue("@p3", txtbaşlık.Text);
            sorgu.Parameters.AddWithValue("@p4", rchdetay.Text);
            sorgu.Parameters.AddWithValue("@p5", txtoluşturan.Text);
            sorgu.Parameters.AddWithValue("@p6", txthitap.Text);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Notlar Eklenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bgl.baglanti().Close();
            notlarılistele(); temizle();


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["Id"].ToString();
                txtbaşlık.Text = dr["Başlık"].ToString();
                txthitap.Text = dr["Hitap"].ToString();
                txtoluşturan.Text = dr["Oluşturan"].ToString();
                msktarih.Text = dr["Tarih"].ToString();
                msksaat.Text = dr["Saat"].ToString();
                rchdetay.Text = dr["Detay"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("delete from tblnotlar where Id="+txtId.Text,bgl.baglanti());
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Not Silinmiştir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bgl.baglanti().Close();
            notlarılistele(); temizle();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblnotlar set Tarih=@p1,Saat=@p2,Başlık=@p3,Detay=@p4,Oluşturan=@p5,Hitap=@p6 where Id="+txtId.Text,bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1", msktarih.Text);
            sorgu.Parameters.AddWithValue("@p2", msksaat.Text);
            sorgu.Parameters.AddWithValue("@p3", txtbaşlık.Text);
            sorgu.Parameters.AddWithValue("@p4", rchdetay.Text);
            sorgu.Parameters.AddWithValue("@p5", txtoluşturan.Text);
            sorgu.Parameters.AddWithValue("@p6", txthitap.Text);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Not Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bgl.baglanti().Close();
            notlarılistele(); temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmNotdetay frm = new frmNotdetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                frm.notdetay = dr["Detay"].ToString();
            }
            frm.Show();            
        }
    }
}
