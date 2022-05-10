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
    public partial class RemoveOrder : Form
    {
        Order o;
        public RemoveOrder()
        {
            InitializeComponent();
        }
        public RemoveOrder(Order oo) : this()
        {
            o = oo;
        }
        private void RemoveOrder_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label4.Text = ctx.Orders.Where(ooo => ooo.Id == o.Id).FirstOrDefault().GoodId.ToString();
                label6.Text = ctx.Orders.Where(ooo => ooo.Id == o.Id).FirstOrDefault().Quantity.ToString();
                label3.Text = ctx.Orders.Where(ooo => ooo.Id == o.Id).FirstOrDefault().InvoiceId.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Order o1 = ctx.Orders
                        .Where(ooo => ooo.Id == o.Id)
                        .FirstOrDefault();
                MessageBox.Show("You are about to delete 1 record!");
                ctx.Orders.Remove(o1);
                ctx.SaveChanges();
            }
            label4.Text = label6.Text = label3.Text="";
            MessageBox.Show("-1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
