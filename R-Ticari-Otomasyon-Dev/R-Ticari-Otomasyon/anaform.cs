using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Charts;
namespace R_Ticari_Otomasyon
{
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }
        public string username;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr15 == null)
            {
                fr15 = new fmanasayfa();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
        frmürünler fr1;
        private void btnürünler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //fr1.disposed-->sekme kapandıktan sonra tekrar tıkladığımızda geri açabiliyoruz
            if (fr1 == null || fr1.IsDisposed)//frm ürünler formumda fr1 diye bir nesne değişkeni tanımladım
            {               //fr1 nesne değişkenim boşta ama ürünler formumun bir nesnesi!!!
                            //fr1 nesne değişkenim boş olduğunda aşağıdakileri yap
                            //ama sadece boştayken yapki sürekli ürünler butonuna her tıklamada 
                            //ürünler sekmesi açılmasın.
                fr1 = new frmürünler();
                fr1.MdiParent = this;//bu parent içerisinde frmürünler formunu aç.
                fr1.Show();
            }
            
        }
        frmmüsteriler fr2;
        private void btnmüşteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null) 
            {
                fr2 = new frmmüsteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        frmfirmalar fr3;
        private void btnfirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null) 
            {
            fr3=new frmfirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            
            }
        }
        frmpersonel fr4;
        private void btnpersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)//fr4 bilinmiyorsa 
            {
                fr4 = new frmpersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        Frmiletişim fr5;
        private void btnrehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null)//fr5 hiç açılmadıysa aşağıdakileri yap. 
            {
              fr5=new Frmiletişim();
                fr5.MdiParent = this;
                fr5.Show();
            
            }
        }
        frmgiderler fr6;
        private void btngiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
            {
                fr6 = new frmgiderler();
                fr6.MdiParent = this;
                fr6.Show();

            }
        }
        frmbankalar fr7;
        private void btnbankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr7 == null)
            {
                fr7 = new frmbankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        Frmfaturalar fr8;

        private void btnfaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new Frmfaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        new frmnotlar fr9;

        private void btnnotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {
                fr9=new frmnotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        frmhareketler fr10;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null)
            {
                fr10 =new frmhareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        frmraporlar fr11;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null)
            {
                fr11 = new frmraporlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        frmstoklar fr12;
        private void btnstoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null) 
            {
                fr12=new frmstoklar();
                fr12.MdiParent = this;
                fr12.Show();

            }
        }
        frmfirmalar fr13;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null) 
            {

                fr13 = new frmfirmalar();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }
        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         frmayarlar frm=new frmayarlar();
            frm.Show();
        }

        frmkasa fr14;
        private void btnkasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null)
            {
                fr14=new frmkasa();
                frmkasa fr = new frmkasa();
                fr14.MdiParent = this;
                fr.kullaniciadi = username;
                fr14.Show();
            }
        }
        fmanasayfa fr15;
        private void btnanasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null)
            {
                fr15 = new fmanasayfa();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
    }
}
