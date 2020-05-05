using System;
using System.Windows.Forms;

namespace HotelReservationSystem
{
    public partial class SplashScreen : Form
    {
        int random = 0;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            random = ran.Next(10,13);
            if (progressBar1.Value <= 85)
            {
                progressBar1.Value += random;
                int ad;
                ad = int.Parse(label2.Text);
                int pr = ad + random;
                label2.Text = pr.ToString();
            }

            if(progressBar1.Value >=85)
            {
                timer1.Interval = 200;
                progressBar1.Value += 1;
                label2.Text = progressBar1.Value.ToString();
            }

            if(progressBar1.Value == 101)
            {
                timer1.Enabled = false;
                this.Hide();
                login f = new login();
                f.Show();
            }
        }
    }
}
