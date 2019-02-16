using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace fingerpriintbasedatm
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (textBox1.Text == "")
            {
                MessageBox.Show("All Fields Mandatory");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("All Fields Mandatory");
            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (SqlCommand cmd = new SqlCommand("select * from admin_master where username=@username and password=@password", dbconnection.conn))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminscreen ass = new adminscreen();
                        ass.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Data");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            main mm = new main();
            mm.Show();
            this.Hide();
        }
    }
}
