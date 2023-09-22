using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมเงินเดือน
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
        private double income, tax, result;
        private byte keyOP = 0;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void button3_Click(object sender, EventArgs e)
        {
            //อันนี้เป็นส่วนที่ใช้แสดงหน้าต่าง Message และรอรับค่าจากปุ่มที่ผู้ใช้กดในเมนูที่แสดง เพื่อดำเนินการขั้นต่อไป
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit(); //ฟังก์ชันที่ใช้ปิดโปรแกรม
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); //ตรงนี้เราใช้ฟังก์ชัน Clear() เพื่อลบสิ่งที่แสดงอยู่่ใน object
            label2.Text = "มูลค่าภาษี : ";
            label3.Text = "รายรับสุทธิ : ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            keyOP = 0;
            textBox1.Focus(); //ฟังก์ชันที่ใช้โฟกัสใน object ต่าง ๆ
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TryCatch ใช้สำหรับดักจับ Error ต่าง ๆ ที่สามารถเกิดขึ้นได้
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่ตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ income
                    income = double.Parse(textBox1.Text);

                    //Switch คือการเปรียบเทียบค่าแต่ละค่าที่อยู่ภายในตัวแปร เราจะใช้ในกรณีเราต้องการเปรียบเทียบเพียงค่าในตัวแปร
                    //ซึ่งมันจะมีความเร็วกว่า if else ดังนั้นเราควรเลือกใช้เป็นตัวนี้แทน
                    switch (keyOP)
                    {
                        case 1:
                            tax = income * 0.03; //นำค่าในตัวแปร income คูณกับ 0.03 แล้วนำไปเก็บที่ tax
                            break;
                        case 2:
                            tax = income * 0.05;
                            break;
                        case 3:
                            tax = income * 0.07;
                            break;
                        default:
                            //กรณีที่ค่าใน keyOP อยู่นอกเหนือ case โค้ดส่วน default จะทำงาน
                            MessageBox.Show("เกิดข้อผิดพลาด โปรดตวจสอบว่าคุณได้เลือกอัตราภาษีแล้ว", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    result = income - tax; //ตัวแปร result มีค่าเป็น income - tax
                    label2.Text = "มูลค่าภาษี : " + tax.ToString("#,#") + " บาท"; //นำค่าจากที่ได้จาก tax ไปแสดงผลไปที่ label2
                    label3.Text = "รายรับสุทธิ : " + result.ToString("#,#") + " บาท"; //นำค่าจากที่ได้จาก result ไปแสดงผลไปที่ label3
                }
            }
            catch (FormatException)
            {
                //ตรงนี้หากโค้ดด้านบนมี Error เกิดขึ้น โค้ดส่วนนี้ก็จะทำงานตามที่เราเขียนไว้
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            keyOP = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            keyOP = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            keyOP = 3;
        }
    }
}
