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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void animalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.animalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.veterinary". При необходимости она может быть перемещена или удалена.
            this.veterinaryTableAdapter.Fill(this.zoo2DataSet.veterinary);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.zoo2DataSet.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Proverka". При необходимости она может быть перемещена или удалена.
            this.proverkaTableAdapter.Fill(this.zoo2DataSet.Proverka);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Lecheniye". При необходимости она может быть перемещена или удалена.
            this.lecheniyeTableAdapter.Fill(this.zoo2DataSet.Lecheniye);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.zoo2DataSet.Service);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Feed". При необходимости она может быть перемещена или удалена.
            this.feedTableAdapter.Fill(this.zoo2DataSet.Feed);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Kletka". При необходимости она может быть перемещена или удалена.
            this.kletkaTableAdapter.Fill(this.zoo2DataSet.Kletka);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Animal". При необходимости она может быть перемещена или удалена.
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox1.Text))
            {
                if (!String.IsNullOrEmpty(comboBox2.Text))
                {
                    if (!String.IsNullOrEmpty(dateTimePicker1.Text))
                    {
                        if (!String.IsNullOrEmpty(textBox3.Text))
                        {
                            sqlCommand1.Parameters["@fio"].Value = comboBox1.SelectedValue;
                            sqlCommand1.Parameters["@id_animal"].Value = Convert.ToInt32(comboBox2.SelectedValue);
                            sqlCommand1.Parameters["@l_day"].Value = dateTimePicker1.Text;
                            sqlCommand1.Parameters["@name"].Value = textBox3.Text;
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
            else MessageBox.Show("Не выбран врач", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
