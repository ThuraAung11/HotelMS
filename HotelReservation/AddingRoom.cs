using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class AddingRoom : UserControl
    {
        DataConnector d = new DataConnector();
        Rooms r = new Rooms();


        public AddingRoom()
        {
            InitializeComponent();
            cbRoomType.SelectedIndex = 0;
            int c = d.countroom();
            lbCountingRoom.Text = "Rooms;" + c.ToString();
            panel1.Controls.Clear();

        }

        private void cachetext() 
        {
            txtprice.Clear();
            txtRoomNo.Clear();
            cbRoomType.SelectedIndex = 0;
            
        }

        public void getdata(Rooms c) 
        {
            r = c;
        }

        private void AddingRoom_Load(object sender, EventArgs e)
        {
            if (r.ID>0)
            {
                txtRoomNo.Text = r.RoomNo;
                txtprice.Text = r.Price.ToString();
                cbRoomType.SelectedItem = r.RoomType;
                if (r.AC_NonAC=="Yes")
                {
                    rdbyes.Checked=true;
                }
                else
                {
                    rdbNo.Checked = true;
                }
                button1.Text = "Edit";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Add")
            {
                Rooms rm = new Rooms
                {
                    RoomType = cbRoomType.Text.Trim().ToString(),
                    RoomNo = txtRoomNo.Text.Trim().ToString(),
                    Price = Convert.ToInt64(txtprice.Text.Trim().ToString()),
                    checkOut = "CheckOut"
                };
                if (rdbyes.Checked)
                {
                    rm.AC_NonAC = "Yes";
                }
                else
                {
                    rm.AC_NonAC = "No";
                }

                try
                {
                    DataConnector dc = new DataConnector();
                    dc.InsertRooms(rm);
                    MessageBox.Show("Successfully Adding.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cachetext();
                }
                catch (Exception x)
                {

                    MessageBox.Show(x.Message);
                }
            }

            else
            {
                Rooms rm = new Rooms
                {
                    ID=r.ID,
                    RoomType = cbRoomType.Text.Trim().ToString(),
                    RoomNo = txtRoomNo.Text.Trim().ToString(),
                    Price = Convert.ToInt64(txtprice.Text.Trim().ToString()),
                    checkOut = r.checkOut
                };
                if (rdbyes.Checked)
                {
                    rm.AC_NonAC = "Yes";
                }
                else
                {
                    rm.AC_NonAC = "No";
                }

                try
                {
                    DataConnector dc = new DataConnector();
                    dc.updateroom(rm);
                    MessageBox.Show("Successfully Editing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cachetext();
                    
                }
                catch (Exception x)
                {

                    MessageBox.Show(x.Message);
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            //panel1.Controls.Clear();


            //RoomList.Instance.Dock = DockStyle.Fill;
            //RoomList.Instance.BringToFront();
            //panel1.Controls.Add(RoomList.Instance);
            //RoomList.Instance.databind();
            RoomList r = new RoomList();
            Mainshow.showcontrol(r,panel1);
        }


    }
}
