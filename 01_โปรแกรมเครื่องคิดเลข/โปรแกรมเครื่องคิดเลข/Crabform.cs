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

        //// Credit : Kuro_kitten ////

        ////ด้านล่างนี้คือตัวแปรที่มีไว้เพื่อเก็บค่าต่าง ๆ
        ////Syntax ประเภทข้อมูล ชื่อตัวแปร; หรือ ประเภทข้อมูล ชื่อตัวแปร = ค่าเริ่มต้น; 
        double num1, num2, result;
        byte btnKey;
        bool keyUp = true;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void button1_Click(object sender, EventArgs e)
        {
            btnKey = 1; //เซ็ตค่าในตัวแปรที่ได้ประกาศเอาไว้
            Calc(); //เรียกใช้ฟังก์ชันที่เราเขียนขึ้นมา
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnKey = 2;
            Calc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKey = 3;
            Calc();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKey = 4;
            Calc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearItems(); //เรียกใช้ฟังก์ชันที่เราเขียนขึ้นมา
            textBox1.Focus(); //ฟังก์ชันที่ใช้โฟกัสใน object ต่าง ๆ
            keyUp = false; //เซ็ตค่าในตัวแปรที่ได้ประกาศเอาไว้
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //อันนี้เป็นส่วนที่ใช้แสดงหน้าต่าง Message และรอรับค่าจากปุ่มที่ผู้ใช้กดในเมนูที่แสดง เพื่อดำเนินการขั้นต่อไป
            if (MessageBox.Show("Do you want to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit(); //ฟังก์ชันที่ใช้ปิดโปรแกรม
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyUp = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            keyUp = true;
        }

        ////ตั้งแต่ส่วนนี้ลงไปคือ event ที่ได้จากหน้าเมนู Events (รูปสายฟ้า) ที่อยู่ในหน้า Properties
        ////วิธีการคือ คลิก object ที่เราต้องการในหน้า Design 1 ครั้ง จากนั้นไปที่เมนูตามบรรทัดบน และดับเบิลคลิก event ที่เราต้องการ
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //ตรงนี้คือการรับค่าจากคีย์บอร์ด และนำค่ามาเปรียบเทียบ เพื่อดำเนินการต่อไป
            //ตรงส่วนพวก if ที่มีหลายเงื่อนไข เราสามารถเชื่อมเงื่อนไขเหล่านั้นได้ด้วย && (และ) กับ || (หรือ)
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                button1.Focus();
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                button2.Focus();
            }
        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                button3.Focus();
            }
        }

        private void button3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                button4.Focus();
            }
        }

        private void button4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyUp)
            {
                button5.Focus();
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        private void ClearItems()
        {
            textBox1.Clear(); //ตรงนี้เราใช้ฟังก์ชัน Clear() เพื่อลบสิ่งที่แสดงอยู่่ใน object
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Calc()
        {
            //TryCatch ใช้สำหรับดักจับ Error ต่าง ๆ ที่สามารถเกิดขึ้นได้
            //ในกรณีนี้ เราใช้มันเพื่อดักจับ Error ที่สามารถเกิดขึ้นได้ในกรณีที่โปรแกรมไม่สามารถแปลงค่าจาก string มาเป็น double
            try
            {
                //อันนี้โค้ดที่ใช้แปลงค่า โดยรับค่าจาก TextBox และส่งค่าที่แปลงได้ไปเก็บที่ตัวแปรที่เราประกาศไว้
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = Convert.ToDouble(textBox2.Text);

                //พวกนี้ใช้บวกลบคูณหารเลข โดยจะทำงานตามเงื่อนไข if ที่เรากำหนดไว้
                //ซึ่งถ้าใครอยากรู้ว่า btnKey มันรับค่าจากที่ใดมาใช้เปรียบเทียบ ให้กลับไปดูโค้ดด้านบน
                if (btnKey == 1)
                {
                    result = num1 + num2;
                }
                else if (btnKey == 2)
                {
                    result = num1 - num2;
                }
                else if (btnKey == 3)
                {
                    result = num1 * num2;
                }
                else if (btnKey == 4)
                {
                    result = num1 / num2;
                }
                else
                {
                    MessageBox.Show("PROGRAM ERROR!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    keyUp = false;
                }

                textBox3.Text = result.ToString(); //แสดงผลจากตัวแปร result ไปยัง TextBox
            }
            catch (FormatException)
            {
                //ตรงนี้หากโค้ดด้านบนมี Error เกิดขึ้น โค้ดส่วนนี้ก็จะทำงานตามที่เราเขียนไว้
                MessageBox.Show("Pls check your input again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                keyUp = false;
            }
        }
    }
}
