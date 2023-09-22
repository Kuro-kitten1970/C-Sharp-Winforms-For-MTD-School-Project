using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace โปรแกรมรายชื่อนักเรียน
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

        //// Credit : Kuro_kitten ////

        /* Note */
        /* จะมีหลายวิธีที่เราสามารถนำรูปมาใช้ในโปรแกรมได้
           1. Import รูปเข้า Resources.resx
           2. ใช้ filepath ในการระบุที่อยู่ของรูป
           3. ใช้คลาส Assembly และ Stream ในการดึงรูปประเภท Embedded Resource มาใช้ (วิธีที่เราใช้)
         
           ซึ่งเราจะใช้วิธีที่ 3 เพราะ Embedded Resource จะถูกคอมไพล์เข้าไปในตัว .exe ทำให้เราไม่จำเป็นต้องกังวลในกรณีที่เราย้ายโปรแกรม
           ไปที่อื่น เพราะถ้าเราใช้วิธีที่ 2 โค้ดเส้นทางที่เราเขียนก็จะถูกเรียกตามนั้น ซึ่งหากไม่มีไฟล์ตามที่เราเขียนไว้ จะทำให้โปรแกรม Error ได้
           แน่นอนว่าวิธีแรกจะใช้ง่ายกว่าทุกวิธีที่กล่าวไป แต่มันจะมีปัญหาตรงไม่สามารถเรียกใช้โค้ดซํ้า ๆ ได้ ผมเลยเลือกที่จะไม่ทำ
          
           ซึ่งก่อนที่เราจะเริ่มโค้ด เราจะต้องสร้าง new folder ขึ้นมาในโปรเจ็กต์ จากนั้นกดคลิกขวาที่โฟล์เดอร์ และกด Add จากนั้นไปที่ Existing Item
           จากนั้นให้หารูปของเรา เพื่อนำมาเข้าสู่โปรเจ็กต์ (หากใครที่ไม่มีไฟล์รูปขึ้น ให้เรากดตรงส่วนที่อยู่ด้านบนคำว่า เพิ่ม หรือ Add และให้เลือกเป็น Image Files)
           เมื่อนำรูปเข้าโปรเจ็กต์ได้แล้ว ให้เราคลิกในแต่ละรูปที่อยู่ในโปรเจ็กต์ จากนั้นไปที่เมนู Properties 
           สุดท้ายให้เราไปที่ส่วน Build Action และเปลี่ยนเป็น Embedded Resource
         */

        ////ด้านล่างนี้คือตัวแปรที่มีไว้เพื่อเก็บค่าต่าง ๆ
        ////Syntax ประเภทข้อมูล ชื่อตัวแปร; หรือ ประเภทข้อมูล ชื่อตัวแปร = ค่าเริ่มต้น;
        private string errorImage = "โปรแกรมรายชื่อนักเรียน.images.error.png"; //ประกาศตัวแปร เพื่อเก็บ path ในการระบุที่อยู่ของรูป
        private string logoImage = "โปรแกรมรายชื่อนักเรียน.images.logo.png"; //string yourVariable = "YourNamespace.YourFolder.YourImage.png";
        private string stdImage = "โปรแกรมรายชื่อนักเรียน.images.";
        private bool keyOP = true;
        private string name, age, height, weight;

        Assembly assembly = Assembly.GetExecutingAssembly();

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            using (Stream stream = assembly.GetManifestResourceStream(logoImage))
            {
                pictureBox1.Image = new Bitmap(stream);
            }

            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                err();
                keyOP = false;
                textBox1.Focus();
                return;
            }
            else
            {
                if (textBox1.Text == "001")
                {
                    StudentIMG("student_001.jpg"); //เรียกใช้ฟังก์ชันที่เราเขียนเอง โดยเป็นฟังก์ชันที่มีตัว Parameter ทำให้เราต้องระบุค่าลงไปภายใต้วงเล็บ
                    name = "Chocola";
                    age = "16 years";
                    height = "152 cm";
                    weight = "45 kg";
                }
                else if (textBox1.Text == "002")
                {
                    StudentIMG("student_002.jpg");
                    name = "Elaina";
                    age = "18 years";
                    height = "162 cm";
                    weight = "48 kg";
                }
                else if (textBox1.Text == "003")
                {
                    StudentIMG("student_003.jpg");
                    name = "Aoba Suzukaze";
                    age = "18 years";
                    height = "149 cm";
                    weight = "44 kg";
                }
                else if (textBox1.Text == "004")
                {
                    StudentIMG("student_004.jpg");
                    name = "Kokkoro";
                    age = "15";
                    height = "140";
                    weight = "35";
                }
                else if (textBox1.Text == "005")
                {
                    StudentIMG("student_005.jpg");
                    name = "Sushi Cat";
                    age = "1 day";
                    height = "20 cm";
                    weight = "100 kg";
                }
                else
                {
                    using (Stream stream = assembly.GetManifestResourceStream(errorImage))
                    {
                        pictureBox2.Image = new Bitmap(stream);
                    }

                    clearItems();
                    MessageBox.Show("เกิดข้อผิดพลาด ไม่พบรายชื่อนักเรียนนระบบ", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                label2.Text = "ชื่อ : " + name + "\nอายุ : " + age + "\nส่วนสูง : " + height + "\nนํ้าหนัก : " + weight;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                button1.Focus();
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox1.Focus();
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        public void err()
        {
            using (Stream stream = assembly.GetManifestResourceStream(errorImage))
            {
                pictureBox2.Image = new Bitmap(stream);
            }

            MessageBox.Show("เกิดข้อผิดพลาด กรุณาตรวจสอบว่าท่านได้ใส่ข้อมูลหรือไม่", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //เมธอดที่ไว้สำหรับเคลียร์ของต่าง ๆ
        private void clearItems()
        {
            textBox1.Clear();
            label2.Text = "";
            keyOP = false;
            textBox1.Focus();
        }

        //ฟังก์ชันที่เราสร้างขึ้น เพื่อดึงรูปมาใช้ไปแสดงผล
        //โค้ดส่วนนี้ค่อนข้างเข้าใจยากสำหรับมือใหม่ แน่นอนว่าเราไม่จำเป็นต้องรู้ว่าโครงสร้างทั้งหมดมันมีอะไรบ้าง ขอแค่เรารู้ว่ามันทำงานอย่างไรก็พอแล้ว
        private void StudentIMG(string imgPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(stdImage + imgPath))
            {
                pictureBox2.Image = new Bitmap(stream);
            }
        }
    }
}
