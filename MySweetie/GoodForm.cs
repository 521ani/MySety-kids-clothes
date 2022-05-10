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
    public partial class GoodForm : Form
    {
        Form addGood;
        public GoodForm()
        {
            InitializeComponent();
        }

        private void TableInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var ctx = new MySweetyDB2Context())
            {
                dataGridView1.DataSource = ctx.Goods.Include(i => i.Material).
                    Select(g => new {
                        Ид = g.Id,
                        Име = g.Name,
                        Материал = g.Material.Material1,
                        Цена = g.RetailPrice
                    }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addGood = new AddGood();
            this.Hide();
            addGood.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Good g = new Good()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form editGood = new EditGood(g);
            this.Hide();
            editGood.ShowDialog();
            this.LoadData();
            this.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Good g = new Good()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form removeGood = new RemoveGood(g);
            this.Hide();
            removeGood.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //????????
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void RemoveButton_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void RemoveButton_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
