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

namespace PPK_Project       //Edit Pinjaman
{
    public partial class Form10 : Form
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
            query.CommandText = "select * from Peminjaman where Kode_Pinjam LIKE '" + textBox1.Text + "%'";
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
            query.CommandText = "update peminjaman set " +
                "ID_Anggota = '" + textBox2.Text + "'," +
                "Kode_Buku= '" + textBox3.Text + "'," +
                "Tgl_Pinjam = '" + dateTimePicker1.Value + "'," +
                "Tgl_Kembali = '" + dateTimePicker2.Value + "' " +
                "where Kode_Pinjam LIKE '" + textBox1.Text + "%'";
            MessageBox.Show("Buku berhasil diedit");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Close();
        }

        public Form10()
        {
            InitializeComponent();
        }
    }
}
