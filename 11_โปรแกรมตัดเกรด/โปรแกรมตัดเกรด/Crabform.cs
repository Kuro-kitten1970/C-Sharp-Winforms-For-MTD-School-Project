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

        //// Credit : Kuro_kitten ////

        ////ด้านล่างนี้คือตัวแปรที่มีไว้เพื่อเก็บค่าต่าง ๆ
        ////Syntax ประเภทข้อมูล ชื่อตัวแปร; หรือ ประเภทข้อมูล ชื่อตัวแปร = ค่าเริ่มต้น;
        private double score1, score2, score3, result;
        private bool keyOP = true;
        private string grade;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearItems();
            keyOP = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
                    else if (result >= 50 && result < 55)
                    {
                        grade = "1";
                    }
                    else if (result >= 55 && result < 60)
                    {
                        grade = "1.5";
                    }
                    else if (result >= 60 && result < 65)
                    {
                        grade = "2";
                    }
                    else if (result >= 65 && result < 70)
                    {
                        grade = "2.5";
                    }
                    else if (result >= 70 && result < 75)
                    {
                        grade = "3";
                    }
                    else if (result >= 75 && result < 80)
                    {
                        grade = "3.5";
                    }
                    else if (result >= 80)
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

        ////ตั้งแต่ส่วนนี้ลงไปคือ event ที่ได้จากหน้าเมนู Events (รูปสายฟ้า) ที่อยู่ในหน้า Properties
        ////วิธีการคือ คลิก object ที่เราต้องการในหน้า Design 1 ครั้ง จากนั้นไปที่เมนูตามบรรทัดบน และดับเบิลคลิก event ที่เราต้องการ
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
                button1.Focus();
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button2.Focus();
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        private void clearItems()
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
    }
}
