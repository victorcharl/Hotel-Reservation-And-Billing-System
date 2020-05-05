using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class changeadmininfo : Form
    {
                    
        public changeadmininfo()
        {
            InitializeComponent();
        }

        private void changeadmininfo_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                OleDbCommand admininfo = new OleDbCommand("SELECT * FROM tblAdmin where admin_username = '" + Class1.Username + "'", con);
                OleDbDataReader reader;
                con.Open();
                reader = admininfo.ExecuteReader();
                while (reader.Read())
                {
                    last.Text = reader["admin_lastname"].ToString() + ",";
                    first.Text = reader["admin_firstname"].ToString();
                    mi.Text = reader["admin_mi"].ToString() + ".";
                    label3.Text = reader["admin_password"].ToString();

                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label10.Visible = true;
            }

            else if (password.Text != label3.Text)
            {
                label10.Visible = false;
                label12.Visible = true;
            }

            else if (textBox2.Text != textBox1.Text)
            {
                label10.Visible = false;
                label13.Visible = true;
            }

            else
            {
                try
                {
                    label10.Visible = false;
                    string strSql = "UPDATE tblAdmin SET admin_password = '" + textBox2.Text + "' where admin_username = '" + label15.Text + "'";
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    OleDbCommand cmd = new OleDbCommand(strSql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Save Successful.");
                    this.Close();
                }

                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                label12.Visible = false;
            }
            else if (password.Text != label3.Text)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label13.Visible = false;
            }
            else if (textBox2.Text != textBox1.Text)
            {
                label13.Visible = true;
            }
            else
            {
                label13.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
