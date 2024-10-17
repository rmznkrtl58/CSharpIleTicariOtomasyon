using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Ticari_Otomasyon
{
    public partial class frmNotdetay : Form
    {
        public frmNotdetay()
        {
            InitializeComponent();
        }
        public string notdetay;
        private void frmNotdetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text= notdetay;
        }
    }
}
