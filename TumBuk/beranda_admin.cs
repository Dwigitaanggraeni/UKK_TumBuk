using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TumBuk
{
    public partial class beranda_admin : Form
    {
        string id;
        FunctionClass p = new FunctionClass();

        private void Logout()
        {
            p.command("insert into log (id_user , activity, created_at) VALUES ('" + FunctionClass.id_user + "', 'Logout' , NOW())");
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        void clear()
        {
            txtuniq.Text = string.Empty;
            JudulBuku.Text = string.Empty;
            JumlahBuku.Text = string.Empty;
            HargaSatuan.Text = string.Empty;
            p.showData("Select * from products", kelola_produk);
        }

        public beranda_admin()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Menambahkankan Data Produk', NOW())");
            if (txtuniq.Text == string.Empty || JudulBuku.Text == string.Empty || JumlahBuku.Text == string.Empty || HargaSatuan.Text == string.Empty)            {
                MessageBox.Show("Semua kolom harus diisi!");
            }
            else
            {
                string query = "INSERT INTO products (kode_produk, nama_produk, jumlah_produk, harga_satuan, created_at) VALUES ( '" + txtuniq.Text + "', '" + JudulBuku.Text + "', '" + JumlahBuku.Text + "', '" + HargaSatuan.Text + "', NOW() )";
                p.command(query);
                clear();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Menghapus Produk', NOW())");
                if (txtuniq.Text == string.Empty ||  JudulBuku.Text == string.Empty || JumlahBuku.Text == string.Empty || HargaSatuan.Text == string.Empty)
    {
                    MessageBox.Show("semua kolom harus di isi!");
                }
    else
                {
                    p.command("delete from products where kode_produk = '" + txtuniq.Text + "'");
                    clear();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Merubah Data Produk', NOW())");
            if (txtuniq.Text == string.Empty || JudulBuku.Text == string.Empty || JumlahBuku.Text == string.Empty || HargaSatuan.Text == string.Empty)

            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                p.command("UPDATE products SET kode_produk = '" + txtuniq.Text + "', nama_produk = '" + JudulBuku.Text + "', jumlah_produk = '" + JumlahBuku.Text + "', harga_satuan = '" + HargaSatuan.Text + "', updated_at = NOW() WHERE id = '" + id + "'");
                clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.kelola_produk.Rows[e.RowIndex];

            txtuniq.Text = dr.Cells[1].Value.ToString();
            JudulBuku.Text = dr.Cells[2].Value.ToString();
            JumlahBuku.Text = dr.Cells[3].Value.ToString();
            HargaSatuan.Text = dr.Cells[4].Value.ToString();
            id = dr.Cells[0].Value.ToString();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void beranda_admin_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beranda_admin beranda_admin = new beranda_admin();
            beranda_admin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                Logout();
            }
        }
    }
}
