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
    public partial class Form5 : Form
    {
        FunctionClass p = new FunctionClass();
        private string defaultQuery;

        private void Logout()
        {
            p.command("insert into log (id_user, nama, activity, created_at) VALUES ('" + FunctionClass.id_user + "', 'Logout' , NOW())");
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        public Form5()
        {
            InitializeComponent();
            defaultQuery = "SELECT l.id, l.id_user, u.nama, u.role, l.activity, l.created_at " + "FROM log " + "JOIN users u ON l.id_user = u.id";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            p.showData("SELECT * FROM log", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
