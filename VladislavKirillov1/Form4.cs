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
 textBox1 - название
textBox2 - цена 
textBox3 - время изготовление (час)
textBox4 - количество
textBox5 - сложность
button1 - выполнить
 */
namespace VladislavKirillov1
{
    public partial class Form4 : Form
    {
        Form1 form1;
        Model1Container _db;
        Employee curEmployee;
        Product currentProduct;
        public Form4(Model1Container db, Form1 backForm, Employee employee)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.curEmployee = employee;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            int timeSum = 0, priceSum = 0;
            foreach (Product product in curEmployee.WorkList.Product)
            {
                listBox1.Items.Add(product);
                priceSum += product.Price;
                timeSum += product.PreparationTime;
            }
            label9.Text = $"Общая стоимость: {priceSum} руб.";
            label9.Text = $"Общее время изготовления:: {timeSum} ч.";
            curEmployee.WorkList.TotalProductionTime = timeSum;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            _db.SaveChanges();


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateList();
            button1.Enabled = false;
            label1.Text = $"ФИО: {curEmployee.Surname} {curEmployee.Name} {curEmployee.Patronymic}";
            label2.Text = $"Логин: {curEmployee.Login}";
            label11.Text = $"Цех: {curEmployee.Shop.Name} {curEmployee.Shop.Address}";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentProduct = listBox1.SelectedItem as Product;
                if (currentProduct != null)
                {
                    textBox1.Text = currentProduct.Name;
                    textBox2.Text = Convert.ToString(currentProduct.Price);
                    textBox3.Text = Convert.ToString(currentProduct.PreparationTime);
                    textBox4.Text = Convert.ToString(currentProduct.Amount);
                    textBox5.Text = currentProduct.Difficulty;
                    button1.Enabled = true;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            curEmployee.WorkList.Product.Remove(currentProduct);
            _db.SaveChanges();
            button1.Enabled = false;
            UpdateList();
            MessageBox.Show("Деталь помечена как выполненная!");
        }
    }
}
