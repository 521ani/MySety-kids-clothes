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
    public partial class RemoveGood : Form
    {
        Good g;
        public RemoveGood()
        {
            InitializeComponent();
        }
        public RemoveGood(Good gg) : this()
        {
            g = gg;
        }
        private void RemoveGood_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label4.Text = ctx.Goods.Where(go => go.Id == g.Id).FirstOrDefault().Name.ToString();
                label3.Text = ctx.Goods.Where(go => go.Id == g.Id).FirstOrDefault().RetailPrice.ToString("c2");
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Good g1 = ctx.Goods
                        .Where(go => go.Id == g.Id)
                        .FirstOrDefault();
                MessageBox.Show("You are about to delete 1 record!");
                ctx.Goods.Remove(g1);
                ctx.SaveChanges();
            }
            label3.Text=label4.Text="";
            MessageBox.Show("-1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
