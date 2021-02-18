using FFmpeg.AutoGen;
using LCSManager.FFmpeg;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OpenCvSharp;
namespace LCSManager
{
    public partial class CameraForm : Form
    {
        bool isInit;
        bool isDecodingThreadRunning;
        bool isEncodingThreadRunning;
        ManualResetEvent isDecodingEvent;
        ConcurrentQueue<AVFrame> decodedFrameQueue = new ConcurrentQueue<AVFrame>();
        VideoInfo videoInfo = new VideoInfo();
        AVHWDeviceType hwDeviceType;
        public delegate void VideoFrameReceivedHandler(BitmapImage bitmapImage);
        public event VideoFrameReceivedHandler VideoFrameReceiving;
        string url;
        VIDEO_INPUT_TYPE videoInputType;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        VideoCapture captureCam;                       // 카메라 2관련 변수
        Mat frameCam;
        Bitmap imageCam;
        private Thread camera;
        int isCameraRunning = 0;
        int isCameraDisplay = 1;
        int isCameraCount = 0;
        //public VideoCapture vc
        //{
        //    get { return captureCam; }
        //    set { captureCam = value; }
        //}
        //public  Mat mat
        //{
        //    get { return frameCam; }
        //    set { frameCam = value;}
        //}
        public CameraForm(string _url)
        {
            InitializeComponent();
            //PlayCamera2(url+"s");
            this.url = _url;
            CaptureCamera1();

        }
            private void CaptureCamera1()
            {
                camera = new Thread(new ThreadStart(CaptureCameraCallback1));
                camera.Start();
            }

            private void CaptureCameraCallback1()
            {
            captureCam = new VideoCapture();
            frameCam = new Mat();
                try
                {
                    isCameraRunning = 1;
                captureCam.Open(url + "s1");
                    while (isCameraRunning == 1)
                    {
                    captureCam.Read(frameCam);
                    captureCam.Read(frameCam);
                        if (!frameCam.Empty())
                        {

                            //FrontCamera.Image.Dispose();
                            imageCam = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frameCam);
                            if (pictureBox1.InvokeRequired)                                           // 쓰레드에서 Image  업데이트 시
                            {
                                pictureBox1.Invoke(new MethodInvoker(
                                delegate ()
                                {
                                    pictureBox1.Image = imageCam;
                                }));
                            }
                            else
                            {
                                pictureBox1.Image = imageCam;

                            }
                        isCameraDisplay = 1;
                        isCameraCount = 0;
                    }

                    }

                }

                catch (Exception e)
                {
                captureCam.Dispose();
                frameCam.Dispose();

                }





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
        public void InitializeFFmpeg(string _url, VIDEO_INPUT_TYPE _inputType)
        {
            url = _url;
            videoInputType = _inputType;

            isInit = true;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            camera.Interrupt();
            this.Hide();
        }


        private void PlayCamera2(string url)
        {
            InitializeFFmpeg(url, VIDEO_INPUT_TYPE.RTP_RTSP);
            PlayVideo2();

            VideoFrameReceiving += VideoFrameReceived;

        }
        private void VideoFrameReceived(BitmapImage frame)
        {
            if (pictureBox1.InvokeRequired)                                           // 쓰레드에서 Image  업데이트 시
            {
                pictureBox1.Invoke(new MethodInvoker(
                delegate ()
                {
                    pictureBox1.Image = BitmapImage2Bitmap(frame);
                }));
            }
            else
            {
                pictureBox1.Image = BitmapImage2Bitmap(frame);
            }

        }
        public void PlayVideo2()
        {
            if (isInit == false)
            {
                Console.WriteLine("FFmpeg 초기화 필요");
                return;
            }

            isDecodingEvent = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DecodeAllFramesToImages));

            isDecodingEvent.Set();
            //lgm.PassLog = camerastatus2 + connected;
            //lgm.Dislog(lgm.PassLog);
            isDecodingThreadRunning = true;

        }
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            return new Bitmap(bitmapImage.StreamSource);
        }
        private unsafe void DecodeAllFramesToImages(object state)
        {
            try
            {
                using (var decoder = new VideoStreamDecoder(url, videoInputType))
                {
                    videoInfo = decoder.GetVideoInfo();

                    var info = decoder.GetContextInfo();
                    info.ToList().ForEach(x => Console.WriteLine($"{x.Key} = {x.Value}"));

                    var sourceSize = decoder.FrameSize;
                    var sourcePixelFormat = hwDeviceType == AVHWDeviceType.AV_HWDEVICE_TYPE_NONE ? decoder.PixelFormat : GetHWPixelFormat(hwDeviceType);
                    var destinationSize = sourceSize;
                    var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;

                    using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                    {
                        while (decoder.TryDecodeNextFrame(out var frame) && isDecodingEvent.WaitOne())
                        {
                            var convertedFrame = vfc.Convert(frame);

                            Bitmap bt = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]);

                            if (isEncodingThreadRunning)
                            {
                                decodedFrameQueue.Enqueue(convertedFrame);
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
        private void BitmapToImageSource(Bitmap bitmap)
        {
            if (isDecodingThreadRunning)
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

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            isCameraCount++;
            if (isCameraRunning == 1 && isCameraCount >= 3)                   // 카메라 1 영상 재생 안될경우 초기화
            {
                pictureBox1.Image = Properties.Resources.대기6;
                //isCameraDisplay = 0;
                //isCameraRunning = 0;
                //frameCam.Release();
                //captureCam.Release();
                camera.Abort();
                //Thread.Sleep(100);
                //CaptureCamera1();
                isCameraCount = 0;
                this.Close();
                //this.Hide();
                //this.Close();
            }
        }
        //private void CaptureCamera()
        //{
        //    string sttr = "rtsp://admin:9819@192.168.10.101/video1";
        //    VideoCapture cap = new VideoCapture();
        //    cap.Open(sttr);

        //    using (Mat img = new Mat())
        //    {
        //        while (true)
        //        {
        //            if (!cap.Read(img))
        //            {
        //                Cv2.WaitKey();
        //            }
        //            if(img.Size().Width > 0 && img.Size().Height > 0)
        //            {
        //                Bitmap bt = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
        //                pictureBox1.Image = bt;
        //            }
        //            if (Cv2.WaitKey(1) >= 0)
        //                break;
        //        }
        //    }
        //}
    }

}