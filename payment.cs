using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fingerpriintbasedatm
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select* from bill", dbconnection.conn))
            {
              
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                decimal Total = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["price"].Value);
                }

                textBox1.Text = Total.ToString();

            }
        }

        private void payment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal a = Convert.ToDecimal(textBox1.Text);
            using(SqlCommand cmd=new SqlCommand("update add_cust set amount=(amount-@amount) where accnumber=@acc",dbconnection.conn))
            {
                cmd.Parameters.AddWithValue("@amount", a);
                cmd.Parameters.AddWithValue("@acc", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" THANK YOU : PAID SUCCESSFULLY!!");
            }
            using(SqlCommand cmd1=new SqlCommand("truncate table bill",dbconnection.conn))
            {
                cmd1.ExecuteNonQuery();
            }

        }
    }
}
