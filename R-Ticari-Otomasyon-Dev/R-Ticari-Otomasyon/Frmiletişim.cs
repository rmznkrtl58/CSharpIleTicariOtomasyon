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
    public partial class Frmiletişim : Form
    {
        public Frmiletişim()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        void müşterilistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select Ad,Soyad,Telefon,Telefon2,Mail from tblmüşteriler",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmalistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select Ad as 'FirmaAd',YetkiliAdSoyad,YetkiliStatü,Telefon1,Telefon2,Mail,Fax from tblfirmalar",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        private void Frmiletişim_Load(object sender, EventArgs e)
        {
            müşterilistele(); firmalistele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {   frmmail frm=new frmmail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                frm.mail = dr["Mail"].ToString();
                frm.Show();
               
            
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmmail frm=new frmmail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr["Mail"].ToString();
                frm.Show();
            }
        }
    }
}
