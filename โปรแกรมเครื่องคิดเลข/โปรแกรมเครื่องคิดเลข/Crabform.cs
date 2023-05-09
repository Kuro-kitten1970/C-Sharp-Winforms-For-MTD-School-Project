using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมเครื่องคิดเงิน
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

        //ประกาศตัวแปร
        public double num1, num2, result;
        public byte numClick, key = 1;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        private void clearItems()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่ตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            key = 0;
        }

        //เมธอดที่ไว้สำหรับคำนวณทางคณิตศาสตร์
        public void myCalc()
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    err(); //เรียกใช้เมธอด
                    textBox1.Focus();
                }
                else if (textBox2.Text == "" || textBox2.Text == null)
                {
                    err(); //เรียกใช้เมธอด
                    textBox2.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ num1, num2
                    num1 = double.Parse(textBox1.Text);
                    num2 = double.Parse(textBox2.Text);

                    switch (numClick) //ใช้เลือกหนึ่งในโค้ดบล็อกจากทั้งหมด โดยจะรันคำสั่งเมื่อค่าใน numClick ตรงกับกรณีต่าง ๆ  
                    {
                        case 1:
                            result = num1 + num2;
                            break;
                        case 2:
                            result = num1 - num2;
                            break;
                        case 3:
                            result = num1 * num2;
                            break;
                        case 4:
                            result = num1 / num2;
                            break;
                        default:
                            numClick = 0;
                            break;
                    }

                    textBox3.Text = result.ToString("0.########"); //นำค่าจากที่ได้จาก result ไปแสดงผลไปที่ textBox3
                }
            }
            catch (Exception) //ใช้ดักจับ Exception ในกรณีที่ double.Parse ไม่สามารถแปลงค่าได้
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems(); //เรียกใช้เมธอด
                textBox1.Focus();
                key = 0;
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้เมธอด
            textBox1.Focus();
            key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numClick = 1;
            myCalc(); //เรียกใช้เมธอด
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numClick = 2;
            myCalc(); //เรียกใช้เมธอด
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numClick = 3;
            myCalc(); //เรียกใช้เมธอด
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numClick = 4;
            myCalc(); //เรียกใช้เมธอด
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            key = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            key = 1;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ที่ต้องการจัดการอีเว้นท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && key == 1)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && key == 1)
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

        private void button4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5.Focus();
            }
        }
    }
}
