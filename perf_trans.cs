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
    public partial class perf_trans : Form
    {
        public perf_trans()
        {
            InitializeComponent();
        }

        private void perf_trans_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("select account_no from user_master", dbconnection.conn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "account_no";
                comboBox1.DisplayMember = "account_no";
                comboBox1.Text = "--SELECT--";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                        cmd1.ExecuteNonQuery();
                       
                        
                    }
                    DataTable dc2 = new DataTable();
                    using (SqlCommand cmd2 = new SqlCommand("select balance_ from user_master where account_no=@account_no", dbconnection.conn))
                    {
                        cmd2.Parameters.AddWithValue("@account_no", comboBox1.SelectedValue);
                        using (SqlDataAdapter adt = new SqlDataAdapter(cmd2))
                        {
                            adt.Fill(dc2);
                        }
                    }
                    int receiver_amount = Convert.ToInt32(dc2.Rows[0].ItemArray[0]);
                    int amt_update = receiver_amount + transfer_amt;
                    using (SqlCommand cmd3 = new SqlCommand("update user_master set balance_=@balance_ where account_no=@account_no", dbconnection.conn))
                    {
                        cmd3.Parameters.AddWithValue("@account_no", comboBox1.SelectedValue);
                        cmd3.Parameters.AddWithValue("@balance_", amt_update);
                        cmd3.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd4 = new SqlCommand("select balance_ from user_master where id=@id", dbconnection.conn))
                    {
                        DataTable dtt = new DataTable();
                        cmd4.Parameters.AddWithValue("@id", id.idd);
                        using (SqlDataAdapter adtt = new SqlDataAdapter(cmd4))
                        {
                            adtt.Fill(dtt);
                        }
                        label2.Text = dtt.Rows[0].ItemArray[0].ToString();
                    }
                    using (SqlCommand cmd5 = new SqlCommand("insert into transaction_master(sender_id,account_no,amount_) values(@sender_id,@account_no,@amount_)", dbconnection.conn))
                    {
                        //@sender_id,@account_no,@amount_
                        cmd5.Parameters.AddWithValue("@sender_id", id.idd);
                        cmd5.Parameters.AddWithValue("@account_no",comboBox1.SelectedValue);
                        cmd5.Parameters.AddWithValue("@amount_",textBox1.Text);
                        cmd5.ExecuteNonQuery();
                    }
                    MessageBox.Show("MONEY TRANSFER SUCCESSFUl!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SomeThing Went Wrong!!");
            }
        }
    }
}
