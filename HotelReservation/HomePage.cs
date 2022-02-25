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
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private static HomePage _instance;
        public static HomePage Instance
        {
            get 
            {
                if (_instance==null)
                {
                    _instance = new HomePage();
                }
                return _instance;
            }
        }

       
    }
}
