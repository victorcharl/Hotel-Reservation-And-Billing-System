using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class CheckInReserveList : Form
    {
        string daysStaying, roomPrice, previousBill, previousDaysStaying;
        
        public CheckInReserveList()
        {
            InitializeComponent();
        }

        private void ReserveRoom_Load(object sender, EventArgs e)
        { 
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            listView1.Items.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number, tblTransactions.checkInDate FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE tblTransactions.transStatus = 'Pending';", con);
            da.Fill(dt);

            foreach (DataRow guest in dt.Rows)
            {
                listView1.Items.Add(guest[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[4].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[5].ToString());
            }
            con.Close();
            dateTimePicker3.Text = DateTime.Now.ToShortDateString();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

            /*CANCEL ALL RESERVATION IF DATE IS PAST DUE*/
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
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number, tblTransactions.checkInDate FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE tblTransactions.transStatus = 'Pending';", con);
                da.Fill(dt);

                foreach (DataRow guest in dt.Rows)
                {
                    listView1.Items.Add(guest[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[4].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[5].ToString());
                }
            }
            else
            {
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                con.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                listView1.Items.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT tbltransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number, tblTransactions.checkInDate FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE (tblGuestInfo.guest_lastname like '" + textBox1.Text + "' +'%' OR tblGuestInfo.guest_firstname like '"+textBox1.Text+"'+'%') AND tblTransactions.transStatus = 'Pending';", con);
                da.Fill(dt);

                foreach (DataRow trans in dt.Rows)
                {
                    listView1.Items.Add(trans[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[3].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[4].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(trans[5].ToString());
                }
            }
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblTransactions where trans_number =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label5.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand trans = new OleDbCommand("SELECT * FROM tblTransactions where trans_number = '" + label5.Text + "'", con);
                    OleDbDataReader reader;
                    con.Open();
                    reader = trans.ExecuteReader();
                    while (reader.Read())
                    {
                        label7.Text = reader["room_number"].ToString();
                        label8.Text = reader["inquireDate"].ToString();
                        label9.Text = reader["checkInDate"].ToString();
                        label10.Text = reader["checkOutDate"].ToString();
                        bil.Text = reader["resBill"].ToString();
                        previousBill = reader["resBill"].ToString();
                        adc.Text = reader["resAdvance"].ToString();
                        if (adc.Text == "0.0000")
                        {
                            adc.Text = "0";
                        }
                        else
                        {
                            adc.Text = reader["resAdvance"].ToString();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            string strSql = "UPDATE tblRoom SET room_status = 'Occupied' where room_number = '" + label7.Text + "'";
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            string strSql2 = "UPDATE tblTransactions SET transStatus = 'Check In' where trans_number = '" + label5.Text + "'";
            OleDbCommand cmd2 = new OleDbCommand(strSql2, con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Check in Successful");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ans = MessageBox.Show("Are you sure you want to cancel this reservation?", "Cancel Reservation?", MessageBoxButtons.OKCancel).ToString();
            if (ans.Equals("OK"))
            {
                string strSql = "UPDATE tblTransactions SET transStatus = 'Cancelled', totalBill = \'0\' where trans_number = '" + label5.Text + "'";
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                OleDbCommand cmd = new OleDbCommand(strSql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                string strSql2 = "UPDATE tblRoom SET room_status = \'Available\' where room_number = '" + label7.Text + "'";
                OleDbCommand cmd2 = new OleDbCommand(strSql2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Reservation Canceled");
                groupBox1.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(adc.Text))
            {
                adc.Text = "0";
            }
            else
            {
                try
                {
                    string strSql = "UPDATE tblTransactions SET checkInDate = '" + dateTimePicker1.Value.ToShortDateString() + " " + DateTime.Now.ToString("T") + "', checkOutDate = '" + dateTimePicker2.Value.ToShortDateString() + " " + "12:00:00 PM" + "', resBill = '" + bil.Text + "', resAdvance = '" + adc.Text + "' where trans_number = '" + label5.Text + "'";
                    OleDbConnection con1 = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand cmd1 = new OleDbCommand(strSql, con1);
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    label9.Text = dateTimePicker1.Value.ToShortDateString() + " " + DateTime.Now.ToString("T");
                    label10.Text = dateTimePicker2.Value.ToShortDateString() + " " + "12:00:00 PM";
                    MessageBox.Show("Update Successful!");
                    btnChIn.Visible = true;
                    btnSave.Visible = true;
                    button1.Visible = true;
                    btncancelRese.Visible = true;
                    btnCancel.Visible = false;
                    label9.Visible = true;
                    label10.Visible = true;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    adc.Text = "0";
                    
                }
                catch
                {
                    MessageBox.Show("Wrong time Format! (hh:mm)");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            TimeSpan t = dateTimePicker2.Value - dateTimePicker1.Value;

            daysStaying = t.TotalDays.ToString();
            dateTimePicker2.Text = dateTimePicker1.Value.AddDays(1).ToShortDateString();
            if (dateTimePicker1.Value < dateTimePicker3.Value)
            {
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan t = dateTimePicker2.Value - dateTimePicker1.Value;

            daysStaying = t.TotalDays.ToString();

            try
            {
                int nu2, ans;
                nu2 = int.Parse(roomPrice);
                ans = nu2 * int.Parse(daysStaying);
                bil.Text = ans.ToString();
                label11.Text = daysStaying.ToString() + "  Day/s";
            }
            catch
            {

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string lastname = listView1.SelectedItems[0].SubItems[1].Text;
            string firstname = listView1.SelectedItems[0].SubItems[2].Text;
            string middleInitial = listView1.SelectedItems[0].SubItems[3].Text;
            label5.Text = listView1.SelectedItems[0].SubItems[0].Text;
            label6.Text = lastname + ", " + firstname + " " + middleInitial;
            groupBox1.Visible = true;
            daysStaying = (int.Parse(bil.Text) / int.Parse(roomPrice)).ToString();
            label11.Text = daysStaying + " Day/s";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            label10.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            bil.Clear();
            button1.Visible = false;
            btnChIn.Visible = false;
            btncancelRese.Visible = false;
            btnCancel.Visible = true;
            previousDaysStaying = daysStaying;
            if (daysStaying == "1")
            {
                bil.Text = roomPrice;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            label5.Text = "";
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label9.Visible = true;
            label10.Visible = true;
            button1.Visible = true;
            daysStaying = "1";
            btnChIn.Visible = true;
            btncancelRese.Visible = true;
            btnCancel.Visible = false;
        }

        private void adc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void bil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblRoom where room_number =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label7.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand room = new OleDbCommand("SELECT * FROM tblRoom WHERE room_number = '"+label7.Text+"'", con);
                    OleDbDataReader reader;
                    con.Open();
                    reader = room.ExecuteReader();
                    while (reader.Read())
                    {
                        roomPrice = reader["room_price"].ToString();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bil.Text = previousBill;
            label11.Text = previousDaysStaying + " Day/s";
            btnCancel.Visible = false;
            button1.Visible = true;
            btnChIn.Visible = true;
            btncancelRese.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }
        
        private void label9_TextChanged(object sender, EventArgs e)
        {
            dateTimePicker4.Text = label9.Text;
            if (dateTimePicker4.Value >= dateTimePicker1.Value)
            {
                btnChIn.Enabled= true;
            }
            else
            {
                btnChIn.Enabled = false;
            }
        }

        private void chInReserve_Activated(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            listView1.Items.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT tblTransactions.trans_number, tblGuestInfo.guest_lastname, tblGuestInfo.guest_firstname, tblGuestInfo.guest_mi, tblTransactions.room_number, tblTransactions.checkInDate FROM tblRoom INNER JOIN (tblGuestInfo INNER JOIN tblTransactions ON tblGuestInfo.guest_ID = tblTransactions.guest_ID) ON tblRoom.room_number = tblTransactions.room_number WHERE tblTransactions.transStatus = 'Pending';", con);
            da.Fill(dt);

            foreach (DataRow guest in dt.Rows)
            {
                listView1.Items.Add(guest[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[4].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[5].ToString());
            }
            dateTimePicker3.Text = DateTime.Now.ToShortDateString();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
