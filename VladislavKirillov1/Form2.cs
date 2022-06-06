using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 groupBox1 - директор
textBox1 - имя директора
textBox2 - фамилия директора
textBox3 - отчество директора
textBox4 - логин директора
textBox5 - пароль директора

 groupBox1 - сотрудник
textBox6 - пароль сотрудник
textBox7 - логин сотрудник
textBox8 -  отчество сотрудник
textBox9 - фамилия сотрудник
textBox10 - имя сотрудник
comboBox2 - название цеха

button1 - зарегестрироваться
radiobutton1 - директор
radiobutton2 - сотрудник
 */
namespace VladislavKirillov1
{
    public partial class Form2 : Form
    {
        string selectedUserType;
        Form1 form1;
        Model1Container _db;
        public Form2(Model1Container db, Form1 backForm)
        {
            InitializeComponent();
            this._db = db;
            this.form1 = backForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var validateResult = ValidateTest.ValidateRegistration(textBox4.Text, textBox5.Text, textBox1.Text, textBox2.Text);
            if (validateResult == "Успешно")
            {
                if (selectedUserType == "Employee")
                {

                    Employee employee = new Employee()
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        Patronymic = textBox3.Text,
                        Login = textBox4.Text,
                        Password = textBox5.Text,
                        Shop = comboBox2.SelectedItem as Shop
                    };

                    employee.WorkList = new WorkList()
                    {
                        TotalProductionTime = 0
                    };

                    _db.EmployeeSet.Add(employee);
                    _db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    this.Close();


                }
                else
                {
                    Director director = new Director()
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        Patronimyc = textBox3.Text,
                        Login = textBox4.Text,
                        Password = textBox5.Text,
                        Post = "Director"
                    };
                    _db.DirectorSet.Add(director);
                    _db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(validateResult);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            selectedUserType = "Employee";
            comboBox2.Visible = false;
            label12.Visible = false;
            foreach (Shop shop in _db.ShopSet)
            {
                comboBox2.Items.Add(shop);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label12.Visible = false;
            selectedUserType = "Director";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            label12.Visible = true;
            selectedUserType = "Employee";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
