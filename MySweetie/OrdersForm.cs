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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var ctx = new MySweetyDB2Context())
            {
                dataGridView1.DataSource = ctx.Orders.Include(O=>O.Good)
                    .Select(o => new {
                    o.Id,
                   Стока = o.Good.Name,
                   Фактура = o.InvoiceId,
                   Количество = o.Quantity
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addOrder = new AddOrder();
            this.Hide();
            addOrder.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order o = new Order()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form editOrder = new EditOrder(o);
            this.Hide();
            editOrder.ShowDialog();
            this.LoadData();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order o = new Order()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form removeOrder = new RemoveOrder(o);
            this.Hide();
            removeOrder.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }
    }
}
