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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stok_Takip
{
    public partial class GeçmişDepoİstekleri : Form
    {
        public GeçmişDepoİstekleri()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TCNO;
        private void GeçmişDepoİstekleri_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Depoistek where isteyenTC=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TCNO);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
