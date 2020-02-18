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
    public partial class Bonuslvl2UC : UserControl
    {
        public Bonuslvl2UC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FirstNum_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] results = new int[5];
            BigInteger ob = new BigInteger();
             results = ob.GenerateKeys();
            n_box.Text = results[2].ToString();
            e_box.Text = results[3].ToString();
            d_box.Text = results[4].ToString();
           // MessageBox.Show(results[0].ToString() + "   " + results[1].ToString());
           
        }
    }
}
