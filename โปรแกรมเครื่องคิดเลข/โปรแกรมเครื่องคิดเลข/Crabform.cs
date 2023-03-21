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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //คีย์เวิร์ด
        // num1, num2 และ result  คือ ตัวแปรใช้เก็บค่าจากผู้ใช้
        // numClick และ keys  ใช้เก็บค่าของกุญแจที่จะนำไปใช้ในการจัดการทางเลือกของโปรแกรม
        // clearItems(), err() และ myCalc()  คือ เมธอดที่เราสร้างขึ้นเอง
        // textBox1, textBox2 และ textBox3  คือ กล่องข้อความที่ใช้รับค่าจากผู้ใช้ก่อนจะนำไปเก็บในตัวแปร
        // exitButton, clearButton, addButton, subButton, multiButton และ divButton
        // ปุ่ม Exit   , ปุ่ม Clear  , ปุ่ม +     , ปุ่ม -     , ปุ่ม *       และ  ปุ่ม /

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public double num1, num2, result;
        public byte numClick, keys = 1;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        public void clearItems()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่ตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            keys = 0;
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
                    err();
                    textBox2.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double
                    num1 = double.Parse(textBox1.Text);
                    num2 = double.Parse(textBox2.Text);

                    switch (numClick)
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

                    textBox3.Text = result.ToString("0.########"); //แสดงผลลัพธ์ไปที่ textBox3
                }
            }
            catch (Exception) //ใช้ดักจับ Exception ในกรณีที่ double.Parse ไม่สามารถแปลงค่าได้
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems(); //เรียกใช้เมธอด
                textBox1.Focus();
                keys = 0;
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นอีเว้นท์ที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้เมธอด
            textBox1.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            numClick = 1;
            myCalc(); //เรียกใช้เมธอด
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            numClick = 2;
            myCalc(); //เรียกใช้เมธอด
        }

        private void multiButton_Click(object sender, EventArgs e)
        {
            numClick = 3;
            myCalc(); //เรียกใช้เมธอด
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            numClick = 4;
            myCalc(); //เรียกใช้เมธอด
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keys = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            keys = 1;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keys == 1)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keys == 1)
            {
                addButton.Focus();
            }
        }

        private void addButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                subButton.Focus();
            }
        }

        private void subButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                multiButton.Focus();
            }
        }

        private void multiButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                divButton.Focus();
            }
        }
    }
}
