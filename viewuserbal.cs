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
    public partial class viewuserbal : Form
    {
        public viewuserbal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void viewuserbal_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select account_no,balance_ from user_master where id=@id", dbconnection.conn))
            {
                cmd.Parameters.AddWithValue("@id", id.idd);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
