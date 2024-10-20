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
using System.Data.SqlTypes;

namespace Stok_Takip
{
    public partial class Depo_Sorumlusu_Panel : Form
    {
        public Depo_Sorumlusu_Panel()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl =new SqlBaglantisi();
        public string TCNO4;

        int urunadet;
        int istekadet;
        int sonadet;
        private void Depo_Sorumlusu_Panel_Load(object sender, EventArgs e)
        {
            LblTC.Text = TCNO4;

            SqlCommand komut = new SqlCommand("select DepoAd,DepoSoyad from Tbl_DepoPersonel where DepoTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                LblİsimSoyisim.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_Depoİstek", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label8.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün where ÜrünAd=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string urunAd = label12.Text;
            int secilenIndex = -1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[1].Value.ToString() == urunAd)
                {
                    secilenIndex = dataGridView1.Rows[i].Index;
                    break; 
                }
            }

            urunadet = Convert.ToInt32(dataGridView1.Rows[secilenIndex].Cells[2].Value);

            sonadet = urunadet - istekadet;

            SqlCommand komut = new SqlCommand("Delete from Tbl_Depoİstek where İstekId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label11.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand komut1 = new SqlCommand("update Tbl_Ürün set ÜrünAdet=@p1 where ÜrünAd=@p2",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",sonadet);
            komut1.Parameters.AddWithValue("@p2", label12.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();



            MessageBox.Show("Gönderim Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            label11.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            label12.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            label13.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            istekadet = Convert.ToInt32(dataGridView2.Rows[secilen].Cells[2].Value);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_Depoİstek", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            depobılgıduzenle frm = new depobılgıduzenle();
            frm.TCNO5 = LblTC.Text;
            frm.Show();
        }
    }
}
