using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip
{
    public partial class Girisler : Form
    {
        public Girisler()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SatınAlma_Giris frm = new SatınAlma_Giris();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Kullanıcı_Giriş frm = new Kullanıcı_Giriş();
            frm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Depo_Personel_Girişi frm = new Depo_Personel_Girişi();
            frm.Show();
            this.Hide();
        }

        
    }
}
