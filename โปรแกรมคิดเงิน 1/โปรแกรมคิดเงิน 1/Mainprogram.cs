using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมคิดเงิน_1
{
    public partial class mainProgram : Form
    {
        public mainProgram()
        {
            InitializeComponent();
        }

        public double tax;

        public double addNum(double num1, double num2)
        {
            return num1 + num2;
        }

        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double result = addNum(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                textBox3.Text = result.ToString("0.##");
                tax = result * 0.03;
                textBox4.Text = tax.ToString("0.##");
                textBox5.Text = (result + tax).ToString("0.##");
            }
            catch (Exception)
            {
                MessageBox.Show("ประมวลผลผิดพลาด โปรดใส่รูปแบบข้อมูลที่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
