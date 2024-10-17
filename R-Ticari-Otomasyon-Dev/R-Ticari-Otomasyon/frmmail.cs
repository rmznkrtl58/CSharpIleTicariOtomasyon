using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Ticari_Otomasyon
{
    public partial class frmmail : Form
    {
        public frmmail()
        {
            InitializeComponent();
        }
        public string mail;
        private void frmmail_Load(object sender, EventArgs e)
        {
            txtmailadresi.Text = mail;
        }

        private void btngönder_Click(object sender, EventArgs e)
        {
            MailMessage mesajım=new MailMessage();
            SmtpClient istemci=new SmtpClient();//kapıyı tıklatma
            istemci.Credentials = new System.Net.NetworkCredential("Mail","Şifre");
            //network credential -->ağ kimliği                   //1.çift tırnağıma mail adresimi 2.çift tırnağıma şifremi yazacam
            istemci.Port = 587;//trdeki mail adresi port numarası                             //önemli. 
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl= true;//gönderdiğimiz epostayı yol boyunca şifrelesinmi? evet.
            mesajım.To.Add(txtmesaj.Text);//kime göndereceğim
            mesajım.From = new MailAddress("Mail");//kimden gönderildiği bizim mail adresimiz yani
            mesajım.Subject = txtkonu.Text;
            mesajım.Body = txtmesaj.Text;//içerik kısmı.
            istemci.Send(mesajım);
        
        
        }
    }
}
