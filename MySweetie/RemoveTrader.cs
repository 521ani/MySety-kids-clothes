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
    public partial class RemoveTrader : Form
    {
        Trader t;
        public RemoveTrader()
        {
            InitializeComponent();
        }
        public RemoveTrader(Trader tt) : this()
        {
            t = tt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Trader t1 = ctx.Traders
                        .Where(to => to.Id == t.Id)
                        .FirstOrDefault();
                MessageBox.Show("You are about to delete 1 record!");
                ctx.Traders.Remove(t1);
                ctx.SaveChanges();
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            MessageBox.Show("-1 record!");
        }

        private void RemoveTrader_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                textBox1.Text = ctx.Traders.Where(to => to.Id == t.Id).FirstOrDefault().Name.ToString();
                textBox2.Text = ctx.Traders.Where(to => to.Id == t.Id).FirstOrDefault().Adress.ToString();
                textBox3.Text = ctx.Traders.Where(to => to.Id == t.Id).FirstOrDefault().Tel.ToString();
                textBox4.Text = ctx.Traders.Where(to => to.Id == t.Id).FirstOrDefault().TaxNumber.ToString();
                textBox5.Text = ctx.Traders.Where(to => to.Id == t.Id).FirstOrDefault().Mol.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
