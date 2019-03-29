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

namespace PPK_Project       //Hapus Buku
{
    public partial class Form6 : Form
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
            query.CommandText = "select * from data_buku where Kode_Buku LIKE '" + textBox1.Text + "%'";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView1.DataSource = data;
            koneksi.Close();
        }

        public Form6()
        {
            InitializeComponent();
        }
        //Tombol Hapus
        private void button1_Click_1(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "delete from data_buku where Kode_Buku LIKE '" + textBox1.Text + "%'";
            MessageBox.Show("Buku sudah dihapus");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            koneksi.Close();
        }
        //Tombol Batal
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Close();
        }
    }
}
