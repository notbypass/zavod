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
    public partial class AdminMenu : Form
    {
        private Form activeForm;
        string query_uni = "select*from zavod.info_menu_;";
        public AdminMenu()
        {
            InitializeComponent();
            this.Menu = Menu;
            get_Info(query_uni + ";"); ;
        }

        void get_Info(string query)
        {

            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            cmDB.CommandTimeout = 99999;


            try
            {

                conn.Open();
                sda.Fill(dt);
                for (int z = 0; z < dataGridView2.Columns.Count; z++)
                {
                    dataGridView2.Columns[z].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                    for (int z = 0; z < dataGridView2.Columns.Count; z++)
                {
                    dataGridView2.Columns[z].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dataGridView2.RowHeadersVisible = true;
                dataGridView2.DataSource = dt;
                dataGridView2.ClearSelection();
                dataGridView2.Columns[0].HeaderText = "Прибор ID";
                dataGridView2.Columns[0].Selected = true;
                conn.Close();
                dataGridView2.Columns[1].HeaderText = "Орг.Произв.Цех";
                dataGridView2.Columns[2].HeaderText = "Отделение (участок) цеха / Помещение";// смена текста с бд на твой(рабочий)
                dataGridView2.Columns[3].HeaderText = "Наименование оборудования";
                dataGridView2.Columns[4].HeaderText = "Заводской номер";
                dataGridView2.Columns[5].HeaderText = "Наименование параметра (функциональное назначение прибора)";
                dataGridView2.Columns[6].HeaderText = "Вид тех. средства";
                dataGridView2.Columns[7].HeaderText = "Тип оборудования";
                dataGridView2.Columns[8].HeaderText = "Дата последней калибр./поверки";
                dataGridView2.Columns[9].HeaderText = "Сроки проведения калибр./поверки";
                dataGridView2.Columns[10].HeaderText = "Шкала (диапазон)";
                dataGridView2.Columns[11].HeaderText = "Шкала (ед.изм.)";
                dataGridView2.Columns[12].HeaderText = "Год монтажа";
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }
            private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(childForm);
            this.panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new add("add", 0), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idLocRemv = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            add Win = new add("change", Convert.ToInt32(Convert.ToString(idLocRemv)));
            OpenChildForm(new add("change", Convert.ToInt32(Convert.ToString(idLocRemv))), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                }
            }
            
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            string query = "select * from info_menu_ where concat(id,name_1,name_2,name_4,name_5,name_6,name_7,name_8,name_9,name_10,name_11,name_12,name_13) like '%" + textBox1.Text + "%'";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.ClearSelection();
                dataGridView2.Columns[0].HeaderText = "Прибор ID";
                dataGridView2.Columns[0].Selected = true;
                conn.Close();
                dataGridView2.Columns[1].HeaderText = "Орг.Произв.Цех";
                dataGridView2.Columns[2].HeaderText = "Отделение (участок) цеха / Помещение";// смена текста с бд на твой(рабочий)
                dataGridView2.Columns[3].HeaderText = "Наименование оборудования";
                dataGridView2.Columns[4].HeaderText = "Заводской номер";
                dataGridView2.Columns[5].HeaderText = "Наименование параметра (функциональное назначение прибора)";
                dataGridView2.Columns[6].HeaderText = "Вид тех. средства";
                dataGridView2.Columns[7].HeaderText = "Тип оборудования";
                dataGridView2.Columns[8].HeaderText = "Дата последней калибр./поверки";
                dataGridView2.Columns[9].HeaderText = "Сроки проведения калибр./поверки";
                dataGridView2.Columns[10].HeaderText = "Шкала (диапазон)";
                dataGridView2.Columns[11].HeaderText = "Шкала (ед.изм.)";
                dataGridView2.Columns[12].HeaderText = "Год монтажа";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idLocRemv = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            string query = "delete from info_menu_ where Id = " + idLocRemv;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 600;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                get_Info(query_uni + ";");
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings(), sender);
        }
    }
}
