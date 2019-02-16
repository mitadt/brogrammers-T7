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
    public partial class view_cust : Form
    {
        public view_cust()
        {
            InitializeComponent();
        }

        private void view_cust_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select id, name,accnumber,phonenb,EmailId,AdharNb,amount from add_cust", dbconnection.conn))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
