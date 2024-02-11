using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelingworkProvaider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Provaider provaider;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            checkBox1.Checked = true;
        }
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)//задание параметров генерации
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            provaider = new Provaider(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox2.Text) && int.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox2.Text = "";
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox2.Text) && int.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox2.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
