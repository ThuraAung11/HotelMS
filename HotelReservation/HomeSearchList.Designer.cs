namespace HotelReservation
{
    partial class HomeSearchList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheckInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CikCheckOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 370);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColMobileNo,
            this.ColGender,
            this.ColID,
            this.ColAddress,
            this.ColNationality,
            this.ColRoomNo,
            this.ColRoomType,
            this.ColCheckInDate,
            this.CikCheckOutDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColName
            // 
            this.ColName.FillWeight = 108.6957F;
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            // 
            // ColMobileNo
            // 
            this.ColMobileNo.FillWeight = 127.3356F;
            this.ColMobileNo.HeaderText = "Mobile No";
            this.ColMobileNo.Name = "ColMobileNo";
            // 
            // ColGender
            // 
            this.ColGender.FillWeight = 106.9413F;
            this.ColGender.HeaderText = "Gender";
            this.ColGender.Name = "ColGender";
            // 
            // ColID
            // 
            this.ColID.FillWeight = 64.86437F;
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            // 
            // ColAddress
            // 
            this.ColAddress.FillWeight = 104.7924F;
            this.ColAddress.HeaderText = "Address";
            this.ColAddress.Name = "ColAddress";
            // 
            // ColNationality
            // 
            this.ColNationality.FillWeight = 114.4743F;
            this.ColNationality.HeaderText = "Nationality";
            this.ColNationality.Name = "ColNationality";
            // 
            // ColRoomNo
            // 
            this.ColRoomNo.FillWeight = 97.0843F;
            this.ColRoomNo.HeaderText = "RoomNo";
            this.ColRoomNo.Name = "ColRoomNo";
            // 
            // ColRoomType
            // 
            this.ColRoomType.FillWeight = 104.3399F;
            this.ColRoomType.HeaderText = "RoomType";
            this.ColRoomType.Name = "ColRoomType";
            // 
            // ColCheckInDate
            // 
            this.ColCheckInDate.FillWeight = 83.46161F;
            this.ColCheckInDate.HeaderText = "Check In Date";
            this.ColCheckInDate.Name = "ColCheckInDate";
            // 
            // CikCheckOutDate
            // 
            this.CikCheckOutDate.FillWeight = 88.01067F;
            this.CikCheckOutDate.HeaderText = "Check Out Date";
            this.CikCheckOutDate.Name = "CikCheckOutDate";
            // 
            // HomeSearchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Name = "HomeSearchList";
            this.Size = new System.Drawing.Size(595, 370);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheckInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CikCheckOutDate;
    }
}
