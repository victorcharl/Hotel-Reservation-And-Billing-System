using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class transactions : Form
    {
            
        public transactions()
        {
            InitializeComponent();
        }

        private void transactions_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            listView1.Items.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE tblTransactions.transStatus = \'Canceled\';", con);
            da.Fill(dt);

            foreach (DataRow guest in dt.Rows)
            {
                listView1.Items.Add(guest[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                con.Open();

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                listView1.Items.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE tblTransactions.transStatus = \'Canceled\';", con);
                da.Fill(dt);

                foreach (DataRow guest in dt.Rows)
                {
                    listView1.Items.Add(guest[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                }
            }

            else
            {
                try
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    listView1.Items.Clear();
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE (tblGuestInfo.guest_lastname like '" + txtSearch.Text + "' +'%' OR tblGuestInfo.guest_firstname like '"+txtSearch.Text+"'+'%') AND tblTransactions.transStatus = \'Canceled\';", con);
                    da.Fill(dt);

                    foreach (DataRow guest in dt.Rows)
                    {
                        listView1.Items.Add(guest[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }
    }
}
