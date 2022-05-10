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
    public partial class EditOrder : Form
    {
        int id;
        public EditOrder()
        {
            InitializeComponent();
        }
        public EditOrder(Order oo) : this()
        {
            id = oo.Id;
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label4.Text = ctx.Orders.Where(ooo => ooo.Id == id).FirstOrDefault().GoodId.ToString();
                label7.Text = ctx.Orders.Where(ooo => ooo.Id == id).FirstOrDefault().Quantity.ToString();
                label3.Text = ctx.Orders.Where(ooo => ooo.Id == id).FirstOrDefault().InvoiceId.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Order o1 = ctx.Orders.Where(ooo => ooo.Id == id).FirstOrDefault();
                o1.GoodId = int.Parse(textBox1.Text);
                o1.Quantity = int.Parse(textBox2.Text);
                o1.InvoiceId = int.Parse(textBox3.Text);
                ctx.SaveChanges();
                MessageBox.Show("1 record edited and saved!");
            }
        }
    }
}
