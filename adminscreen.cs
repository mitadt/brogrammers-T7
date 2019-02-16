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
    public partial class adminscreen : Form
    {
        public adminscreen()
        {
            InitializeComponent();
        }

        private void vIEWTRANSACTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //view_trans vt = new view_trans();
            //vt.Show();
        }

        private void vIEWCUSTOMERSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            view_cust vc = new view_cust();
            vc.Show();
        }

        private void aDDNEWCUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer ac = new Customer();
            ac.Show();
        }

        private void vIEWCUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addmoney am = new addmoney();
            //am.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mm = new main();
            mm.Show();
        }

        private void adminscreen_Load(object sender, EventArgs e)
        {

        }
    }
}
