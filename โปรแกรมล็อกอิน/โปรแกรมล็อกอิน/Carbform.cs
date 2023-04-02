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

            pictureBox1.Image = Image.FromFile(logoImage);  //อย่าลืมเขียนโค้ดนี้ด้วยนะ
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //คีย์เวิร์ด
        // errorImage, logoImage และ userImage คือ ตัวแปรที่ใช้เก็บ Filepath ของรูปภาพ
        // err()  คือ เมธอดที่เราสร้างขึ้นมาเอง
        // textBox1 และ textBox2  คือ กล่องข้อความที่ใช้รับค่าจากผู้ใช้ก่อนจะนำไปเก็บในตัวแปร
        // acceptButton และ cancelButton
        // ปุ่ม ออก       และ ปุ่ม ยกเลิก / ล็อกเอาท์

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public string errorImage = "./img/error.png";
        public string logoImage = "./img/logo.png";
        public string userImage = "./img/user.jpg";

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            pictureBox1.Image = Image.FromFile(errorImage);
            MessageBox.Show("เกิดข้อผิดพลาด กรุณาตรวจสอบว่าท่านได้ใส่ข้อมูลหรือไม่", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                err();  //เรียกใช้เมธอด
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                err();  //เรียกใช้เมธอด
                textBox2.Focus();
            }
            else
            {
                if (textBox1.Text == "Admin" && textBox2.Text == "123")
                {
                    pictureBox1.Image = Image.FromFile(userImage);
                    MessageBox.Show("ยินดีต้อนรับนายท่าน!", "WELCOME ADMIN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cancelButton.Text = "ล็อกเอาท์";
                }
                else 
                {
                    pictureBox1.Image = Image.FromFile(errorImage);
                    MessageBox.Show("เกิดข้อผิดพลาด ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (cancelButton.Text == "ล็อกเอาท์")
            {
                MessageBox.Show("หวังว่าเราจะได้พบกันอีกครั้งนะ", "BYE ADMIN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pictureBox1.Image = Image.FromFile(logoImage);
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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ที่ต้องการจัดการอีเว้นท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceptButton.Focus();
            }
        }
    }
}
