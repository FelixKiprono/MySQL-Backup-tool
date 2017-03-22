using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texas
{
    public partial class Texas : Form
    {
        public Texas()
        {
            InitializeComponent();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Silver;
            panel2.BorderStyle = BorderStyle.None;
            label2.ForeColor = Color.Black;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.None;
            label2.ForeColor = Color.Black;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Backup c = new Backup();
            c.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Silver;
            panel3.BorderStyle = BorderStyle.None;
            label3.ForeColor = Color.White;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            RestoreDb c = new RestoreDb();
            c.ShowDialog();
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.None;
            label3.ForeColor = Color.Black;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Silver;
            panel4.BorderStyle = BorderStyle.None;
            label4.ForeColor = Color.White;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.None;
            label4.ForeColor = Color.Black;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Status ss = new Status();
            ss.ShowDialog();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            /*this.Close();
            Environment.Exit(0);*/
            Exit ex = new Exit();
            ex.ShowDialog();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.None;
            label5.ForeColor = Color.Black;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Silver;
            panel5.BorderStyle = BorderStyle.None;
            label5.ForeColor = Color.White;
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tm = DateTime.Today;
            label10.Text = "Today : " + DateTime.Now.ToString();
        }

        private void Texas_Load(object sender, EventArgs e)
        {
            label9.Text = "Machine Name : "+Environment.UserDomainName.ToString();
        }
    }
}
