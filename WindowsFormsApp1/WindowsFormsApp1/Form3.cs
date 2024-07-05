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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.zootechnic". При необходимости она может быть перемещена или удалена.
            this.zootechnicTableAdapter.Fill(this.zoo2DataSet.zootechnic);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Kletka". При необходимости она может быть перемещена или удалена.
            this.kletkaTableAdapter.Fill(this.zoo2DataSet.Kletka);
            sqlConnection1.Open();
            label6.Text = "Вольеров в зоопарке: " + sqlCommand1.ExecuteScalar().ToString();
            sqlConnection1.Close();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Proverka". При необходимости она может быть перемещена или удалена.
            this.proverkaTableAdapter.Fill(this.zoo2DataSet.Proverka);
            label4.Text = "Добро пожаловать, " + ProfileInfo.FIO;
            label5.Text = "Ваш логин: " + ProfileInfo.EmpLogin;
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Деавторизация");
            ToolTip a = new ToolTip();
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            if (!String.IsNullOrEmpty(comboBox1.Text))
            {
                if (!String.IsNullOrEmpty(textBox3.Text))
                {
                    sqlCommand2.Parameters["@id_TypeAnimal"].Value = Convert.ToInt32(comboBox1.SelectedValue);
                    sqlCommand2.Parameters["@area"].Value = textBox3.Text;
                    sqlConnection1.Open();
                    sqlCommand2.ExecuteNonQuery();
                    sqlConnection1.Close();
                    this.kletkaTableAdapter.Fill(this.zoo2DataSet.Kletka);
                }
                else MessageBox.Show("Не указана площадь вольера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Не выбран вид особи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { sqlConnection1.Close(); MessageBox.Show("Введены некорректные данные"); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kletkaBindingSource.Filter = "ID_TypeAnimal = " + comboBox4.SelectedValue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kletkaBindingSource.Filter = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
        
                if (!String.IsNullOrEmpty(comboBox3.Text))
                {
                    if (!String.IsNullOrEmpty(dateTimePicker1.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox4.Text))
                        {
                            sqlCommand3.Parameters["@fio"].Value = ProfileInfo.FIO;
                            sqlCommand3.Parameters["@id_kletka"].Value = comboBox3.SelectedValue;
                            sqlCommand3.Parameters["@date"].Value = dateTimePicker1.Value;
                            sqlCommand3.Parameters["@kindwork"].Value = textBox4.Text;
                            sqlConnection1.Open();
                            sqlCommand3.ExecuteNonQuery();
                            sqlConnection1.Close();
                            this.proverkaTableAdapter.Fill(this.zoo2DataSet.Proverka);
                        }
                        else MessageBox.Show("Не указан вид работ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не выбрана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не выбран вольер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            proverkaBindingSource.Filter = "Date = '" + dateTimePicker2.Value.ToString() + "'";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            proverkaBindingSource.Filter = "";
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

        private void kletkaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.SelectedValue = this.kletkaDataGridView1.CurrentRow.Cells[0].Value;
            comboBox5.SelectedValue = this.kletkaDataGridView1.CurrentRow.Cells[1].Value;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.kletkaDataGridView1.CurrentRow.Cells[0].Value = comboBox2.SelectedValue;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.kletkaDataGridView1.CurrentRow.Cells[1].Value = comboBox5.SelectedValue;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kletkaBindingSource.EndEdit();
            this.kletkaTableAdapter.Update(this.zoo2DataSet.Kletka);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            kletkaBindingSource.Filter = "ID_TypeAnimal = " + comboBox6.SelectedValue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kletkaBindingSource.Filter = "";
        }
    }
}
