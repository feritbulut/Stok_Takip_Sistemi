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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stok_Takip
{
    public partial class satinbilgiduzenle : Form
    {
        public satinbilgiduzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string TCNO3;

        private void satinbilgiduzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = TCNO3.ToString();

            SqlCommand komut = new SqlCommand("select * from Tbl_SatınAlımPersonel where SatınTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr[2].ToString();
                textBox6.Text = dr[3].ToString();
                textBox2.Text = dr[4].ToString();
                
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("update Tbl_SatınAlımPersonel set SatınAd=@p1, SatınSoyad=@p2, SatınSifre=@p3 where SatınTC=@p4", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", textBox7.Text);
            komut1.Parameters.AddWithValue("@p2", textBox6.Text);
            komut1.Parameters.AddWithValue("@p3", textBox2.Text);
            komut1.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
