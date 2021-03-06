﻿using System;
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
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=apriyanto12;database=sistem_kos;SslMode=none";
        private Form1 frm1;
        private Form3 frm3;
        private Form5 frm5;

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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            frm3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();

            try
            {
                String query = "SELECT * FROM tabel_kamar";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                        var listViewItem = new ListViewItem(row);
                        listView3.Items.Add(listViewItem);
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
        

        private void button8_Click(object sender, EventArgs e)
        {
            
            try
            {
                String query = "INSERT INTO tabel_kamar(no_kamar, ketersediaan, harga) VALUES ('" + tbNo_Kamar.Text + "' , '" + textBox1.Text + "' , '"+ tbHarga_Kamar.Text + "') ";

                String query2 = "INSERT INTO tabel_fasilitas(no_kamar, ukuran_kamar, tipe_kamar, kmLuar_dalam, meja, kursi, lemari, televisi, ac) VALUES ('" + tbNo_Kamar.Text + "' , ' ' , ' ', ' ', '0', '0', '0', '0', '0') ";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Berhasil Menambahkan Data");

                databaseConnection.Close();

                commandDatabase = new MySqlCommand(query2, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();

            try
            {
                String query = "SELECT * FROM tabel_fasilitas";
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
                        listView4.Items.Add(listViewItem);
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

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                String query = "SELECT tabel_fasilitas.* FROM tabel_fasilitas JOIN tabel_kamar ON tabel_fasilitas.no_kamar = tabel_kamar.no_kamar WHERE tabel_kamar.ketersediaan = 0 ORDER BY tabel_fasilitas.no_kamar ASC";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm5 = new Form5();
            frm5.Show();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView3.SelectedItems[0];
            tbNo_Kamar.Text = item.SubItems[0].Text;
            textBox1.Text = item.SubItems[1].Text;
            tbHarga_Kamar.Text = item.SubItems[2].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                String id = tbNo_Kamar.Text;
                String query = "DELETE FROM tabel_kamar WHERE no_kamar = " + id;
                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Data sukses dihapus");
                databaseConnection.Close();

                String query2 = "DELETE FROM tabel_fasilitas WHERE no_kamar = " + id;
                commandDatabase = new MySqlCommand(query2, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            this.Close();
            frm1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            this.Close();
            frm1.Show();
        }
    }
}
