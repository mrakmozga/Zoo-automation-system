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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
        }
        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            checkPassword.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myCommand.Parameters["@login"].Value = login.Text;
            myCommand.Parameters["@password"].Value = password.Text;
            myCommand2.Parameters["@login"].Value = login.Text;
            myConnection.Open();
            string result = (string)myCommand.ExecuteScalar().ToString();
            ProfileInfo.FIO = myCommand2.ExecuteScalar().ToString();
            myConnection.Close();
            if (result.Contains("Зоолог"))
            {
                ProfileInfo.EmpLogin = login.Text;
                MessageBox.Show("Вы успешно вошли");
                Form form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else if (result.Contains("test"))
            {
                ProfileInfo.EmpLogin = login.Text;
                MessageBox.Show("Вы успешно вошли");
                Form form6 = new Form6();
                form6.Show(); //другую форму
                this.Hide();

            }
            else if (result.Contains("Зоотехник"))
            {
                ProfileInfo.EmpLogin = login.Text;
                MessageBox.Show("Вы успешно вошли");
                Form form3 = new Form3();
                form3.Show(); //другую форму
                this.Hide();

            }
            else if (result.Contains("Работник кормления"))
            {
                ProfileInfo.EmpLogin = login.Text;
                MessageBox.Show("Вы успешно вошли");
                Form form5 = new Form5();
                form5.Show(); //другую форму
                this.Hide();

            }
            else if (result.Contains("Ветеринар"))
            {
                ProfileInfo.EmpLogin = login.Text;
                MessageBox.Show("Вы успешно вошли");
                Form form4 = new Form4();
                form4.Show(); //другую форму
                this.Hide();

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
