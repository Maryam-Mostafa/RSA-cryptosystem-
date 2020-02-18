using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            if (first.Text != "" || second.Text != "")
                res.Text = inst.Addition(first.Text, second.Text);

            else
            {
                FileStream add_in = new FileStream("AddTestCases.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(add_in);
                int count = int.Parse(sr.ReadLine());
                FileStream fs = new FileStream("AddOutput.txt", FileMode.Append);
                TextWriter txt = new StreamWriter(fs);

                while (count > 0)
                {
                    sr.ReadLine();
                    string Number1 = sr.ReadLine();
                    string Number2 = sr.ReadLine();

                    txt.WriteLine(inst.Addition(Number1, Number2));
                    txt.WriteLine();

                    count--;
                    first.Text = "";
                    second.Text = "";
                    res.Text = "";

                }
                sr.Close();
                add_in.Close();
                txt.Close();
                fs.Close();

                MessageBox.Show("Add output file has been created successfully ^o^");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            if (first.Text != "" || second.Text != "")
                res.Text = inst.Subtract(first.Text, second.Text);

            else
            {
                FileStream add_in = new FileStream("SubtractTestCases.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(add_in);
                int count = int.Parse(sr.ReadLine());
                FileStream fs = new FileStream("SubOutput.txt", FileMode.Append);
                TextWriter txt = new StreamWriter(fs);

                while (count > 0)
                {
                    sr.ReadLine();
                    string Number1 = sr.ReadLine();
                    string Number2 = sr.ReadLine();

                    txt.WriteLine(inst.Subtract(Number1, Number2));
                    txt.WriteLine();

                    count--;
                    first.Text = "";
                    second.Text = "";
                    res.Text = "";

                }
                sr.Close();
                add_in.Close();
                txt.Close();
                fs.Close();
                MessageBox.Show("Subtraction output file has been created successfully ^o^");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            if (first.Text != "" || second.Text != "")
                res.Text = inst.multiplication(first.Text, second.Text);

            else
            {
                FileStream add_in = new FileStream("MultiplyTestCases.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(add_in);
                int count = int.Parse(sr.ReadLine());
                FileStream fs = new FileStream("MultiplyOutput.txt", FileMode.Append);
                TextWriter txt = new StreamWriter(fs);

                while (count > 0)
                {
                    sr.ReadLine();
                    string Number1 = sr.ReadLine();
                    string Number2 = sr.ReadLine();

                    txt.WriteLine(inst.multiplication(Number1, Number2));
                    txt.WriteLine();

                    count--;
                    first.Text = "";
                    second.Text = "";
                    res.Text = "";

                }
                sr.Close();
                add_in.Close();
                txt.Close();
                fs.Close();
                MessageBox.Show("Multiplication output file has been created successfully ^o^");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            res.Text = inst.Div(first.Text, second.Text);
            if (res.Text == "")
                MessageBox.Show("Result = Error You Cant Divide By Zero \nReminder =  :) ", "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
