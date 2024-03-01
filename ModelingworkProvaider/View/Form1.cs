using ModelingworkProvaider.Inteface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ModelingworkProvaider
{
    public partial class Form1 : Form
    {
        RandomForAll rd = new RandomForAll();
        private int Rules_for_generation_human;
        private int time_for_Users;
        public Form1()
        {
            InitializeComponent();
        }
        public string otchet = "Пользователь под Id: ";
        public string otchetafter = "зашел в сеть";
        private void Form1_Load(object sender, EventArgs e)
        {
            
            checkBox1.Checked = true;
            Rules_for_generation_human = 1;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            label2.Visible = false;
            textBox4.Visible = true;
            checkBox4.Checked = true;
            
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
                textBox3.Visible = true;
                Rules_for_generation_human = 1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                textBox3.Visible = false;
                Rules_for_generation_human = 2;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)//задание параметров генерации
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                textBox3.Visible = true;
                Rules_for_generation_human = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IProvaider provaider = new Provaider(int.Parse(textBox1.Text));
            QueueUsers users = new QueueUsers();
            bool spawner = false;
            int spawn = 0;
            for (int i = 0; i < 3600; i++)
            {
                if(spawner == false)
                {
                    spawn = Convert.ToInt32(chislo())+1;
                    int userID= users.Add(Convert.ToInt32(GenerateTime()));
                    listBox1.Items.Add(otchet+userID+otchetafter);
                    spawner = true;
                    continue;
                }
                if(spawn == 0) {
                    spawner = false;
                }
                provaider.working(users);
                spawn--;
                chart1.Series[0].Points.AddXY(i, users.cout);
            }
            users.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox1.Text) && int.Parse(textBox1.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox1.Text = "";
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
        private double chislo()
        {
            double rand;
            if (time_for_Users == 1)
            {
                rand = rd.PuassonNextArrivalTime(int.Parse(textBox4.Text));
            }
            else if (time_for_Users == 2)
            {
                rand = rd.ExponecialNextArrivalTime(int.Parse(textBox4.Text));
            }
            else
            {
                if (int.Parse(textBox4.Text) < int.Parse(textBox5.Text))
                {
                    rand = rd.Parametre_ravn(int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                }
                else
                {
                    rand = rd.Parametre_ravn(int.Parse(textBox5.Text), int.Parse(textBox4.Text));
                }
            }
            return rand;
        }
        public double GenerateTime()
        {
            double rand=0;
            if (Rules_for_generation_human == 1)
            {
                rand = rd.GenerateNormalDistribution(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            }
            else if (Rules_for_generation_human == 2)
            {
                rand = rd.ExponecialNextArrivalTime(int.Parse(textBox2.Text));
            }
            else
            {
                if (int.Parse(textBox2.Text) < int.Parse(textBox3.Text))
                {
                    rand = rd.Parametre_ravn(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                }
                else
                {
                    rand = rd.Parametre_ravn(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                }
            }
            return rand;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox4.Visible == false)
            {
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                label2.Visible = true;
            }
            else
            {
                label2.Visible=false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не выбирая будет выбран\r\nПуасоновский закон\r\nраспределения\r\nдля появления следующего\r\nпользователя в очереди\r\n а выбор влияет\r\n только на время\r\nпользователя");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                textBox5.Visible = false;
                time_for_Users = 1;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                textBox5.Visible = false;
                time_for_Users = 2;
            }
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox4.Checked = false;
                textBox5.Visible = true;
                time_for_Users = 3;
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox4.Text) && int.Parse(textBox4.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox4.Text = "";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox3.Text) && int.Parse(textBox3.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox3.Text = "";
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                // Проверка на наличие только цифр
                if (!IsNumeric(textBox5.Text) && int.Parse(textBox5.Text) < 0)
                {
                    MessageBox.Show("Пожалуйста, введите только цифры.");
                    textBox5.Text = "";
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
