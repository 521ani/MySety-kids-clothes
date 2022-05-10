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
    public partial class EditInvoice : Form
    {
        int id;
        public EditInvoice()
        {
            InitializeComponent();
        }
        public EditInvoice(Invoice ii) : this()
        {
            id = ii.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Invoice i1 = ctx.Invoices.Where(io => io.Id == id).FirstOrDefault();
                i1.Date = DateTime.Parse(textBox3.Text);
                i1.TraderId = int.Parse(textBox1.Text);
                ctx.SaveChanges();
                MessageBox.Show("1 record edited and saved!");
            }
            textBox1.Text = textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditInvoice_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label2.Text = ctx.Invoices.Where(io => io.Id == id).FirstOrDefault().Date.ToString();
                label5.Text = ctx.Invoices.Where(io => io.Id == id).FirstOrDefault().TraderId.ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
