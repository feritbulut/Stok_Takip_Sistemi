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
    public partial class Depo_Personel_Girişi : Form
    {
        public Depo_Personel_Girişi()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_DepoPersonel where DepoTC=@p1 and DepoSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtTC.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Depo_Sorumlusu_Panel frm = new Depo_Sorumlusu_Panel();
                frm.TCNO4 = TxtTC.Text;
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
