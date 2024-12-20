using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vokzal
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=vok; charset=utf8";
            conn = new MySqlConnection(constr);
        }
        private bool ValidateName(string name)
        {
            
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Имя не может быть пустым!");
                return false;
            }

            
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$"))
            {
                MessageBox.Show("Имя должно содержать только буквы!");
                return false;
            }

            return true;
        }
        private bool ValidatePassportNumber(string passportNumber)
        {
            
            if (string.IsNullOrWhiteSpace(passportNumber))
            {
                MessageBox.Show("Номер паспорта не может быть пустым!");
                return false;
            }

            
            if (!System.Text.RegularExpressions.Regex.IsMatch(passportNumber, @"^[A-ZА-Я]{2}\d{6}$"))
            {
                MessageBox.Show("Номер паспорта должен содержать 2 буквы и 6 цифр (например, AB123456)!");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateName(textBox1.Text) && ValidatePassportNumber(textBox2.Text))
            {
                try
                {
                    conn.Open();
                    string qq = "insert into vokr(name,passportN,dis) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "');";
                    MySqlCommand cmd = new MySqlCommand(qq, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ok");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}
