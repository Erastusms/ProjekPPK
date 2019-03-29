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

namespace PPK_Project
{
    public partial class Form1 : Form
    {
        string perpustakaan = "server=localhost; uid=root; pwd=; database=perpus";
        MySqlConnection koneksi;
        MySqlCommand query;
        
        public void Daftar_Peminjam()
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "select anggota.ID_Anggota,anggota.Nama,anggota.No_KTP,anggota.Alamat,anggota.No_HP," +
                "data_buku.Kode_Buku,data_buku.Judul_Buku,data_buku.Pengarang,peminjaman.Tgl_Pinjam,peminjaman.Tgl_Kembali " +
                    "from peminjaman " +
                    "join anggota on peminjaman.ID_Anggota=anggota.ID_Anggota " +
                    "join data_buku on peminjaman.Kode_Buku=data_buku.Kode_Buku";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView1.DataSource = data;
            koneksi.Close(); 
        }

        public void Data_Buku()
        {
            koneksi = new MySqlConnection(perpustakaan);        //rancangan jembatan
            koneksi.Open();                                     //membuka koneksi
            query = new MySqlCommand();                         //membuat MySqlcommand dengan nama query
            query.Connection = koneksi;                         //query menggunakan koneksi "koneksi"
            query.CommandType = CommandType.Text;               //query bertipe text
            query.CommandText = "select * from data_buku";      //mendeklarasikan isi perintah query
            MySqlDataAdapter dt = new MySqlDataAdapter(query);  //membuat data adapter dengan nama dt
            DataTable data = new DataTable();
            dt.Fill(data);                                      //mengisi data adapter dengan isi data di tabel
            dataGridView2.DataSource = data;                    //mendeklarasikan data member dengan data_buku
            koneksi.Close();                                    //menutup koneksi
        }   

        public void Data_Anggota()
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "select * from anggota";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data); 
            dataGridView3.DataSource = data;
            koneksi.Close();
        }

        public void Data_Peminjam()
        {
            koneksi = new MySqlConnection(perpustakaan);
            koneksi.Open();
            query = new MySqlCommand();
            query.Connection = koneksi;
            query.CommandType = CommandType.Text;
            query.CommandText = "select * from peminjaman";
            MySqlDataAdapter dt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            dt.Fill(data);
            dataGridView4.DataSource = data;
            koneksi.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        

        //label
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Tambah Anggota
        private void anggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        //Tambah Buku
        private void bukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        //Tambah Peminjam
        private void peminjamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
        //Hapus Anggota
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
        //Hapus Buku
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }
        //Hapus Peminjam
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }
        //Edit Anggota
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }
        //Edit Buku
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }
        //Edit Peminjam
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Daftar_Peminjam();
            Data_Anggota();
            Data_Buku();
            Data_Peminjam();
        }
    }
}
