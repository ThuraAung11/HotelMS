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
    public partial class CheckOut : UserControl
    {
        customerReservation cr = new customerReservation();
        public CheckOut()
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                cr = new customerReservation()
                {
                    ID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColID"].Value.ToString()),
                    Name = dataGridView1.Rows[e.RowIndex].Cells["ColName"].Value.ToString(),
                    MobileNo = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColMobileNo"].Value.ToString()),
                    Nationality = dataGridView1.Rows[e.RowIndex].Cells["ColNationality"].Value.ToString(),
                    Gender = dataGridView1.Rows[e.RowIndex].Cells["ColGender"].Value.ToString(),
                    ID_No = dataGridView1.Rows[e.RowIndex].Cells["ColIDNo"].Value.ToString(),
                    Address = dataGridView1.Rows[e.RowIndex].Cells["ColAddress"].Value.ToString(),
                    DateOfBirth = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColDateOfBirth"].Value.ToString()),
                    CheckIn = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColCheckIn"].Value.ToString()),
                    RoomNo = dataGridView1.Rows[e.RowIndex].Cells["ColRoomNo"].Value.ToString(),
                    //CheckOut = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ColCheckOut"].Value.ToString()),
                    Price = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["ColPrice"].Value.ToString())
                };
                //if (dataGridView1.Rows[e.RowIndex].Cells["ColCheckOut"].Value.ToString() == null)
                //{
                //    cr.CheckOut = null;

                //}
                textBox1.Text = cr.Price.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cr.ID>0)
            {
                if (textBox1.Text == "" || textBox1.Text == "0")
                {
                    MessageBox.Show("Please fill the bill!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string c = "CheckOut";
                    cr.CheckOut = DateTime.Now.ToLocalTime();
                    cr.Price = Convert.ToInt64(textBox1.Text);

                    DataConnector dc = new DataConnector();
                    dc.updateCheckout(cr, c);
                    dc.updatecustomerList(cr);
                    databind();
                    MessageBox.Show("CheckOut Complete!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please Select a data to delete...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cr.ID>0)
            {
                cr.Price = Convert.ToInt64(textBox1.Text.Trim().ToString());
                if (cr.Price == Convert.ToInt64(textBox1.Text.Trim().ToString()))
                {
                    MessageBox.Show("Please Fill the new Aomount in the Price.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataConnector dc = new DataConnector();
                    dc.updatecustomer(cr);
                    MessageBox.Show("Update Complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    databind();
                }
               
            }

            else
            {
                MessageBox.Show("Please Select a data to delete...", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text=="Search")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                textBox2.Text = "Search";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataConnector dc = new DataConnector();
            var result=dc.searchresult(textBox2.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }
    }
}
