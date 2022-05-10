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
    public partial class InvoicesForm : Form
    {
        public InvoicesForm()
        {
            InitializeComponent();
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var ctx = new MySweetyDB2Context())
            {
                dataGridView1.DataSource = ctx.Invoices.Include(i=>i.Trader)
                    .Select(i => new {
                    i.Id,
                   Дата = i.Date,
                   Купувач = i.Trader.Name
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addInvoice = new AddInvoice();
            this.Hide();
            addInvoice.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Invoice i = new Invoice()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form editInvoice = new EditInvoice(i);
            this.Hide();
            editInvoice.ShowDialog();
            this.LoadData();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form removeInvoice = new RemoveInvoice(i); 
            this.Hide();
            removeInvoice.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
