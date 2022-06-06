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
textBox3 - время изготовления(час)
textBox4 - количество
textBox5 - сложность
button1 - добавить
 */
namespace VladislavKirillov1
{
    public partial class Form6 : Form
    {
        Model1Container _db;
        Form5 form5;
        public Form6(Model1Container db, Form5 backForm)
        {
            InitializeComponent();
            this._db = db;
            this.form5 = backForm;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    Name = textBox1.Text,
                    Price = Convert.ToInt32(textBox2.Text),
                    PreparationTime = Convert.ToInt32(textBox3.Text),
                    Amount = Convert.ToInt32(textBox4.Text),
                    Difficulty = textBox5.Text
                };


                _db.ProductSet.Add(product);
                _db.SaveChanges();
                form5.UpdateList();
                MessageBox.Show("Успешно добавлено!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неправильный формат данных");
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            form5.Show();
        }
    }
}
