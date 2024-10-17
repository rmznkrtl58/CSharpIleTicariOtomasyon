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
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }

        private void frmadmin_Load(object sender, EventArgs e)
        {

        }

        private void btngirişyap_MouseHover(object sender, EventArgs e)
        {
            
            
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        private void btngirişyap_Click(object sender, EventArgs e)
        {
            bgl.baglanti();
            SqlCommand sorgu=new SqlCommand("select * from tblkullanıcı where Kullanici=@p1 and Sifre=@p2",bgl.baglanti());
            sorgu.Parameters.AddWithValue("@p1",txtkullanıcı.Text);
            sorgu.Parameters.AddWithValue("@p2",txtşifre.Text);
            SqlDataReader dr=sorgu.ExecuteReader();
            if (dr.Read()) 
            {
              anaform frm=new anaform();
                frm.username = txtkullanıcı.Text;  
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre Girişi Tekrar Deneyiniz....","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
        }
    }
}
