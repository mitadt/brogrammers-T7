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
    public partial class addmoney : Form
    {
        public addmoney()
        {
            InitializeComponent();
        }

        private void addmoney_Load(object sender, EventArgs e)
        {
            //dbconnection.conn.Open();
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            using (SqlCommand cmd1 = new SqlCommand("select name_,balance_ from user_master where account_no=@account_no", dbconnection.conn))
            {
                cmd1.Parameters.AddWithValue("@account_no", comboBox1.SelectedValue);
                using (SqlDataAdapter add = new SqlDataAdapter(cmd1))
                {
                    add.Fill(dt1);
                }
                if (dt1.Rows.Count > 0)
                {
                    textBox1.Text = dt1.Rows[0].ItemArray[0].ToString();
                    textBox2.Text = dt1.Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    MessageBox.Show("NO USER EXIST");
                }
            }
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int current_bal;
                int new_bal;
                if (textBox2.Text == "")
                {
                    current_bal = 0;
                }
                else
                {
                    current_bal = Convert.ToInt32(textBox2.Text);
                }
                if (textBox3.Text == "")
                {
                    new_bal = 0;
                }
                else
                {
                    new_bal = Convert.ToInt32(textBox3.Text);
                }


                int updated_bal = current_bal + new_bal;

                using (SqlCommand cmdd = new SqlCommand("update user_master set balance_=@balance_ where account_no=@account_no", dbconnection.conn))
                {
                    //balance_,account_no
                    cmdd.Parameters.AddWithValue("@balance_", updated_bal);
                    cmdd.Parameters.AddWithValue("@account_no", comboBox1.SelectedValue);
                    cmdd.ExecuteNonQuery();
                    //dbconnection.conn.Close();
                    MessageBox.Show("BALANCE UPDATED!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOMETHING WENT WRONG");
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
