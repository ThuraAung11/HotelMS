using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panelhighlight.Height = button1.Height;
            //home();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void movepanel(Button btn) 
        {
            panelhighlight.Visible = true;
            panelhighlight.Height = btn.Height;
            panelhighlight.Top = btn.Top;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panelmenu.Width<=42)
            {
                panelmenu.Width += 123;
            }
            else
            {
                panelmenu.Width = 42;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            movepanel(button2);

            Reservation r = new Reservation();
            Mainshow.showcontrol(r,panel3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            movepanel(button1);
            HomePage h = new HomePage();
            Mainshow.showcontrol(h,panel3);
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    movepanel(button3);
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            movepanel(button4);
            CheckOut c = new CheckOut();
            c.databind();
            Mainshow.showcontrol(c,panel3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            movepanel(button5);
            Guest g = new Guest();
            Mainshow.showcontrol(g,panel3);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            movepanel(button6);
            AddingRoom a = new AddingRoom();
            Mainshow.showcontrol(a,panel3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("dd:MM:yy hh:mm:ss");
        }
    }
}
