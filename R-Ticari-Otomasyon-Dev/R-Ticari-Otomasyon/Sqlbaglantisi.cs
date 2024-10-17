using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_Ticari_Otomasyon
{
   public class Sqlbaglantisi
    {
        public SqlConnection baglanti() 
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-VM4NR9R\SQLEXPRESS;Initial Catalog=dboticariotomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
