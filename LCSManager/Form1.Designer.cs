
namespace LCSManager
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.lbCurTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Camera2Button = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DrivingConnection = new System.Windows.Forms.Button();
            this.WebConnection = new System.Windows.Forms.Button();
            this.CameraButton = new System.Windows.Forms.Button();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.CameraTimer = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.BackCamera = new System.Windows.Forms.PictureBox();
            this.FrontCamera = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.차량번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.차선 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검시일지 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FirstLCSButton = new System.Windows.Forms.Button();
            this.SecondLCSButton = new System.Windows.Forms.Button();
            this.ThirdLCSButton = new System.Windows.Forms.Button();
            this.ScreenBoardButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ScreenBoardLabel = new System.Windows.Forms.Label();
            this.lcsthird = new System.Windows.Forms.PictureBox();
            this.lcssecond = new System.Windows.Forms.PictureBox();
            this.lcsfirst = new System.Windows.Forms.PictureBox();
            this.ScreenBoradImage = new System.Windows.Forms.PictureBox();
            this.GarbageTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcsthird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcssecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcsfirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenBoradImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(587, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(362, 37);
            this.label11.TabIndex = 172;
            this.label11.Text = "이동식 LCS 제어 프로그램";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label11_MouseDown);
            // 
            // lbCurTime
            // 
            this.lbCurTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurTime.AutoSize = true;
            this.lbCurTime.BackColor = System.Drawing.Color.Transparent;
            this.lbCurTime.Font = new System.Drawing.Font("굴림", 22F, System.Drawing.FontStyle.Bold);
            this.lbCurTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbCurTime.Location = new System.Drawing.Point(61, 1);
            this.lbCurTime.Name = "lbCurTime";
            this.lbCurTime.Size = new System.Drawing.Size(338, 30);
            this.lbCurTime.TabIndex = 206;
            this.lbCurTime.Text = "0000-00-01 24:00:00";
            this.lbCurTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCurTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbCurTime_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lbCurTime);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1585, 36);
            this.panel2.TabIndex = 207;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LCSManager.Properties.Resources.free_icon_wall_clock_8757642;
            this.pictureBox2.Location = new System.Drawing.Point(12, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 212;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::LCSManager.Properties.Resources.cancel_close_delete_exit_logout_remove_x_icon_123217__1_;
            this.button3.Location = new System.Drawing.Point(1406, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 36);
            this.button3.TabIndex = 211;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LCSManager.Properties.Resources.window_minimize_icon_144028__1___1_;
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Location = new System.Drawing.Point(1347, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 36);
            this.button1.TabIndex = 210;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::LCSManager.Properties.Resources.logout_icon_151219__1_;
            this.button2.Location = new System.Drawing.Point(1288, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 36);
            this.button2.TabIndex = 209;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.Camera2Button);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.DrivingConnection);
            this.panel1.Controls.Add(this.WebConnection);
            this.panel1.Controls.Add(this.CameraButton);
            this.panel1.Location = new System.Drawing.Point(0, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1578, 36);
            this.panel1.TabIndex = 212;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DarkBlue;
            this.richTextBox1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Yellow;
            this.richTextBox1.Location = new System.Drawing.Point(447, -1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(915, 39);
            this.richTextBox1.TabIndex = 217;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // Camera2Button
            // 
            this.Camera2Button.Location = new System.Drawing.Point(135, 2);
            this.Camera2Button.Name = "Camera2Button";
            this.Camera2Button.Size = new System.Drawing.Size(41, 36);
            this.Camera2Button.TabIndex = 217;
            this.Camera2Button.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LCSManager.Properties.Resources.KakaoTalk_20210111_162559091_011;
            this.pictureBox3.Location = new System.Drawing.Point(1368, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 36);
            this.pictureBox3.TabIndex = 216;
            this.pictureBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(318, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 215;
            this.label9.Text = "구동장치";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(204, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 25);
            this.label8.TabIndex = 214;
            this.label8.Text = "센터";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(24, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 213;
            this.label7.Text = "카메라";
            // 
            // DrivingConnection
            // 
            this.DrivingConnection.BackgroundImage = global::LCSManager.Properties.Resources.device1;
            this.DrivingConnection.Location = new System.Drawing.Point(400, -1);
            this.DrivingConnection.Name = "DrivingConnection";
            this.DrivingConnection.Size = new System.Drawing.Size(39, 36);
            this.DrivingConnection.TabIndex = 211;
            this.DrivingConnection.UseVisualStyleBackColor = true;
            this.DrivingConnection.Click += new System.EventHandler(this.DrivingConnection_Click);
            // 
            // WebConnection
            // 
            this.WebConnection.Image = global::LCSManager.Properties.Resources.device1;
            this.WebConnection.Location = new System.Drawing.Point(254, 0);
            this.WebConnection.Name = "WebConnection";
            this.WebConnection.Size = new System.Drawing.Size(42, 36);
            this.WebConnection.TabIndex = 210;
            this.WebConnection.UseVisualStyleBackColor = true;
            this.WebConnection.Click += new System.EventHandler(this.WebConnection_Click);
            // 
            // CameraButton
            // 
            this.CameraButton.Location = new System.Drawing.Point(90, 2);
            this.CameraButton.Name = "CameraButton";
            this.CameraButton.Size = new System.Drawing.Size(41, 36);
            this.CameraButton.TabIndex = 209;
            this.CameraButton.UseVisualStyleBackColor = true;
            // 
            // ClockTimer
            // 
            this.ClockTimer.Enabled = true;
            this.ClockTimer.Interval = 1000;
            this.ClockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            // 
            // CameraTimer
            // 
            this.CameraTimer.Enabled = true;
            this.CameraTimer.Interval = 1000;
            this.CameraTimer.Tick += new System.EventHandler(this.CameraTimer_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BackCamera);
            this.panel4.Controls.Add(this.FrontCamera);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(871, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 579);
            this.panel4.TabIndex = 214;
            // 
            // BackCamera
            // 
            this.BackCamera.Image = global::LCSManager.Properties.Resources.대기6;
            this.BackCamera.Location = new System.Drawing.Point(3, 311);
            this.BackCamera.Name = "BackCamera";
            this.BackCamera.Size = new System.Drawing.Size(467, 271);
            this.BackCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackCamera.TabIndex = 219;
            this.BackCamera.TabStop = false;
            this.BackCamera.DoubleClick += new System.EventHandler(this.BackCamera_DoubleClick);
            // 
            // FrontCamera
            // 
            this.FrontCamera.BackColor = System.Drawing.Color.DarkBlue;
            this.FrontCamera.Image = global::LCSManager.Properties.Resources.대기6;
            this.FrontCamera.Location = new System.Drawing.Point(3, 53);
            this.FrontCamera.Name = "FrontCamera";
            this.FrontCamera.Size = new System.Drawing.Size(467, 246);
            this.FrontCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FrontCamera.TabIndex = 218;
            this.FrontCamera.TabStop = false;
            this.FrontCamera.DoubleClick += new System.EventHandler(this.FrontCamera_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(470, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 37);
            this.label12.TabIndex = 217;
            this.label12.Text = "후방";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(470, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 37);
            this.label10.TabIndex = 216;
            this.label10.Text = "전방";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, -19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 43);
            this.label3.TabIndex = 213;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 212;
            this.label4.Text = "카메라 모니터링";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 209;
            this.label1.Text = "장비 모니터링";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(833, 521);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 210;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(14, -19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 43);
            this.label2.TabIndex = 211;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(26, 331);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(457, 210);
            this.panel5.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.차량번호,
            this.차선,
            this.검시일지});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(20, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(426, 150);
            this.dataGridView1.TabIndex = 217;
            // 
            // NO
            // 
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            this.NO.Width = 45;
            // 
            // 차량번호
            // 
            this.차량번호.HeaderText = "장비";
            this.차량번호.Name = "차량번호";
            this.차량번호.Width = 90;
            // 
            // 차선
            // 
            this.차선.HeaderText = "에러 형태";
            this.차선.Name = "차선";
            this.차선.Width = 150;
            // 
            // 검시일지
            // 
            this.검시일지.HeaderText = "발생시간";
            this.검시일지.Name = "검시일지";
            this.검시일지.Width = 180;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 214;
            this.label6.Text = "장비 장애 현황";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, -26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 43);
            this.label5.TabIndex = 215;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstLCSButton
            // 
            this.FirstLCSButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.FirstLCSButton.Location = new System.Drawing.Point(93, 116);
            this.FirstLCSButton.Name = "FirstLCSButton";
            this.FirstLCSButton.Size = new System.Drawing.Size(75, 23);
            this.FirstLCSButton.TabIndex = 218;
            this.FirstLCSButton.Text = "변경";
            this.FirstLCSButton.UseVisualStyleBackColor = true;
            this.FirstLCSButton.Click += new System.EventHandler(this.FirstLCSButton_Click);
            // 
            // SecondLCSButton
            // 
            this.SecondLCSButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.SecondLCSButton.Location = new System.Drawing.Point(260, 116);
            this.SecondLCSButton.Name = "SecondLCSButton";
            this.SecondLCSButton.Size = new System.Drawing.Size(75, 23);
            this.SecondLCSButton.TabIndex = 219;
            this.SecondLCSButton.Text = "변경";
            this.SecondLCSButton.UseVisualStyleBackColor = true;
            this.SecondLCSButton.Click += new System.EventHandler(this.SecondLCSButton_Click);
            // 
            // ThirdLCSButton
            // 
            this.ThirdLCSButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.ThirdLCSButton.Location = new System.Drawing.Point(394, 116);
            this.ThirdLCSButton.Name = "ThirdLCSButton";
            this.ThirdLCSButton.Size = new System.Drawing.Size(75, 23);
            this.ThirdLCSButton.TabIndex = 220;
            this.ThirdLCSButton.Text = "변경";
            this.ThirdLCSButton.UseVisualStyleBackColor = true;
            this.ThirdLCSButton.Click += new System.EventHandler(this.ThirdLCSButton_Click);
            // 
            // ScreenBoardButton
            // 
            this.ScreenBoardButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.ScreenBoardButton.Location = new System.Drawing.Point(662, 116);
            this.ScreenBoardButton.Name = "ScreenBoardButton";
            this.ScreenBoardButton.Size = new System.Drawing.Size(75, 23);
            this.ScreenBoardButton.TabIndex = 221;
            this.ScreenBoardButton.Text = "변경";
            this.ScreenBoardButton.UseVisualStyleBackColor = true;
            this.ScreenBoardButton.Click += new System.EventHandler(this.ScreenBoardButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ScreenBoardLabel);
            this.panel3.Controls.Add(this.lcsthird);
            this.panel3.Controls.Add(this.lcssecond);
            this.panel3.Controls.Add(this.lcsfirst);
            this.panel3.Controls.Add(this.ScreenBoardButton);
            this.panel3.Controls.Add(this.ThirdLCSButton);
            this.panel3.Controls.Add(this.SecondLCSButton);
            this.panel3.Controls.Add(this.FirstLCSButton);
            this.panel3.Controls.Add(this.ScreenBoradImage);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 582);
            this.panel3.TabIndex = 213;
            // 
            // ScreenBoardLabel
            // 
            this.ScreenBoardLabel.BackColor = System.Drawing.Color.Black;
            this.ScreenBoardLabel.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold);
            this.ScreenBoardLabel.ForeColor = System.Drawing.Color.Red;
            this.ScreenBoardLabel.Location = new System.Drawing.Point(492, 136);
            this.ScreenBoardLabel.Name = "ScreenBoardLabel";
            this.ScreenBoardLabel.Size = new System.Drawing.Size(245, 60);
            this.ScreenBoardLabel.TabIndex = 225;
            this.ScreenBoardLabel.Text = "전차로 정상 운행중";
            this.ScreenBoardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ScreenBoardLabel.Click += new System.EventHandler(this.label15_Click);
            // 
            // lcsthird
            // 
            this.lcsthird.Image = global::LCSManager.Properties.Resources.진입;
            this.lcsthird.Location = new System.Drawing.Point(399, 137);
            this.lcsthird.Name = "lcsthird";
            this.lcsthird.Size = new System.Drawing.Size(66, 59);
            this.lcsthird.TabIndex = 224;
            this.lcsthird.TabStop = false;
            this.lcsthird.Click += new System.EventHandler(this.ThirdLCS_Click);
            // 
            // lcssecond
            // 
            this.lcssecond.Image = global::LCSManager.Properties.Resources.진입;
            this.lcssecond.Location = new System.Drawing.Point(264, 137);
            this.lcssecond.Name = "lcssecond";
            this.lcssecond.Size = new System.Drawing.Size(66, 59);
            this.lcssecond.TabIndex = 223;
            this.lcssecond.TabStop = false;
            this.lcssecond.Click += new System.EventHandler(this.SecondLCS_Click);
            // 
            // lcsfirst
            // 
            this.lcsfirst.Image = global::LCSManager.Properties.Resources.진입;
            this.lcsfirst.Location = new System.Drawing.Point(96, 137);
            this.lcsfirst.Name = "lcsfirst";
            this.lcsfirst.Size = new System.Drawing.Size(66, 59);
            this.lcsfirst.TabIndex = 222;
            this.lcsfirst.TabStop = false;
            this.lcsfirst.Click += new System.EventHandler(this.firstLCS_Click);
            // 
            // ScreenBoradImage
            // 
            this.ScreenBoradImage.Image = ((System.Drawing.Image)(resources.GetObject("ScreenBoradImage.Image")));
            this.ScreenBoradImage.Location = new System.Drawing.Point(494, 136);
            this.ScreenBoradImage.Name = "ScreenBoradImage";
            this.ScreenBoradImage.Size = new System.Drawing.Size(243, 60);
            this.ScreenBoradImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenBoradImage.TabIndex = 217;
            this.ScreenBoradImage.TabStop = false;
            this.ScreenBoradImage.Click += new System.EventHandler(this.ScreenBorad_Click);
            // 
            // GarbageTimer
            // 
            this.GarbageTimer.Enabled = true;
            this.GarbageTimer.Tick += new System.EventHandler(this.GarbageTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1460, 678);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "이동식 LCS 제어 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcsthird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcssecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcsfirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenBoradImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbCurTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DrivingConnection;
        private System.Windows.Forms.Button WebConnection;
        private System.Windows.Forms.Button CameraButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer CameraTimer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox BackCamera;
        private System.Windows.Forms.PictureBox FrontCamera;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FirstLCSButton;
        private System.Windows.Forms.Button SecondLCSButton;
        private System.Windows.Forms.Button ThirdLCSButton;
        private System.Windows.Forms.Button ScreenBoardButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox lcsthird;
        private System.Windows.Forms.PictureBox lcssecond;
        private System.Windows.Forms.PictureBox lcsfirst;
        private System.Windows.Forms.Timer GarbageTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn 차량번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 차선;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검시일지;
        private System.Windows.Forms.Button Camera2Button;
        private System.Windows.Forms.PictureBox ScreenBoradImage;
        private System.Windows.Forms.Label ScreenBoardLabel;
    }
}

