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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Note */
        /* จะมี 2 วิธีที่เราสามารถนำรูปมาใช้ในโปรแกรมได้
           1. Import รูปเข้า Resources.resx (วิธีนี้ง่าย) 
           2. ใช้ filepath ในการระบุที่อยู่ของรูป (วิธีที่เราใช้)
         
           ซึ่งเราใช้วิธีที่ 2 เพราะมันใช้แค่โค้ด แต่จะมีความยากตรงที่เราต้องระบุที่อยู่ของรูปให้ถูกต้อง 
           นอกจากนี้หากเรานำรูปมาไว้ที่โฟลเดอร์ img ที่เราได้สร้างขึ้นไว้ให้ เราจะต้องคลิกที่รูป 1 ครั้ง
           และไปที่หน้า Properties เปลี่ยนค่าในตัวเลือก Copy To Output Directory จาก
           Do not copy เปลี่ยนเป็น Copy always ในทุก ๆ ไฟล์เสมอ*/

        //ประกาศตัวแปร
        public string errorImage = "./img/error.png"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public string logoImage = "./img/logo.png"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public string userImage = "./img/user.jpg"; //ประกาศตัวแปร เพื่อเก็บ filepath ในการระบุที่อยู่ของรูป
        public bool keyOP = true;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            pictureBox1.Image = Image.FromFile(errorImage); //เปลี่ยนรูปใน pictureBox1
            MessageBox.Show("เกิดข้อผิดพลาด กรุณาตรวจสอบว่าท่านได้ใส่ข้อมูลหรือไม่", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Carbform_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(logoImage); //เปลี่ยนรูปใน pictureBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                keyOP = false;
                err();  //เรียกใช้เมธอด
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                keyOP = false;
                err();  //เรียกใช้เมธอด
                textBox2.Focus();
            }
            else
            {
                if (textBox1.Text == "Admin" && textBox2.Text == "123")
                {
                    pictureBox1.Image = Image.FromFile(userImage); //เปลี่ยนรูปใน pictureBox1
                    MessageBox.Show("ยินดีต้อนรับนายท่าน!", "WELCOME ADMIN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Text = "ล็อกเอาท์";
                }
                else 
                {
                    pictureBox1.Image = Image.FromFile(errorImage); //เปลี่ยนรูปใน pictureBox1
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

            pictureBox1.Image = Image.FromFile(logoImage); //เปลี่ยนรูปใน pictureBox1
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
                button1.Focus();
            }
        }
    }
}
