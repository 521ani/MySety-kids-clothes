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
    public partial class AddGood : Form
    {
        public AddGood()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("You have to fill in both textboxes!!!");
                return;
            }
            using (var ctx = new MySweetyDB2Context())
            {
                Good g = new Good() { Name = textBox1.Text, MaterialId = SelectMaterial() , RetailPrice = int.Parse(textBox2.Text)};
                ctx.Goods.Add(g);
                ctx.SaveChanges();
            }
            textBox1.Text = textBox2.Text = "";
            MessageBox.Show("+1 record!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddGood_Load(object sender, EventArgs e)
        {
            using (var ctx = new MySweetyDB2Context())
            {
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
        private int SelectMaterial()
        {
            int matId = 1;
            using (var ctx = new MySweetyDB2Context())
            {
                Material m = ctx.Materials.Where(m1 => m1.Material1 == comboBox1.Text).FirstOrDefault();
                matId = m.Id;
            }
            return matId;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
