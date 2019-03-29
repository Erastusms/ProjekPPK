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

namespace PPK_Project       //Edit Buku
{
    public partial class Form9 : Form
    {
        string perpustakaan = "server=localhost; uid=root; pwd=; database=perpus";
        MySqlConnection koneksi;
        MySqlCommand query;

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "select * from data_buku where Kode_Buku LIKE '" + textBox1.Text + "%'";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView1.DataSource = data;
            koneksi.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "update data_buku set " +
                "Judul_Buku = '" + textBox2.Text + "'," +
                "Pengarang = '" + textBox3.Text + "'," +
                "Penerbit = '" + textBox4.Text + "'," +
                "Tahun_Terbit = '" + textBox5.Text + "' " +
                "where Kode_Buku LIKE '" + textBox1.Text + "%'";
            MessageBox.Show("Buku berhasil diedit");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            this.Close();
        }

        public Form9()
        {
            InitializeComponent();
        }
    }
}
