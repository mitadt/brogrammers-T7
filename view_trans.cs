using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fingerpriintbasedatm
{
    public partial class view_trans : Form
    {
        public view_trans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void view_trans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select * from trans_mast", dbconnection.conn))
            {
                using(SqlDataAdapter adp =new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
}
