using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show(); //другую форму
            this.Hide();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.rabotnik_kormleniya". При необходимости она может быть перемещена или удалена.
            this.rabotnik_kormleniyaTableAdapter.Fill(this.zoo2DataSet.rabotnik_kormleniya);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Feed". При необходимости она может быть перемещена или удалена.
            this.feedTableAdapter.Fill(this.zoo2DataSet.Feed);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            label4.Text = "Добро пожаловать, " + ProfileInfo.FIO;
            label5.Text = "Ваш логин: " + ProfileInfo.EmpLogin;
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Деавторизация");
            dateTimePicker2.MaxDate = DateTime.Today;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "TypeAnimal LIKE '" + textBox1.Text + "%'";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCommand1.Parameters["@typefeed"].Value = textBox3.Text;
            sqlConnection1.Open();
            sqlCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            this.feedTableAdapter.Fill(this.zoo2DataSet.Feed);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.typeAnimalDataGridView.CurrentRow.Cells[2].Value = comboBox3.SelectedValue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.typeAnimalDataGridView.CurrentRow.Cells[3].Value = textBox4.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.typeAnimalDataGridView.CurrentRow.Cells[4].Value = textBox5.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try { 
            this.Validate();
            this.typeAnimalBindingSource.EndEdit();
            this.typeAnimalTableAdapter.Update(this.zoo2DataSet.TypeAnimal);
            } catch { MessageBox.Show("Введены некорректные"); }
        }

        private void typeAnimalDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.SelectedValue = this.typeAnimalDataGridView.CurrentRow.Cells[2].Value;
            textBox4.Text = this.typeAnimalDataGridView.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = this.typeAnimalDataGridView.CurrentRow.Cells[4].Value.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            serviceBindingSource.Filter = "ID_TypeAnimal = " + comboBox9.SelectedValue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
                if (!String.IsNullOrEmpty(comboBox5.Text))
                {
                    if (!String.IsNullOrEmpty(dateTimePicker2.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox7.Text))
                        {
                            sqlCommand2.Parameters["@fio"].Value = ProfileInfo.FIO;
                            sqlCommand2.Parameters["@id_typeanimal"].Value = Convert.ToInt32(comboBox5.SelectedValue);
                            sqlCommand2.Parameters["@date"].Value = dateTimePicker2.Value;
                            sqlCommand2.Parameters["@typeofwork"].Value = textBox7.Text;
                            sqlConnection1.Open();
                            sqlCommand2.ExecuteNonQuery();
                            sqlConnection1.Close();
                            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
                        }
                        else MessageBox.Show("Не указан вид работ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не указана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не выбран вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            serviceBindingSource.Filter = "";
        }
    }
}
