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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //คีย์เวิร์ด
        // radioButton1 - radioButton7  คือ เครื่องมือตัวเลือกที่จะเลือกได้เพียงแค่ตัวใดตัวหนึ่ง ภายใต้ groupBox เดียวกัน
        // label2 และ label3  คือ ข้อความที่ใช้แสดงผลให้กับผู้ใช้
        // clearItems()  คือ เมธอดที่เราสร้างขึ้นมาเอง
        // nameBox  คือ กล่องข้อความที่ใช้รับค่าจากผู้ใช้ ซึ่งถูกเปลี่ยนชื่อมาจาก textBox
        // exitButton, clearButton และ fortuneButton
        // ปุ่ม ออก   , ปุ่ม รีเซ็ท     และ ปุ่ม ทำนาย

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่มีไว้สำหรับรีเซ็ท nameBox, label และ radioButton
        public void clearItems()
        {
            nameBox.Clear();
            label2.Text = "";
            label3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            nameBox.Focus();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้เมธอด
        }

        private void fortuneButton_Click(object sender, EventArgs e)
        {
            //ถ้า nameBox ไม่มีข้อความใด ๆ เลย
            if (nameBox.Text == "" || nameBox.Text == null)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาระบุชื่อของท่าน", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems(); //เรียกใช้เมธอด
            }
            else 
            {
                label2.Text = "สวัสดีท่าน " + nameBox.Text;
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
                }
            }
        }
    }
}
