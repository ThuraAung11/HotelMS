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
    public partial class Reservation : UserControl
    {
        customerReservation c = new customerReservation();
        public Reservation()
        {
            InitializeComponent();
            cbGender.SelectedIndex = 0;
            cbRoomNo.Enabled = false;
        }

        private bool CheckingError() 
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Fill Name Box","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("Please Fill Mobile-No Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtNationality.Text))
            {
                MessageBox.Show("Please Fill Nationality Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please Fill Address Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please Fill ID Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpDateofBirth.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Check Birthday(Must be over 18)","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void cachetext() 
        {
            txtName.Clear();
            txtMobile.Clear();
            txtNationality.Clear();
            txtID.Clear();
            txtAddress.Clear();
            cbGender.SelectedIndex = 0;
            cbRoomType.SelectedIndex = 1;
            dtpCheckIn.Value = DateTime.Now;
            dtpDateofBirth.Value = DateTime.Now;

        }

        public void getdata(customerReservation cr) 
        {
            c = cr;
        }
        private void Reservation_Load(object sender, EventArgs e)
        {
            //roomdatabind();
            if (c.ID>0)
            {
                label1.Text = "Update Reservation...";
                DataConnector dc = new DataConnector();
                var result=dc.SelectCutomer();
                string ac = "";
                foreach (var item in result)
                {
                    if (item.ID==c.ID)
                    {
                        ac = item.ac;
                    }
                }
                txtName.Text = c.Name;
                txtMobile.Text = c.MobileNo.ToString() ;
                txtID.Text = c.ID_No;
                txtAddress.Text = c.Address;
                txtNationality.Text = c.Nationality;
                cbGender.SelectedItem = c.Gender;
                cbRoomNo.Text = c.RoomNo;
                cbRoomType.SelectedItem = c.RoomType;
                dtpCheckIn.Value = c.CheckIn;
                dtpDateofBirth.Value = c.DateOfBirth;
                if (ac=="Yes")
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

        public void roomnobind() 
        {
            
            DataConnector d = new DataConnector();
            var result = d.Selectroomtype(cbRoomType.Text.ToString());

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            dt.Columns.Add("Room_No",typeof(string));

            foreach (var item in result)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.ID;
                dr["Room_No"] = item.RoomNo;
                dt.Rows.Add(dr);
            }

            cbRoomNo.DisplayMember = "Room_No";
            cbRoomNo.ValueMember = "ID";

            if (dt.Rows.Count==0)
            {
                cbRoomNo.Text = "non";
                cbRoomNo.Enabled = false;
            }
            else { 
                cbRoomNo.DataSource = dt; }
                 
        }
        private void roomdatabind() 
        {
            DataConnector dc = new DataConnector();
            List<Rooms> r = dc.selectroom();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            dt.Columns.Add("Room_No", typeof(string));

            foreach (var item in r)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.ID;
                dr["Room_No"] = item.RoomNo;

                dt.Rows.Add(dr);
            }
           
            cbRoomNo.DisplayMember = "Room_No";
            cbRoomNo.ValueMember = "ID";
            cbRoomNo.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckingError())
                {
                    string checkin = "CheckIn";
                    if (button1.Text == "Submit")
                    {

                        customerReservation cr = new customerReservation()
                        {
                            Name = txtName.Text.Trim().ToString(),
                            MobileNo = Convert.ToInt64(txtMobile.Text.Trim().ToString()),
                            Nationality = txtNationality.Text.Trim().ToString(),
                            Gender = cbGender.SelectedItem.ToString(),
                            ID_No = txtID.Text.Trim().ToString(),
                            Address = txtAddress.Text.Trim().ToString(),
                            DateOfBirth = (dtpDateofBirth.Value).Date,
                            CheckIn = dtpCheckIn.Value,
                            RoomNo = cbRoomNo.Text.ToString(),
                            RoomType = cbRoomType.Text.ToString(),
                            CheckOut = null
                        };

                        DataConnector dc = new DataConnector();

                        dc.insertRes(cr);
                        dc.updateCheckout(cr, checkin);
                        MessageBox.Show("Reserve Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cachetext();
                    }

                    else
                    {
                        customerReservation cr = new customerReservation()
                        {
                            ID = c.ID,
                            Name = txtName.Text.Trim().ToString(),
                            MobileNo = Convert.ToInt64(txtMobile.Text.Trim().ToString()),
                            Nationality = txtNationality.Text.Trim().ToString(),
                            Gender = cbGender.SelectedItem.ToString(),
                            ID_No = txtID.Text.Trim().ToString(),
                            Address = txtAddress.Text.Trim().ToString(),
                            DateOfBirth = (dtpDateofBirth.Value).Date,
                            CheckIn = (dtpCheckIn.Value).Date,
                            RoomNo = cbRoomNo.Text.ToString(),
                            RoomType = cbRoomType.Text.ToString(),
                            CheckOut = null
                        };

                        string checkout = "CheckOut";
                        DataConnector dc = new DataConnector();
                        dc.updatecustomer(cr);
                        dc.updateCheckout(cr, checkin);
                        dc.updateCheckout(c, checkout);
                        MessageBox.Show("Edit Compelete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cachetext();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRoomNo.Enabled = true;
            roomnobind();
        }

        //private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (txtName.Text!="")
        //    {
        //        txtName.Text = txtName.Text.Substring(0, 1).ToUpper();

        //    }
        //}

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtName.Text);
            txtName.Select(txtName.Text.Length,0);
        }
    }
}
