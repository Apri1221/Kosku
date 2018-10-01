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
    public partial class Form5 : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=apriyanto12;database=sistem_kos;SslMode=none;convert zero datetime=true;allow user variables=true";

        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        public Form5()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "INSERT INTO tabel_fasilitas(no_kamar, ukuran_kamar, tipe_kamar, kmLuar_dalam, meja, kursi, lemari, televisi, ac)" +
                    "VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "' , '" + textBox6.Text + "' , '" + textBox7.Text + "' , '" + textBox8.Text + 
                    "' , '" + textBox9.Text + "') ";

                
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


        private void button2_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                String query = "SELECT tabel_fasilitas.* FROM tabel_kamar JOIN tabel_fasilitas ON tabel_fasilitas.no_kamar = tabel_kamar.no_kamar ORDER BY tabel_kamar.no_kamar ASC";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8) };
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
            textBox1.Text = item.SubItems[0].Text;
            textBox2.Text = item.SubItems[1].Text;
            textBox3.Text = item.SubItems[2].Text;
            textBox4.Text = item.SubItems[3].Text;
            textBox5.Text = item.SubItems[4].Text;
            textBox6.Text = item.SubItems[5].Text;
            textBox7.Text = item.SubItems[6].Text;
            textBox8.Text = item.SubItems[7].Text;
            textBox9.Text = item.SubItems[8].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                String id = item.SubItems[0].Text;
                String ukuran_kamar = textBox2.Text;
                String tipe_kamar = textBox3.Text;
                String kamar_mandi = textBox4.Text;
                String meja = textBox5.Text;
                String kursi = textBox6.Text;
                String lemari = textBox7.Text;
                String televisi = textBox8.Text;
                String ac = textBox9.Text;


                String query = "UPDATE tabel_fasilitas SET ukuran_kamar ='" + ukuran_kamar + "',tipe_kamar ='" + tipe_kamar + "',kmLuar_dalam ='" + kamar_mandi + "',meja ='" + meja + "',kursi ='" + kursi + "',lemari ='" + lemari + "',televisi ='" + televisi + "',ac ='" + ac + "' WHERE no_kamar = " + id;
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Kamar sukses diupdate");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                String id = item.SubItems[0].Text;
                String query = "DELETE FROM tabel_fasilitas WHERE no_kamar = " + id;
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
    }
}
