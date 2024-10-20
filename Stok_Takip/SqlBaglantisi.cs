using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok_Takip
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-F5EB85PM\\SQLEXPRESS;Initial Catalog=StokTakipSistemi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
