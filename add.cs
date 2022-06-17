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
    public partial class add : Form
    {

        public string modeS = "";
        int item;
        void setMode(string mode)
        {
            if (mode == "add")
            {
                button1.Text = "Добавить";
            }
            else if (mode == "change")
            {
                button1.Text = "Изменить";
                string Info = "select id,name_1, name_2,name_4,name_5,name_6,name_7,name_8,name_9,name_10,name_11,name_12,name_13 from info_menu_ where id =" + item.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmInfo = new MySqlCommand(Info, conn);
                MySqlDataReader inRead;
                cmInfo.CommandTimeout = 600;
                try
                {
                    conn.Open();
                    inRead = cmInfo.ExecuteReader();
                    if (inRead.HasRows)
                    {
                        while (inRead.Read())
                        {

                            textBox1.Text = inRead.GetString(0);
                            textBox2.Text = inRead.GetString(1);
                            textBox3.Text = inRead.GetString(2);
                            textBox5.Text = inRead.GetString(3);
                            textBox6.Text = inRead.GetString(4);
                            textBox7.Text = inRead.GetString(5);
                            textBox8.Text = inRead.GetString(6);
                            textBox9.Text = inRead.GetString(7);
                            textBox10.Text = inRead.GetString(8);
                            textBox11.Text = inRead.GetString(9);
                            textBox12.Text = inRead.GetString(10);
                            textBox13.Text = inRead.GetString(11);
                            textBox14.Text = inRead.GetString(12);
                       



                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

          public add(string mode, int id)
        {
            InitializeComponent();
            modeS = mode;
            item = id;
            setMode(mode);
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (modeS == "add")
            {

                string query = "insert into info_menu_ values('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "');";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 600;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    conn.Close();
                    AdminMenu Win = new AdminMenu();
                    Win.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (modeS == "change")
            {

                string query = "update info_menu_ set id ='" + textBox1.Text + "',name_1 ='" + textBox2.Text + "',name_2 = '" + textBox3.Text + "',name_4 = '" + textBox5.Text + "',name_5 = '" + textBox6.Text + "',name_6 = '" + textBox7.Text + "',name_7 = '" + textBox8.Text + "',name_8 = '" + textBox9.Text + "',name_9 = '" + textBox10.Text + "',name_9 = '" + textBox10.Text + "',name_10 = '" + textBox11.Text + "',name_11 = '" + textBox12.Text + "',name_12 = '" + textBox13.Text + "',name_13 = '" + textBox14.Text + "' where id =" + item.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 600;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    conn.Close();
                    AdminMenu Win = new AdminMenu();
                    Win.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
