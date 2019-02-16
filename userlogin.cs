using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;

namespace fingerpriintbasedatm
{

    public partial class userlogin : Form
    {
        public userlogin()
        {
            InitializeComponent();
        }
        SerialPort ports = default(SerialPort);
        private void button1_Click(object sender, EventArgs e)
        {
            //ports.Close();
            ports = new SerialPort("COM39", 9600, Parity.None, 8, StopBits.One);
            ports.Handshake = Handshake.None;
            ports.DataReceived += DataReceivedHandler;
            ports.ReadTimeout = 800;
            ports.WriteTimeout = 800;
            ports.Open();
            ports.Write("@;2;1;^");

            //usrhomepage uh = new usrhomepage();
            //uh.Show();
            //this.Hide();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();
                string[] strArr = new string[4];
                ports.Close();
                //strArr = indata.Split(";");
                strArr = indata.Split(';');
                using (SqlCommand cnd = new SqlCommand("select * from user_master where id=@id", dbconnection.conn))
                {
                    DataTable dt = new DataTable();
                    cnd.Parameters.AddWithValue("@id", strArr[3]);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cnd))
                    {
                        adp.Fill(dt);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        // this.Hide();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(AccessControl));
                        }
                        //usrhomepage uh = new usrhomepage();
                        //uh.Show();

                        id.idd = dt.Rows[0].ItemArray[0].ToString();
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Fingerprint Not Match");
                        //main ms = new main();
                        //ms.Show();
                        //this.Close();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(AccessControl1));
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fingerprint Not Match");
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(AccessControl1));
                }
            }
        }

        private void userlogin_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void AccessControl()
        {
            this.Hide();
            usrhomepage uh = new usrhomepage();
            uh.Show();
        }
        private void AccessControl1()
        {
            main ms = new main();
            ms.Show();
            this.Close();
        }

    }
}
