using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class putGuest : Form
    {            
        public putGuest()
        {
            InitializeComponent();
        }

        private void putGuest_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            listView1.Items.Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblGuestInfo", con);
            da.Fill(dt);

            foreach (DataRow guest in dt.Rows)
            {
                listView1.Items.Add(guest[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
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
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblGuestInfo", con);
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
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblGuestInfo where guest_lastname like '" + textBox1.Text + "' +'%' OR guest_firstname like '"+textBox1.Text+"' +'%' ", con);
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
            guestID1.guestID = label2.Text;
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string id = listView1.SelectedItems[0].SubItems[0].Text;

                label2.Text = id;
                guestID1.guestID = label2.Text;
            }
            catch
            {

            }
        }
    }
}
