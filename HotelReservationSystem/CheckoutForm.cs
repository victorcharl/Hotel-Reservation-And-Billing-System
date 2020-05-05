using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class CheckoutForm : Form
    {
        string roomPrice;

        public CheckoutForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label2.Visible = false;
                label3.Text = "- - - - - -";
                label4.Text = "- - - - - -";
                label5.Text = "- - - - - -";
                label6.Text = "- - - - - -";
                label6.Text = "- - - - - -";
                label7.Text = "- - - - - -";
                label8.Text = "- - - - - -";
                textBox2.Clear();
                label10.Text = "- - - - - -";
                label11.Text = "- - - - - -";
            }
            else
            {
                label19.Visible = false;
                textBox3.Clear();
                textBox4.Clear();
                string cmdText = "select Count(*) from tblTransactions where trans_number =?";
                using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                        OleDbCommand trans = new OleDbCommand("SELECT * FROM tblTransactions where trans_number = '" + textBox1.Text + "'", con);
                        OleDbDataReader reader;
                        con.Open();
                        reader = trans.ExecuteReader();
                        while (reader.Read())
                        {
                            label2.Visible = false;
                            label3.Text = reader["guest_ID"].ToString();
                            label4.Text = reader["room_number"].ToString();
                            label5.Text = reader["checkInDate"].ToString();
                            label6.Text = reader["checkOutDate"].ToString();
                            label7.Text = reader["resBill"].ToString();
                            label8.Text = reader["resAdvance"].ToString();
                            label22.Text = reader["transStatus"].ToString();
                            if (label22.Text != "Check In")
                            {
                                label2.Visible = true;
                                label3.Text = "- - - - - -";
                                label4.Text = "- - - - - -";
                                label5.Text = "- - - - - -";
                                label6.Text = "- - - - - -";
                                label6.Text = "- - - - - -";
                                label7.Text = "- - - - - -";
                                label8.Text = "- - - - - -";
                                textBox2.Clear();
                                label10.Text = "- - - - - -";
                                label11.Text = "- - - - - -";
                            }
                            else if (label8.Text == "0.0000")
                            {
                                label8.Text = "0";
                                int nu1, nu2;
                                nu1 = int.Parse(label7.Text);
                                nu2 = int.Parse(label8.Text);
                                int ans = nu1 - nu2;
                                label10.Text = ans.ToString();

                            }
                            else
                            {
                                label8.Text = reader["resAdvance"].ToString();
                                int nu1, nu2;
                                nu1 = int.Parse(label7.Text);
                                nu2 = int.Parse(label8.Text);
                                int ans = nu1 - nu2;
                                label10.Text = ans.ToString();
                            }
                            label20.Text = textBox1.Text;
                        }
                    }

                    else
                    {
                        label2.Visible = true;
                        label3.Text = "- - - - - -";
                        label4.Text = "- - - - - -";
                        label5.Text = "- - - - - -";
                        label6.Text = "- - - - - -";
                        label6.Text = "- - - - - -";
                        label7.Text = "- - - - - -";
                        label8.Text = "- - - - - -";
                        textBox2.Clear();
                        label10.Text = "- - - - - -";
                        label11.Text = "- - - - - -";
                    }
                    conn.Close();
                }            
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            new EnterTransactionID().ShowDialog();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblGuestInfo where guest_ID =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label3.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand guest = new OleDbCommand("SELECT * FROM tblGuestInfo where guest_ID = '" + label3.Text + "'", con);
                    OleDbDataReader reader;
                    con.Open();
                    reader = guest.ExecuteReader();
                    while (reader.Read())
                    {
                        label11.Text = reader["guest_firstname"].ToString() + " " + reader["guest_mi"].ToString() + ". " + reader["guest_lastname"].ToString() + "";
                    }
                }
                else
                {
                    label11.Text = "";

                }
            }
        }

        private void CheckoutForm_Activated(object sender, EventArgs e)
        {
            textBox1.Text = trans.transNum;
            textBox1.Text = label20.Text;
        }

        private void CheckoutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            trans.transNum = "";
        }

        private void btnChOut_Click(object sender, EventArgs e)
        {
            string ans = MessageBox.Show("Checking Out Guest?", "Check Out", MessageBoxButtons.YesNo).ToString();
            if (ans.Equals("Yes"))
            {
                string strSql = "UPDATE tblTransactions SET transStatus = '" + label13.Text + "', totalBill = '" + label7.Text + "' where trans_number = '" + textBox1.Text + "'";
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                OleDbCommand cmd = new OleDbCommand(strSql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                string strSql1 = "UPDATE tblRoom SET room_status = '" + label12.Text + "' where room_number = '" + label4.Text + "'";
                OleDbConnection con1 = new OleDbConnection(DatabaseLocation.dbLocation);
                OleDbCommand cmd1 = new OleDbCommand(strSql1, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                this.Close();
                string ans1 = MessageBox.Show("Check Out Successful. Do you want a printed receipt?", "Check Out?", MessageBoxButtons.YesNo).ToString();
                if (ans.Equals("Yes"))
                {
                    textBox1.Clear();
                    trans.transNum = label20.Text;
                    Print p = new Print();
                    p.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label10.Text);
                nu2 = int.Parse(textBox2.Text);
                int ans = nu1 + nu2;
                label7.Text = ans.ToString();
                label17.Visible = false;
                label19.Text = "P"+ label18.Text + " is added to their bill";
                label19.Visible = true;
                textBox2.Clear();
                textBox3.Clear();
            } catch {label17.Visible = true; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            { label17.Visible = false; }
            label18.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(textBox3.Text);
                nu2 = int.Parse(label10.Text);
                int ans = nu1 - nu2;
                textBox4.Text = ans.ToString();
                label21.Visible = false;
            }
            catch
            {
                label21.Visible = true;
                textBox4.Clear();
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            label23.Text = label10.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(textBox3.Text);
                nu2 = int.Parse(label10.Text);
                if (nu1 < nu2)
                {
                    btnChOut.Enabled = false;
                }
                else
                {
                    btnChOut.Enabled = true;
                }
            } catch {/*Do Nothing*/}
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                choutdate.Text = label6.Text;
                chInDate.Text = label5.Text;
                if (datenow.Value >= choutdate.Value)
                {
                    btnChOut.Enabled = true;
                    textBox3.Enabled = true;
                    lblChOut.Visible = false;
                    if (lblChOut.Visible == false)
                    {
                        btnChOut.Enabled = false;
                    }
                    else
                    {
                        btnChOut.Enabled = true;
                    }
                }
                else
                {
                    btnChOut.Enabled = false;
                    textBox3.Enabled = false;
                    lblChOut.Visible = true;
                }
            } catch {/*Do Nothing*/}
        }

        private void lblChOut_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label29.Text = label10.Text;
            TimeSpan t = choutdate.Value - dateTimePicker1.Value;
            label30.Text = t.TotalDays.ToString();

        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            string cmdText = "select Count(*) from tblRoom where room_number =?";
            using (OleDbConnection conn = new OleDbConnection(DatabaseLocation.dbLocation))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@p1", label4.Text);
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand room = new OleDbCommand("SELECT * FROM tblRoom WHERE room_number = '" + label4.Text + "'", con);
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

        private void label7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label7.Text);
                nu2 = int.Parse(label8.Text);
                int ans = nu1 - nu2;
                label10.Text = ans.ToString();
            } catch {/*Do Nothing*/}
        }

        private void CheckoutForm_Load_1(object sender, EventArgs e)
        {
            datenow.Text = DateTime.Now.AddDays(1).ToShortDateString();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void label30_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float nu1, nu2;
                nu1 = float.Parse(label30.Text);
                nu2 = float.Parse(roomPrice) / 2; // Need to pay half the price of the room per day if you check out early
                float ans = nu1 * nu2;
                label31.Text = ans.ToString();
            } catch {/*Do Nothing*/}
        }

        private void label31_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float nu1, nu2;
                nu1 = float.Parse(label29.Text);
                nu2 = float.Parse(label31.Text);
                float ans = nu1 - nu2;
                label34.Text = ans.ToString();
            } catch {/*Do Nothing*/}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string strSql = "UPDATE tblTransactions SET checkOutDate = '"+DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToShortTimeString()+"', resBill = '" + label34.Text + "' where trans_number = '" + textBox1.Text + "'";
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Successful!");
            groupBox1.Visible = false;
            label6.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            label7.Text = label34.Text;
        }
    }
}
