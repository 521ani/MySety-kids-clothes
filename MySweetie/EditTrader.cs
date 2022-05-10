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
    public partial class EditTrader : Form
    {
        int id;
        public EditTrader()
        {
            InitializeComponent();
        }
        public EditTrader(Trader tt) : this()
        {
            id = tt.Id;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            //----------------------------------------------
        }

        private void EditTrader_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label1.Text = ctx.Traders.Where(to => to.Id == id).FirstOrDefault().Name.ToString();
                label2.Text = ctx.Traders.Where(to => to.Id == id).FirstOrDefault().Adress.ToString();
                label3.Text = ctx.Traders.Where(to => to.Id == id).FirstOrDefault().Tel.ToString();
                label4.Text = ctx.Traders.Where(to => to.Id == id).FirstOrDefault().TaxNumber.ToString();
                label5.Text = ctx.Traders.Where(to => to.Id == id).FirstOrDefault().Mol.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Trader t1 = ctx.Traders.Where(to => to.Id == id).FirstOrDefault();
                t1.Name = textBox1.Text;
                t1.Adress = textBox2.Text;
                t1.Tel = textBox3.Text;
                t1.TaxNumber = Convert.ToInt64(textBox4.Text);
                t1.Mol = textBox5.Text;
                ctx.SaveChanges();
                MessageBox.Show("1 record edited and saved!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
