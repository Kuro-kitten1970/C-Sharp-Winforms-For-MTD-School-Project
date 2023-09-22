using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมดูดวง
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

        //// Credit : Kuro_kitten ////

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //อันนี้เป็นส่วนที่ใช้แสดงหน้าต่าง Message และรอรับค่าจากปุ่มที่ผู้ใช้กดในเมนูที่แสดง เพื่อดำเนินการขั้นต่อไป
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //ฟังก์ชันที่ใช้ปิดโปรแกรม
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้เมธอด
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ถ้า textBox1 ไม่มีข้อความใด ๆ เลย
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาระบุชื่อของท่าน", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            else 
            {
                label2.Text = "สวัสดีท่าน " + textBox1.Text;
                //แสดงผลข้อความไปที่ label2

                //if statement ใช้เปรียบเทียบข้อมูล หรือค่าต่าง ๆ
                //ถ้า radioButton ถูกเช็ค มีค่าเป็นจริง
                if (radioButton1.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันจันทร์ ท่านจะมีดวงสุ่มได้ SSR\nแต่ต้องสุ่มช่วงกลางคืนเท่านั้น";
                }
                else if (radioButton2.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันอังคาร ท่านจะมีดวงสุ่มได้ SSR\nแต่ต้องสุ่มช่วงกลางวันเท่านั้น";
                }
                else if (radioButton3.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันพุธ ท่านจะมีดวงสุ่มได้ SSR\nแต่ท่านจำเป็นต้องเซ่นไหว้เสียก่อน";
                }
                else if (radioButton4.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันพฤหัสบดี ท่านจะสุ่มไม่ได้อะไร\nเลย ท่านจึงต้องเติมสู้เท่านั้น";
                }
                else if (radioButton5.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันศุกร์ ท่านจะมีคู่ครองที่ดี\nแต่ท่านจะตกอับเรื่องดวงตอนสุ่มกาชา";
                }
                else if (radioButton6.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันเสาร์ ท่านจะประสบความ\nสำเร็จด้านการงาน แต่ท่านมักจะหมดเงิน\nไปกับคำว่า ของมันต้องมี";
                }
                else if (radioButton7.Checked == true)
                {
                    label3.Text = "ท่านเกิดวันอาทิตย์ ท่านจะประสบความ\nสำเร็จในทุก ๆ ด้าน ยกเว้นด้านความรัก";
                }
                else //ถ้าไม่เข้าเงื่อนไขข้างต้นทั้งหมด
                {
                    label2.Text = "";
                    label3.Text = "";
                    MessageBox.Show("เกิดข้อผิดพลาด กรุณาเลือกวันเกิดของท่าน", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        ////ส่วนสุดท้ายนี้คือ กลุ่มฟังก์ชันที่เราเขียนขึ้นมาเองกับมือ
        ////การสร้างฟังก์ชันเหล่านี้มีข้อดีอยู่เยอะ เช่น โค้ดเก่าสามารถซํ้า ๆ ได้ หรือทำให้เรา Maintain โค้ดได้ง่ายขึ้นอะไรทำนองนี้
        private void clearItems()
        {
            textBox1.Clear();
            label2.Text = "";
            label3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            textBox1.Focus();
        }
    }
}
