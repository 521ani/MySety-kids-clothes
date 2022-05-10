using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySweetie
{
    public partial class Queries : Form
    {
        Form goodByName, datesOfGoodOrders , ordersByClient;
        public Queries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goodByName = new GoodsByPartOfName();
            this.Hide();
            goodByName.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ordersByClient = new OrdersOfClient();
            this.Hide();
            ordersByClient.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datesOfGoodOrders = new DatesOfOrdersOfGood();
            this.Hide();
            datesOfGoodOrders.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form QOBD = new QueeryOrderByDate();
            this.Hide();
            QOBD.ShowDialog();
        }
    }
}
