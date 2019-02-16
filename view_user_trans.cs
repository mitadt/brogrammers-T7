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
    public partial class view_user_trans : Form
    {
        public view_user_trans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void view_user_trans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select * from transaction_master where sender_id=@sender_id", dbconnection.conn))
            {
                cmd.Parameters.AddWithValue("@sender_id", id.idd);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
}
