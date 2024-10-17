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
    public partial class frmürünler : Form
    {
        public frmürünler()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void ürünlistele() 
        {
        SqlDataAdapter da=new SqlDataAdapter("select * from tblürünler",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtId.Text = "";
            txtürünadı.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            mskyıl.Text = "";
            nmradet.Value = 0;
            txtalışfiyat.Text = "";
            txtsatışfiyat.Text = "";
            richTextBox1.Text = "";

        }
        private void frmürünler_Load(object sender, EventArgs e)
        {
            ürünlistele();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //ürünleri kaydet
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("insert into tblürünler (ÜrünAd,Marka,Model,Yıl,Adet,AlışFiyat,SatışFiyat,Detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtürünadı.Text);
            sorgu.Parameters.AddWithValue("@p2", txtmarka.Text);
            sorgu.Parameters.AddWithValue("@p3", txtmodel.Text);
            sorgu.Parameters.AddWithValue("@p4", mskyıl.Text);
            sorgu.Parameters.AddWithValue("@p5", int.Parse((nmradet.Value).ToString()));
            sorgu.Parameters.AddWithValue("@p6", txtalışfiyat.Text);
            sorgu.Parameters.AddWithValue("@p7", txtsatışfiyat.Text);
            sorgu.Parameters.AddWithValue("@p8", richTextBox1.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi...","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ürünlistele();
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblürünler where Id="+txtId.Text,bgl.baglanti());
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sistemden Silindi...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ürünlistele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {           //İmlecin Satır Odağı Değiştiği zaman
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //verilerin olduğu satırlara ait sınıftan dr adında bir nesne türettim.
            //datagridwiew'in satırlarına imlecin tıklanmasıyla (focuslanmasıyla) o satırdaki verileri al
            txtId.Text = dr["Id"].ToString();
            txtürünadı.Text = dr["ÜrünAd"].ToString();
            txtmarka.Text = dr["Marka"].ToString();
            txtmodel.Text = dr["Model"].ToString();
            mskyıl.Text = dr["Yıl"].ToString();
            nmradet.Value = int.Parse(dr["Adet"].ToString());
            txtalışfiyat.Text = dr["AlışFiyat"].ToString();
            txtsatışfiyat.Text = dr["SatışFiyat"].ToString();
            richTextBox1.Text = dr["Detay"].ToString();





        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblürünler set ÜrünAd=@p2,Marka=@p3,Model=@p4,Yıl=@p5,Adet=@p6,AlışFiyat=@p7,SatışFiyat=@p8,Detay=@p9 where Id=@p1", bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtId.Text);
            sorgu.Parameters.AddWithValue("@p2", txtürünadı.Text);
            sorgu.Parameters.AddWithValue("@p3", txtmarka.Text);
            sorgu.Parameters.AddWithValue("@p4", txtmodel.Text);
            sorgu.Parameters.AddWithValue("@p5", mskyıl.Text);
            sorgu.Parameters.AddWithValue("@p6", int.Parse((nmradet.Value).ToString()));
            sorgu.Parameters.AddWithValue("@p7", decimal.Parse(txtalışfiyat.Text));
            sorgu.Parameters.AddWithValue("@p8", decimal.Parse(txtsatışfiyat.Text));
            sorgu.Parameters.AddWithValue("@p9", richTextBox1.Text);
            sorgu.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ürünlistele();
            temizle();

        }
    }
}
