using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมแคชเชียร์
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //คีย์เวิร์ด
        // items, lists และ getMoney  คือ ตัวแปรที่ใช้เก็บค่าต่าง ๆ
        // keyOP และ checkInput  คือ ตัวแปรที่จะใช้เก็บค่าตรรกศาสตร์ เพื่อที่จะนำไปใช้ในการจัดการทางเลือกของโปรแกรม
        // textBox1, textBox2 และ textBox3  คือ กล่องข้อความที่ใช้รับค่าจากผู้ใช้ก่อนจะนำไปเก็บในตัวแปร
        // checkBox1 - checkBox5  คือ เครื่องมือที่ให้ผู้ใช้เลือกหรือยกเลิกการดำเนินการต่าง ๆ
        // exitButton, clearButton, calcButton และ changeButton
        // ปุ่ม ออก   , ปุ่ม รีเซ็ท    , ปุ่มคิดเงิน    และ ปุ่มทอนเงิน   

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public int items = 0, getMoney = 0;
        public string lists;
        public bool keyOP = true;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            Start:  //จุดที่เรากำหนดไว้ เพื่อให้โปรแกรมกลับมาทำงานอีกครั้ง โดยจะเริ่มรันคำสั่งใหม่จากจุดนี้ลงไป
            if (keyOP == true)
            {
                if (checkBox1.Checked == true)
                {
                    items += 30;
                    lists += checkBox1.Text + ("\n");
                }
                if (checkBox2.Checked == true)
                {
                    items += 40;
                    lists += checkBox2.Text + ("\n");
                }
                if (checkBox3.Checked == true)
                {
                    items += 50;
                    lists += checkBox3.Text + ("\n");
                }
                if (checkBox4.Checked == true)
                {
                    items += 40;
                    lists += checkBox4.Text + ("\n");
                }
                if (checkBox5.Checked == true)
                {
                    items += 20;
                    lists += checkBox5.Text + ("\n");
                }

                keyOP = false;
                textBox2.Focus();
            }
            else 
            {
                items = 0;
                lists = "";
                keyOP = true;
                goto Start;  //ฟังก์ชั่นที่สามารถทำให้โปรแกรมกลับไปทำงานตรงจุดที่เรากำหนดไว้
            }

            textBox1.Text = items.ToString();
            label1.Text = lists;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            //แปลงชนิดข้อมูลจาก string ไปหา int โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ getMoney
            bool checkInput = int.TryParse(textBox2.Text, out getMoney);

            if (checkInput)
            {
                textBox3.Text = (getMoney - items).ToString();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();      
            }
        }
    }
}
