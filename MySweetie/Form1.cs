using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySweetie.Models;

namespace MySweetie
{
    public partial class Form1 : Form
    {
        Form goodsForm, invoicesForm, ordersForm, tradersForm, queriesForm;

        private void button3_Click(object sender, EventArgs e)
        {
            ordersForm = new OrdersForm();
            this.Hide();
            ordersForm.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            queriesForm = new Queries();
            queriesForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Изготвили : Станислав Вълев, Евдокия Борисова, Калоян Бялков, Анелия Восеничарова");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tradersForm = new TradersForm();
            this.Hide();
            tradersForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invoicesForm = new InvoicesForm();
            this.Hide();
            invoicesForm.ShowDialog();
            this.Show();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goodsForm = new GoodForm();
            this.Hide();
            goodsForm.ShowDialog();
            this.Show();
        }
    }
}
