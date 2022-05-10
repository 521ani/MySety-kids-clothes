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
    public partial class RemoveInvoice : Form
    {
        Invoice i;
        public RemoveInvoice()
        {
            InitializeComponent();
        }
        public RemoveInvoice(Invoice ii) : this()
        {
            i = ii;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Invoice i1 = ctx.Invoices
                        .Where(io => io.Id == i.Id)
                        .FirstOrDefault();
                MessageBox.Show("You are about to delete 1 record!");
                ctx.Invoices.Remove(i1);
                ctx.SaveChanges();
            }
            label3.Text = label4.Text = "";
            MessageBox.Show("-1 record!");
        }

        private void RemoveInvoice_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label4.Text = ctx.Invoices.Where(io => io.Id == i.Id).FirstOrDefault().Date.ToString();
                label3.Text = ctx.Invoices.Where(io => io.Id == i.Id).FirstOrDefault().TraderId.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
