using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class CheckinForm : Form
    {
             
        public CheckinForm()
        {
            InitializeComponent();
        }

        private void CheckinForm_Load(object sender, EventArgs e)
        {
            label11.Text = Class1.Username;
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

            OleDbCommand admininfo = new OleDbCommand("SELECT * FROM tblAdmin where admin_username = '" + label11.Text + "'", con);
            con.Open();
            reader = admininfo.ExecuteReader();
            while (reader.Read())
            {
                label24.Text = reader["admin_firstname"].ToString() + " " + reader["admin_mi"].ToString() + ". " + reader["admin_lastname"].ToString() + "";
            }
            con.Close();

            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker3.Text = DateTime.Now.AddDays(1).ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();

        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            addingNewGuest a = new addingNewGuest();
            a.ShowDialog();
        }

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RoomForWalkInClient w = new RoomForWalkInClient();
            w.ShowDialog();
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
                            label16.Text = textBox2.Text;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label9.Text = "";
            }

            else
            {
                label25.Visible = false;
                string cmdText = "select Count(*) from tblRoom where room_number =?";
                using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@p1", textBox3.Text);
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        label23.Visible = false;
                        OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                        OleDbCommand admininfo = new OleDbCommand("SELECT * FROM tblRoom where room_number = '" + textBox3.Text + "'", con);
                        OleDbDataReader reader;
                        con.Open();
                        reader = admininfo.ExecuteReader();
                        while (reader.Read())
                        {
                            label13.Text = reader["room_status"].ToString();
                            label27.Text = reader["room_price"].ToString();
                            
                            if (label13.Text != "Available")
                            {
                                MessageBox.Show("This room is " + label13.Text + ".Choose another room!");
                                textBox2.Text = label16.Text;
                                textBox3.Clear();
                                label9.Text = "";
                            }
                            else
                            {
                                label9.Text = "P" + label27.Text +".00";

                                int nu1, nu2;
                                nu1 = int.Parse(label27.Text);
                                nu2 = int.Parse(label18.Text);
                                int ans = nu1 * nu2;
                                label20.Text = ans.ToString();
                                textBox1.Text = "P" + label20.Text + ".00";

                                label26.Text = textBox3.Text;
                            }
                        }
                    }

                    else
                    {
                        label9.Text = "";
                    }
                    conn.Close();
                }
            }
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            putGuest a = new putGuest();
            a.ShowDialog();
        }

        private void CheckinForm_Activated(object sender, EventArgs e)
        {
            textBox3.Text = reserve.roomNum;
            textBox2.Text = guestID1.guestID;
        }

        private void CheckinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            guestID1.guestID = "";
            reserve.roomNum = "";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label12.Text))
            {
                label25.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label21.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                label22.Visible = true;
            }
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label31.Visible = true;
            }
            else
            {
                try
                {
                    label31.Visible = false;
                    string traID = label10.Text;
                    string usnam = label11.Text;
                    string gueID = textBox2.Text;
                    string rmNum = textBox3.Text;
                    string rsda = dateTimePicker2.Value.ToShortDateString();
                    string inda = dateTimePicker1.Value.ToShortDateString() + " " + textBox5.Text;
                    string ouda = dateTimePicker3.Value.ToShortDateString() + " " + textBox6.Text;
                    string bill = label20.Text;
                    string adva = textBox4.Text;
                    string addc = textBox7.Text;
                    string stat = label28.Text;

                    OleDbConnection condatabase = new OleDbConnection(DatabaseLocation.dbLocation);
                    condatabase.Open();

                    OleDbCommand trans = new OleDbCommand("INSERT INTO tblTransactions(trans_number, admin_username, guest_ID, room_number, inquireDate, checkInDate, checkOutDate, resBill, resAdvance, additionalCharges, transStatus ) VALUES('" + traID + "','" + usnam + "','" + gueID + "','" + rmNum + "','" + rsda + "','" + inda + "','" + ouda + "', '" + bill + "', '" + adva + "','" + addc + "', '" + stat + "')", condatabase);
                    trans.ExecuteNonQuery();
                    string strSql = "UPDATE tblRoom SET room_status = 'Occupied' where room_number = '" + textBox3.Text + "'";
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand cmd = new OleDbCommand(strSql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Occupied!");
                    guestID1.guestID = "";
                    this.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error! Either time format or currency format. Use this format in time to continue, hour:minute(ex. 10:00 AM/PM or 15:00(3:00 PM)), and input only numbers in payments!");
                    textBox2.Text = label16.Text;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan t = dateTimePicker3.Value - dateTimePicker1.Value;

            label18.Text = t.TotalDays.ToString();

            if (dateTimePicker3.Value <= dateTimePicker1.Value)
            {
                dateTimePicker3.Value = dateTimePicker1.Value.AddDays(1);
            }

            if (string.IsNullOrWhiteSpace(label9.Text))
            {
                label27.Text = "";
            }
        }

        private void label18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label27.Text);
                nu2 = int.Parse(label18.Text);
                int ans = nu1 * nu2;
                label20.Text = ans.ToString();
                textBox1.Text = "P" + label20.Text + ".00";
            }
            catch
            {
                MessageBox.Show("No Selected Room Yet! Select room first to compute their bill!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label21.Visible = true;
            }
            else
            {
                label21.Visible = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label22.Visible = true;
            }
            else
            {
                label22.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label20.Text);
                nu2 = int.Parse(textBox7.Text);
                int ans = nu1 + nu2;
                label20.Text = ans.ToString();
                textBox1.Text = "P" + label20.Text;
                textBox7.Text = "0";
                label30.Text = "Charges added";
                label30.Visible = true;
            }
            catch
            {
                label30.Text = "Charges not added!";
                label30.Visible = true;
            }
        }
    }
}
