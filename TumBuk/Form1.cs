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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TumBuk
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=db_tumbuk");
        FunctionClass p = new FunctionClass();
        void login()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * From users WHERE username='" + username.Text + "'AND password='" + password.Text + "'", conn);
                DataTable dt = new DataTable(); 
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        FunctionClass.role = dr["role"].ToString();
                        FunctionClass.id_user = dr ["id"].ToString();


                        p.command("insert into log (id_user,  activity, created_at) VALUES('" + FunctionClass.id_user + "', 'login', NOW())");
                        MessageBox.Show("Login Sukses !", "informasi",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (FunctionClass.role == "admin")
                        {
                            this.Hide();
                            new beranda_admin().Show();
                        }
                        else if (FunctionClass.role == "kasir")
                        {
                            this.Hide();
                            new transaksi().Show();
                        }
                        else if (FunctionClass.role == "owner")
                        {
                            this.Hide();
                            new beranda_owner().Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Akun Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
            public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}

