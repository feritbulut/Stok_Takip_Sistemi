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
using System.Net.Http.Headers;

namespace Stok_Takip
{
    public partial class SatınAlma_Giris : Form
    {
        public SatınAlma_Giris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_SatınAlımPersonel where SatınTC=@p1 and SatınSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtTC.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Satın_Alım_Panel frm = new Satın_Alım_Panel();
                frm.TCNO2 = TxtTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girmiş olduğunuz bilgiler hatalı", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
