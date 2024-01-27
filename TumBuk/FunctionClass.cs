using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TumBuk
{
    internal class FunctionClass
    {
        public static string role;
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db_tumbuk");
        private Form activateForm;
        public static string username = "";
        public static string id_user = "";

        public void openChildForm(Form childForm, Panel panel, object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }

            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel.Controls.Add(childForm);
            panel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        public void command(string query)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
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

        public void getDatarole(ComboBox cb)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select distinct role from users", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string data;
            while (reader.Read())
            {
                data = reader["role"].ToString();
                cb.Items.Add(data);
            }
            reader.Close();
            conn.Close();
        }

        public void showData(string query, DataGridView dg)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from products", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                dg.DataSource = dt;
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
    }
}
