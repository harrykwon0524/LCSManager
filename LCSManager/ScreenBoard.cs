using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace LCSManager
{
    public partial class ScreenBoard : Form
    {
        private string txt;
        private string elsetxt;
        private string cond;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public string PassStatus
        {
            get { return this.txt; }
            set { this.txt = value; }
        }

        public string ElseStatus
        {
            get { return this.elsetxt; }
            set { this.elsetxt = value; }
        }
        public ScreenBoard()
        {
            InitializeComponent();

        }

        private void ScreenBoard_Load(object sender, EventArgs e)
        {
            ShowScreenBoard(PassStatus);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowScreenBoard(string pass)
        {

            switch (pass)
            {
                case "정상 운행중":
                    NormalRadio.Checked = true;
                    break;
                case "안개 주의":
                    FogRadio.Checked = true;
                    break;
                case "공사중":
                    ConstructionRadio.Checked = true;
                    break;
                case "속도 제한중":
                    SlowDownRadio.Checked = true;
                    break;
                case "기타":
                    ElseButton.Checked = true;
                    break;
            }

        }



        private void CheckWhat()
        {

            if (ElseButton.Checked == false && ElseBox.Text != "")
            {
                ElseBox.Clear();
                MessageBox.Show("기타로 설정한 후 글을 작성해주세요");
            }
            else
            {
                if (NormalRadio.Checked == true)
                {
                    PassStatus = "정상 운행중";
                }
                else if (FogRadio.Checked == true)
                {
                    PassStatus = "안개 주의";
                }
                else if (SlowDownRadio.Checked == true)
                {
                    PassStatus = "속도 제한중";
                }
                else if (ConstructionRadio.Checked == true)
                {
                    PassStatus = "공사중";
                }
                else if (ElseButton.Checked == true)
                {
                    PassStatus = "기타";
                    elsetxt = ElseBox.Text;
                }
                this.Hide();
            }



        }

        private void SetScreen_Click(object sender, EventArgs e)
        {
            CheckWhat();
            
        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        
    }
}
