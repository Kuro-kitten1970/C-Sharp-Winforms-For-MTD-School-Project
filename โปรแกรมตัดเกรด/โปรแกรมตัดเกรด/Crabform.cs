using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมตัดเกรด
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //คีย์เวิร์ด
        // grade, score1, score2, score3 และ result  คือ ตัวแปรที่ใช้เก็บค่าต่าง ๆ
        // keyOP  คือ ตัวแปรที่จะใช้เก็บค่าตรรกศาสตร์ เพื่อที่จะนำไปใช้ในการจัดการทางเลือกของโปรแกรม
        // clearItems() และ err()  คือ เมธอดที่เราสร้างขึ้นมาเอง
        // textBox1, textBox2, textBox3 และ textBox4  คือ กล่องข้อความที่ใช้รับค่าจากผู้ใช้ก่อนจะนำไปเก็บในตัวแปร
        // exitButton, clearButton และ calcButton
        // ปุ่ม ออก   , ปุ่ม รีเซ็ท     และ ปุ่ม ตัดเกรด  

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public double score1, score2, score3, result;
        public bool keyOP = true;
        public string grade;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        public void clearItems()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label5.Text = "";
            textBox1.Focus();
        }

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่ตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            keyOP = false;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearItems();
            keyOP = false;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    err();
                    textBox1.Focus();
                }
                else if (textBox2.Text == "" || textBox2.Text == null)
                {
                    err();
                    textBox2.Focus();
                }
                else if (textBox3.Text == "" || textBox3.Text == null)
                {
                    err();
                    textBox3.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ score
                    score1 = double.Parse(textBox1.Text);
                    score2 = double.Parse(textBox2.Text);
                    score3 = double.Parse(textBox3.Text);

                    //ตัวแปร result มีค่าเป็น score1 + score2 + score3
                    result = score1 + score2 + score3;
                    textBox4.Text = result.ToString();
                    //นำค่าจากที่ได้จาก result ไปแสดงผลไปที่ textBox4

                    if (result >= 0 && result < 50)
                    {
                        grade = "0";
                    }
                    if (result >= 50 && result < 55)
                    {
                        grade = "1";
                    }
                    if (result >= 55 && result < 60)
                    {
                        grade = "1.5";
                    }
                    if (result >= 60 && result < 65)
                    {
                        grade = "2";
                    }
                    if (result >= 65 && result < 70)
                    {
                        grade = "2.5";
                    }
                    if (result >= 70 && result < 75)
                    {
                        grade = "3";
                    }
                    if (result >= 75 && result < 80)
                    {
                        grade = "3.5";
                    }
                    if (result >= 80)
                    {
                        grade = "4";
                    }

                    if (result < 0)
                    {
                        label5.Text = "คะแนนติดลบ โปรดตรวจสอบว่าคุณใส่คะแนนถูกต้อง";
                    }
                    else
                    {
                        label5.Text = "คุณได้รับเกรด: " + grade;
                    }
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems(); //เรียกใช้เมธอด
                keyOP = false;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ที่ต้องการจัดการอีเว้นท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                calcButton.Focus();
            }
        }

        private void calcButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                clearButton.Focus();
            }
        }
    }
}
