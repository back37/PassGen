using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = 0;
        }
        string result = "";
        Random rnd = new Random();
        System.IO.StreamWriter sw;
        string l = "";
        string L = "";
        string lE = "qwertyuiopasdfghjklzxcvbnm";
        string LE = "QWERTYUIOPASDFGHJKLZXCVBNM";
        string lR = "йцукенгшщзхъфывапролджэячсмитьбюё";
        string LR = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
        string N = "0123456789";
        string S = "!@#$%^&*()_";

        private void button1_Click(object sender, EventArgs e)
        {
            string abc = "";
            int sk = listBox1.Items.Count;

            if (checkBox6.Checked == true)
            {
                abc += maskedTextBox1.Text;
            }
            if (checkBox1.Checked == true)
            {
                abc += S;
            }
            if (checkBox2.Checked == true)
            {
                abc += N;
            }
            if (checkBox3.Checked == true)
            {
                abc += L;
            }
            if (checkBox7.Checked == true)
            {
                abc += l;
            }

            if (abc != "")
            {

                listBox1.Items.Add(textBox2.Text + ":");

                for (int c = 0; c < numericUpDown2.Value; c++)
                {
                    if (checkBox5.Checked && textBox1.Text != "")
                    {
                        for (int f = 0; f < textBox1.TextLength; f++)
                        {
                            int lng = 0;

                            if (textBox1.Text[f] == Convert.ToChar("l") || textBox1.Text[f] == Convert.ToChar("б"))
                            {
                                lng = l.Length - 1;
                                result += l[rnd.Next(lng)];
                            }
                            if (textBox1.Text[f] == Convert.ToChar("L") || textBox1.Text[f] == Convert.ToChar("Б"))
                            {
                                lng = L.Length - 1;
                                result += L[rnd.Next(lng)];
                            }
                            if (textBox1.Text[f] == Convert.ToChar("C") || textBox1.Text[f] == Convert.ToChar("c")|| textBox1.Text[f] == Convert.ToChar("С") || textBox1.Text[f] == Convert.ToChar("с"))
                            {
                                if (checkBox6.Enabled)
                                    if (maskedTextBox1.Text != "")
                                    {
                                        lng = maskedTextBox1.Text.Length - 1;
                                        result += maskedTextBox1.Text[rnd.Next(lng)];
                                    }
                                    else
                                    {
                                        lng = abc.Length - 1;
                                        result += abc[rnd.Next(lng)];
                                    }
                            }
                            if (textBox1.Text[f] == Convert.ToChar("N") || textBox1.Text[f] == Convert.ToChar("n") || textBox1.Text[f] == Convert.ToChar("Ц") || textBox1.Text[f] == Convert.ToChar("ц"))
                            {
                                lng = N.Length - 1;
                                result += N[rnd.Next(lng)];
                            }
                            if (textBox1.Text[f] == Convert.ToChar("S") || textBox1.Text[f] == Convert.ToChar("s") || textBox1.Text[f] == Convert.ToChar("З") || textBox1.Text[f] == Convert.ToChar("з"))
                            {
                                lng = S.Length - 1;
                                result += S[rnd.Next(lng)];
                            }
                            if (textBox1.Text[f] == Convert.ToChar("R") || textBox1.Text[f] == Convert.ToChar("r") || textBox1.Text[f] == Convert.ToChar("Р") || textBox1.Text[f] == Convert.ToChar("р"))
                            {
                                lng = abc.Length - 1;
                                result += abc[rnd.Next(lng)];
                            }
                            if (textBox1.Text[f] == Convert.ToChar("!"))
                            {
                                result += textBox1.Text[f + 1];
                            }
                        }
                    }
                    else
                    {
                        int kol = Convert.ToInt32(numericUpDown1.Value);
                        int lng = abc.Length;
                        for (int i = 0; i < kol; i++)
                            result += abc[rnd.Next(lng)];
                        
                    }

                    bool h = true;
                    for (int k = sk; k < listBox1.Items.Count; k++)
                    {
                        if (result == listBox1.Items[k].ToString())
                            h = false;
                    }

                    if (h == true)
                        listBox1.Items.Add(result);

                    int z = abc.Length;
                    foreach (var letter in abc.Distinct().ToArray())
                    {
                        var count = abc.Count(chr => chr == letter);
                        if (count > 1)
                            z -= count;
                    }
                    if (c == listBox1.Items.Count - 1 - sk && listBox1.Items.Count - 1 < Math.Pow(abc.Length, Convert.ToDouble(numericUpDown1.Value)))
                        c--;

                    result = "";
                }
            }
            else return;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (checkBox4.Checked == true)
                {
                    sw = new System.IO.StreamWriter(saveFileDialog1.FileName, true);
                }
                else
                {
                    saveFileDialog1.OverwritePrompt = false;
                    sw = new System.IO.StreamWriter(saveFileDialog1.FileName);
                }
                foreach (var item in listBox1.Items)
                    sw.WriteLine(item.ToString());
                sw.WriteLine();
                sw.Close();
                MessageBox.Show("Сохранено");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string resStr = string.Empty;
            foreach (object o in listBox1.Items)
            {
                resStr += (string)o + Environment.NewLine;
            }
            Clipboard.SetDataObject(resStr,true);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                maskedTextBox1.Visible = true;
            }
            else
            {
                maskedTextBox1.Visible = false;
                maskedTextBox1.Text = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox1.Visible = true;
                for (int i = 0; i < numericUpDown1.Value; i++)
                    textBox1.Text += "R";
            }
            else
            {
                textBox1.Visible = false;
                textBox1.Text = "";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int Z = 0;
            string st = textBox1.Text;

            for (int f = 0; f< textBox1.TextLength;f++)
            {
                if (st[f] == Convert.ToChar("!"))
                    Z++;
            }

            if (numericUpDown1.Value > textBox1.TextLength - Z)
            {
                if (checkBox5.Checked)
                {
                    for (int i = textBox1.TextLength - Z; i < numericUpDown1.Value; i++)
                    {
                        textBox1.Text += "R";
                    }
                }
            }
            else
            {
                int f = Convert.ToInt16(st.Length - Z - numericUpDown1.Value);
                st = st.Substring(0, st.Length - f);
                if (st.EndsWith("!"))
                    st = st.Substring(0, st.Length - 1);
                textBox1.Text = st;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                while (listBox1.SelectedIndex != -1)
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count<1)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                l = lE;
                L = LE;
            }
            else
                if (comboBox1.SelectedIndex == 1)
                {
                l = lR;
                L = LR;
            }
            else
            {
                l = lE + lR;
                L = LE + LR;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked || checkBox7.Checked)
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;
            }
            else
                comboBox1.Enabled = false;
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string resStr = string.Empty;
            foreach (object o in listBox1.SelectedItems)
            {
                resStr += (string)o + Environment.NewLine;
            }
            Clipboard.SetDataObject(resStr,true);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1_KeyDown(this, null);
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox1.SetSelected(i,true);
        }
    }
}
