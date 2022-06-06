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
 textBox1 логин сотрудник
textBox2 пароль сотрудник
textBox3 логин директор
textBox4 пароль директор
button1 - войти сотрудник
button2 - войти директор
 */
namespace VladislavKirillov1
{
    public partial class Form1 : Form
    {
        string selectedUserType = "Employee";
        Model1Container _db = new Model1Container();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedUserType == "Employee")
            {
                Employee employee = _db.EmployeeSet.FirstOrDefault(el => el.Login == textBox1.Text && el.Password == textBox2.Text);
                if (employee != null)
                {
                    Form4 form4 = new Form4(_db, this, employee);
                    this.Hide();
                    form4.Show();
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден!");
                }
                
            }
            else
            {
                Director director = _db.DirectorSet.FirstOrDefault(el => el.Login == textBox1.Text && el.Password == textBox2.Text);
                if (director != null)
                {
                    Form3 form3 = new Form3(_db, this, director);
                    this.Hide();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Директор не найден!");
                }
                
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2(_db, this);
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_db.ShopSet.Count() == 0)
            {
                Shop shop1 = new Shop()
                {
                    Name = "Цех №1",
                    Address = "г. Казань, ул. Кремлевская"
                };

                Shop shop2 = new Shop()
                {
                    Name = "Цех №2",
                    Address = "г. Казань, ул. Ершова"
                };

                _db.ShopSet.Add(shop1);
                _db.ShopSet.Add(shop2);
                _db.SaveChanges();
            }
            radioButton2.Checked = true;
        }

        // Director
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedUserType = "Director";
        }

        // Employee
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectedUserType = "Employee";
        }
    }
}
