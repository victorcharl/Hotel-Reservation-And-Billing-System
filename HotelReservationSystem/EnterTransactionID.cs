using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class EnterTransactionID : Form
    {             
        public EnterTransactionID()
        {
            InitializeComponent();
        }

        private void putTransactionID_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            listView1.Items.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number where transStatus = '"+label3.Text+"'", con);
            da.Fill(dt);

            foreach (DataRow trans in dt.Rows)
            {
                listView1.Items.Add(trans[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[3].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[4].ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                con.Open();

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                listView1.Items.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number where transStatus = '"+label3.Text+"'", con);
                da.Fill(dt);

                foreach (DataRow trans in dt.Rows)
                {
                    listView1.Items.Add(trans[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[3].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[4].ToString());
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
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number where (tblGuestInfo.guest_lastname like '"+textBox1.Text+"' +'%' OR tblGuestInfo.guest_firstname like '"+textBox1.Text+"' +'%') AND tblTransactions.transStatus = '"+label3.Text+"';", con);
                    da.Fill(dt);

                    foreach (DataRow trans in dt.Rows)
                    {
                        listView1.Items.Add(trans[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string tra = listView1.SelectedItems[0].SubItems[0].Text;
            label2.Text = tra;
            trans.transNum = label2.Text;
            this.Close();
        }
    }
}
