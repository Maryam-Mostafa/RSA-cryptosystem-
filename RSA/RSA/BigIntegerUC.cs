using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class BigIntegerUC : UserControl
    {
        public BigIntegerUC()
        {
            InitializeComponent();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BigIntegerUC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            res.Text = inst.Addition(first.Text, second.Text); 
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            res.Text = inst.Subtract(first.Text, second.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            res.Text = inst.multiplication(first.Text, second.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            res.Text = inst.Div(first.Text, second.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
