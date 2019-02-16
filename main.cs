using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fingerpriintbasedatm
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminlogin algn = new adminlogin();
            algn.Show();
            this.Hide();
        }

        private void main_Load(object sender, EventArgs e)
        {
            dbconnection.conn.Close();
            dbconnection.conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MerchantLogin mul = new MerchantLogin();
            mul.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminlogin algn = new adminlogin();
            algn.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MerchantLogin mul = new MerchantLogin();
            mul.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
