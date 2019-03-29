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

namespace PPK_Project       //Hapus Peminjam
{
    public partial class Form7 : Form
    {
        string perpustakaan = "server=localhost; uid=root; pwd=; database=perpus";
        MySqlConnection koneksi;
        MySqlCommand query;

        //Pencarian
        private void button3_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "select * from peminjaman where Kode_Pinjam LIKE '" + textBox1.Text + "%'";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView1.DataSource = data;
            koneksi.Close();
        }

        public Form7()
        {
            InitializeComponent();
        }
        //Tombol Hapus
        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "delete from peminjaman where Kode_Pinjam LIKE '" + textBox1.Text + "%'";
            MessageBox.Show("Peminjam sudah dihapus");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            koneksi.Close();
        }
        //Tombol Batal
        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Close();
        }
    }
}
