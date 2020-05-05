using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {
            label4.Text = trans.transNum;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            print();
            printPreviewDialog1.ShowDialog();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int width, int nheight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        private void print()
        {
            Graphics grp = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, grp);
            Graphics grp1 = Graphics.FromImage(memoryImage);
            IntPtr dc1 = grp.GetHdc();
            IntPtr dc2 = grp1.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            grp.ReleaseHdc(dc1);
            grp1.ReleaseHdc(dc2);
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblTransactions where trans_number =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
               conn.Open();
               cmd.Parameters.AddWithValue("@p1", label4.Text);
               int result = (int)cmd.ExecuteScalar();

               if (result > 0)
               {
                   OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                   OleDbCommand trans = new OleDbCommand("SELECT * FROM tblTransactions where trans_number = '" + label4.Text + "'", con);
                   OleDbDataReader reader;
                   con.Open();
                   reader = trans.ExecuteReader();
                   while (reader.Read())
                   {
                       label6.Text = reader["guest_ID"].ToString();
                       label11.Text = reader["room_number"].ToString();
                       label13.Text = reader["checkInDate"].ToString();
                       label15.Text = reader["checkOutDate"].ToString();
                       label17.Text = "P" + reader["resBill"].ToString() + ".OO";
                       label18.Text = reader["admin_username"].ToString();

                   }
                    conn.Close();
                }            
            }
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblGuestInfo where guest_ID =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label6.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand guest = new OleDbCommand("SELECT * FROM tblGuestInfo where guest_ID = '" + label6.Text + "'", con);
                    OleDbDataReader reader;
                    con.Open();
                    reader = guest.ExecuteReader();
                    while (reader.Read())
                    {
                        label9.Text = reader["guest_firstname"].ToString() + " " + reader["guest_mi"].ToString() + ". " + reader["guest_lastname"].ToString() + "";
                    }
                }
            }
        }

        private void label18_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblAdmin where admin_username =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label18.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand guest = new OleDbCommand("SELECT * FROM tblAdmin where admin_username = '" + label18.Text + "'", con);
                    OleDbDataReader reader;
                    con.Open();
                    reader = guest.ExecuteReader();
                    while (reader.Read())
                    {
                        label19.Text = reader["admin_firstname"].ToString() + " " + reader["admin_mi"].ToString() + ". " + reader["admin_lastname"].ToString() + "";
                    }
                }
            }
        }

        private void Print_Activated(object sender, EventArgs e)
        {
            btnPrint.Visible = true;
        }
    }
}
