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
    public partial class addsett : Form
    {
        public string modeS = "";
        int item;
        void setMode(string mode)
        {
            if (mode == "add")
            {
                button7.Text = "Добавить";
            }
            else if (mode == "change")
            {
                button7.Text = "Изменить";
                string Info = "select id,name, password,mode from users where id =" + item.ToString() + ";";
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
                            comboBox1.Text = inRead.GetString(3);




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
        public addsett(string mode, int id)
        {
            InitializeComponent();
            modeS = mode;
            item = id;
            setMode(mode);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (modeS == "add")
            {

                string query = "insert into users(id,name,password,mode) values('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "');";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 600;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    conn.Close();
                    Settings Win = new Settings();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (modeS == "change")
            {

                string query = "update users set id ='" + textBox1.Text + "',name ='" + textBox2.Text + "',password = '" + textBox3.Text + "',mode = '" + comboBox1.Text + "' where id =" + item.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 600;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    conn.Close();
                    Settings Win = new Settings();
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
