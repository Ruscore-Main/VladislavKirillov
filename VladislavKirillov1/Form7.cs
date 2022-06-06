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
 listBox1 детали
listBox2 сотрудники 
button1 - передать работу
textBox1 - название детали
textBox2 - цена детали
textBox3 - время изготовления (час)
textBox4 - количество деталей
textBox5 - сложность детали

textBox6 - название цеха сотрудника
textBox8 - отчество сотрудника
textBox9 - фамилия сотрудника
textBox10 - имя сотрудника
 */
namespace VladislavKirillov1
{
    public partial class Form7 : Form
    {
        Form3 form3;
        Model1Container _db;
        Product currentProduct;
        Employee currentEmployee;
        public Form7(Model1Container db, Form3 backForm)
        {
            InitializeComponent();
            this.form3 = backForm;
            this._db = db;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            UpdateLists();
        }

        public void UpdateLists()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (Product product in _db.ProductSet)
            {
                listBox1.Items.Add(product);
            }
            foreach (Employee employee in _db.EmployeeSet)
            {
                listBox2.Items.Add(employee);
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
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
                    textBox3.Text = Convert.ToString(currentProduct.PreparationTime) + " часов";
                    textBox4.Text = Convert.ToString(currentProduct.Amount);
                    textBox5.Text = currentProduct.Difficulty;
                }
            }
            catch { }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentEmployee = listBox2.SelectedItem as Employee;
                if (currentProduct != null)
                {
                    textBox6.Text = currentEmployee.Shop.ToString();
                    textBox8.Text = currentEmployee.Patronymic;
                    textBox9.Text = currentEmployee.Surname;
                    textBox10.Text = currentEmployee.Name;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!currentEmployee.WorkList.Product.Contains(currentProduct))
                {
                    currentEmployee.WorkList.Product.Add(currentProduct);
                    _db.SaveChanges();
                    MessageBox.Show("Успешно добавлено в список работы!");
                }
                else
                {
                    MessageBox.Show("У этого работника уже есть эта детаель в списке работы!");
                }
            }
            catch
            {
                MessageBox.Show("Выберите И товар И сотрудника");
            }
        }
    }
}
