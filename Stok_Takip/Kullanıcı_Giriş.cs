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


namespace Stok_Takip
{
    public partial class Kullanıcı_Giriş : Form
    {
        public Kullanıcı_Giriş()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Kullanıcılar where KullanıcıTC=@p1 and KullanıcıŞifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Kullanıcı_Panel frm = new Kullanıcı_Panel();           
                frm.TC = TxtTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girmiş olduğunuz bilgiler hatalı", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Kullanıcı_Giriş_Load(object sender, EventArgs e)
        {
          
        }
    }
}
