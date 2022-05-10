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
    public partial class DatesOfOrdersOfGood : Form
    {
        public DatesOfOrdersOfGood()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string trName = textBox1.Text;
            if (trName == "") { MessageBox.Show("Please fill the field!"); return; }

            using (var ctx = new MySweetyDB2Context())
            {
                var trader = ctx.Traders.Where(t => t.Mol == trName).FirstOrDefault();

                var traderInvoices = ctx.Invoices.Where(i => i.TraderId == trader.Id).ToList();

                foreach (var invoice in traderInvoices)
                {
                    textBox2.Text += "Дата : " + invoice.Date.ToString() + " :";
                    var orders = ctx.Orders.Where(o => o.InvoiceId == invoice.Id).ToList();
                    foreach (var order in orders)
                    {
                        textBox2.Text += Environment.NewLine;
                        textBox2.Text += "\t Количество: " + order.Quantity + "  Цена: ";
                        var good = ctx.Goods.Where(g => g.Id == order.GoodId).FirstOrDefault();
                        double price = Convert.ToDouble(good.RetailPrice)*order.Quantity;
                        textBox2.Text += price.ToString("c2");
                    }
                    textBox2.Text += Environment.NewLine;
                }

            }
        }

        private void DatesOfOrdersOfGood_Load(object sender, EventArgs e)
        {

        }
    }
}
