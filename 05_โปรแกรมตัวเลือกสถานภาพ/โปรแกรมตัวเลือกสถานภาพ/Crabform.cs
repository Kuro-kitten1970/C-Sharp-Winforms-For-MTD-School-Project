using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมตัวเลือกสถานภาพ
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
        public string Sex, Status;

        ////ถัดมาส่วนนี้คือ default event ของ object ซึ่งเราสามารถสร้างกลุ่มคำสั่งเหล่านี้ได้ด้วยการดับเบิลคลิกที่ object ในหน้า Design
        ////ข้อควรระวัง หากเราลบกลุ่ม event ออกไปจะทำให้โปรแกรมเกิด Error ได้ วิธีแก้ง่าย ๆ คือ คลิก Error ที่แสดงในเมนู Error List
        ////จากนั้นลบโค้ดบรรทัดที่มัน Error ออกไป
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sex1.Checked == true)
            {
                Sex = sex1.Text;
            }
            else if (sex2.Checked == true)
            {
                Sex = sex2.Text;
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาเลือกเพศของท่าน", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (status1.Checked == true)
            {
                Status = status1.Text;
            }
            else if (status2.Checked == true)
            {
                Status = status2.Text;
            }
            else if (status3.Checked == true)
            {
                Status = status3.Text;
            }
            else if (status4.Checked == true)
            {
                Status = status4.Text;
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาเลือกสถานะของท่าน", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "";
                return;
            }

            if (Status != null && Sex != null)
            {
                label1.Text = "ท่านได้เลือกเพศ " + Sex + " และมีสถานะ " + Status;
                //นำค่าจากตัวแปร Sex และ Status แสดงผลข้อความไปที่ label1
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sex = "";
            Status = "";
            sex1.Checked = false;
            sex2.Checked = false;
            status1.Checked = false;
            status2.Checked = false;
            status3.Checked = false;
            status4.Checked = false;
            label1.Text = "";
        }
    }
}
