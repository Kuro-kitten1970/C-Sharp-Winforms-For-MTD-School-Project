using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double addNum(double num1, double num2)
        {
            return num1 + num2;
        }

        public double subNum(double num1, double num2)
        {
            return num1 - num2;
        }

        public double multiNum(double num1, double num2)
        {
            return num1 * num2;
        }

        public double divNum(double num1, double num2)
        {
            return num1 / num2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double result = addNum(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                textBox3.Text = result.ToString("0.######");
            }
            catch (Exception)
            {
                MessageBox.Show("Pls check your input again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double result = subNum(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                textBox3.Text = result.ToString("0.######");
            }
            catch (Exception)
            {
                MessageBox.Show("Pls check your input again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double result = multiNum(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                textBox3.Text = result.ToString("0.######");
            }
            catch (Exception)
            {
                MessageBox.Show("Pls check your input again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double result = divNum(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                textBox3.Text = result.ToString("0.######");
            }
            catch (Exception)
            {
                MessageBox.Show("Pls check your input again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
            }
        }

        private void button3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.Focus();
            }
        }
    }
}
