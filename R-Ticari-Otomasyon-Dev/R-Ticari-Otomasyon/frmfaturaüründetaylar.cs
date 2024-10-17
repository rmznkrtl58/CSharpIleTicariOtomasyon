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
    public partial class frmfaturaüründetaylar : Form
    {
        public frmfaturaüründetaylar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl=new Sqlbaglantisi();
        public string id;
        void faturaürünlistele()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from TblFaturaDetay where FaturaId='"+id+"'",bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void frmfaturaüründetaylar_Load(object sender, EventArgs e)
        {
            faturaürünlistele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {   frmfaturaüründüzenleme frm=new frmfaturaüründüzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                frm.Faturaürünid = dr["FaturaÜrünId"].ToString();
                frm.Show();
            }
        }
    }
}
