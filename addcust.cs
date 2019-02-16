using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.IO.Ports;


namespace fingerpriintbasedatm
{
    public partial class addcust : Form
    {
        static int i = 0;
        static string status = "true";
        public addcust()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                string account_no = this.Encrypt(textBox2.Text);
                using (SqlCommand cmd1 = new SqlCommand("select * from user_master where account_no=@account_no", dbconnection.conn))
                {
                    cmd1.Parameters.AddWithValue("@account_no", account_no);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd1))
                    {
                        adp.Fill(dt);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    using (SqlCommand cmd = new SqlCommand("insert into user_master(name_, email_id, phone_no, aadhar_card_no, pancard_no,account_no,balance_) values(@name_, @email_id, @phone_no, @aadhar_card_no, @pancard_no,@account_no,@balance_)", dbconnection.conn))
                    {//name_, email_id, phone_no, aadhar_card_no, pancard_no
                        cmd.Parameters.AddWithValue("@name_", textBox1.Text);
                        cmd.Parameters.AddWithValue("@email_id", textBox2.Text);
                        cmd.Parameters.AddWithValue("@phone_no", textBox3.Text);
                        cmd.Parameters.AddWithValue("@aadhar_card_no", textBox4.Text);
                        cmd.Parameters.AddWithValue("@pancard_no", textBox5.Text);
                        cmd.Parameters.AddWithValue("@account_no", account_no);
                        // cmd.Parameters.AddWithValue("@bank_name", comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@balance_", textBox6.Text);
                        //balance_
                        //bank_name
                        //account_no
                        dbconnection.conn.Open();
                        cmd.ExecuteNonQuery();
                        dbconnection.conn.Close();
                        MessageBox.Show("ADDED SUCCESSFULLY!!");
                        //dbconnection.conn.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        i++;
                        // comboBox1.Text = "--SELECT--";
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unable to save");
                    //    //Interaction.MsgBox("Unable to save", MsgBoxStyle.Critical, "Information");
                    //}
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save");
                // Interaction.MsgBox("Unable to save", MsgBoxStyle.Critical, "Information");
            }

            //SerialPort ports = default(SerialPort);
            //try
            //{
            //    //if (i > 0)
            //    //{
            //    //    ports.Close();
            //    //}
            //    //ports.Close();
            //    ports = new SerialPort("COM39", 9600, Parity.None, 8, StopBits.One);
            //    ports.Handshake = Handshake.None;
            //    ports.DataReceived += DataReceivedHandler;
            //    ports.ReadTimeout = 500;
            //    ports.WriteTimeout = 500;
            //    ports.Open();
            //    // Dim buffer As Byte()
            //    ports.Write("@;1;" + label6.Text + ";^");
            //}


            ////}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("SOMETHING WENT WRONG!!");
            //    ports.Close();
            //    status = "false";
            //    //textBox1.Text = "";
            //    //textBox2.Text = "";
            //    //textBox3.Text = "";
            //    //textBox4.Text = "";
            //    //textBox5.Text = "";
            //    //textBox6.Text = "";
            //    //comboBox1.Text = "--SELECT--";
            //}
            //finally
            //{
            //    // ports.Close();
            //}
            //DataTable ddv = new DataTable();
            //using (SqlCommand cmdd = new SqlCommand("select top 1 id from user_master order by id desc", dbconnection.conn))
            //{
            //    using (SqlDataAdapter adp = new SqlDataAdapter(cmdd))
            //    {
            //        adp.Fill(ddv);
            //    }
            //    if (ddv.Rows.Count > 0)
            //    {
            //        int idd = Convert.ToInt32(ddv.Rows[0].ItemArray[0]);
            //        idd = idd + 1;
            //        label6.Text = idd.ToString();
            //    }
            //    else
            //    {
            //        label6.Text = "1";
            //    }
            //    //comboBox1.DataSource = dt;
            //    // comboBox1.ValueMember = "bank_name";
            //    // comboBox1.DisplayMember = "bank_name";
            //    //  comboBox1.Text = "--SELECT--";

        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private void addcust_Load(object sender, EventArgs e)
        {
            dbconnection.conn.Close();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            DataTable dt = new DataTable();
            using (SqlCommand cmdd = new SqlCommand("select top 1 id from user_master order by id desc", dbconnection.conn))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(cmdd))
                {
                    adp.Fill(dt);
                }
                if (dt.Rows.Count > 0)
                {
                    int idd = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                    idd = idd + 1;
                    label6.Text = idd.ToString();
                }
                else
                {
                    label6.Text = "1";
                }
                //SerialPort ports = default(SerialPort);
                //ports.Open();
                //ports.Close();
                //comboBox1.DataSource = dt;
                // comboBox1.ValueMember = "bank_name";
                // comboBox1.DisplayMember = "bank_name";
                //  comboBox1.Text = "--SELECT--";
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            System.Threading.Thread.Sleep(200);
            string indata = sp.ReadExisting();
            if (indata.Equals("#;1;1;"))
            {
                // This is true
                // SetCheckbox(true);
                chkFinger.Checked = true;
                MessageBox.Show("MATCHED");
            }
            else if (indata.Equals("#;1;3;"))
            {
                // this is not done
                //SetCheckbox(false);
                chkFinger.Checked = false;
                MessageBox.Show("NOT MATCHED");
            }
        }
        private void txtReadFinger_Click(object sender, EventArgs e)
        {
            SerialPort ports = default(SerialPort);
            try
            {
                //if (i > 0)
                //{
                //    ports.Close();
                //}
                //ports.Close();
                ports = new SerialPort("COM39", 9600, Parity.None, 8, StopBits.One);
                ports.Handshake = Handshake.None;
                ports.DataReceived += DataReceivedHandler;
                ports.ReadTimeout = 500;
                ports.WriteTimeout = 500;
                ports.Open();
                // Dim buffer As Byte()
                ports.Write("@;1;" + label6.Text + ";^");
            }


            //}
            catch (Exception ex)
            {
                MessageBox.Show("SOMETHING WENT WRONG!!");
                //ports.Close();
                //status = "false";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                //comboBox1.Text = "--SELECT--";
            }
            //ports.Write(string.Format("@;1;{0};^", sId));
        }

        private void chkFinger_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
