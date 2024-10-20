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
    public partial class Gecmissatinalim : Form
    {
        public Gecmissatinalim()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();
        public string TCNO1;
        private void Gecmissatinalim_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_satınistek where isteyenTC=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TCNO1);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
