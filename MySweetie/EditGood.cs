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
    public partial class EditGood : Form
    {
        int id;
        public EditGood()
        {
            InitializeComponent();
        }
        public EditGood(Good gg): this()
        {
            id = gg.Id;
        }

        private void EditGood_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                label2.Text = ctx.Goods.Where(go => go.Id == id).FirstOrDefault().Name.ToString();
                label5.Text = ctx.Goods.Where(go => go.Id == id).FirstOrDefault().RetailPrice.ToString("c2");

                var matnames = ctx.Materials.Select(m => new { m.Material1 }).ToList();
                List<string> strMats = new List<string>();
                foreach (var material in matnames)
                {
                    string newName = material.ToString().Substring(14);
                    string materialStr = newName.Remove(newName.Length - 2);
                    strMats.Add(materialStr);
                }
                comboBox1.DataSource = strMats;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
                Good g1 = ctx.Goods.Where(go => go.Id == id).FirstOrDefault();
                g1.Name = textBox3.Text;
                g1.RetailPrice = int.Parse(textBox1.Text);
                g1.Material = ctx.Materials.Where(m => m.Material1 == comboBox1.Text).FirstOrDefault();
                ctx.SaveChanges();
                MessageBox.Show("1 record edited and saved!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
