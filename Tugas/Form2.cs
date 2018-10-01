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
    public partial class Form2 : Form
    {
<<<<<<< HEAD
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistem_kos;SslMode=none";
=======
        private Form3 frm3;

        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=apriyanto12;database=sistem_kos;SslMode=none;convert zero datetime=true;allow user variables=true";
>>>>>>> 1af777046da2b9fe1c15761ac99d0f456a63c022

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            try
            {
                String query = "SELECT tabel_sewa.*, tabel_fasilitas.ukuran_kamar FROM tabel_sewa JOIN tabel_fasilitas ON tabel_sewa.no_kamar = tabel_fasilitas.no_kamar ORDER BY tabel_sewa.no_kamar ASC";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) };
                        var listViewItem = new ListViewItem(row);
                        listView2.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Ada");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

<<<<<<< HEAD
=======
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            frm3.Show();
        }
>>>>>>> 1af777046da2b9fe1c15761ac99d0f456a63c022
    }
}
