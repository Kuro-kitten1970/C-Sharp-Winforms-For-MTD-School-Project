using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมรายชื่อนักเรียน
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Note */
        /* จะมี 2 วิธีที่เราสามารถนำรูปมาใช้ในโปรแกรมได้
           1. Import รูปเข้า Resources.resx (วิธีนี้ง่าย) 
           2. ใช้ filepath ในการระบุที่อยู่ของรูป (วิธีที่เราใช้)
         
           ซึ่งเราใช้วิธีที่ 2 เพราะมันใช้แค่โค้ด แต่จะมีความยากตรงที่เราต้องระบุที่อยู่ของรูปให้ถูกต้อง 
           นอกจากนี้หากเรานำรูปมาไว้ที่โฟลเดอร์ img ที่เราได้สร้างขึ้นไว้ให้ เราจะต้องคลิกที่รูป 1 ครั้ง
           และไปที่หน้า Properties เปลี่ยนค่าในตัวเลือก Copy To Output Directory จาก
           Do not copy เปลี่ยนเป็น Copy always ในทุก ๆ ไฟล์เสมอ
         */

        //ประกาศตัวแปร
        public string errorImage = "./images/error.png"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public string logoImage = "./images/logo.png"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public string stdImage = "./images/"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public bool keyOP = true;
        public string name, age, height, weight;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            pictureBox2.Image = Image.FromFile(errorImage); //เปลี่ยนรูปใน pictureBox1
            MessageBox.Show("เกิดข้อผิดพลาด กรุณาตรวจสอบว่าท่านได้ใส่ข้อมูลหรือไม่", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clearItems()
        {
            textBox1.Clear();
            label2.Text = "";
            keyOP = false;
            textBox1.Focus();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(logoImage);
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                err();  //เรียกใช้เมธอด
                keyOP = false;
                textBox1.Focus();
            }
            else
            {
                if (textBox1.Text == "001")
                {
                    pictureBox2.Image = Image.FromFile(stdImage + "student_001.jpg"); //เปลี่ยนรูปใน pictureBox2
                    name = "Chocola";
                    age = "16 years";
                    height = "152 cm";
                    weight = "45 kg";
                }
                else if (textBox1.Text == "002")
                {
                    pictureBox2.Image = Image.FromFile(stdImage + "student_002.jpg"); //เปลี่ยนรูปใน pictureBox2
                    name = "Elaina";
                    age = "18 years";
                    height = "162 cm";
                    weight = "48 kg";
                }
                else if (textBox1.Text == "003")
                {
                    pictureBox2.Image = Image.FromFile(stdImage + "student_003.jpg"); //เปลี่ยนรูปใน pictureBox2
                    name = "Aoba Suzukaze";
                    age = "18 years";
                    height = "149 cm";
                    weight = "44 kg";
                }
                else if (textBox1.Text == "004")
                {
                    pictureBox2.Image = Image.FromFile(stdImage + "student_004.jpg"); //เปลี่ยนรูปใน pictureBox2
                    name = "Kokkoro";
                    age = "15";
                    height = "140";
                    weight = "35";
                }
                else if (textBox1.Text == "005")
                {
                    pictureBox2.Image = Image.FromFile(stdImage + "student_005.jpg"); //เปลี่ยนรูปใน pictureBox2
                    name = "Sushi Cat";
                    age = "1 day";
                    height = "20 cm";
                    weight = "100 kg";
                }
                else
                {
                    pictureBox2.Image = Image.FromFile(errorImage); //เปลี่ยนรูปใน pictureBox2
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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ที่ต้องการจัดการอีเว้นท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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
                textBox1.Focus();
            }
        }
    }
}
