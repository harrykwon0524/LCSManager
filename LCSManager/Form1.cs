using FFmpeg.AutoGen;
using LCSManager.FFmpeg;
using OpenCvSharp;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;


namespace LCSManager
{
    public partial class Form1 : Form
    {
        
        VIDEO_INPUT_TYPE videoInputType;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private string v2 = "[comon][px0 py0] 안녕하세요[act0][comoff]";
        private char[] vvv;
        private ScreenBoard scb;
        private string firstlcs;
        private string secondlcs;
        private string thirdlcs;
        private string alllcs;
        private string stop;
        private string forward;
        private string start;
        private string connected;
        private string disconnected;
        private string camerastatus1;
        private string camerastatus2;
        private string end;
        bool imagemax1;
        bool imagemax2;
        int camera1cnt;
        int camera2cnt;
        int video1cnt;
        int video2cnt;
        int camera1record;
        int camera2record;
        VideoWriter recorder1;
        VideoWriter recorder2;
        int logcount = 0;
        int gridcnt = 0;
        int log2count = 0;
        private LogManager lgm;
        Bitmap enter = Properties.Resources.진입;
        Bitmap hold = Properties.Resources.금지;
        private bool enterhold;
        private bool enterhold2;
        private bool enterhold3;
        VideoCapture captureCam1;                       // 카메라 1관련 변수
        Mat frameCam1;
        Bitmap imageCam1;
        private Thread camera1;
        int isCamera1Running = 0;
        string lcsgo;
        string lcsgostop;
        string lcsstop;
        string lcsstopstop;
        string lcsflash;
        string lcsflashstop;
        int isCamera1Display = 0;
        int isCamera1Count = 0;
        VideoCapture captureCam2;                       // 카메라 2관련 변수
        Mat frameCam2;
        Bitmap imageCam2;
        private Thread camera2;
        int isCamera2Running = 0;
        int isCamera2Display = 0;
        int isCamera2Count = 0;
        string status;
        private CameraForm cfm;
        AVHWDeviceType hwDeviceType;
        AVHWDeviceType hwDeviceType2;

        string url;
        bool isInit;
        bool isDecodingThreadRunning1;
        bool isEncodingThreadRunning1;
        ManualResetEvent isDecodingEvent1;
        ManualResetEvent isEncodingEvent1;
        ConcurrentQueue<AVFrame> decodedFrameQueue1 = new ConcurrentQueue<AVFrame>();
        AVFrame queueFrame1;
        VideoInfo videoInfo1 = new VideoInfo();
        H264VideoStreamEncoder h264Encoder1;
        int frameNumber1 = 0;
        bool isRecordComplete1;


        string url2;
        bool isInit2;
        bool isDecodingThreadRunning2;
        bool isEncodingThreadRunning2;
        ManualResetEvent isDecodingEvent2;
        ManualResetEvent isEncodingEvent2;
        ConcurrentQueue<AVFrame> decodedFrameQueue2 = new ConcurrentQueue<AVFrame>();
        AVFrame queueFrame2;
        VideoInfo videoInfo2 = new VideoInfo(); 
        int frameNumber2 = 0;
        H264VideoStreamEncoder h264Encoder2;
        bool isRecordComplete2;

        public delegate void VideoFrameReceivedHandler(BitmapImage bitmapImage);
        public event VideoFrameReceivedHandler VideoFrameReceiving1;
        public delegate void VideoFrameReceivedHandler2(BitmapImage bitmapImage);
        public event VideoFrameReceivedHandler2 VideoFrameReceiving2;
        //Dispatcher dispatcher = Application.Current.Dispatcher;
        public enum VTYPE
        {
            RTSP_RTP = 0,
            CAM
        }



        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            this.scb = new ScreenBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image screenboard = ScreenBoradImage.Image;
            status = "정상 운행중";
            end = "프로그램을 종료합니다.";
            start = "프로그램을 시작합니다.";
            connected = "연결이 되었습니다.";
            disconnected = "연결이 끊겼습니다.";
            camerastatus1 = "전방 카메라 ";
            camerastatus2 = "후방 카메라 ";
            firstlcs = "1차로 ";
            secondlcs = "2차로 ";
            thirdlcs = "3차로 ";
            alllcs = "전차로 ";
            stop = "진입금지";
            forward = "진입가능";
            this.lgm = new LogManager(start);
            enterhold = true;
            enterhold2 = true;
            enterhold3 = true;
            camera1cnt = 0;
            camera2cnt = 0;
            video1cnt = 0;
            video2cnt = 0;
            gridcnt = 0;
            imagemax1 = false;
            imagemax2 = false;
            camera1record = 0;
            camera2record = 0;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 13, FontStyle.Bold);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Courier New", 13);
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.DarkBlue;

            lcsgo = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=0&on=1&time=0&pwd=0&";
            lcsgostop = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=0&on=0&time=0&pwd=0&";
            
            lcsstop = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=1&on=1&time=0&pwd=0&";
            lcsstopstop = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=1&on=0&time=0&pwd=0&";

            lcsflash = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=2&on=1&time=0&pwd=0&";
            lcsflashstop = "http://192.168.10.105/relay_cgi.cgi?type=0&relay=2&on=0&time=0&pwd=0&";

            //SendLcsData(lcsgo);
            PlayCamera1();
            PlayCamera2();
            hwDeviceType = AVHWDeviceType.AV_HWDEVICE_TYPE_NONE;
            hwDeviceType2 = AVHWDeviceType.AV_HWDEVICE_TYPE_NONE;    //temp

            FFmpegBinariesHelper.RegisterFFmpegBinaries();

            //ConfigureHWDecoder(out hwDeviceType);

            isInit = false;
            isInit2 = false;

        }



        public void InitializeFFmpeg(string _url, VIDEO_INPUT_TYPE _inputType)
        {
            url = _url;
            videoInputType = _inputType;
            isInit = true;
        }

        public void InitializeFFmpeg2(string _url, VIDEO_INPUT_TYPE _inputType)
        {
            url2 = _url;
            videoInputType = _inputType;
            isInit2 = true;
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            return new Bitmap(bitmapImage.StreamSource);
        }
        private void PlayCamera1()
        {
            isCamera1Count = 0;
            InitializeFFmpeg("rtsp://192.168.10.102:554/video1", VIDEO_INPUT_TYPE.RTP_RTSP);
            PlayVideo1();
            VideoFrameReceiving1 += VideoFrameReceived;
        }

        private void PlayCamera2()
        {
            isCamera2Count = 0;
            InitializeFFmpeg2("rtsp://192.168.10.101:554/video1", VIDEO_INPUT_TYPE.RTP_RTSP);
            PlayVideo2();
            VideoFrameReceiving2 += VideoFrameReceived2;
        }
        private void VideoFrameReceived(BitmapImage frame)
        {
            logcount++;

            if (logcount == 1)
            {
                string condition = camerastatus1 + connected;
                lgm.PassLog = condition;
                lgm.Dislog(condition);

            }
            //if (camera1record == 0)
            //{

            //    string fileName = camerastatus1 + DateTime.Now.ToString("yyMMdd_hh.mm.ss") + ".mp4";
            //    RecordVideo(fileName);
            //}
            try
            {
                isCamera1Running = 1;
                camera1record++;
                if (FrontCamera.InvokeRequired)                                           // 쓰레드에서 Image  업데이트 시
                {
                    FrontCamera.Invoke(new MethodInvoker(
                    delegate ()
                    {

                        FrontCamera.Image = BitmapImage2Bitmap(frame);

                        //NoticeText(logcount, log2count);
                    }));
                }
                else
                {
                    FrontCamera.Image = BitmapImage2Bitmap(frame);
                    //NoticeText(logcount, log2count);
                }
                //if (camera1record == 1670)
                //{
                //    camera1cnt++;
                //    string condition = camerastatus1 + camera2cnt + "번째 저장";
                //    lgm.PassLog = condition;
                //    lgm.Dislog(condition);
                //    StopRecord();
                //    camera1record = 0;
                //}
                isCamera1Display = 1;
                isCamera1Count = 0;

            }
            catch (Exception e)
            {
                DisposeFFmpeg();

            }

        }
        private void VideoFrameReceived2(BitmapImage frame)
        {
            log2count++;
            
            if(log2count == 1)
            {
                string condition = camerastatus2 + connected;
                lgm.PassLog = condition;
                lgm.Dislog(condition);
                
            }
            //if(camera2record == 0)
            //{
               
            //    string fileName = camerastatus2 + DateTime.Now.ToString("yyMMdd_hh.mm.ss") + ".mp4";
            //    RecordVideo2(fileName);
            //}
            try
            {
                isCamera2Running = 1;
                camera2record++;
                if (BackCamera.InvokeRequired)                                           // 쓰레드에서 Image  업데이트 시
                {
                    BackCamera.Invoke(new MethodInvoker(
                    delegate ()
                    {

                        BackCamera.Image = BitmapImage2Bitmap(frame);

                        //NoticeText(logcount, log2count);
                    }));
                }
                else
                {
                    BackCamera.Image = BitmapImage2Bitmap(frame);
                    //NoticeText(logcount, log2count);
                }
                //if (camera2record == 1670)
                //{
                //    camera2cnt++;
                //    string condition = camerastatus2 + camera2cnt + "번째 저장";
                //    lgm.PassLog = condition;
                //    lgm.Dislog(condition);
                //    StopRecord2();
                //    camera2record = 0;
                //}
                    isCamera2Display = 1;
                isCamera2Count = 0;
                
            }
            catch (Exception e)
            {
                DisposeFFmpeg2();

            }
            
        }

        public void PlayVideo1()
        {
            if (isInit == false)
            {
                Console.WriteLine("FFmpeg 초기화 필요");
                return;
            }

            isDecodingEvent1 = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DecodeAllFramesToImages));

            isDecodingEvent1.Set();
            isDecodingThreadRunning1 = true;

        }
        public void PlayVideo2()
        {
            if (isInit2 == false)
            {
                Console.WriteLine("FFmpeg 초기화 필요");
                return;
            }
            
            isDecodingEvent2 = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DecodeAllFramesToImages2));

            isDecodingEvent2.Set();
            isDecodingThreadRunning2 = true;

        }
        private void panel2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                //lgm.PassLog = end;
                //lgm.Dislog(lgm.PassLog);
                //RecordTimer.Enabled = false;
                //if (frameCam1 != null && recorder1 != null)
                //{
                //    lgm.PassLog = camerastatus1 + (video1cnt + 1) + "번째 영상 저장";
                //    lgm.Dislog(lgm.PassLog);
                //    recorder1.Release();
                //    camera1.Interrupt();
                //}
                //else if (frameCam2 != null && recorder2 != null)
                //{
                //    lgm.PassLog = camerastatus2 + (video2cnt + 1) + "번째 영상 저장";
                //    lgm.Dislog(lgm.PassLog);
                ////recorder2.Release();
                //camera1.Interrupt();
                //camera2.Interrupt();

                //if(recorder2 != null)
                //{
                //    recorder2.Release();
                //}


                //}
                //recorder2.Release();
                //captureCam2.Release();
                //Cv2.DestroyAllWindows();
                
                //SendLcsData(lcsstop);
                
                DisposeFFmpeg();
                DisposeFFmpeg2();
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lgm.ShowDialog();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lbCurTime.Text = GetTime();
        }

        private String GetTime()
        {
            String regDt = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime parsedDate = DateTime.Parse(regDt);
            DateTime parsedTime = DateTime.Parse(regDt);
            String TIME = parsedDate.ToString("yyyy/MM/dd HH:mm:ss");

            return TIME;
        }

        private void label11_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lbCurTime_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void firstLCS_Click(object sender, EventArgs e)
        {
            FirstLCSStatus();

        }

        private void SecondLCS_Click(object sender, EventArgs e)
        {
            SecondLCSStatus();
        }

        private void ThirdLCS_Click(object sender, EventArgs e)
        {
            ThirdLCSStatus();
        }

        private void firstLCS_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.lcsfirst.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void SecondLCS_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.lcssecond.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void ThirdLCS_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.lcsthird.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void NoticeText(int display1, int display2)
        {
            richTextBox1.Text = "";
            if (display1 == 0)
            {
                richTextBox1.Text += camerastatus1 + disconnected;
                CameraButton.Image = Properties.Resources.pngwing_com__3_;
                
            }
            if (display1 == 1)
            {
                richTextBox1.Text = camerastatus1 + connected;
                CameraButton.Image = Properties.Resources.device1;
            }
            if (display2 == 0)
            {
                richTextBox1.Text += camerastatus2 + disconnected;
                Camera2Button.Image = Properties.Resources.pngwing_com__3_;
                
            }
            if (display2 == 1)
            {
                richTextBox1.Text += camerastatus2 + connected;
                Camera2Button.Image = Properties.Resources.device1;
            }
            
            
        }

        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            isCamera1Count++;
            if ((isCamera1Running == 0 || isCamera1Running == 1) && isCamera1Count == 3)
            {
                CameraErrorMessage(camerastatus1);
                isCamera1Display = 0;
                FrontCamera.Image = Properties.Resources.대기6;
                CameraButton.Image = Properties.Resources.pngwing_com__3_;
                isCamera1Running = 0;
                logcount = 0;
            }
            //isCamera1Count++;
            //if (isCamera1Running == 0 && isCamera1Count == 5)
            //{
            //    CameraErrorMessage(camerastatus1);
            //}
            //else if (isCamera1Running == 1 && isCamera1Count >= 10)                   // 카메라 1 영상 재생 안될경우 초기화
            //{
            //    logcount++;
            //    if (logcount == 1)
            //    {
            //        CameraErrorMessage(camerastatus1);
            //    }
            //    FrontCamera.Image = Properties.Resources.대기6;

            //    CameraButton.Image = Properties.Resources.pngwing_com__3_;

            //    camera1.Abort();
            //    Thread.Sleep(100);
            //    CaptureCamera1();
            //    isCamera1Count = 0;
            //    logcount = 0;
            //}

            isCamera2Count++;
            if ((isCamera2Running == 0 || isCamera2Running == 1) && isCamera2Count == 3)
            {
                CameraErrorMessage(camerastatus2); 
                isCamera2Display = 0;
                BackCamera.Image = Properties.Resources.대기6;
                Camera2Button.Image = Properties.Resources.pngwing_com__3_;
                isCamera2Running = 0;
                log2count = 0;
            }
            NoticeText(isCamera1Display, isCamera2Display);
        }

        private void ScreenBorad_Click(object sender, EventArgs e)
        {
            ScreenBoardStatus();
        }


        private void CameraErrorMessage(string camera)
        {
            string condition = camera + disconnected;
            lgm.PassLog = condition;
            lgm.Dislog(lgm.PassLog);
            gridcnt++;
            dataGridView1.Font = new Font("Fixsys", 12);
            String time = GetTime();
            dataGridView1.Rows.Add(gridcnt, camera, lgm.PassLog, time);
        }


        private void FrontCamera_DoubleClick(object sender, EventArgs e)
        {
            this.cfm = new CameraForm(url);

            cfm.ShowDialog();
            //if (imagemax1 == false)
            //{
            //    FrontCamera.Location = new System.Drawing.Point(-200, 260);
            //    FrontCamera.Size = new System.Drawing.Size(500, 400);
            //    imagemax1 = true;
            //}
            //else
            //{
            //    FrontCamera.Location = new System.Drawing.Point(30, 53);
            //    FrontCamera.Size = new System.Drawing.Size(309, 246);
            //    imagemax1 = false;
            //}
        }
        private void BackCamera_DoubleClick(object sender, EventArgs e)
        {
            //camera2.Interrupt();
            //captureCam2.Release();
            //frameCam2.Release();

            this.cfm = new CameraForm(url2);

            cfm.ShowDialog();
            //if(imagemax2 == false)
            //{
            //    BackCamera.Location = new System.Drawing.Point(BackCamera.Location.X - 50, BackCamera.Location.Y - 80);
            //    BackCamera.Size = new System.Drawing.Size(BackCamera.Size.Width + 50, BackCamera.Size.Height + 80);
            //    imagemax2 = true;
            //}
            //else
            //{
            //    BackCamera.Location = new System.Drawing.Point(30, 311);
            //    BackCamera.Size = new System.Drawing.Size(309, 271);
            //    imagemax2 = false;
            //}

        }

        private void FirstLCSButton_Click(object sender, EventArgs e)
        {
            FirstLCSStatus();
        }

        private void SecondLCSButton_Click(object sender, EventArgs e)
        {
            SecondLCSStatus();
        }

        private void ThirdLCSButton_Click(object sender, EventArgs e)
        {
            ThirdLCSStatus();
        }

        private void ScreenBoardButton_Click(object sender, EventArgs e)
        {
            ScreenBoardStatus();
        }

        private void FirstLCSStatus()
        {
            this.lcsfirst.Cursor = System.Windows.Forms.Cursors.Hand;
            if (enterhold == true)
            {
                if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로1 상태변경",
                                                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lcsfirst.Image = Properties.Resources.금지;
                    MessageBox.Show("진입금지로 변경되었습니다.");
                    enterhold = false;
                    lgm.PassLog = firstlcs + stop;
                    lgm.Dislog(lgm.PassLog);
                    status = "차단중";
                    ScreenBoardLabel.Text = firstlcs;

                    if (enterhold2 == true && enterhold3 == false)
                    {
                        ScreenBoardLabel.Text += thirdlcs;
                    }
                    else if (enterhold2 == false && enterhold3 == true)
                    {
                        ScreenBoardLabel.Text += secondlcs;
                    }
                    else if(enterhold2 == false && enterhold3 == false)
                    {
                        ScreenBoardLabel.Text = alllcs;
                    }
                    ScreenBoardLabel.Text += stop;

                }
               
            }

            else if (enterhold == false)
            {
                if (status == "공사중")
                {
                    MessageBox.Show("공사중이여서 차로 상태 변경 불가합니다.");

                }
                else
                {
                    if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로1 상태변경",
                                                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lcsfirst.Image = Properties.Resources.진입;
                        MessageBox.Show("진입가능으로 변경되었습니다.");
                        enterhold = true;
                        lgm.PassLog = firstlcs + forward;
                        lgm.Dislog(lgm.PassLog); 
                        status = "정상 운행중";
                        ScreenBoardLabel.Text = firstlcs + forward;

                        if (enterhold2 == true && enterhold3 == false)
                        {
                            ScreenBoardLabel.Text = thirdlcs + stop;
                        }
                        else if (enterhold2 == false && enterhold3 == true)
                        {
                            ScreenBoardLabel.Text = secondlcs + stop;
                        }
                        else if (enterhold2 == false && enterhold3 == false)
                        {
                            ScreenBoardLabel.Text = secondlcs + thirdlcs + stop;
                        }
                        else
                        {
                            ScreenBoardLabel.Text = "정상 운행중";
                        }
                    }
                }
                

            }



        }

        private void SecondLCSStatus()
        {
            this.lcssecond.Cursor = System.Windows.Forms.Cursors.Hand;
            if (enterhold2 == true)
            {
                if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로2 상태변경",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lcssecond.Image = Properties.Resources.금지;
                    MessageBox.Show("진입금지로 변경되었습니다.");
                    enterhold2 = false;
                    lgm.PassLog = secondlcs + stop;
                    lgm.Dislog(lgm.PassLog);
                    status = "차단중";
                    if(enterhold == false && enterhold3 == true)
                    {
                        ScreenBoardLabel.Text = firstlcs + secondlcs;
                    }
                    else
                    {
                        ScreenBoardLabel.Text = secondlcs;
                    }
                    

                    if (enterhold == true && enterhold3 == false)
                    {
                        ScreenBoardLabel.Text += thirdlcs;
                    }
                    else if (enterhold == false && enterhold3 == false)
                    {
                        ScreenBoardLabel.Text = alllcs;
                    }
                    ScreenBoardLabel.Text += stop;
                }
            }
            else if (enterhold2 == false)
            {
                if (status == "공사중")
                {
                    MessageBox.Show("공사중이여서 차로 상태 변경 불가합니다.");

                }
                else
                {
                    if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로2 상태변경",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lcssecond.Image = Properties.Resources.진입;
                        MessageBox.Show("진입가능으로 변경되었습니다.");
                        enterhold2 = true;
                        lgm.PassLog = secondlcs + forward;
                        lgm.Dislog(lgm.PassLog);
                        status = "정상 운행중";
                        ScreenBoardLabel.Text = secondlcs + forward;

                        if (enterhold == true && enterhold3 == false)
                        {
                            ScreenBoardLabel.Text = thirdlcs + stop;
                        }
                        else if (enterhold == false && enterhold3 == true)
                        {
                            ScreenBoardLabel.Text = firstlcs + stop;
                        }
                        else if (enterhold == false && enterhold3 == false)
                        {
                            ScreenBoardLabel.Text = firstlcs + thirdlcs + stop;
                        }
                        else
                        {
                            ScreenBoardLabel.Text = "정상 운행중";
                        }
                    }
                }

            }

        }

        private void ThirdLCSStatus()
        {
            this.lcsthird.Cursor = System.Windows.Forms.Cursors.Hand;
            if (enterhold3 == true)
            {
                if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로3 상태변경",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lcsthird.Image = Properties.Resources.금지;
                    MessageBox.Show("진입금지로 변경되었습니다.");
                    enterhold3 = false;
                    lgm.PassLog = thirdlcs + stop;
                    lgm.Dislog(lgm.PassLog);
                    status = "차단중";
                    if (enterhold == false && enterhold2 == true)
                    {
                        ScreenBoardLabel.Text = firstlcs + thirdlcs;
                    }
                    else if (enterhold == true && enterhold2 == false)
                    {
                        ScreenBoardLabel.Text = secondlcs + thirdlcs;
                    }
                    else
                    {
                        ScreenBoardLabel.Text = thirdlcs;
                    }
                       
                    
                    if (enterhold == false && enterhold2 == false)
                    {
                        ScreenBoardLabel.Text = alllcs;
                    }
                    ScreenBoardLabel.Text += stop;
                }
            }
            else if (enterhold3 == false)
            {
                if (status == "공사중")
                {
                    MessageBox.Show("공사중이여서 차로 상태 변경 불가합니다.");

                }
                else
                {
                    if (MessageBox.Show("모드를 바꾸시겠습니까?", "차로3 상태변경",
                               MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lcsthird.Image = Properties.Resources.진입;
                        MessageBox.Show("진입가능으로 변경되었습니다.");
                        enterhold3 = true;
                        lgm.PassLog = thirdlcs + forward;
                        lgm.Dislog(lgm.PassLog);
                        status = "정상 운행중";
                        ScreenBoardLabel.Text = thirdlcs + forward;

                        if (enterhold == true && enterhold2 == false)
                        {
                            ScreenBoardLabel.Text = secondlcs + stop;
                        }
                        else if (enterhold == false && enterhold2 == true)
                        {
                            ScreenBoardLabel.Text = firstlcs + stop;
                        }
                        else if (enterhold == false && enterhold2 == false)
                        {
                            ScreenBoardLabel.Text = firstlcs + secondlcs + stop;
                        }
                        else
                        {
                            ScreenBoardLabel.Text = "정상 운행중";
                        }
                    }
                }

            }
        }
        private void ScreenBoardStatus()
        {
            scb.PassStatus = status;
            scb.ShowDialog();
            if (status == scb.PassStatus)
            {
            }
            else
            {
                status = scb.PassStatus;

                switch (scb.PassStatus)
                {
                    case "정상 운행중":
                        ScreenBoardLabel.Text = alllcs + "정상 운행중";
                        lcsfirst.Image = Properties.Resources.진입;
                        lcssecond.Image = Properties.Resources.진입;
                        lcsthird.Image = Properties.Resources.진입;
                        enterhold = true;
                        enterhold2 = true;
                        enterhold3 = true;
                        SendScreenBoardData("정상 운행중");
                        MessageBox.Show("차로 정상 운행합니다.");
                        break;
                    case "공사중":
                        ScreenBoardLabel.Text = alllcs + "공사중";
                        //lcsfirst.Image = Properties.Resources.금지;
                        //lcssecond.Image = Properties.Resources.금지;
                        //lcsthird.Image = Properties.Resources.금지;
                        //enterhold = false;
                        //enterhold2 = false;
                        //enterhold3 = false;
                        SendScreenBoardData("공사중");
                        MessageBox.Show("공사중 입니다.");
                        break;
                    case "속도 제한중":
                        ScreenBoardLabel.Text = "속도 60km/h 제한중";
                        //lcsfirst.Image = Properties.Resources.진입;
                        //lcssecond.Image = Properties.Resources.진입;
                        //lcsthird.Image = Properties.Resources.진입;
                        //enterhold = true;
                        //enterhold2 = true;
                        //enterhold3 = true;
                        SendScreenBoardData("속도 제한중");
                        MessageBox.Show("속도제한으로 바꿨습니다.");
                        break;
                    case "안개 주의":
                        ScreenBoardLabel.Text = "안개 주의";
                        SendScreenBoardData("안개 주의");
                        MessageBox.Show("안개 주의");
                        break;
                    case "기타":
                        ScreenBoardLabel.Text = scb.ElseStatus;
                        scb.PassStatus = scb.PassStatus + "(" + ScreenBoardLabel.Text + ")";
                        SendScreenBoardData(ScreenBoardLabel.Text);
                        MessageBox.Show(ScreenBoardLabel.Text);
                        break;
                }
                lgm.PassLog = scb.PassStatus;
                lgm.Dislog(lgm.PassLog);
            }
        }
        private void SendLcsData(string url)
        {

            string posturl = url;
            string responsetext = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(posturl);

                request.Method = "GET";
                request.Timeout = 30 * 1000;
                request.Headers.Add("Authorization", "BASIC SGVsbG8=");
                    using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                    {
                        HttpStatusCode status = resp.StatusCode;

                        Stream respStream = resp.GetResponseStream();
                        using (StreamReader sr = new StreamReader(respStream))
                        {
                            responsetext = sr.ReadToEnd();

                        }
                    }
                    MessageBox.Show("LCS 문제");
                    Console.WriteLine(responsetext);
               
                
            }

            catch (WebException we)
            {
                var resp = we.Response as HttpWebResponse;
                //if (resp == null)
                //    throw;
                //Console.WriteLine(resp);
                
            }
        }

        public void RecordVideo(string fileName)
        {
            //isInit = true;
            //if (isInit == false)
            //{
            //    Console.WriteLine("FFmpeg 초기화 필요");
            //    return;
            //}

            isEncodingEvent1 = new ManualResetEvent(false);

            h264Encoder1 = new H264VideoStreamEncoder();

            //initialize output format&codec
            h264Encoder1.OpenOutputURL(fileName, videoInfo1);

            ThreadPool.QueueUserWorkItem(new WaitCallback(EncodeImagesToH264));

            isEncodingEvent1.Set();

            isEncodingThreadRunning1 = true;
            isRecordComplete1 = false;


        }

        public void RecordVideo2(string fileName)
        {
            //isInit = true;
            //if (isInit == false)
            //{
            //    Console.WriteLine("FFmpeg 초기화 필요");
            //    return;
            //}

            isEncodingEvent2 = new ManualResetEvent(false);

            h264Encoder2 = new H264VideoStreamEncoder();

            //initialize output format&codec
            h264Encoder2.OpenOutputURL(fileName, videoInfo2);

            ThreadPool.QueueUserWorkItem(new WaitCallback(EncodeImagesToH2642));

            isEncodingEvent2.Set();

            isEncodingThreadRunning2 = true;
            isRecordComplete2 = false;


        }
        public int StopRecord()
        {
            try
            {
                isEncodingThreadRunning1 = false;
                isEncodingEvent1.Reset();

                h264Encoder1.FlushEncode();
                h264Encoder1.Dispose();

                frameNumber1 = 0;

                isRecordComplete1 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }

            return 0;
        }

        public int StopRecord2()
        {
            try
            {
                isEncodingThreadRunning2 = false;
                isEncodingEvent2.Reset();

                h264Encoder2.FlushEncode();
                h264Encoder2.Dispose();

                frameNumber2 = 0;

                isRecordComplete2 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }

            return 0;
        }

        private unsafe void EncodeImagesToH264(object state)
        {
            try
            {
                while (isEncodingEvent1.WaitOne())
                {
                    if (decodedFrameQueue1.TryDequeue(out queueFrame1))
                    {
                        var sourcePixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
                        var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_YUV420P; //for h.264

                        using (var vfc = new VideoFrameConverter(videoInfo1.SourceFrameSize, sourcePixelFormat, videoInfo1.DestinationFrameSize, destinationPixelFormat))
                        {
                            var convertedFrame = vfc.Convert(queueFrame1);
                            convertedFrame.pts = frameNumber1;       //to do
                            h264Encoder1.TryEncodeNextPacket(convertedFrame);
                        }

                        frameNumber1++;
                    }
                }
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private unsafe void EncodeImagesToH2642(object state)
        {
            try
            {
                while (isEncodingEvent2.WaitOne())
                {
                    if (decodedFrameQueue2.TryDequeue(out queueFrame2))
                    {
                        var sourcePixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
                        var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_YUV420P; //for h.264

                        using (var vfc = new VideoFrameConverter(videoInfo2.SourceFrameSize, sourcePixelFormat, videoInfo2.DestinationFrameSize, destinationPixelFormat))
                        {
                            var convertedFrame = vfc.Convert(queueFrame2);
                            convertedFrame.pts = frameNumber2;       //to do
                            h264Encoder2.TryEncodeNextPacket(convertedFrame);
                        }

                        frameNumber2++;
                    }
                }
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisposeFFmpeg()
        {
            if (isDecodingThreadRunning1)
            {
                isDecodingThreadRunning1 = false;

                isDecodingEvent1.Reset();
                isDecodingEvent1.Dispose();
            }

            if (isEncodingThreadRunning1)
            {
                isEncodingThreadRunning1 = false;

                isEncodingEvent1.Reset();
                isEncodingEvent1.Dispose();

                if (isRecordComplete1 == false)
                {
                    h264Encoder1.FlushEncode();
                    h264Encoder1.Dispose();
                }
            }
        }

        public void DisposeFFmpeg2()
        {
            if (isDecodingThreadRunning2)
            {
                isDecodingThreadRunning2 = false;

                isDecodingEvent2.Reset();
                isDecodingEvent2.Dispose();
            }

            if (isEncodingThreadRunning2)
            {
                isEncodingThreadRunning2 = false;

                isEncodingEvent2.Reset();
                isEncodingEvent2.Dispose();

                if (isRecordComplete2 == false)
                {
                    h264Encoder2.FlushEncode();
                    h264Encoder2.Dispose();
                }
            }
        }

        private unsafe void DecodeAllFramesToImages(object state)
        {
            try
            {
                using (var decoder = new VideoStreamDecoder(url, videoInputType))
                {
                    videoInfo1 = decoder.GetVideoInfo();

                    var info = decoder.GetContextInfo();
                    info.ToList().ForEach(x => Console.WriteLine($"{x.Key} = {x.Value}"));

                    var sourceSize = decoder.FrameSize;
                    var sourcePixelFormat = hwDeviceType == AVHWDeviceType.AV_HWDEVICE_TYPE_NONE ? decoder.PixelFormat : GetHWPixelFormat(hwDeviceType);
                    var destinationSize = sourceSize;
                    var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;

                    using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                    {
                        while (decoder.TryDecodeNextFrame(out var frame) && isDecodingEvent1.WaitOne())
                        {
                            var convertedFrame = vfc.Convert(frame);

                            Bitmap bt = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]);

                            if (isEncodingThreadRunning1)
                            {
                                decodedFrameQueue1.Enqueue(convertedFrame);
                            }
                            BitmapToImageSource(bt);
                        }
                    }
                    
                }
                
               
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private unsafe void DecodeAllFramesToImages2(object state)
        {
            try
            {
                using (var decoder = new VideoStreamDecoder(url2, videoInputType))
                {
                    videoInfo2 = decoder.GetVideoInfo();

                    var info = decoder.GetContextInfo();
                    info.ToList().ForEach(x => Console.WriteLine($"{x.Key} = {x.Value}"));

                    var sourceSize = decoder.FrameSize;
                    var sourcePixelFormat = hwDeviceType2 == AVHWDeviceType.AV_HWDEVICE_TYPE_NONE ? decoder.PixelFormat : GetHWPixelFormat(hwDeviceType2);
                    var destinationSize = sourceSize;
                    var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;

                    using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                    {
                        while (decoder.TryDecodeNextFrame(out var frame) && isDecodingEvent2.WaitOne())
                        {
                            var convertedFrame = vfc.Convert(frame);

                            Bitmap bt = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]);

                            if (isEncodingThreadRunning2)
                            {
                                decodedFrameQueue2.Enqueue(convertedFrame);
                            }
                            BitmapToImageSource2(bt);
                        }
                    }

                }


            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private AVPixelFormat GetHWPixelFormat(AVHWDeviceType hWDevice)
        {
            switch (hWDevice)
            {
                case AVHWDeviceType.AV_HWDEVICE_TYPE_NONE:
                    return AVPixelFormat.AV_PIX_FMT_NONE;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_VDPAU:
                    return AVPixelFormat.AV_PIX_FMT_VDPAU;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_CUDA:
                    return AVPixelFormat.AV_PIX_FMT_CUDA;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_VAAPI:
                    return AVPixelFormat.AV_PIX_FMT_VAAPI;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_DXVA2:
                    return AVPixelFormat.AV_PIX_FMT_NV12;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_QSV:
                    return AVPixelFormat.AV_PIX_FMT_QSV;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_VIDEOTOOLBOX:
                    return AVPixelFormat.AV_PIX_FMT_VIDEOTOOLBOX;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_D3D11VA:
                    return AVPixelFormat.AV_PIX_FMT_NV12;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_DRM:
                    return AVPixelFormat.AV_PIX_FMT_DRM_PRIME;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_OPENCL:
                    return AVPixelFormat.AV_PIX_FMT_OPENCL;
                case AVHWDeviceType.AV_HWDEVICE_TYPE_MEDIACODEC:
                    return AVPixelFormat.AV_PIX_FMT_MEDIACODEC;
                default:
                    return AVPixelFormat.AV_PIX_FMT_NONE;
            }
        }
        private void BitmapToImageSource(Bitmap bitmap)
        {
            if (isDecodingThreadRunning1)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.StreamSource = memory;
                    bitmapimage.EndInit();
                    bitmapimage.Freeze();

                    VideoFrameReceived(bitmapimage);

                    memory.Dispose();
                }
            }
            
        }

        private void BitmapToImageSource2(Bitmap bitmap)
        {
            if (isDecodingThreadRunning2)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.StreamSource = memory;
                    bitmapimage.EndInit();
                    bitmapimage.Freeze();

                    VideoFrameReceived2(bitmapimage);

                    memory.Dispose();
                }
            }

        }

        private void GarbageTimer_Tick(object sender, EventArgs e)
        {
            System.GC.Collect(0, GCCollectionMode.Forced);
            System.GC.WaitForFullGCComplete();
        }

        private void DrivingConnection_Click(object sender, EventArgs e)
        {

        }

        private void WebConnection_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        byte[,] dots = new byte[4, 8];
        private void SendScreenBoardData(string status)
        {
            //if (serialPort1.IsOpen)
            //{
            //    char[] result = v2.ToCharArray();
            //    serialPort1.Write(result, 0, 32);
            //}
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
