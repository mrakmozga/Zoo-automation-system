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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Feed". При необходимости она может быть перемещена или удалена.
            this.feedTableAdapter.Fill(this.zoo2DataSet.Feed);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.veterinary". При необходимости она может быть перемещена или удалена.
            this.veterinaryTableAdapter.Fill(this.zoo2DataSet.veterinary);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Animal". При необходимости она может быть перемещена или удалена.
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Lecheniye". При необходимости она может быть перемещена или удалена.
            this.lecheniyeTableAdapter.Fill(this.zoo2DataSet.Lecheniye);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
            label4.Text = "Добро пожаловать, " + ProfileInfo.FIO;
            label5.Text = "Ваш логин: " + ProfileInfo.EmpLogin;
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Деавторизация");
            ToolTip a = new ToolTip();
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker3.MaxDate = DateTime.Today;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            serviceBindingSource.Filter = "Date = '" + dateTimePicker1.Value.ToString() + "'";   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serviceBindingSource.Filter = "";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "TypeAnimal LIKE '" + textBox3.Text + "%'";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lecheniyeBindingSource.Filter = "L_Day = '" + dateTimePicker3.Value.ToString() + "'";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            lecheniyeBindingSource.Filter = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show(); //другую форму
            this.Close();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                if (!String.IsNullOrEmpty(comboBox2.Text))
                {
                    if (!String.IsNullOrEmpty(dateTimePicker2.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox1.Text))
                        {
                            sqlCommand1.Parameters["@fio"].Value = ProfileInfo.FIO;
                            sqlCommand1.Parameters["@id_animal"].Value = Convert.ToInt32(comboBox2.SelectedValue);
                            sqlCommand1.Parameters["@l_day"].Value = dateTimePicker2.Text;
                            sqlCommand1.Parameters["@name"].Value = textBox1.Text;
                            sqlConnection1.Open();
                            sqlCommand1.ExecuteNonQuery();
                            sqlConnection1.Close();
                            this.lecheniyeTableAdapter.Fill(this.zoo2DataSet.Lecheniye);
                        }
                        else MessageBox.Show("Не заполнено наименование процедуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не заполнена дата процедуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не выбрано животное", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void typeAnimalDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.SelectedValue = this.typeAnimalDataGridView.CurrentRow.Cells[2].Value;
            textBox4.Text = this.typeAnimalDataGridView.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = this.typeAnimalDataGridView.CurrentRow.Cells[4].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
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
            }
            catch { MessageBox.Show("Введены некорректные данные"); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "Nickname LIKE '" + textBox6.Text + "%'";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "";
        }
    }
}
