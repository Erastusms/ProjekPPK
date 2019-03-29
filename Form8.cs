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

namespace PPK_Project       //Edit Anggota
{
    public partial class Form8 : Form
    {
        string perpustakaan = "server=localhost; uid=root; pwd=; database=perpus";
        MySqlConnection koneksi;
        MySqlCommand query;

        public Form8()
        {
            InitializeComponent();
        }
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
        //Tombol Edit
        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "update anggota set " +
                "Nama = '" + textBox2.Text + "'," +
                "No_KTP = '" + textBox3.Text + "'," +
                "Alamat = '" + textBox4.Text + "'," +
                "No_HP = '" + textBox5.Text + "' " +
                "where ID_Anggota = " + textBox1.Text;
            MessageBox.Show("Anggota berhasil diedit");
            query.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            koneksi.Close();
        }
        //Tombol Bata
        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Close();
        }
    }
}
