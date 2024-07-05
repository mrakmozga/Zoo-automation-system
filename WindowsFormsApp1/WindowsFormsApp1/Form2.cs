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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show(); //другую форму
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Children". При необходимости она может быть перемещена или удалена.
            this.childrenTableAdapter.Fill(this.zoo2DataSet.Children);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Feed". При необходимости она может быть перемещена или удалена.
            this.feedTableAdapter.Fill(this.zoo2DataSet.Feed);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet1.zoolog". При необходимости она может быть перемещена или удалена.
            this.zoologTableAdapter.Fill(this.zoo2DataSet1.zoolog);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet1.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.zoo2DataSet1.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Kletka". При необходимости она может быть перемещена или удалена.
            this.kletkaTableAdapter.Fill(this.zoo2DataSet.Kletka);
            sqlConnection1.Open();
            label15.Text = "Животных в зоопарке: " + sqlCommand1.ExecuteScalar().ToString();
            sqlConnection1.Close();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Animal". При необходимости она может быть перемещена или удалена.
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);
            label4.Text = "Добро пожаловать, " + ProfileInfo.FIO;
            label5.Text = "Ваш логин: " + ProfileInfo.EmpLogin;
            
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Деавторизация");
            ToolTip a = new ToolTip();
            a.SetToolTip(button3, "Режим удаления");
            ToolTip g = new ToolTip();
            g.SetToolTip(button1, "Обновить таблицы");
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
                animalBindingSource.Filter = "Nickname LIKE '" + textBox1.Text + "%'";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "";
        }

        private void button36_Click(object sender, EventArgs e)
        {

        }


        

        private void button10_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "TypeAnimal LIKE '" + textBox2.Text + "%'";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show(); //другую форму
            this.Close();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            serviceBindingSource1.Filter = "ID_TypeAnimal = " + comboBox9.SelectedValue;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            serviceBindingSource1.Filter = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form8 = new Form8();
            form8.Show(); //другую форму
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try { 
            if (!String.IsNullOrEmpty(textBox4.Text))
            {
                if (!String.IsNullOrEmpty(comboBox1.Text))
                {
                    if (!String.IsNullOrEmpty(comboBox2.Text))
                    {
                        if (!String.IsNullOrEmpty(dateTimePicker1.Text))
                        {
                            if (!String.IsNullOrEmpty(textBox8.Text))
                            {
                                if (!String.IsNullOrEmpty(comboBox3.Text))
                                {
                                    sqlCommand3.Parameters["@nickname"].Value = textBox4.Text;
                                    sqlCommand3.Parameters["@id_TypeAnimal"].Value = Convert.ToInt32(comboBox1.SelectedValue);
                                    sqlCommand3.Parameters["@gender"].Value = comboBox2.Text;
                                    sqlCommand3.Parameters["@birthday"].Value = dateTimePicker1.Value;
                                    sqlCommand3.Parameters["@color"].Value = textBox8.Text;
                                    sqlCommand3.Parameters["@id_kletka"].Value = Convert.ToInt32(comboBox3.Text); ;
                                    sqlConnection1.Open();
                                    sqlCommand3.ExecuteNonQuery();
                                    sqlConnection1.Close();
                                    this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);
                                    }
                                else MessageBox.Show("Не введён номер вольера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Не введён окрас особи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Не введена дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не выбран пол особи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не выбран вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Дайте кличку особи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            catch (System.Exception ex)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox5.Text))
                {
                    if (!String.IsNullOrEmpty(textBox6.Text))
                    {
                        if (!String.IsNullOrEmpty(comboBox6.Text))
                        {
                            if (!String.IsNullOrEmpty(textBox9.Text))
                            {
                                if (!String.IsNullOrEmpty(textBox11.Text))
                                {
                                    sqlCommand4.Parameters["@typeanimal"].Value = textBox5.Text;
                                    sqlCommand4.Parameters["@squad"].Value = textBox6.Text;
                                    sqlCommand4.Parameters["@id_feed"].Value = Convert.ToInt32(comboBox6.SelectedValue);
                                    sqlCommand4.Parameters["@quantity"].Value = textBox9.Text;
                                    sqlCommand4.Parameters["@serving"].Value = Convert.ToString(textBox11   .Text); ;
                                    sqlConnection1.Open();
                                    sqlCommand4.ExecuteNonQuery();
                                    sqlConnection1.Close();
                                    this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
                                }
                                else MessageBox.Show("Не введён размер порции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Не введена частота кормления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Не выбран корм", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не введён отряд", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не введён вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex) { sqlConnection1.Close(); MessageBox.Show("Введены некорректные данные"); }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (!String.IsNullOrEmpty(comboBox5.Text))
                {
                    if (!String.IsNullOrEmpty(dateTimePicker2.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox7.Text))
                        {
                            sqlCommand5.Parameters["@fio"].Value = ProfileInfo.FIO;
                            sqlCommand5.Parameters["@id_typeanimal"].Value = Convert.ToInt32(comboBox5.SelectedValue);
                            sqlCommand5.Parameters["@date"].Value = dateTimePicker2.Value;
                            sqlCommand5.Parameters["@typeofwork"].Value = textBox7.Text;
                            sqlConnection1.Open();
                            sqlCommand5.ExecuteNonQuery();
                            sqlConnection1.Close();
                            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
                        }
                        else MessageBox.Show("Не указан вид работ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Не указана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Не выбран вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Exception ex) { sqlConnection1.Close(); MessageBox.Show("Введены некорректные данные"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sqlCommand6.Parameters["@id_children"].Value = Convert.ToInt32(comboBox8.SelectedValue);
            sqlCommand6.Parameters["@id_animal"].Value = Convert.ToInt32(comboBox7.SelectedValue);
            
            sqlConnection1.Open();
            sqlCommand6.ExecuteNonQuery();
            sqlConnection1.Close();
            this.childrenTableAdapter.Fill(this.zoo2DataSet.Children);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            childrenBindingSource.Filter = "ID_Animal = " + Convert.ToString(comboBox10.SelectedValue) + "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            childrenBindingSource.Filter = "ID_Parent = " + Convert.ToString(comboBox11.SelectedValue) + "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            childrenBindingSource.Filter = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "ID_TypeAnimal = " + comboBox12.SelectedValue;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "Squad LIKE '" + textBox3.Text + "%'";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            this.childrenTableAdapter.Fill(this.zoo2DataSet.Children);
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);
        }
    }
}


