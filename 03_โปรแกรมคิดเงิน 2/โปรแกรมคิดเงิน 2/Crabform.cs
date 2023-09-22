using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมคิดเงิน_2
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
        private double item1, item2, result, getMoney;
        private bool keyOP = true;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void button4_Click(object sender, EventArgs e)
        {
            //อันนี้เป็นส่วนที่ใช้แสดงหน้าต่าง Message และรอรับค่าจากปุ่มที่ผู้ใช้กดในเมนูที่แสดง เพื่อดำเนินการขั้นต่อไป
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit(); //ฟังก์ชันที่ใช้ปิดโปรแกรม
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้ฟังก์ชันที่เราเขียนขึ้นมา
            keyOP = false; //เซ็ตค่าในตัวแปรที่ได้ประกาศเอาไว้
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TryCatch ใช้สำหรับดักจับ Error ต่าง ๆ ที่สามารถเกิดขึ้นได้
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    err();
                    textBox1.Focus(); //ฟังก์ชันที่ใช้โฟกัสใน object ต่าง ๆ
                }
                else if (textBox2.Text == "" || textBox2.Text == null)
                {
                    err();
                    textBox2.Focus();
                }
                else 
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ item1, item2
                    item1 = double.Parse(textBox1.Text);
                    item2 = double.Parse(textBox2.Text);
                    result = item1 + item2; //ตัวแปร result มีค่าเป็น item1 + item2

                    textBox3.Text = result.ToString();
                    //นำค่าจากที่ได้จาก result ไปแสดงผลไปที่ textBox3
                }
            }
            catch (FormatException) 
            {
                //ตรงนี้หากโค้ดด้านบนมี Error เกิดขึ้น โค้ดส่วนนี้ก็จะทำงานตามที่เราเขียนไว้
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems();
                keyOP = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "" || textBox4.Text == null)
                {
                    err();
                    textBox4.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ getMoney
                    getMoney = double.Parse(textBox4.Text);

                    textBox5.Text = (getMoney - result).ToString();
                    //นำค่าจากที่ได้จาก getMoney - result ไปแสดงผลไปที่ textBox5
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
                textBox4.Focus();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

        ////ตั้งแต่ส่วนนี้ลงไปคือ event ที่ได้จากหน้าเมนู Events (รูปสายฟ้า) ที่อยู่ในหน้า Properties
        ////วิธีการคือ คลิก object ที่เราต้องการในหน้า Design 1 ครั้ง จากนั้นไปที่เมนูตามบรรทัดบน และดับเบิลคลิก event ที่เราต้องการ
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //ตรงนี้คือการรับค่าจากคีย์บอร์ด และนำค่ามาเปรียบเทียบ เพื่อดำเนินการต่อไป
            //ตรงส่วนพวก if ที่มีหลายเงื่อนไข เราสามารถเชื่อมเงื่อนไขเหล่านั้นได้ด้วย && (และ) กับ || (หรือ)
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
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
                textBox4.Focus();
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button2.Focus();
            }
        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button3.Focus();
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        private void clearItems()
        {
            textBox1.Clear(); //ตรงนี้เราใช้ฟังก์ชัน Clear() เพื่อลบสิ่งที่แสดงอยู่่ใน object
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
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
