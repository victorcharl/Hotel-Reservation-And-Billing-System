using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class mainpage : Form
    {

        public mainpage()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string strSql = "Select admin_firstname from tblAdmin where admin_username = '"+Class1.Username+"'";
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            string value = (string)cmd.ExecuteScalar();
            con.Close();
            toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + value + "                    ";
            toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + DateTime.Now.ToLongDateString() + "       ";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = MessageBox.Show("Are you sure you want to log Out?", "Logging out?", MessageBoxButtons.OKCancel).ToString();
            if (ans.Equals("OK"))
            {
                this.Close();
                new login().Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.OKCancel).ToString();
            if (ans.Equals("OK"))
            {
                this.Close();
            }
        }

        private void newGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new addingNewGuest().ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new changeadmininfo().ShowDialog();
        }

        private void guestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new guestList().ShowDialog();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new transactions().ShowDialog();
        }

        private void cheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new room().ShowDialog();
        }

        private void checkInListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CheckInList().ShowDialog();
        }

        private void checkOutListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CheckOutList().ShowDialog();
        }

        private void aboutHotelSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void room_Click(object sender, EventArgs e)
        {
            new room().ShowDialog();
        }

        private void res_Click(object sender, EventArgs e)
        {
            new CheckInReserveList().ShowDialog();
        }

        private void guest_Click(object sender, EventArgs e)
        {
            new guestList().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AddRoom().ShowDialog();
        }

        private void ckIn_Click(object sender, EventArgs e)
        {
            new CheckinForm().ShowDialog();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Developer().ShowDialog();
        }

        private void ckOut_Click(object sender, EventArgs e)
        {
            new CheckoutForm().ShowDialog();
        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CheckInReserveList().ShowDialog();   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.toolStripStatusLabel4.Text = "Time:  " + dt.ToLongTimeString() + "       ";
        }

        private void mainpage_Activated(object sender, EventArgs e)
        {
            reserve.roomNum = "";
        }

        private void extendStayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExtendBook().ShowDialog();
        }
    }
}
