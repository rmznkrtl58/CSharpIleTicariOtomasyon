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
    public partial class frmgiderler : Form
    {
        public frmgiderler()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void giderlistesi()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from tblgiderler order by Id asc",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtId.Text = "";
            cmbaylar.Text = "";
            cmbyıllar.Text = "";
            txtelektirk.Text = "";
            txtsu.Text = "";
            txtdoğalgaz.Text = "";
            txtinternet.Text = "";
            txtmaaşlar.Text = "";
            txtekstralar.Text = "";
            rchnotlar.Text = "";
        }
        private void frmgiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("insert into tblgiderler (Ay,Yıl,Elektirik,Su,Doğalgaz,İnternet,Maaslar,Ekstra,Notlar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",cmbaylar.Text);
            sorgu.Parameters.AddWithValue("@p2", cmbyıllar.Text);
            sorgu.Parameters.AddWithValue("@p3", decimal.Parse(txtelektirk.Text));
            sorgu.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            sorgu.Parameters.AddWithValue("@p5", decimal.Parse(txtdoğalgaz.Text));
            sorgu.Parameters.AddWithValue("@p6", decimal.Parse (txtinternet.Text));
            sorgu.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaşlar.Text));
            sorgu.Parameters.AddWithValue("@p8", decimal.Parse(txtekstralar.Text));
            sorgu.Parameters.AddWithValue("@p9", rchnotlar.Text);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Giderler Sisteme Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
            giderlistesi();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                txtId.Text = dr["Id"].ToString();
                cmbaylar.Text = dr["Ay"].ToString();
                cmbyıllar.Text = dr["Yıl"].ToString();
                txtelektirk.Text = dr["Elektirik"].ToString();
                txtsu.Text = dr["Su"].ToString();
                txtdoğalgaz.Text = dr["Doğalgaz"].ToString();
                txtinternet.Text = dr["İnternet"].ToString();
                txtmaaşlar.Text = dr["Maaslar"].ToString();
                txtekstralar.Text = dr["Ekstra"].ToString();
                rchnotlar.Text = dr["Notlar"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("delete from tblgiderler where Id="+txtId.Text,bgl.baglanti());
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Giderler Sistemden Silindi...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bgl.baglanti().Close();
            giderlistesi();
            temizle();
           
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu = new SqlCommand("update tblgiderler set Ay=@p1,Yıl=@p2,Elektirik=@p3,Su=@p4,Doğalgaz=@p5,İnternet=@p6,Maaslar=@p7,Ekstra=@p8,Notlar=@p9 where Id="+txtId.Text,bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",cmbaylar.Text);
            sorgu.Parameters.AddWithValue("@p2", cmbyıllar.Text);
            sorgu.Parameters.AddWithValue("@p3", decimal.Parse(txtelektirk.Text));
            sorgu.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            sorgu.Parameters.AddWithValue("@p5", decimal.Parse(txtdoğalgaz.Text));
            sorgu.Parameters.AddWithValue("@p6", decimal.Parse( txtinternet.Text));
            sorgu.Parameters.AddWithValue("@p7", decimal.Parse( txtmaaşlar.Text));
            sorgu.Parameters.AddWithValue("@p8", decimal.Parse(txtekstralar.Text));
            sorgu.Parameters.AddWithValue("@p9",  rchnotlar.Text);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Giderler Güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bgl.baglanti().Close();
            giderlistesi();
            temizle();


        }
    }
}
