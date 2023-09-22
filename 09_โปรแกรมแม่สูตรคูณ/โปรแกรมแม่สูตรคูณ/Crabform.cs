using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมแม่สูตรคูณ
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
        private int getNum = 0;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";

            //อันนี้คือ ฟังก์ชัน tryparse ที่จะสามารถบอกเราได้ว่าตัวที่เราต้องการแปลงค่านั้นสามารถแปลงได้หรือไม่
            //ถ้าไม่มันจะส่งค่าไปยังตัวแปรที่เราประกาศไว้
            //ถ้าได้มันจะส่งค่าไปยังตัวแปรที่อยู่หลังคำสั่ง out แทน
            bool checkNum = int.TryParse(textBox1.Text, out getNum);

            if (!checkNum && textBox1.Text != "")
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear(); //เรียกใช้ฟังก์ชันที่เราเขียนเอง
                return;
            }
            else if (getNum < 0)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาใส่เฉพาะตัวเลขที่เป็นจำนวนเต็มบวก", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
                return;
            }
            else if (getNum > 100)
            {
                MessageBox.Show("เกิดข้อผิดพลาด โปรแกรมนี้รองรับเลขสูงสุดที่ 100 เท่านั้น", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
                return;
            }
            else if (textBox1.Text == "")
            {
                label1.Text = "";
            }
            else
            {
                for (int i = 1; i < 13; i++) //For คือฟังก์ชันพื้นฐานที่ใช้สำหรับการลูป โดยมักจะใช้ในกรณีที่เรารู้ว่าควรให้เราลูปเท่าไหร่ หรือเรารู้รอบในการลูปที่แน่นอน 
                {
                    label1.Text += getNum + " x " + i + " = " + (getNum * i).ToString() + "\n";
                }
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        private void clear()
        {
            textBox1.Clear();
            textBox1.Focus();
        }
    }
}
