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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            get_Info(userslist); //вызов при включении 
        }

        void get_Info(ListView List)
        {
            string query = "select*from users"; //вывод данных
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
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3) }; //Столбцы из ListView
                        var listItem = new ListViewItem(row);
                        userslist.Items.Add(listItem);

                    }
                }
                userslist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addsett Win = new addsett("add", 0); //Переход на форму добавления 
            Win.Show();

            userslist.Items.Clear();
            get_Info(userslist);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addsett Win = new addsett("change", Convert.ToInt32(Convert.ToString(userslist.Items[userslist.SelectedIndices[0]].Text))); //Переход на форму редактирования по id
            Win.Show();
            
            userslist.Items.Clear();
            get_Info(userslist);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from users where id = " + userslist.Items[userslist.SelectedIndices[0]].Text + ";"; //Удаление данных в ListView по id
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            userslist.Items.Clear();
            get_Info(userslist);
        }
    }
}
