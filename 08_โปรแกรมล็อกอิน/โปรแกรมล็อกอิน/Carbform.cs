using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมล็อกอิน
{
    public partial class Carbform : Form
    {
        public Carbform()
        {
            InitializeComponent();
        }

        //// Credit : Kuro_kitten ////

        /* Note */
        /* จะมีอยู่หลายวิธีที่เราสามารถนำรูปมาใช้ในโปรแกรมได้
           1. Import รูปเข้า Resources.resx (วิธีที่เราใช้)
           2. ใช้ filepath ในการระบุที่อยู่ของรูป
           3. ใช้คลาส Assembly และ Stream ในการดึงรูปประเภท Embedded Resource มาใช้
         
           ซึ่งเราใช้วิธีที่ 1 โดยให้เราคลิกขวาที่โปรเจ็กต์ของเรา จากนั้นกดคำว่า Add และต่อด้วย New Item จากนั้นให้เลื่อนหา Resource File
           เมื่อหาเจอแล้วให้เราตั้งชื่อตามที่ต้องการ (จำชื่อให้ดี เพราะเราต้องใช้โค้ดเรียกมัน) เมื่อตั้งชื่อเสร็จให้เราเพิ่มมันเข้ามา
         
           เสร็จจากข้างบน ให้เราดับเบิลคลิกไฟล์ที่เพิ่งเพิ่มเข้ามา เปลี่ยนจาก Strings เป็น Images แล้วกดที่สามเหลี่ยมเล็ก ๆ ที่อยู่ด้านหลัง Add Resource
           จากนั้นกด Add Existing File แล้วให้เราหารูปที่เราต้องการเพิ่ม เท่านี้เราก็จะได้รูปเข้าไฟล์ Resource.resx*/

        ////ด้านล่างนี้คือตัวแปรที่มีไว้เพื่อเก็บค่าต่าง ๆ
        ////Syntax ประเภทข้อมูล ชื่อตัวแปร; หรือ ประเภทข้อมูล ชื่อตัวแปร = ค่าเริ่มต้น;
        public bool keyOP = true;


        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Carbform_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = IMGResource.logo; //เซ็ตรูปใน pictureBox จาก "ชื่อไฟล์ Resource ที่เราเพิ่มมา.ชื่อรูปภาพที่เราเพิ่มมา"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                keyOP = false;
                err(); //เรียกใช้ฟังก์ชันที่เราเขียนเอง
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                keyOP = false;
                err();
                textBox2.Focus();
            }
            else
            {
                if (textBox1.Text == "Admin" && textBox2.Text == "123")
                {
                    pictureBox1.Image = IMGResource.user;
                    MessageBox.Show("ยินดีต้อนรับนายท่าน!", "WELCOME ADMIN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Text = "ล็อกเอาท์";
                }
                else 
                {
                    pictureBox1.Image = IMGResource.error;
                    MessageBox.Show("เกิดข้อผิดพลาด ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button2.Text = "ยกเลิก";
                    keyOP = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "ล็อกเอาท์")
            {
                MessageBox.Show("หวังว่าเราจะได้พบกันอีกครั้งนะ", "BYE ADMIN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            keyOP = false;

            pictureBox1.Image = IMGResource.logo; //เปลี่ยนรูปใน pictureBox1
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
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

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            pictureBox1.Image = IMGResource.error; //เปลี่ยนรูปใน pictureBox1
            MessageBox.Show("เกิดข้อผิดพลาด กรุณาตรวจสอบว่าท่านได้ใส่ข้อมูลหรือไม่", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
