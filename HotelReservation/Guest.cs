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
    public partial class Guest : UserControl
    {
        customerReservation cr = new customerReservation();
        public Guest()
        {
            InitializeComponent();
            
        }
       
        public void databind() 
        {
            DataConnector dc = new DataConnector();
            var result = dc.SelectCutomer();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            databind();
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {

            if (txtsearch.Text == "Name,Room No")
            {
                txtsearch.Text = "";
                txtsearch.ForeColor = Color.Black;
            }
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                txtsearch.Text = "Name,Room No";
                txtsearch.ForeColor = Color.Gray;
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataConnector dc = new DataConnector();
            var result=dc.searchresult(txtsearch.Text.ToString());
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cr.ID>0)
            {
                DialogResult result = MessageBox.Show("You really want to delete?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    DataConnector dc = new DataConnector();
                    dc.deletecustomer(cr);
                    MessageBox.Show("Delete Complete!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    databind();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                cr = new customerReservation()
                {
                    ID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColID"].Value.ToString()),
                    Name = dataGridView1.Rows[e.RowIndex].Cells["ColName"].Value.ToString(),
                    MobileNo = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColMobile"].Value.ToString()),
                    Nationality = dataGridView1.Rows[e.RowIndex].Cells["ColNationality"].Value.ToString(),
                    Gender = dataGridView1.Rows[e.RowIndex].Cells["ColGender"].Value.ToString(),
                    ID_No = dataGridView1.Rows[e.RowIndex].Cells["ColIDNo"].Value.ToString(),
                    Address = dataGridView1.Rows[e.RowIndex].Cells["ColAddress"].Value.ToString(),
                    DateOfBirth = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColDateOfBirth"].Value.ToString()),
                    CheckIn = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColCheckIn"].Value.ToString()),
                    RoomNo = dataGridView1.Rows[e.RowIndex].Cells["ColRoomNo"].Value.ToString(),
                    RoomType=dataGridView1.Rows[e.RowIndex].Cells["ColRoomType"].Value.ToString(),
                    Price = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColPrice"].Value.ToString())
                };
                //if (dataGridView1.Rows[e.RowIndex].Cells["ColCheckOut"].Value.ToString() == null)
                //{
                //    cr.CheckOut = null;

                //}
                //else
                //{
                //    cr.CheckOut = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColCheckOut"].Value.ToString());
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservation r = new Reservation();
            r.getdata(cr);
            Mainshow.showcontrol(r,panel2);
        }
    }
}
