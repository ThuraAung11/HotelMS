using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    class Mainshow
    {
        public static void showcontrol(Control c, Panel p) 
        {
            p.Controls.Clear();
            c.Dock = DockStyle.Fill;
            c.BringToFront();
            c.Focus();
            p.Controls.Add(c);
            p.BringToFront();
        }

    }
}
