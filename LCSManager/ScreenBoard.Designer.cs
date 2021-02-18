
namespace LCSManager
{
    partial class ScreenBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SetScreen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FogRadio = new System.Windows.Forms.RadioButton();
            this.NormalRadio = new System.Windows.Forms.RadioButton();
            this.SlowDownRadio = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ElseBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConstructionRadio = new System.Windows.Forms.RadioButton();
            this.ElseButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "표시하실 전광판을 선택해주세요";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SetScreen
            // 
            this.SetScreen.Font = new System.Drawing.Font("Courier New", 15F);
            this.SetScreen.Location = new System.Drawing.Point(371, 262);
            this.SetScreen.Name = "SetScreen";
            this.SetScreen.Size = new System.Drawing.Size(75, 36);
            this.SetScreen.TabIndex = 7;
            this.SetScreen.Text = "설정";
            this.SetScreen.UseVisualStyleBackColor = true;
            this.SetScreen.Click += new System.EventHandler(this.SetScreen_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ElseButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ElseBox);
            this.panel1.Controls.Add(this.FogRadio);
            this.panel1.Controls.Add(this.ConstructionRadio);
            this.panel1.Controls.Add(this.NormalRadio);
            this.panel1.Controls.Add(this.SlowDownRadio);
            this.panel1.Location = new System.Drawing.Point(21, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 222);
            this.panel1.TabIndex = 8;
            // 
            // FogRadio
            // 
            this.FogRadio.AutoSize = true;
            this.FogRadio.Font = new System.Drawing.Font("Courier New", 16F);
            this.FogRadio.ForeColor = System.Drawing.Color.Transparent;
            this.FogRadio.Location = new System.Drawing.Point(3, 43);
            this.FogRadio.Name = "FogRadio";
            this.FogRadio.Size = new System.Drawing.Size(105, 28);
            this.FogRadio.TabIndex = 13;
            this.FogRadio.Text = "안개 주의";
            this.FogRadio.UseVisualStyleBackColor = true;
            // 
            // NormalRadio
            // 
            this.NormalRadio.AutoSize = true;
            this.NormalRadio.Font = new System.Drawing.Font("Courier New", 16F);
            this.NormalRadio.ForeColor = System.Drawing.Color.Transparent;
            this.NormalRadio.Location = new System.Drawing.Point(3, 8);
            this.NormalRadio.Name = "NormalRadio";
            this.NormalRadio.Size = new System.Drawing.Size(105, 28);
            this.NormalRadio.TabIndex = 11;
            this.NormalRadio.Text = "정상 운행";
            this.NormalRadio.UseVisualStyleBackColor = true;
            // 
            // SlowDownRadio
            // 
            this.SlowDownRadio.AutoSize = true;
            this.SlowDownRadio.Font = new System.Drawing.Font("Courier New", 16F);
            this.SlowDownRadio.ForeColor = System.Drawing.Color.Transparent;
            this.SlowDownRadio.Location = new System.Drawing.Point(3, 79);
            this.SlowDownRadio.Name = "SlowDownRadio";
            this.SlowDownRadio.Size = new System.Drawing.Size(183, 28);
            this.SlowDownRadio.TabIndex = 10;
            this.SlowDownRadio.Text = "제한속도 60km/h";
            this.SlowDownRadio.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ExitButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(458, 30);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // ExitButton
            // 
            this.ExitButton.BackgroundImage = global::LCSManager.Properties.Resources.cancel_close_delete_exit_logout_remove_x_icon_123217__1_;
            this.ExitButton.Location = new System.Drawing.Point(405, -3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(53, 36);
            this.ExitButton.TabIndex = 216;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(182, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 31);
            this.label2.TabIndex = 214;
            this.label2.Text = "전광판";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // ElseBox
            // 
            this.ElseBox.Location = new System.Drawing.Point(69, 146);
            this.ElseBox.Multiline = true;
            this.ElseBox.Name = "ElseBox";
            this.ElseBox.Size = new System.Drawing.Size(183, 28);
            this.ElseBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 16F);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "기타";
            // 
            // ConstructionRadio
            // 
            this.ConstructionRadio.AutoSize = true;
            this.ConstructionRadio.Font = new System.Drawing.Font("Courier New", 16F);
            this.ConstructionRadio.ForeColor = System.Drawing.Color.Transparent;
            this.ConstructionRadio.Location = new System.Drawing.Point(3, 114);
            this.ConstructionRadio.Name = "ConstructionRadio";
            this.ConstructionRadio.Size = new System.Drawing.Size(121, 28);
            this.ConstructionRadio.TabIndex = 12;
            this.ConstructionRadio.Text = "전방 공사중";
            this.ConstructionRadio.UseVisualStyleBackColor = true;
            // 
            // ElseButton
            // 
            this.ElseButton.AutoSize = true;
            this.ElseButton.Font = new System.Drawing.Font("Courier New", 16F);
            this.ElseButton.ForeColor = System.Drawing.Color.Transparent;
            this.ElseButton.Location = new System.Drawing.Point(3, 146);
            this.ElseButton.Name = "ElseButton";
            this.ElseButton.Size = new System.Drawing.Size(60, 28);
            this.ElseButton.TabIndex = 16;
            this.ElseButton.Text = "기타";
            this.ElseButton.UseVisualStyleBackColor = true;
            // 
            // ScreenBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(458, 310);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SetScreen);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenBoard";
            this.Text = "ScreenBoard";
            this.Load += new System.EventHandler(this.ScreenBoard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetScreen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton NormalRadio;
        private System.Windows.Forms.RadioButton SlowDownRadio;
        private System.Windows.Forms.RadioButton FogRadio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ElseBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton ElseButton;
        private System.Windows.Forms.RadioButton ConstructionRadio;
    }
}