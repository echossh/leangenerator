// Source Code Made By: Cloudyy#1337 2023-2024 / All Rights Reserved\

// You Don't have the Rights to tell that this Program is Yours
// You Have to Add Cloudyy#1337 as a Developer in your Server/Project for Lifetime
// If you Remove this Lines from your Code, the Developer will Delete your KeyAuth Applications
// If we Learn in anyway that you Claim that this Code is Yours, we'll delete your KeyAuty Application and Stop your Small Updates

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyAuth
{
    public partial class Main : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
 (
     int nLeftRect,     // x-coordinate of upper-left corner
     int nTopRect,      // y-coordinate of upper-left corner
     int nRightRect,    // x-coordinate of lower-right corner
     int nBottomRect,   // y-coordinate of lower-right corner
     int nWidthEllipse, // width of ellipse
     int nHeightEllipse // height of ellipse
 );

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        string chatchannel = ""; // chat channel name

        private void Main_Load(object sender, EventArgs e)
        {
            Login.KeyAuthApp.check();
            key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
            expiry.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry));
            subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
            numUsers.Text = "Number of users: " + Login.KeyAuthApp.app_data.numUsers;
            version.Text = "Current version: " + Login.KeyAuthApp.app_data.version;
            hwid.Text = "HWID: " + Login.KeyAuthApp.user_data.hwid;
            ip.Text = "IP Address: " + Login.KeyAuthApp.user_data.ip;
            lastLogin.Text = "Last login: " + UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.lastlogin));


            var onlineUsers = Login.KeyAuthApp.fetchOnline();
            foreach (var user in onlineUsers)
            {
            }
        }

        public static bool SubExist(string name, int len)
        {
            for (var i = 0; i < len; i++)
            {
                if (Login.KeyAuthApp.user_data.subscriptions[i].subscription == name)
                {
                    return true;
                }
            }
            return false;
        }
        public string expirydaysleft()
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
            TimeSpan difference = dtDateTime - DateTime.Now;
            return Convert.ToString(difference.Days + " Days " + difference.Hours + " Hours Left");
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;
        }
    }
}