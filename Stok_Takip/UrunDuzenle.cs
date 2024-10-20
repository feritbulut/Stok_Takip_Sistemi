using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip
{
    public partial class UrunDuzenle : Form
    {
        public UrunDuzenle()
        {
            InitializeComponent();
        }
        
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void UrunDuzenle_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Ürün (ÜrünAd,ÜrünAdet,Tedarikçi) values (@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut1 = new SqlCommand("update Tbl_Ürün set ÜrünAd=@p1, ÜrünAdet=@p2, Tedarikçi=@p3 where ÜrünId=@p4", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", richTextBox1.Text);
            komut1.Parameters.AddWithValue("@p4", label5.Text);

            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label5.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Ürün where ÜrünId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label5.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
