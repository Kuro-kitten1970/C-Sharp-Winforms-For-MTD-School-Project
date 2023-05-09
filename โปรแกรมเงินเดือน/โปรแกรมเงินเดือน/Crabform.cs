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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public double income, tax, result;
        public byte keyOP = 0;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label2.Text = "มูลค่าภาษี : ";
            label3.Text = "รายรับสุทธิ : ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            keyOP = 0;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

                    switch (keyOP)
                    {
                        case 1:
                            tax = income * 0.03;
                            break;
                        case 2:
                            tax = income * 0.05;
                            break;
                        case 3:
                            tax = income * 0.07;
                            break;
                        default:
                            MessageBox.Show("เกิดข้อผิดพลาด โปรดตวจสอบว่าคุณได้เลือกอัตราภาษีแล้ว", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    if (keyOP != 0)
                    {
                        result = income - tax;
                        label2.Text = "มูลค่าภาษี : " + tax.ToString("#,#") + " บาท";
                        label3.Text = "รายรับสุทธิ : " + result.ToString("#,#") + " บาท";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
