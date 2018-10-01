using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tugas
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistem_kos;SslMode=none";
=======
        private Form2 frm2;
<<<<<<< HEAD
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistem_kos;SslMode=none";
=======
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=apriyanto12;database=sistem_kos;SslMode=none";
>>>>>>> 1f9a794b387538080b39c4930f0915eb193bdf94
>>>>>>> d6a9e2e09ae66b72fffa021ad54f4ae8ab32f226

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                String query = "SELECT * FROM tabel_admin WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    this.Hide();
                    frm2 = new Form2();
                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Tidak ada user yang dimaksud");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
