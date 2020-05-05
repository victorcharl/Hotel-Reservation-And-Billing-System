using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class guestList : Form
    {            
        public guestList()
        {
            InitializeComponent();
        }

        private void guestList_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                con.Open();

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblGuestInfo", con);
                da.Fill(dt);

                foreach (DataRow guest in dt.Rows)
                {
                    listView1.Items.Add(guest[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[4].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[5].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[6].ToString());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            con.Open();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from tblGuestInfo where guest_lastname like '"+textBox1.Text+"' + '%' or guest_firstname like '"+textBox1.Text+"' + '%'", con);
            da.Fill(dt);

            foreach (DataRow guest in dt.Rows)
            {
                listView1.Items.Add(guest[0].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[1].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[2].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[3].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[4].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[5].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(guest[6].ToString());
            }
        }
    }
}
