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

namespace PPK_Project       //Hapus Anggota
{
    public partial class Form5 : Form
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
            query.CommandText = "select * from anggota where ID_Anggota LIKE '" + textBox1.Text + "%'";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView1.DataSource = data;
            koneksi.Close();
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "delete from anggota where ID_Anggota LIKE '" + textBox1.Text + "%'";
            MessageBox.Show("Anggota sudah dihapus");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Close();
        }
    }
}
