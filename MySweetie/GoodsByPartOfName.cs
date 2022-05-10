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
    public partial class GoodsByPartOfName : Form
    {
        public GoodsByPartOfName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* using (var ctx = new MySweetyDB2Context())
            {
                string d = textBox1.Text;
                dataGridView1.DataSource = ctx.Goods.FromSqlInterpolated($"EXEC usp_2 {d}")
                  .AsEnumerable()
                  .Select(s => new { s.Name, s.RetailPrice })
                   .ToList();
            }*/
            string d = textBox1.Text;
            var context = new MySweetyDB2Context();
            dataGridView1.DataSource = context.Goods
                .Where(s => s.Name.Contains(d))
                .Select(s=> new {Име=s.Name, Цена=s.RetailPrice})
                .ToList();
                }

        private void GoodsByPartOfName_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
