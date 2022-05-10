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
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("You have to fill in both textboxes!!!");
                return;
            }
            using (var ctx = new MySweetyDB2Context())
            {
                Order o = new Order() { GoodId = int.Parse(textBox1.Text), Quantity = int.Parse(textBox2.Text), InvoiceId = int.Parse(textBox3.Text) };
                ctx.Orders.Add(o);
                ctx.SaveChanges();
            }
            textBox1.Text = textBox2.Text = "";
            MessageBox.Show("+1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
