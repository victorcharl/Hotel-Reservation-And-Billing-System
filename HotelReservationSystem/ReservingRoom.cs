using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class reservingRoom : Form
    {
        int roomPrice, totalBill;

        public reservingRoom()
        {
            InitializeComponent();
        }


        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new putGuest().ShowDialog();
        }

        private void reservingRoom_Load(object sender, EventArgs e)
        {
            label12.Text = "";
            label33.Text = DateTime.Now.ToLongDateString();
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand trans = new OleDbCommand("SELECT count(*) + 1 FROM tblTransactions", con);
            OleDbDataReader reader;
            con.Open();
            reader = trans.ExecuteReader();
            while (reader.Read())
            {
                label10.Text = label10.Text + reader["Expr1000"].ToString();
            }
            con.Close();
            roomPrice = int.Parse(rmPrice.romprice);
            label19.Text = "P"+roomPrice+"/day";
            label11.Text = Class1.Username;
            label13.Text = reserve.roomNum;

            OleDbCommand admininfo = new OleDbCommand("SELECT * FROM tblAdmin where admin_username = '" + label11.Text + "'", con);
            con.Open();
            reader = admininfo.ExecuteReader();
            while (reader.Read())
            {
                label24.Text = reader["admin_firstname"].ToString() + " "+reader["admin_mi"].ToString()+". "+reader["admin_lastname"].ToString()+"";
            }
            con.Close();

            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker3.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void reservingRoom_Activated(object sender, EventArgs e)
        {
            textBox2.Text = guestID1.guestID;
        }

        private void btnAddGuest_Click_1(object sender, EventArgs e)
        {
            new addingNewGuest().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label12.Text))
            {
                label25.Visible = true;
            }
                
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        textBox3.Text = "0";
                    }
                    if (string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        textBox4.Text = "0";
                    }

                    string traID = label10.Text;
                    string usnam = label11.Text;
                    string gueID = textBox2.Text;
                    string rmNum = label13.Text;
                    string rsda = DateTime.Now.ToShortDateString();
                    string inda = dateTimePicker1.Value.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    string ouda = dateTimePicker3.Value.ToShortDateString() + " " + "12:00:00 PM";
                    string bill = totalBill.ToString();
                    string adva = textBox4.Text;
                    string addc = textBox3.Text;

                    OleDbConnection condatabase = new OleDbConnection(DatabaseLocation.dbLocation);
                    condatabase.Open();

                    OleDbCommand trans = new OleDbCommand("INSERT INTO tblTransactions(trans_number, admin_username, guest_ID, room_number, inquireDate, checkInDate, checkOutDate, resBill, resAdvance, additionalCharges, transStatus ) VALUES('" + traID + "','" + usnam + "','" + gueID + "','" + rmNum + "','" + rsda + "','" + inda + "','" + ouda + "', '" + bill + "', '" + adva + "','" + addc + "', 'Pending')", condatabase);
                    trans.ExecuteNonQuery();
                    string strSql = "UPDATE tblRoom SET room_status = 'Reserved' where room_number = '" + label13.Text + "'";
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand cmd = new OleDbCommand(strSql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Reserved!");
                    guestID1.guestID = "";
                    reserve.roomNum = "";
                    this.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error! Either time format or currency format. Use this format in time to continue, hour:minute(ex. 12:00 AM/PM), and input only numbers in payments!");
                    textBox2.Text = guestID1.guestID;
                }
            }
        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan t = dateTimePicker3.Value - dateTimePicker1.Value;

            label18.Text = t.TotalDays.ToString();

            if (dateTimePicker3.Value <= dateTimePicker1.Value)
            {
                dateTimePicker3.Value = dateTimePicker1.Value.AddDays(1);
            }
            totalBill = roomPrice * int.Parse(label18.Text);
            textBox1.Text = "P" + totalBill.ToString() + ".00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guestID1.guestID = "";
            this.Close();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label23.Visible = false;
                label12.Text = "";
            }

            else
            {
                label25.Visible = false;
                string cmdText = "select Count(*) from tblGuestInfo where guest_ID =?";
                using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@p1", textBox2.Text);
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        label23.Visible = false;
                        OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                        OleDbCommand admininfo = new OleDbCommand("SELECT * FROM tblGuestInfo where guest_ID = '" + textBox2.Text + "'", con);
                        OleDbDataReader reader;
                        con.Open();
                        reader = admininfo.ExecuteReader();
                        while (reader.Read())
                        {
                            label12.Text = reader["guest_firstname"].ToString() + " " + reader["guest_mi"].ToString() + ". " + reader["guest_lastname"].ToString() + "";
                        }
                    }

                    else
                    {
                        label23.Visible = true;
                        label12.Text = "";
                    }
                    conn.Close();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Text = dateTimePicker1.Value.AddDays(1).ToShortDateString();
            if (dateTimePicker1.Value < dateTimePicker5.Value)
            {
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox3.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalBill += int.Parse(textBox3.Text);
            textBox1.Text = "P" + totalBill.ToString() + ".00";
            textBox3.Text = "0";
            label29.Visible = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
