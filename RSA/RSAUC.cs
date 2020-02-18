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
    public partial class RSAUC : UserControl
    {
        public RSAUC()
        {
            InitializeComponent();
        }

        public string FormatTime(long time)
        {
            long hrs = time / 3600000000;
            time %= 3600000000;
            long mins = time / 60000;
            time %= 60000;
            long secs = time / 1000;
            time %= 1000;
            long millisecs = time;

            return (hrs + " : " + mins + " : " + secs + " : " + millisecs).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int f_time = System.Environment.TickCount;
            BigInteger ob = new BigInteger();
            string result = "";

            if (Integer.Checked)
            {
                if (ob.IsSmaller(mess.Text, n.Text))
                    res.Text = ob.FindMod(mess.Text, pow.Text, n.Text);
                else
                    MessageBox.Show("please make sure that the message you entered is smaller than the N ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            else if (Text.Checked)
            {
                if(ob.IsSmaller(mess.Text, n.Text))
                {
                    string s = ob.FindMod(mess.Text, pow.Text, n.Text);

                    for (int i = 0; i < s.Length; i++)
                    {

                        string curr = "";
                        int current = 0;
                        if (s[i] == '9')
                        {

                            curr = s.Substring(i, 2);
                            i += 1;

                        }
                        else if (s[i] == '1')
                        {

                            curr = s.Substring(i, 3);
                            i += 2;
                        }
                        current = Convert.ToInt32(curr);
                        result += (Convert.ToChar(current)).ToString();


                    }
                    res.Text = result;
                  
                }
                else
                    MessageBox.Show("please make sure the the message you entered is smaller than the N ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            long s_time = System.Environment.TickCount;
            long time = s_time - f_time;
            MessageBox.Show(FormatTime(time));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
             int f_time= System.Environment.TickCount;
            BigInteger ob = new BigInteger();
            if (Integer.Checked) {
                if (ob.IsSmaller(mess.Text, n.Text))
                    res.Text = ob.FindMod(mess.Text, pow.Text, n.Text);
                else
                    MessageBox.Show("please make sure the the message you entered is smaller than the N ","Invalid Input",MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
            else if (Text.Checked) {
                byte[] r = Encoding.ASCII.GetBytes(mess.Text);
                String MSG = String.Join("",r);
                if(ob.IsSmaller(MSG,n.Text))
                res.Text = ob.FindMod(MSG, pow.Text, n.Text); 
                else
                    MessageBox.Show("please make sure the the message you entered is smaller than the N ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            long s_time = System.Environment.TickCount;
            long time = s_time - f_time;
            MessageBox.Show(FormatTime(time));

        }

        private void RSAUC_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Integer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            FileStream sample_rsa = new FileStream("SampleRSA.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(sample_rsa);
            int count = int.Parse(sr.ReadLine());
            FileStream sample_out = new FileStream("SampleRSA_Out.txt", FileMode.Append, FileAccess.Write);
            TextWriter output = new StreamWriter(sample_out);
            while (count > 0)
            {
                string N = sr.ReadLine();
                string E_orD = sr.ReadLine();
                string M_orEM = sr.ReadLine();
                int option = int.Parse(sr.ReadLine());
                if (option == 0)
                {
                    DateTime before = DateTime.Now;
                    string result = inst.FindMod(M_orEM, E_orD, N);

                    output.WriteLine(result);
                    MessageBox.Show("result=", result);

                }
                else if (option == 1)
                {
                    string result = inst.FindMod(M_orEM, E_orD, N);
                    output.WriteLine(result);
                    MessageBox.Show("result=", result);

                }

                count--;
            }
            sr.Close();
            sample_rsa.Close();
            output.Close();
            sample_out.Close();
            MessageBox.Show("Sample output file has been created successfully ^o^");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BigInteger inst = new BigInteger();
            FileStream sample_rsa = new FileStream("TestRSA.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(sample_rsa);
            int count = int.Parse(sr.ReadLine());
            FileStream sample_out = new FileStream("TestRSA_Out.txt", FileMode.Append, FileAccess.Write);
            TextWriter output = new StreamWriter(sample_out);
            while (count > 0)
            {
                string N = sr.ReadLine();
                string E_orD = sr.ReadLine();
                string M_orEM = sr.ReadLine();
                int option = int.Parse(sr.ReadLine());
                if (option == 0)
                {
                    DateTime before = DateTime.Now;
                    string result = inst.FindMod(M_orEM, E_orD, N);

                    output.WriteLine(result);
                    MessageBox.Show("result=", result);

                }
                else if (option == 1)
                {
                    string result = inst.FindMod(M_orEM, E_orD, N);
                    output.WriteLine(result);
                    MessageBox.Show("result=", result);

                }

                count--;
            }
            sr.Close();
            sample_rsa.Close();
            output.Close();
            sample_out.Close();
            MessageBox.Show("Add output file has been created successfully ^o^");
        }
    }
}
