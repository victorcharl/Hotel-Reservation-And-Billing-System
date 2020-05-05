using System;
using System.Windows.Forms;

namespace HotelReservationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }

    class DatabaseLocation
    {
        public const string dbLocation = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = |DataDirectory|\HotelReservationDatabase.mdb; Persist Security Info =true; ";
    }

    class Class1
    {
        static string user;
        public static string Username
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
    }

    class reserve
    {
        static string room;
        public static string roomNum
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }
        }
    }

    class guestID1
    {
        static string guest;
        public static string guestID
        {
            get
            {
                return guest;
            }
            set
            {
                guest = value;
            }
        }
    }

    class rmPrice
    {
        static string rom;
        public static string romprice
        {
            get
            {
                return rom;
            }
            set
            {
                rom = value;
            }
        }
    }

    class trans
    {
        static string tra;
        public static string transNum
        {
            get
            {
                return tra;
            }
            set
            {
                tra = value;
            }
        }
    }
}
