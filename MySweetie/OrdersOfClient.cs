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
using Microsoft.EntityFrameworkCore;


namespace MySweetie
{
    public partial class OrdersOfClient : Form
    {
        public OrdersOfClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ctx = new MySweetyDB2Context(); /*good po data na obratno pishesh iydelie dava poruchka*/
            string d = textBox1.Text;
            var q = ctx.Orders
                .Include(g => g.Good)
                .Include(a=> a.Invoice) /*ne moga da izkaram order->invoice.date*/
                .Where(g => g.Good.Name == d)
                .Select(g => new {g.Good.Name,g.Invoice.Date}).ToList();
            dataGridView1.DataSource = q;
        }

        private void OrdersOfClient_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
