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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                DataTable dt = new DataTable();
                //string account_no = this.Encrypt(textBox2.Text);
                using (SqlCommand cmd1 = new SqlCommand("select * from add_cust where accnumber=@accnumber", dbconnection.conn))
                {
                    cmd1.Parameters.AddWithValue("@accnumber", textBox2.Text);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd1))
                    {
                        adp.Fill(dt);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    using (SqlCommand cmd = new SqlCommand("insert into add_cust(name,accnumber,phonenb,EmailId,AdharNb,amount) values(@name,@acc, @phone,@email, @AdharNb,@amount )", dbconnection.conn))
                    {//name_, email_id, phone_no, aadhar_card_no, pancard_no
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@acc", textBox2.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                        cmd.Parameters.AddWithValue("@AdharNb", textBox4.Text);
                        cmd.Parameters.AddWithValue("@email", textBox5.Text);
                        cmd.Parameters.AddWithValue("@amount",textBox6.Text);
                        
                        
                        

                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("ADDED SUCCESSFULLY!!");
                       
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                       
                        
                    }
                   
                    this.Close();
                }
            }
           
        }
    }

