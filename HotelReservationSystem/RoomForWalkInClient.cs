using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class RoomForWalkInClient : Form
    {
            
        public RoomForWalkInClient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listView1.Items.Clear();
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
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_type like '" + textBox1.Text + "' +'%' ", con);
                    da.Fill(dt);

                    foreach (DataRow room in dt.Rows)
                    {
                        listView1.Items.Add(room[0].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(room[1].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(room[2].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(room[3].ToString());
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }

        private void roomForWalkInClien_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblRoom where room_status = '"+label2.Text+"'", con);
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string ro = listView1.SelectedItems[0].SubItems[0].Text;
            label3.Text = ro;
            this.Close(); 
            reserve.roomNum = label3.Text;
        }
    }
}
