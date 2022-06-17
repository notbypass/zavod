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

namespace Zavod
{
    public partial class Auto : Form
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string mod = "";
                string id = "";
                string query = "select id, mode from users where name ='" + textBox1.Text + "' and password = '" + textBox2.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 60;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            id = rd.GetString(0);
                            mod = rd.GetString(1);
                        }
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка авторизации. Попробуйте еще раз.");
                    MessageBox.Show(ex.Message);
                }
                if (Convert.ToInt32(id) > 0)
                {
                    if (mod == "Администратор")
                    {
                        AdminMenu Win = new AdminMenu();
                        Win.Show();
                        this.Hide();

                    }
                    else if (mod == "Пользователь")
                    {
                        info Win = new info();
                        Win.Show();
                        this.Hide();

                    }
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addusers Win = new addusers();
            Win.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
