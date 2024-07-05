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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.TypeAnimal". При необходимости она может быть перемещена или удалена.
            this.typeAnimalTableAdapter.Fill(this.zoo2DataSet.TypeAnimal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zoo2DataSet.Animal". При необходимости она может быть перемещена или удалена.
            this.animalTableAdapter.Fill(this.zoo2DataSet.Animal);

        }

        private void animalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.animalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.zoo2DataSet);

        }

        private void animalDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedValue = this.animalDataGridView.CurrentRow.Cells[0].Value;
            textBox1.Text = this.animalDataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            animalBindingSource.RemoveCurrent(); 
            this.Validate();
            this.animalBindingSource.EndEdit();
            this.animalTableAdapter.Update(this.zoo2DataSet.Animal);
        }
    }
}
