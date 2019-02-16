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
    public partial class usrhomepage : Form
    {
        public usrhomepage()
        {
            InitializeComponent();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id.idd = null;
            main mm = new main();
            mm.Show();
            this.Hide();
        }

        private void vIEWBALANCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewuserbal vbb = new viewuserbal();
            vbb.Show();
        }

        private void vIEWTRANSACTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_user_trans vt = new view_user_trans();
            vt.Show();
        }

        private void pERFORMTRANSACTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perf_trans ptv = new perf_trans();
            ptv.Show();
        }

        private void wITHDRAWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withdraw1 wd = new withdraw1();
            wd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id.idd = null;
            main mm = new main();
            mm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewuserbal vbb = new viewuserbal();
            vbb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            withdraw1 wd = new withdraw1();
            wd.Show();
        }

        private void usrhomepage_Load(object sender, EventArgs e)
        {
           
        }
    }
}
