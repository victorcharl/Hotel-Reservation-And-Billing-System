using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HotelReservationSystem
{
    public partial class addingNewGuest : Form
    {
        string gender;

        public addingNewGuest()
        {
            InitializeComponent();
        }

        private void rdbmale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void rdbfemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void addingNewGuest_Load(object sender, EventArgs e)
        {
            string strSql = "SELECT count(guest_ID) FROM tblGuestInfo";
            OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            int count = (int)cmd.ExecuteScalar() + 1; 
            label13.Text += count ;
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtlastName.Text) || string.IsNullOrWhiteSpace(txtfirstName.Text) ||
                string.IsNullOrWhiteSpace(txtmi.Text) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(txtNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtcity.Text) ||
                string.IsNullOrWhiteSpace(txtProvince.Text) || string.IsNullOrWhiteSpace(txtNationality.Text) ||
                string.IsNullOrWhiteSpace(txtType.Text) || string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                label16.Visible = true;
            }

            else
            {
                try
                {
                    OleDbConnection con = new OleDbConnection(DatabaseLocation.dbLocation);
                    con.Open();
                    OleDbCommand addGuest = new OleDbCommand("INSERT INTO tblGuestInfo(guest_ID, guest_lastname, guest_firstname, guest_mi, guest_gender, guest_contactno, guest_email, guest_city, guest_province, guest_nationality, guest_presentIDType, guest_IDNumber) VALUES(@gid, @lname, @fname, @mname, @gender, @contact, @email, @cm, @prov, @nat, @typ, @idnu)", con);

                    addGuest.Parameters.Add("@gid", OleDbType.VarWChar, 99).Value = label13.Text;
                    addGuest.Parameters.Add("@lname", OleDbType.VarWChar, 99).Value = txtlastName.Text;
                    addGuest.Parameters.Add("@fname", OleDbType.VarWChar, 99).Value = txtfirstName.Text;
                    addGuest.Parameters.Add("@mname", OleDbType.VarWChar, 99).Value = txtmi.Text;
                    addGuest.Parameters.Add("@gender", OleDbType.VarWChar, 99).Value = gender;
                    addGuest.Parameters.Add("@contact", OleDbType.VarWChar, 99).Value = "+639" + txtContactNo.Text;
                    addGuest.Parameters.Add("@email", OleDbType.VarWChar, 99).Value = txtEmail.Text;
                    addGuest.Parameters.Add("@cm", OleDbType.VarWChar, 99).Value = txtcity.Text;
                    addGuest.Parameters.Add("@prov", OleDbType.VarWChar, 99).Value = txtProvince.Text;
                    addGuest.Parameters.Add("@nat", OleDbType.VarWChar, 99).Value = txtNationality.Text;
                    addGuest.Parameters.Add("@typ", OleDbType.VarWChar, 99).Value = txtType.Text;
                    addGuest.Parameters.Add("@idnu", OleDbType.VarWChar, 99).Value = txtNumber.Text;
                    addGuest.ExecuteNonQuery();
                    MessageBox.Show("Guest Added");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtlastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true; 
        }

        private void txtfirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true;
        }

        private void txtmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8  ? false : true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true;
        }

        private void txtcity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true;
        }

        private void txtProvince_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 ? false : true;
        }
    }
}
