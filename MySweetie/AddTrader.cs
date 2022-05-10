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
    public partial class AddTrader : Form
    {
        public AddTrader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("You have to fill in both textboxes!!!");
                return;
            }
            using (var ctx = new MySweetyDB2Context())
            {
                Trader t = new Trader() { Name = textBox1.Text, Adress = textBox2.Text, Tel = textBox3.Text, TaxNumber=Convert.ToInt64(textBox4.Text), Mol=textBox5.Text };
                ctx.Traders.Add(t);
                ctx.SaveChanges();
            }
            //Има ограничение за Tax?nummer трябва много да се внимава
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            MessageBox.Show("+1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddTrader_Load(object sender, EventArgs e)
        {

        }
    }
}
