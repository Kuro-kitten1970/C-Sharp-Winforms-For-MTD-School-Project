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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //คีย์เวิร์ด
        // sex1, sex2 และ status1 - status4  คือ เครื่องมือตัวเลือกที่จะเลือกได้เพียงแค่ตัวใดตัวหนึ่ง ภายใต้ groupBox เดียวกัน
        // Sex และ Status  คือ ตัวแปรที่ใช้เก็บค่าต่าง ๆ
        // (หรือก็คือ radioButton ที่ถูกเปลี่ยนชื่อ)
        // label1  คือ ข้อความที่ใช้แสดงผลให้กับผู้ใช้
        // cancelButton และ acceptButton
        // ปุ่ม ยกเลิก     และ ปุ่ม ตกลง     

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public string Sex = "", Status = "";

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void acceptButton_Click(object sender, EventArgs e)
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
            }

            if (Status != "" && Sex != "")
            {
                label1.Text = "ท่านได้เลือกเพศ " + Sex + " และมีสถานะ " + Status;
                //นำค่าจากตัวแปร Sex และ Status แสดงผลข้อความไปที่ label1
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
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
