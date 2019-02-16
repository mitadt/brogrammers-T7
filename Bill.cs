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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
            using(SqlCommand cmd=new SqlCommand("select items,price  from item ",dbconnection.conn))
            {
                using (SqlDataAdapter adp=new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "items";
                    comboBox1.ValueMember = "price";

                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String status = comboBox1.SelectedText;
           using(SqlCommand cmd=new SqlCommand("insert into bill (price,items) values(@price,@items) ",dbconnection.conn))
           { 
             cmd.Parameters.AddWithValue ("@items",comboBox1.GetItemText(comboBox1.SelectedItem)); 
               
               cmd.Parameters.AddWithValue("@price",comboBox1.SelectedValue);
              
               cmd.ExecuteNonQuery();
              
               
           }
               
               
                
            }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select* from bill", dbconnection.conn))
            {
                cmd.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
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

        private void button3_Click(object sender, EventArgs e)
        {
            payment p1 = new payment();
            p1.Show();
                

            }

        }

       

    }

 