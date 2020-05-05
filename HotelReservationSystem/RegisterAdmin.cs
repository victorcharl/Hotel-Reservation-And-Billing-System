using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class registerAdmin : Form
    {
        public registerAdmin()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(reglast.Text) || string.IsNullOrWhiteSpace(regfirst.Text) ||
                string.IsNullOrWhiteSpace(regmi.Text) || string.IsNullOrWhiteSpace(label7.Text) ||
                string.IsNullOrWhiteSpace(regusername.Text) || string.IsNullOrWhiteSpace(regpassword.Text) ||
                string.IsNullOrWhiteSpace(regconfirm.Text))
            {
                label12.Visible = true;
                label3.Visible = false;
            }

            else if (regpassword.Text != regconfirm.Text)
            {
                label3.Visible = true;
                label12.Visible = false;
            }

            else
            {
                try
                {
                    string lName = reglast.Text;
                    string fName = regfirst.Text;
                    string mi = regmi.Text;
                    string sex = label7.Text;
                    string user = regusername.Text;
                    string pswd = regpassword.Text;

                    OleDbConnection condatabase = new OleDbConnection(DatabaseLocation.dbLocation);
                    condatabase.Open();
                    OleDbCommand addUser = new OleDbCommand("INSERT INTO tblAdmin(admin_lastname, admin_firstname, admin_mi, admin_gender, admin_username, admin_password) VALUES(@lName, @fName, @mi, @sex, @user, @pswd)", condatabase);

                    addUser.Parameters.Add("@lName", OleDbType.VarWChar, 99).Value = lName;
                    addUser.Parameters.Add("@fName", OleDbType.VarWChar, 99).Value = fName;
                    addUser.Parameters.Add("@mi", OleDbType.VarWChar, 99).Value = mi;
                    addUser.Parameters.Add("@sex", OleDbType.VarWChar, 99).Value = sex;
                    addUser.Parameters.Add("@user", OleDbType.VarWChar, 99).Value = user;
                    addUser.Parameters.Add("@pswd", OleDbType.VarWChar, 99).Value = pswd;
                    addUser.ExecuteNonQuery();
                    MessageBox.Show("New Admin Added");
                    reglast.Clear();
                    regfirst.Clear();
                    regmi.Clear();
                    regmale.Checked = false;
                    regfemale.Checked = false;
                    regusername.Clear();
                    regpassword.Clear();
                    regconfirm.Clear();
                    label3.Visible = false;
                    label12.Visible = false;
                    condatabase.Close();
                }

                catch (Exception)
                {
                    
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reglast.Clear();
            regfirst.Clear();
            regmi.Clear();
            regmale.Checked = false;
            regfemale.Checked = false;
            regusername.Clear();
            regpassword.Clear();
            regconfirm.Clear();
            this.Close();
        }

        private void regmale_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "male";
        }

        private void regfemale_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "female";
        }

        private void regconfirm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(regpassword.Text) || string.IsNullOrWhiteSpace(regconfirm.Text))
            {
                label3.Visible = false;
            }

            if (regpassword.Text != regconfirm.Text)
            {
                label3.Visible = true;
            }

            else
            {
                label3.Visible = false;
            }
        }

        private void regusername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(regusername.Text))
            {
                label1.Visible = false;
            }

            else
            {
                string cmdText = "select Count(*) from tblAdmin where admin_username =?";
                using (OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@p1", regusername.Text);
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        label1.Visible = true;

                    }

                    else
                    {
                        label1.Visible = false;
                    }
                    con.Close();
                }
            }
        }

        private void reglast_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true; 
        }

        private void regfirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true; 
        }

        private void regmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true; 
        }
    }
}
