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
    public partial class transaksi : Form
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

        public transaksi()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
