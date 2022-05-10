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
    public partial class QueeryOrderByDate : Form
    {
        public QueeryOrderByDate()
        {
            InitializeComponent();
        }

        private void QueeryOrderByDate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ctx = new MySweetyDB2Context(); /*Klienti po data*/
            DateTime d = DateTime.Parse(textBox1.Text);
            var q = ctx.Invoices
                .Include(t => t.Trader)
                .Where(i => i.Date == d)
                .Select(i => new { i.Trader.Name, i.Date, i.Id }).ToList();
            dataGridView1.DataSource = q;

            /*var ctx = new MySweetyDB2Context();
            DateTime d = DateTime.Parse(textBox1.Text);

            var invoiceList = ctx.Invoices.ToList();
            foreach (Invoice i in invoiceList)
            {
                ctx.Entry(i).Reference(i => i.Trader).Load();
                listBox1.Items.Add($"{i.Date },{i.Trader.Name}");
            }*/
               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
