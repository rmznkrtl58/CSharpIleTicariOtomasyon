using DevExpress.XtraBars;
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
    public partial class frmayarlar : Form
    {
        public frmayarlar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void kullanıcılistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblkullanıcı",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void clear()
        {
            txtkullanıcıadı.Text = " ";
            txtsifre.Text = " ";
        }
        private void frmayarlar_Load(object sender, EventArgs e)
        {
            kullanıcılistele();
            clear();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("insert into tblkullanıcı values (@p1,@p2)",bgl.baglanti());
            //eğer idli bir tablon yoksa insert intoyu bu şekilde kullanabilirsin.
            sorgu.Parameters.AddWithValue("@p1",txtkullanıcıadı.Text);
            sorgu.Parameters.AddWithValue("@p2", txtsifre.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Admin Bilgileri Kaydedilmiştir...","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            kullanıcılistele();
            clear();
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                txtkullanıcıadı.Text = dr["Kullanici"].ToString();
                txtsifre.Text = dr["Sifre"].ToString();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblkullanıcı set Sifre=@p2 where Kullanici=@p1",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
            sorgu.Parameters.AddWithValue("@p2",txtsifre.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Adminin Şifresi Güncellenmiştir....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            kullanıcılistele();
            clear();

        }
    }
}
