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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=apriyanto12;database=sistem_kos;SslMode=none;convert zero datetime=true;allow user variables=true";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                String query = "SELECT * FROM tabel_sewa";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada kamar");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime masuk = dateTimePicker1.Value;
            DateTime keluar = dateTimePicker2.Value;
            try
            {
                String query = "INSERT INTO tabel_sewa(no_kamar, nama_penghuni, tanggal_masuk, tanggal_keluar, pelunasan)" +
                    "VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + masuk.ToString("yyyy-MM-dd H:mm:ss") + "' , '"
                    + keluar.ToString("yyyy-MM-dd H:mm:ss") + "' , '" + textBox4.Text + "') ";

                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Berhasil Menambahkan Data");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
            textBox1.Text = item.SubItems[0].Text;
            textBox2.Text = item.SubItems[1].Text;
            dateTimePicker1.Text = item.SubItems[2].Text;
            dateTimePicker2.Text = item.SubItems[3].Text;
            textBox4.Text = item.SubItems[4].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                String id = item.SubItems[0].Text;
                String query = "DELETE FROM tabel_sewa WHERE no_kamar = " + id;
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Data sukses dihapus");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                String id = item.SubItems[0].Text;
                String nama_penghuni = textBox2.Text;
                DateTime masuk = dateTimePicker1.Value;
                DateTime keluar = dateTimePicker2.Value;
                String pelunasan = textBox4.Text;

                String query = "UPDATE tabel_sewa SET nama_penghuni='" + nama_penghuni + "',tanggal_masuk='" + masuk.ToString("yyyy-MM-dd H:mm:ss") + "',tanggal_keluar ='" + keluar.ToString("yyyy-MM-dd H:mm:ss") +  "' WHERE no_kamar = " + id;
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("User sukses diupdate");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
