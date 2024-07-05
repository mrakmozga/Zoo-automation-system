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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show(); //другую форму
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Proverka". При необходимости она может быть перемещена или удалена.
            this.proverkaTableAdapter.Fill(this.zoo2DataSet.Proverka);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.View_5". При необходимости она может быть перемещена или удалена.
            this.view_5TableAdapter.Fill(this.zoo2DataSet.View_5);
            label17.Text = "Добро пожаловать, " + ProfileInfo.FIO;
            label18.Text = "Ваш логин: " + ProfileInfo.EmpLogin;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet2.View_4". При необходимости она может быть перемещена или удалена.
            this.view_4TableAdapter.Fill(this.zoo2DataSet2.View_4);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Service". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet1.View_3". При необходимости она может быть перемещена или удалена.
            this.view_3TableAdapter.Fill(this.zoo2DataSet1.View_3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Feed". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.View_2". При необходимости она может быть перемещена или удалена.
            this.view_1TableAdapter.Fill(this.zoo2DataSet.View_1);
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);
            ToolTip t = new ToolTip();
            t.SetToolTip(button9, "Деавторизация");
            sqlConnection1.Open();
            var temp = new DataTable();
            temp.Load(sqlCommand1.ExecuteReader());
            dataGridView4.DataSource = temp;
            sqlConnection1.Close();
            ToolTip a = new ToolTip();
            a.SetToolTip(button4, "Режим редактирования");
            ToolTip b = new ToolTip();
            b.SetToolTip(button5, "Режим редактирования");
            ToolTip c = new ToolTip();
            c.SetToolTip(button6, "Режим редактирования");
            ToolTip d = new ToolTip();
            d.SetToolTip(button6, "Режим редактирования");
            ToolTip f = new ToolTip();
            f.SetToolTip(button12, "Режим редактирования");
            ToolTip g = new ToolTip();
            g.SetToolTip(button13, "Режим редактирования");
            ToolTip h = new ToolTip();
            h.SetToolTip(button17, "Режим редактирования");
            ToolTip i = new ToolTip();
            i.SetToolTip(button18, "Режим редактирования");

        }

        private void animalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.animalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = dataGridViewTextBoxColumn3;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    Col = dataGridViewTextBoxColumn3;
                    break;
                case 1:
                    Col = dataGridViewTextBoxColumn4;
                    break;
                case 2:
                    Col = dataGridViewTextBoxColumn5;
                    break;
                case 3:
                    Col = dataGridViewTextBoxColumn6;
                    break;
            }
            if (radioButton1.Checked)
                animalDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                animalDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "Nickname LIKE '" + textBox1.Text + "%'";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            animalBindingSource.Filter = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.animalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = dataGridViewTextBoxColumn1;
            switch (listBox2.SelectedIndex)
            {
                case 0:
                    Col = dataGridViewTextBoxColumn1;
                    break;
                case 1:
                    Col = dataGridViewTextBoxColumn2;
                    break;
                case 2:
                    Col = Area;
                    break;
            }
            if (radioButton4.Checked)
                view_1DataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                view_1DataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            view_1BindingSource.Filter = "TypeAnimal LIKE '" + textBox2.Text + "%'";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            view_1BindingSource.Filter = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button8.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = dataGridViewTextBoxColumn1;
            switch (listBox3.SelectedIndex)
            {
                case 0:
                    Col = typeFeedDataGridViewTextBoxColumn;
                    break;
                case 1:
                    Col = typeAnimalDataGridViewTextBoxColumn;
                    break;
                case 2:
                    Col = quantityDataGridViewTextBoxColumn;
                    break;
                case 3:
                    Col = servingSizeDataGridViewTextBoxColumn;
                    break;
            }
            if (radioButton6.Checked)
                dataGridView1.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                dataGridView1.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button16_Click(object sender, EventArgs e)
        {
           view3BindingSource.Filter = "TypeAnimal LIKE '" + textBox3.Text + "%'";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            view3BindingSource.Filter = "";
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button14.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.view_1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.view3BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = Id_Service;
            switch (listBox4.SelectedIndex)
            {
                case 0:
                    Col = Id_Service;
                    break;
                case 1:
                    Col = fIODataGridViewTextBoxColumn;
                    break;
                case 2:
                    Col = typeAnimalDataGridViewTextBoxColumn1;
                    break;
                case 3:
                    Col = dateDataGridViewTextBoxColumn;
                    break;
                case 4:
                    Col = typeOfWorkDataGridViewTextBoxColumn;
                    break;
            }
            if (radioButton8.Checked)
                dataGridView2.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                dataGridView2.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            button19.Enabled = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            view4BindingSource.Filter = "FIO LIKE '" + textBox4.Text + "%'";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            view4BindingSource.Filter = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            button24.Enabled = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = fIODataGridViewTextBoxColumn1;
            switch (listBox5.SelectedIndex)
            {
                case 0:
                    Col = fIODataGridViewTextBoxColumn1;
                    break;
                case 1:
                    Col = iDAnimalDataGridViewTextBoxColumn;
                    break;
                case 2:
                    Col = nicknameDataGridViewTextBoxColumn;
                    break;
                case 3:
                    Col = lDayDataGridViewTextBoxColumn;
                    break;
                case 4:
                    Col = nameDataGridViewTextBoxColumn;
                    break;
            }
            if (radioButton10.Checked)
                dataGridView3.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                dataGridView3.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            view5BindingSource.Filter = "FIO LIKE '" + textBox5.Text + "%'";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            view5BindingSource.Filter = "";
        }
        private void button29_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = Column1;
            switch (listBox6.SelectedIndex)
            {
                case 0:
                    Col = Column1;
                    break;
                case 1:
                    Col = dataGridViewTextBoxColumn8;
                    break;
                case 2:
                    Col = dataGridViewTextBoxColumn9;
                    break;
                case 3:
                    Col = dataGridViewTextBoxColumn10;
                    break;
                case 4:
                    Col = dataGridViewTextBoxColumn11;
                    break;
            }
            if (radioButton12.Checked)
                proverkaDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                proverkaDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            proverkaBindingSource.Filter = "FIO LIKE '" + textBox6.Text + "%'";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            proverkaBindingSource.Filter = "";
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            button29.Enabled = true;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = default(System.Windows.Forms.DataGridViewColumn);
            Col = dataGridViewTextBoxColumn12;
            switch (listBox6.SelectedIndex)
            {
                case 0:
                    Col = dataGridViewTextBoxColumn12;
                    break;
                case 1:
                    Col = dataGridViewTextBoxColumn13;
                    break;
            }
            if (radioButton13.Checked)
                typeAnimalDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            else
                typeAnimalDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            button34.Enabled = true;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "TypeAnimal LIKE '" + textBox7.Text + "%'";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            typeAnimalBindingSource.Filter = "";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.typeAnimalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.proverkaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show(); //другую форму
        }
    }
}
