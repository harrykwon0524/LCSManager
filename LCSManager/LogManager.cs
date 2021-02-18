using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LCSManager
{


    public partial class LogManager : Form
    {
        private string log;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public string PassLog
        {
            get { return this.log; }
            set { this.log = value; }
        }

        public LogManager(String data)
        {

            InitializeComponent();
            Dislog(data);
        }



        public void Dislog(String str)
        {
            String currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string data = currentTime + " >> " + str + "\r\n";

            if (File.Exists("C:/Users/user/source/repos/LCSManager/LCSManager/sys_log.txt") == false) File.Create("C:/Users/user/source/repos/LCSManager/LCSManager/sys_log.txt");
            File.AppendAllText("C:/Users/user/source/repos/LCSManager/LCSManager/sys_log.txt", data + "\n");

            if (tbLog.InvokeRequired)
            {
                tbLog.BeginInvoke(new Action(() => tbLog.AppendText(data)));
            }
            else
            {
                tbLog.AppendText(data);
            }
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LogManager_Load(object sender, EventArgs e)
        {

        }
    }
}

