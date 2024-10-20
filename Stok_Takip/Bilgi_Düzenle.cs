using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Takip
{
    public partial class Bilgi_Düzenle : Form
    {
        public Bilgi_Düzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TCNO2;

        private void Bilgi_Düzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = TCNO2;

            SqlCommand komut = new SqlCommand("select * from Tbl_kullanıcılar where KullanıcıTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr[1].ToString();
                textBox6.Text = dr[2].ToString();
                maskedTextBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox3.Text = dr[5].ToString();
                textBox2.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("update Tbl_kullanıcılar set KullanıcıAd=@p1, KullanıcıSoyad=@p2, KullanıcıTelefon=@p3, KullanıcıMeslek=@p4, KullanıcıBölüm=@p5, KullanıcıŞifre=@p6 where KullanıcıTC=@p7",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",textBox7.Text);
            komut1.Parameters.AddWithValue("@p2",textBox6.Text);
            komut1.Parameters.AddWithValue("@p3",maskedTextBox2.Text);
            komut1.Parameters.AddWithValue("@p4",textBox4.Text);
            komut1.Parameters.AddWithValue("@p5",textBox3.Text);
            komut1.Parameters.AddWithValue("@p6",textBox2.Text);
            komut1.Parameters.AddWithValue("@p7",maskedTextBox1.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
