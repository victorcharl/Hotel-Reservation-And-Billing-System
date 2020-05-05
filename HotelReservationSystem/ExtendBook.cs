using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class ExtendBook : Form
    {
        public ExtendBook()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label28.Text = textBox1.Text;
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
                label27.Text = "0";
                label16.Text = "- - - - - -";
                label12.Visible = false;
                label13.Visible = false;
            }
            else
            {
                label19.Visible = false;
                textBox3.Clear();
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
                            label31.Text = label8.Text;
                            label22.Text = reader["transStatus"].ToString();
                            label12.Visible = true;
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
                                label27.Text = "0";
                                label16.Text = "- - - - - -";
                                label12.Visible = false;
                            }
                            else if (label8.Text == "0.0000")
                            {
                                label8.Text = "0";
                                int nu1, nu2;
                                nu1 = int.Parse(label7.Text);
                                nu2 = int.Parse(label8.Text);
                                int ans = nu1 - nu2;
                                label10.Text = ans.ToString();
                                label29.Text = label10.Text;

                            }
                            else
                            {
                                label8.Text = reader["resAdvance"].ToString();
                                int nu1, nu2;
                                nu1 = int.Parse(label7.Text);
                                nu2 = int.Parse(label8.Text);
                                int ans = nu1 - nu2;
                                label10.Text = ans.ToString();
                                label29.Text = label10.Text;
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
                        label27.Text = "- - - - - -";
                        label16.Text = "- - - - - -";
                        label12.Visible = false;
                    }
                    conn.Close();
                }
            }
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

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label18.Text = textBox2.Text;
            int nu1, nu2;
            nu1 = int.Parse(label10.Text);
            nu2 = int.Parse(textBox2.Text);
            int ans = nu1 + nu2;
            label10.Text = ans.ToString();
            label19.Text = "P" + label18.Text + " is added to their bill";
            label19.Visible = true;
            textBox2.Clear();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EnterTransactionID p = new EnterTransactionID();
            p.ShowDialog();
        }

        private void Extend_Activated(object sender, EventArgs e)
        {
            textBox1.Text = trans.transNum;
            textBox1.Text = label28.Text;
        }

        private void Extend_FormClosed(object sender, FormClosedEventArgs e)
        {
            trans.transNum = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSql = "UPDATE tblTransactions SET checkOutDate = '"+dateTimePicker1.Value.ToShortDateString() + " "+dateTimePicker2.Value.ToShortTimeString()+"', resBill = '" + label10.Text + "' where trans_number = '" + textBox1.Text + "'";
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Complete");
        }

        private void Extend_Load(object sender, EventArgs e)
        {
            dateTimePicker3.Text = DateTime.Now.ToShortDateString();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker5.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            dateTimePicker2.Text = "00:00:00 PM";
            label12.Visible = false;
            label13.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label10.Text = label29.Text;
            TimeSpan t = dateTimePicker1.Value - dateTimePicker3.Value;
        
            label17.Text = t.TotalDays.ToString();
            if (dateTimePicker1.Value <= dateTimePicker3.Value)
            {
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
                dateTimePicker2.Text = "00:00:00 PM";
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label13.Visible = true;
            label12.Visible = true;
        }

        private void label17_TextChanged(object sender, EventArgs e)
        {
            int nu1, nu2;
            nu1 = int.Parse(label26.Text);
            nu2 = int.Parse(label17.Text);
            int ans = nu1 * nu2;
            label27.Text = ans.ToString();
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
                        label26.Text = reader["room_price"].ToString();
                    }
                }
            }
        }

        private void label27_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label27.Text);
                nu2 = int.Parse(label10.Text);
                int ans = nu1 + nu2;
                label10.Text = ans.ToString();
            }
            catch
            {

            }
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker4.Text = label6.Text;

                if (dateTimePicker4.Value >= dateTimePicker5.Value)
                {
                    btnSave.Enabled = false;
                    label12.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    label12.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(textBox3.Text);
                nu2 = int.Parse(label8.Text);
                int ans = nu1 + nu2;
                label8.Text = ans.ToString();
                textBox3.Clear();
            }
            catch
            {

            }
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2, nu3;
                nu1 = int.Parse(label10.Text);
                nu2 = int.Parse(label8.Text);
                nu3 = int.Parse(label31.Text);
                int ans = (nu1 - nu2) + nu3;
                label16.Text = ans.ToString();
            }
            catch
            {
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nu1, nu2;
                nu1 = int.Parse(label7.Text);
                nu2 = int.Parse(label8.Text);
                int ans = nu1 - nu2;
                label16.Text = ans.ToString();
            }
            catch
            {

            }
        }
    }
}
