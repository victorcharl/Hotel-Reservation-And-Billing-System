using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class room : Form
    {
        
        public room()
        {
            InitializeComponent();
        }

        private void room_Load(object sender, EventArgs e)
        {
            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);
            gbRooms.Text = "All Rooms";
            searchRooms();
            allroom();
            availableroom();
            unavailableroom();
            occupiedroom();
            reservedroom();
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "All";
            gbRooms.Text = "All Rooms";
            searchRooms();
            label9.Visible = false;
            textBox6.Visible = false;

            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);

            label10.Visible = false;
        }

        private void rdbReserved_CheckedChanged(object sender, EventArgs e)
        {
            gbRooms.Text = "Reserved Rooms";
            label1.Text = "Reserved";
            searchRooms();
            label9.Visible = false;
            textBox6.Visible = false;

            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);

            label10.Visible = false;
            if (label4.Text == "(0)")
            {
                label10.Text = "No Reserved Rooms";
                label10.Visible = true;
            }
        }

        private void rdbOccupied_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Occupied";
            gbRooms.Text = "Occupied Rooms";
            searchRooms();
            label9.Visible = false;
            textBox6.Visible = false;

            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);

            label10.Visible = false;
            if (label5.Text == "(0)")
            {
                label10.Text = "No Occupied Rooms";
                label10.Visible = true;
            }
        }

        private void rdbAvailable_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Available";
            gbRooms.Text = "Available Rooms";
            searchRooms();
            label9.Visible = true;
            textBox6.Visible = true;

            label8.Location = new System.Drawing.Point(11, 46);
            listView1.Location = new System.Drawing.Point(7, 62);
            listView1.Size = new System.Drawing.Size(567, 433);

            label10.Visible = false;
            if (label6.Text == "(0)")
            {
                label10.Text = "No Available Rooms";
                label10.Visible = true;
            }
        }

        private void rdbUnavailble_CheckedChanged(object sender, EventArgs e)
        {
            gbRooms.Text = "Unavailable Rooms";
            label1.Text = "Unavailable";
            searchRooms();
            label9.Visible = false;
            textBox6.Visible = false;

            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);

            label10.Visible = false;
            if (label7.Text == "(0)")
            {
                label10.Text = "No Unavailable Rooms";
                label10.Visible = true;
            }
        }

        public void searchRooms()
        {

            if (rdbOccupied.Checked)
            {
                try
                {
                    listView1.Items.Clear();
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_status = '"+label1.Text+"'", con);
                    da.Fill(dt);

                    foreach (DataRow rooms in dt.Rows)
                    {
                        listView1.Items.Add(rooms[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }

            else if (rdbAvailable.Checked)
            {
                try
                {
                    listView1.Items.Clear();
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_status = '"+label1.Text+"'", con);
                    da.Fill(dt);

                    foreach (DataRow rooms in dt.Rows)
                    {
                        listView1.Items.Add(rooms[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }

            else if (rdbUnavailble.Checked)
            {
                try
                {
                    listView1.Items.Clear();
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_status = '" + label1.Text + "'", con);
                    da.Fill(dt);

                    foreach (DataRow rooms in dt.Rows)
                    {
                        listView1.Items.Add(rooms[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }

            else if (rdbReserved.Checked)
            {
                try
                {
                    listView1.Items.Clear();
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_status = '"+label1.Text+"'", con);
                    da.Fill(dt);

                    foreach (DataRow rooms in dt.Rows)
                    {
                        listView1.Items.Add(rooms[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
            else
            {
                try
                {
                    listView1.Items.Clear();
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom", con);
                    da.Fill(dt);

                    foreach (DataRow rooms in dt.Rows)
                    {
                        listView1.Items.Add(rooms[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }

        public void allroom()
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand allroom = new OleDbCommand("SELECT count(*) FROM tblRoom", con);
            OleDbDataReader reader;
            con.Open();
            reader = allroom.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = "(" + reader["Expr1000"].ToString() + ")";
            }
            con.Close();
        }

        public void availableroom()
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand allroom = new OleDbCommand("SELECT count(*) FROM tblRoom where room_status = '"+rdbAvailable.Text+"'", con);
            OleDbDataReader reader;
            con.Open();
            reader = allroom.ExecuteReader();
            while (reader.Read())
            {
                label6.Text = "(" + reader["Expr1000"].ToString() + ")";

            }
            con.Close();
        }

        public void unavailableroom()
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand allroom = new OleDbCommand("SELECT count(*) FROM tblRoom where room_status = '" +rdbUnavailble.Text+"'", con);
            OleDbDataReader reader;
            con.Open();
            reader = allroom.ExecuteReader();
            while (reader.Read())
            {
                label7.Text = "(" + reader["Expr1000"].ToString() + ")";

            }
            con.Close();
        }

        public void occupiedroom()
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand allroom = new OleDbCommand("SELECT count(*) FROM tblRoom where room_status = '" +rdbOccupied.Text+"'", con);
            OleDbDataReader reader;
            con.Open();
            reader = allroom.ExecuteReader();
            while (reader.Read())
            {
                label5.Text = "(" + reader["Expr1000"].ToString() + ")";

            }
            con.Close();
        }

        public void reservedroom()
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand allroom = new OleDbCommand("SELECT count(*) FROM tblRoom where room_status = '"+rdbReserved.Text+"'", con);
            OleDbDataReader reader;
            con.Open();
            reader = allroom.ExecuteReader();
            while (reader.Read())
            {
                label4.Text = "(" + reader["Expr1000"].ToString() + ")";

            }
            con.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string rnum = listView1.SelectedItems[0].SubItems[0].Text;
            string rtyp = listView1.SelectedItems[0].SubItems[1].Text;
            string rocc = listView1.SelectedItems[0].SubItems[2].Text;
            string rpri = listView1.SelectedItems[0].SubItems[3].Text;
            string rsta = listView1.SelectedItems[0].SubItems[4].Text;

            textBox1.Text = rnum;
            textBox2.Text = rtyp;
            textBox3.Text = rocc;
            textBox4.Text = rpri;
            textBox5.Text = rsta;

            if (textBox5.Text != "Available")
            {
                MessageBox.Show("This room cannot be reserved!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }

            else
            {
                reserve.roomNum = textBox1.Text;
                rmPrice.romprice = textBox4.Text;
                reservingRoom r = new reservingRoom();
                r.ShowDialog();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_type like '"+textBox6.Text+"' +'%' AND room_status = '" + rdbAvailable.Text + "'", con);
            da.Fill(dt);

            foreach (DataRow rooms in dt.Rows)
            {
                listView1.Items.Add(rooms[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[3].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rooms[4].ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            rdbAll.Checked = true;
            label1.Text = "All";
            gbRooms.Text = "All Rooms";
            searchRooms();
            label9.Visible = false;
            textBox6.Visible = false;

            label8.Location = new System.Drawing.Point(11, 20);
            listView1.Location = new System.Drawing.Point(7, 37);
            listView1.Size = new System.Drawing.Size(567, 460);
        }

        private void room_Activated(object sender, EventArgs e)
        {
            guestID1.guestID = "";
            searchRooms();
            allroom();
            availableroom();
            unavailableroom();
            occupiedroom();
            reservedroom();
        }
    }
}
