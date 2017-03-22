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
   
    public partial class Backup : Form
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            getDatabases();
        }
        public void getDatabases()
        {


            try
            {

                string myConnectionString = "SERVER='" + server.Text + "';UID='" + username.Text + "';" + "PASSWORD='" + password.Text + "';";
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SHOW DATABASES;";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                        row += Reader.GetValue(i).ToString() + " ";
                    databases.Items.Add(row);
                }
                connection.Close();
            }
            catch (Exception)
            {
            }



        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            databases.Items.Clear();

            getDatabases();
        }

        private void databases_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbname.Text = databases.Text;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {

                folder.Text = f.SelectedPath + "\\" + dbname.Text + ".sql";
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (server.Text == "" || username.Text == "" || dbname.Text == "" || folder.Text == "")
            {
                MessageBox.Show("Error Some Values Missing Please Fill All Parameters", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    Application.DoEvents();
                    backUp();
                }
                catch (UnauthorizedAccessException aue)
                {
                    Console.Write(aue.ToString());
                }
            }
        }

        private void backUp()
        {
            string file = folder.Text;
            string servername = server.Text;
            string user = username.Text;
            string pass = password.Text;
            string db = dbname.Text;
            string path = "server=" + servername + ";user=" + user + ";pwd=" + pass+ ";database=" + db + ";";
            conn = new MySqlConnection(path);
            cmd = new MySqlCommand();
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = conn;
                conn.Open();
               // progressBar1.Value = progressBar1.Value + 1;

                mb.ExportToFile(file);
                conn.Close();
                MessageBox.Show("Texas Successfully Completed Backup", "Texas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // groupBox1.Visible = true;
            }

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
