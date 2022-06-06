using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VladislavKirillov1
{
/*
    textBox1 - название
    textBox2 - цена
    textBox3 - время изготовления (час)
    textBox4 - количество
    textBox5 - сложность
    button1 - удалить
    button2 - изменить
    button3 - добавить
*/
    public partial class Form5 : Form
    {
        Form3 form3;
        Model1Container _db;
        Product currentProduct;
        public Form5(Model1Container db, Form3 backForm)
        {
            InitializeComponent();
            this.form3 = backForm;
            this._db = db;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(_db, this);
            this.Hide();
            form6.Show();
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Product product in _db.ProductSet)
            {
                listBox1.Items.Add(product);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            UpdateList();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            form3.Show();
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
                    button2.Enabled = true;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _db.ProductSet.Remove(currentProduct);
                _db.SaveChanges();
                UpdateList();
                MessageBox.Show("Успешно удалено!");
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
    textBox1 - название
    textBox2 - цена
    textBox3 - время изготовления (час)
    textBox4 - количество
    textBox5 - сложность
    button1 - удалить
    button2 - изменить
    button3 - добавить
*/
            try
            {
                currentProduct.Name = textBox1.Text;
                currentProduct.Price = Convert.ToInt32(textBox2.Text);
                currentProduct.PreparationTime = Convert.ToInt32(textBox3.Text);
                currentProduct.Amount = Convert.ToInt32(textBox4.Text);
                currentProduct.Difficulty = textBox5.Text;

                _db.SaveChanges();
                UpdateList();
                MessageBox.Show("Успешно изменено!");
            }
            catch
            {
                MessageBox.Show("Неправильный формат данных!");
            }
        }
    }
}
