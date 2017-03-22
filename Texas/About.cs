using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texas
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/leexy.lee.7");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitter.com/greencodemaster");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/felixkiptoo");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Whatsapp Number : \n Safaricom : 0717860458 \n Orange : 0776474372");
           // Process.Start("https://www.facebook.com/leexy.lee.7");
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
