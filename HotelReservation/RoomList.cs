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
    public partial class RoomList : UserControl
    {
        Rooms rm = new Rooms();
        public RoomList()
        {
            InitializeComponent();
            databind();
        }
       
        public void databind() 
        {
            DataConnector dc = new DataConnector();
            var reslut = dc.Selectallroom();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = reslut;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rm.ID>0)
            {
                DialogResult result = MessageBox.Show("You really want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataConnector dc = new DataConnector();
                    dc.deleteroom(rm);
                    databind();
                }
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                rm = new Rooms()
                {
                    ID=Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColID"].Value.ToString()),
                    RoomNo = dataGridView1.Rows[e.RowIndex].Cells["ColRoomNo"].Value.ToString(),
                    RoomType=dataGridView1.Rows[e.RowIndex].Cells["ColRoomType"].Value.ToString(),
                    AC_NonAC= dataGridView1.Rows[e.RowIndex].Cells["ColAC_NonAc"].Value.ToString(),
                    Price=Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColPrice"].Value.ToString()),
                    checkOut= dataGridView1.Rows[e.RowIndex].Cells["ColCheckOut"].Value.ToString(),

                };

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rm.ID>0)
            {
                AddingRoom ar = new AddingRoom();
                ar.getdata(rm);
                
                Mainshow.showcontrol(ar,panel2);
            }
        }

        
    }
}
