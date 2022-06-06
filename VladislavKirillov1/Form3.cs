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
 button1- детали
button2 - сотрудники
 */
namespace VladislavKirillov1
{
    public partial class Form3 : Form
    {
        Form1 form1;
        Model1Container _db;
        Director curDirector;
        public Form3(Model1Container db, Form1 backForm, Director director)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.curDirector = director;
        }

        private void button1_Click(object sender, EventArgs e) // Details form
        {
            Form5 form5 = new Form5(_db, this);
            this.Hide();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Employee form
        {
            Form7 form7 = new Form7(_db, this);
            this.Hide();
            form7.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = $"ФИО: {curDirector.Surname} {curDirector.Name} {curDirector.Patronimyc}";
            label2.Text = $"Логин: {curDirector.Login}";
        }
    }
}
