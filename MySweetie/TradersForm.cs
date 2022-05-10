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
    public partial class TradersForm : Form
    {
        public TradersForm()
        {
            InitializeComponent();
        }

        private void TradersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var ctx = new MySweetyDB2Context())
            {
                dataGridView1.DataSource = ctx.Traders.Select(t => new {
                    t.Id,
                    Име = t.Name,
                    MOL = t.Mol,
                    Адрес = t.Adress,
                    Телефон = t.Tel,
                    ДДС = t.TaxNumber
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addTrader = new AddTrader();
            this.Hide();
            addTrader.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trader t = new Trader()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form editTrader = new EditTrader(t);
            this.Hide();
            editTrader.ShowDialog();
            this.LoadData();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trader t = new Trader()
            {
                Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
            };
            Form removeTrader = new RemoveTrader(t);
            this.Hide();
            removeTrader.ShowDialog();
            this.Show();
            this.LoadData();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
