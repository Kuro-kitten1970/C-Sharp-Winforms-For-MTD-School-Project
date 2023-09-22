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

        ////ด้านล่างนี้คือตัวแปรที่มีไว้เพื่อเก็บค่าต่าง ๆ
        ////Syntax ประเภทข้อมูล ชื่อตัวแปร; หรือ ประเภทข้อมูล ชื่อตัวแปร = ค่าเริ่มต้น;
        private int items = 0, getMoney = 0;
        private string lists;
        private bool keyOP = true;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //อันนี้คือ ฟังก์ชัน tryparse ที่จะสามารถบอกเราได้ว่าตัวที่เราต้องการแปลงค่านั้นสามารถแปลงได้หรือไม่
            //ถ้าไม่มันจะส่งค่าไปยังตัวแปรที่เราประกาศไว้
            //ถ้าได้มันจะส่งค่าไปยังตัวแปรที่อยู่หลังคำสั่ง out แทน
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();      
            }
        }
    }
}
