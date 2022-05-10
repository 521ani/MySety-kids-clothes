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
    public partial class AddInvoice : Form
    {
        public AddInvoice() //Тук трбва да се види ID-то на продавача сиг трябва да се направи с име
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
                Invoice i = new Invoice() { Date = DateTime.Parse(textBox1.Text), TraderId = int.Parse(textBox2.Text)};
                ctx.Invoices.Add(i);
                ctx.SaveChanges();
            }
            textBox1.Text = textBox2.Text = "";
            MessageBox.Show("+1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
