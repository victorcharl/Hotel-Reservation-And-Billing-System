using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace HotelReservationSystem
{
    public partial class login : Form
    {   
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbConnection database = new OleDbConnection(DatabaseLocation.dbLocation);
            OleDbCommand login = new OleDbCommand("SELECT * FROM tblAdmin WHERE admin_username = '"+txtUsername.Text+"' AND admin_password = '"+txtPassword.Text+"';",database);
            OleDbDataReader reader;
            database.Open();
            reader = login.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count += 1;
            }
            if (count >= 1)
            {
                MessageBox.Show("Login Successful");
                Class1.Username = txtUsername.Text;
                this.Close();
                new mainpage().Show();
            }

            else
            {
                MessageBox.Show("Unregistered user!!");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void lblreg_Click(object sender, EventArgs e)
        {
            new registerAdmin().ShowDialog();
        }
    }
}