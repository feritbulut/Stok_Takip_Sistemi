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
using System.Reflection.Emit;

namespace Stok_Takip
{
    public partial class Satın_Alım_Panel : Form
    {
        public Satın_Alım_Panel()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TCNO2;

        private void Satın_Alım_Panel_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_satınistek", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            LblTC.Text = TCNO2.ToString();

            SqlCommand komut = new SqlCommand("select SatınAd,SatınSoyad from Tbl_SatınAlımPersonel where SatınTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                LblİsimSoyisim.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün where ÜrünAd=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satinbilgiduzenle frm = new satinbilgiduzenle();
            frm.TCNO3 = LblTC.Text;
            frm.Show();
        }
    }
}
