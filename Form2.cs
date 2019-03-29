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

namespace PPK_Project       //Tambah Anggota
{
    public partial class Form2 : Form
    {
        string perpustakaan = "server=localhost; uid=root; pwd=; database=perpus";
        MySqlConnection koneksi;
        MySqlCommand query;
        
        private void button1_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = koneksi.CreateCommand();
            query.CommandText = "insert into anggota values (@textBox1,@textBox2,@textBox3,@textBox4,@textBox5)";
            query.Parameters.AddWithValue("@textBox1", textBox1.Text);
            query.Parameters.AddWithValue("@textBox2", textBox2.Text);
            query.Parameters.AddWithValue("@textBox3", textBox3.Text);
            query.Parameters.AddWithValue("@textBox4", textBox4.Text);
            query.Parameters.AddWithValue("@textBox5", textBox5.Text);
            MessageBox.Show("Anggota sukses ditambahkan");
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
            Form2 f2 = new Form2();
            this.Close();
        }

        public Form2()
        {
            InitializeComponent();
        }       
    }
}
