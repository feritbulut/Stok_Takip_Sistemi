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
    public partial class Kullanıcı_Panel : Form
    {
        public Kullanıcı_Panel()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TC;
        private void Kullanıcı_Panel_Load(object sender, EventArgs e)
        {
            label8.Text = TC;

            SqlCommand komut = new SqlCommand("select KullanıcıAd,KullanıcıSoyad,KullanıcıTelefon from Tbl_Kullanıcılar where KullanıcıTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label8.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
                label11.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ürünId,ürünAd,ürünAdet from Tbl_Ürün", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnAramaYap_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ürün where ÜrünAd=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label3.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            label5.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnDepodanİste_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")
            {
                MessageBox.Show("Herhangi bir ürün seçmediniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen adet giriniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen bölüm giriniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand komut = new SqlCommand("insert into Tbl_Depoİstek (İstekAd,İstekAdet,İsteyenKullanıcı,İsteyenBölüm,İsteyenTC,İsteyenTelefon) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label5.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", label4.Text);
            komut.Parameters.AddWithValue("@p4", textBox3.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", label11.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("İstek Oluşturuldu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSatınAlımİstek_Click(object sender, EventArgs e)
        {

            if (label5.Text == "")
            {
                MessageBox.Show("Herhangi bir ürün seçmediniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen adet giriniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen bölüm giriniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand komut = new SqlCommand("insert into Tbl_Satınİstek (İstekAd,İstekAdet,İstekKullanıcı,İsteyenBölüm,İsteyenTC,İsteyenTelefon) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label5.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", label4.Text);
            komut.Parameters.AddWithValue("@p4", textBox3.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", label11.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("İstek Oluşturuldu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BtnDepoİstekleri_Click(object sender, EventArgs e)
        {
            GeçmişDepoİstekleri frm = new GeçmişDepoİstekleri();
            frm.TCNO = TC;
            frm.Show();
        }

        private void BtnSatınAlmaİstekleri_Click(object sender, EventArgs e)
        {
            Gecmissatinalim frm =new Gecmissatinalim();
            frm.TCNO1 = TC;
            frm.Show();
        }

        private void BtnBilgiDüzenle_Click(object sender, EventArgs e)
        {
            Bilgi_Düzenle frm = new Bilgi_Düzenle();
            frm.TCNO2 = TC;
            frm.Show();
        }
    }
}
