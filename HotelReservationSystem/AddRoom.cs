using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class AddRoom : Form
    {
                    
        public AddRoom()
        {
            InitializeComponent();
        }

        private void addRoom_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand addroom = new OleDbCommand("SELECT count(*) + 1 FROM tblRoom", con);
            OleDbDataReader reader;
            con.Open();
            reader = addroom.ExecuteReader();
            while (reader.Read())
            {
                label6.Text = label6.Text + reader["Expr1000"].ToString();
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox2.Clear();
                textBox3.Clear();
            }

            if (textBox1.Text == "Suite Room")
            {
                textBox2.Text = "5";
                textBox3.Text = "1800";
            }

            if (textBox1.Text == "Deluxe Room")
            {
                textBox2.Text = "2";
                textBox3.Text = "1500";
            }

            if (textBox1.Text == "Front View Room")
            {
                textBox2.Text = "2";
                textBox3.Text = "1600";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label7.Visible = true;
            }

            else
            {
                try
                {
                    OleDbConnection condatabase = new OleDbConnection(DatabaseLocation.dbLocation);
                    condatabase.Open();
                    OleDbCommand addroom = new OleDbCommand("INSERT INTO tblRoom(room_number, room_type, room_occupancy, room_price, room_status) VALUES(@rmNum, @rmTyp, @rmOcc, @rmPri, @rmSta)", condatabase);
                    addroom.Parameters.Add("@rmNum", OleDbType.VarWChar, 99).Value = label6.Text;
                    addroom.Parameters.Add("@rmTyp", OleDbType.VarWChar, 99).Value = textBox1.Text;
                    addroom.Parameters.Add("@rmOcc", OleDbType.VarWChar, 99).Value = textBox2.Text;
                    addroom.Parameters.Add("@rmPri", OleDbType.Currency, 99).Value = textBox3.Text;
                    addroom.Parameters.Add("@rmSta", OleDbType.VarChar, 99).Value = "Available";
                    addroom.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added!");
                    this.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
    }
}
