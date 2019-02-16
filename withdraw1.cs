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
    public partial class withdraw1 : Form
    {
        public withdraw1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                int current_bal = Convert.ToInt32(label2.Text);
                int transfer_amt = Convert.ToInt32(textBox1.Text);
                if (current_bal < transfer_amt)
                {
                    MessageBox.Show("AMOUNT EXCEEDS");
                }
                else
                {
                    int bal_update = current_bal - transfer_amt;
                    using (SqlCommand cmd1 = new SqlCommand("update user_master set balance_=@balance_ where id=@id", dbconnection.conn))
                    {
                        cmd1.Parameters.AddWithValue("@id", id.idd);
                        cmd1.Parameters.AddWithValue("@balance_", bal_update);
                      //  dbconnection.conn.Open();
                        cmd1.ExecuteNonQuery();
                      //  dbconnection.conn.Close();
                    }
                    using (SqlCommand cmd2 = new SqlCommand("select balance_ from user_master where id=@id", dbconnection.conn))
                    {
                        DataTable dtt = new DataTable();
                        cmd2.Parameters.AddWithValue("@id", id.idd);
                        using (SqlDataAdapter adtt = new SqlDataAdapter(cmd2))
                        {
                            adtt.Fill(dtt);
                        }
                        label2.Text = dtt.Rows[0].ItemArray[0].ToString();
                    }
                    using (SqlCommand cmd4 = new SqlCommand("insert into trans_mast(id,amount) values(@id,@amount)", dbconnection.conn))
                    {
                        cmd4.Parameters.AddWithValue("@id",id.idd);
                        cmd4.Parameters.AddWithValue("@amount", transfer_amt);
                        //dbconnection.conn.Close();
                      //  dbconnection.conn.Open();
                        cmd4.ExecuteNonQuery();
                        //dbconnection.conn.Close();
                    }
                    this.Hide();
                    MessageBox.Show("TRANSACTION SUCCESSFUL");
                }
           
        }

        private void withdraw1_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd2 = new SqlCommand("select balance_ from user_master where id=@id", dbconnection.conn))
            {
                DataTable dtt = new DataTable();
                cmd2.Parameters.AddWithValue("@id", id.idd);
                using (SqlDataAdapter adtt = new SqlDataAdapter(cmd2))
                {
                    adtt.Fill(dtt);
                }
                label2.Text = dtt.Rows[0].ItemArray[0].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
