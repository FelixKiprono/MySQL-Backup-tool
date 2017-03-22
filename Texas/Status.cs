using MySql.Data.MySqlClient;
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
    public partial class Status : Form
    {
        public Status()
        {
            InitializeComponent();
        }
        void loadDBS()
        {
            try
            {
                string myConnectionString = "SERVER='" + server.Text + "';UID='" + username.Text + "';" + "PASSWORD='" + password.Text + "';";
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SHOW DATABASES;";
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView1.DataSource = dt;
                connection.Close();
                countdb();
            }
            catch(Exception)
            {

            }

        }
        void countdb()
        {
            label7.Text = "No of Databases (" + dataGridView1.Rows.Count+") s ";
            label8.Text = "Connected To : " + server.Text;
        }
        private void Status_Load(object sender, EventArgs e)
        {
            loadDBS();
          
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            loadDBS();
        }

        private void addDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newdb.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            newdb.Visible = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "SERVER='" + server.Text + "';UID='" + username.Text + "';port=3306;" + "PASSWORD='" + password.Text + "';";
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + textBox1.Text + "`;", connection);
                command.ExecuteNonQuery();
                // MessageBox.Show("Texas Created Database : "+textBox1.Text+" Successfully", "Texas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newdb.Visible = false;
                loadDBS();
            }
            catch (Exception)
            {

               
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(MouseButtons.Right == e.Button)
            {
                contextMenuStrip1.Show(MousePosition.X,MousePosition.Y);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "SERVER='" + server.Text + "';UID='" + username.Text + "';port=3306;" + "PASSWORD='" + password.Text + "';";
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("DROP SCHEMA IF EXISTS `" + textBox2.Text + "`", connection);
                command.ExecuteNonQuery();
                loadDBS();
            }
            catch (Exception)
            {

            }
           // MessageBox.Show("Database Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dropDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dropdb.Visible = true;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dropDatabaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row;
                row = this.dataGridView1.SelectedRows[0];
                textBox2.Text = row.Cells[0].Value.ToString();
                dropdb.Visible = true;
            }
            catch (Exception)
            {
                
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            dropdb.Visible = false;
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
