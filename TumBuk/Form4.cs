using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TumBuk
{
    public partial class Form4 : Form
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
        public Form4()
        {
            InitializeComponent();
        }
       
        void clear()
        {
            username.Text = string.Empty;
            password.Text = string.Empty;
            namaLengkap.Text = string.Empty;
            role.SelectedItem =null;
            p.showData("Select * from users", dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            username.Text = dr.Cells[1].Value.ToString();
            password.Text = dr.Cells[2].Value.ToString();
            namaLengkap.Text = dr.Cells[3].Value.ToString();
            role.SelectedItem = dr.Cells[4].Value.ToString();
            id = dr.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            if (username.Text == string.Empty || password.Text == string.Empty || namaLengkap.Text == string.Empty || role.SelectedItem == null)
            {
                MessageBox.Show("Semua kolom harus diisi!");
            }
            else
            {
                p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Menambahkan User', NOW())");
                string query = "INSERT INTO users ( username, password, nama, role, created_at) VALUES ( '" + username.Text + "', '" + password.Text + "', '" + namaLengkap.Text + "', '" + role.SelectedItem + "', NOW() )";
                p.command(query);
                clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Melakukan Perubahan Pada User', NOW())");
            if (username.Text == string.Empty || password.Text == string.Empty || namaLengkap.Text == string.Empty || role.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                p.command("update users set username = '" + username.Text + "', password = '" + password.Text + "', nama = '" + namaLengkap.Text + "', role = '" + role.Text + "', updated_at = NOW() where id = '" + id + "' ");
                clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p.command("insert into log (id_user, activity, created_at) VALUES('" + FunctionClass.id_user + "', 'Admin Menghapus User', NOW())");
            if (username.Text == string.Empty || password.Text == string.Empty || namaLengkap.Text == string.Empty || role.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                p.command("delete from users where username = '" + username.Text +  "'");
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beranda_admin beranda_admin = new beranda_admin();
            beranda_admin.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            clear();
            p.getDatarole(role);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Anda Yakin Ingin Keluar?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                Logout();
            }
        }

        private void role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
