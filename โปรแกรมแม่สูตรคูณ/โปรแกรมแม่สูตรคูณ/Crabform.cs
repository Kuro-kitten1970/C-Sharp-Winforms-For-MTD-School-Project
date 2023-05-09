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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ประกาศตัวแปร
        public int getNum = 0;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        private void clear()
        {
            textBox1.Clear();
            textBox1.Focus();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void Crabform_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";

            bool checkNum = int.TryParse(textBox1.Text, out getNum);

            if (!checkNum && textBox1.Text != "")
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear(); //เรียกใช้เมธอด
                return;
            }
            else if (getNum < 0)
            {
                MessageBox.Show("เกิดข้อผิดพลาด กรุณาใส่เฉพาะตัวเลขที่เป็นจำนวนเต็มบวก", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear(); //เรียกใช้เมธอด
                return;
            }
            else if (getNum > 100)
            {
                MessageBox.Show("เกิดข้อผิดพลาด โปรแกรมนี้รองรับเลขสูงสุดที่ 100 เท่านั้น", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear(); //เรียกใช้เมธอด
                return;
            }
            else if (textBox1.Text == "")
            {
                label1.Text = "";
            }
            else
            {
                for (int i = 1; i < 13; i++) //ทำการลูปโค้ดซํ้า ๆ
                {
                    label1.Text += getNum + " x " + i + " = " + (getNum * i).ToString() + "\n";
                }
            }
        }
    }
}
