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
    public partial class RestoreDb : Form
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        public RestoreDb()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            catch(Exception )
            {

            }


        }
        private void RestoreDb_Load(object sender, EventArgs e)
        {
            getDatabases();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            databases.Items.Clear();
            getDatabases();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            server.Text = "";
            username.Text = "";
            password.Text = "";
            dbname.Text = "";
            folder.Text = "";
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select SQL  Database File.";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    folder.Text = op.FileName;
                }
            }
            catch (Exception)
            {
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (server.Text == "" || username.Text == "" || dbname.Text == "" || folder.Text == "")
            {
                MessageBox.Show("Texas Says : Error Some Values Missing Please Enter Details", "Texas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    Restore();
                    label9.Text = "Uploaded File : " + folder.Text;
                    label10.Text = "Host Database : " + dbname.Text;
                }
                catch (UnauthorizedAccessException aue)
                {
                    Console.Write(aue.ToString());
                }
            }
        }

        private void Restore()
        {
            string file = folder.Text;
            string servername = server.Text;
            string user = username.Text;
            string pass = password.Text;
            string db = dbname.Text;
            string path = "server=" + servername + ";user=" + user + ";pwd=" + pass + ";database=" + db + ";";
            using (conn = new MySqlConnection(path))
            {
                using (cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                        MessageBox.Show("Texas Has Completed Database Upload Successfully", "Texas ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void databases_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbname.Text = databases.Text;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
