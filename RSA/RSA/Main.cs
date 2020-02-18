using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            BigIntegerUC n = new BigIntegerUC();
            flowLayoutPanel2.Controls.Add(n);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            BigIntegerUC n = new BigIntegerUC();
            flowLayoutPanel2.Controls.Add(n); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            RSAUC n = new RSAUC();
            flowLayoutPanel2.Controls.Add(n);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            Bonuslvl2UC n = new Bonuslvl2UC();
            flowLayoutPanel2.Controls.Add(n);
        }
    }
}
