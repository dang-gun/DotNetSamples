namespace LoggingNReco_WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLog_Info = new Button();
            btnLog_Debug = new Button();
            btnLog_Warning = new Button();
            btnLogGlobal_Info = new Button();
            btnLogGlobal_Debug = new Button();
            btnLogGlobal_Warning = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            btnDotNetLogging_Form_Info = new Button();
            btnDotNetLogging_Form_Debug = new Button();
            btnDotNetLogging_Form_Warning = new Button();
            groupBox4 = new GroupBox();
            btnDotNetLogging_GlobalStatic_Info = new Button();
            btnDotNetLogging_GlobalStatic_Debug = new Button();
            btnDotNetLogging_GlobalStatic_Warning = new Button();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // btnLog_Info
            // 
            btnLog_Info.Location = new Point(6, 22);
            btnLog_Info.Name = "btnLog_Info";
            btnLog_Info.Size = new Size(123, 23);
            btnLog_Info.TabIndex = 4;
            btnLog_Info.Text = "정보 로그";
            btnLog_Info.UseVisualStyleBackColor = true;
            btnLog_Info.Click += btnLog_Info_Click;
            // 
            // btnLog_Debug
            // 
            btnLog_Debug.Location = new Point(6, 51);
            btnLog_Debug.Name = "btnLog_Debug";
            btnLog_Debug.Size = new Size(123, 23);
            btnLog_Debug.TabIndex = 4;
            btnLog_Debug.Text = "디버그 로그";
            btnLog_Debug.UseVisualStyleBackColor = true;
            btnLog_Debug.Click += btnLog_Debug_Click;
            // 
            // btnLog_Warning
            // 
            btnLog_Warning.Location = new Point(6, 80);
            btnLog_Warning.Name = "btnLog_Warning";
            btnLog_Warning.Size = new Size(123, 23);
            btnLog_Warning.TabIndex = 4;
            btnLog_Warning.Text = "경고 로그";
            btnLog_Warning.UseVisualStyleBackColor = true;
            btnLog_Warning.Click += btnLog_Warning_Click;
            // 
            // btnLogGlobal_Info
            // 
            btnLogGlobal_Info.Location = new Point(6, 22);
            btnLogGlobal_Info.Name = "btnLogGlobal_Info";
            btnLogGlobal_Info.Size = new Size(123, 23);
            btnLogGlobal_Info.TabIndex = 4;
            btnLogGlobal_Info.Text = "정보 로그";
            btnLogGlobal_Info.UseVisualStyleBackColor = true;
            btnLogGlobal_Info.Click += btnLogGlobal_Info_Click;
            // 
            // btnLogGlobal_Debug
            // 
            btnLogGlobal_Debug.Location = new Point(6, 51);
            btnLogGlobal_Debug.Name = "btnLogGlobal_Debug";
            btnLogGlobal_Debug.Size = new Size(123, 23);
            btnLogGlobal_Debug.TabIndex = 4;
            btnLogGlobal_Debug.Text = "디버그 로그";
            btnLogGlobal_Debug.UseVisualStyleBackColor = true;
            btnLogGlobal_Debug.Click += btnLogGlobal_Debug_Click;
            // 
            // btnLogGlobal_Warning
            // 
            btnLogGlobal_Warning.Location = new Point(6, 80);
            btnLogGlobal_Warning.Name = "btnLogGlobal_Warning";
            btnLogGlobal_Warning.Size = new Size(123, 23);
            btnLogGlobal_Warning.TabIndex = 4;
            btnLogGlobal_Warning.Text = "경고 로그";
            btnLogGlobal_Warning.UseVisualStyleBackColor = true;
            btnLogGlobal_Warning.Click += btnLogGlobal_Warning_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLog_Info);
            groupBox1.Controls.Add(btnLog_Debug);
            groupBox1.Controls.Add(btnLog_Warning);
            groupBox1.Location = new Point(6, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(139, 113);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Form1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLogGlobal_Info);
            groupBox2.Controls.Add(btnLogGlobal_Debug);
            groupBox2.Controls.Add(btnLogGlobal_Warning);
            groupBox2.Location = new Point(6, 141);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(139, 117);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "GlobalStatic";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnDotNetLogging_Form_Info);
            groupBox3.Controls.Add(btnDotNetLogging_Form_Debug);
            groupBox3.Controls.Add(btnDotNetLogging_Form_Warning);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(139, 113);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Form1";
            // 
            // btnDotNetLogging_Form_Info
            // 
            btnDotNetLogging_Form_Info.Location = new Point(6, 22);
            btnDotNetLogging_Form_Info.Name = "btnDotNetLogging_Form_Info";
            btnDotNetLogging_Form_Info.Size = new Size(123, 23);
            btnDotNetLogging_Form_Info.TabIndex = 4;
            btnDotNetLogging_Form_Info.Text = "정보 로그";
            btnDotNetLogging_Form_Info.UseVisualStyleBackColor = true;
            btnDotNetLogging_Form_Info.Click += btnDotNetLogging_Form_Info_Click;
            // 
            // btnDotNetLogging_Form_Debug
            // 
            btnDotNetLogging_Form_Debug.Location = new Point(6, 51);
            btnDotNetLogging_Form_Debug.Name = "btnDotNetLogging_Form_Debug";
            btnDotNetLogging_Form_Debug.Size = new Size(123, 23);
            btnDotNetLogging_Form_Debug.TabIndex = 4;
            btnDotNetLogging_Form_Debug.Text = "디버그 로그";
            btnDotNetLogging_Form_Debug.UseVisualStyleBackColor = true;
            btnDotNetLogging_Form_Debug.Click += btnDotNetLogging_Form_Debug_Click;
            // 
            // btnDotNetLogging_Form_Warning
            // 
            btnDotNetLogging_Form_Warning.Location = new Point(6, 80);
            btnDotNetLogging_Form_Warning.Name = "btnDotNetLogging_Form_Warning";
            btnDotNetLogging_Form_Warning.Size = new Size(123, 23);
            btnDotNetLogging_Form_Warning.TabIndex = 4;
            btnDotNetLogging_Form_Warning.Text = "경고 로그";
            btnDotNetLogging_Form_Warning.UseVisualStyleBackColor = true;
            btnDotNetLogging_Form_Warning.Click += btnDotNetLogging_Form_Warning_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDotNetLogging_GlobalStatic_Info);
            groupBox4.Controls.Add(btnDotNetLogging_GlobalStatic_Debug);
            groupBox4.Controls.Add(btnDotNetLogging_GlobalStatic_Warning);
            groupBox4.Location = new Point(6, 140);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(139, 117);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "GlobalStatic";
            // 
            // btnDotNetLogging_GlobalStatic_Info
            // 
            btnDotNetLogging_GlobalStatic_Info.Location = new Point(6, 22);
            btnDotNetLogging_GlobalStatic_Info.Name = "btnDotNetLogging_GlobalStatic_Info";
            btnDotNetLogging_GlobalStatic_Info.Size = new Size(123, 23);
            btnDotNetLogging_GlobalStatic_Info.TabIndex = 4;
            btnDotNetLogging_GlobalStatic_Info.Text = "정보 로그";
            btnDotNetLogging_GlobalStatic_Info.UseVisualStyleBackColor = true;
            btnDotNetLogging_GlobalStatic_Info.Click += btnDotNetLogging_GlobalStatic_Info_Click;
            // 
            // btnDotNetLogging_GlobalStatic_Debug
            // 
            btnDotNetLogging_GlobalStatic_Debug.Location = new Point(6, 51);
            btnDotNetLogging_GlobalStatic_Debug.Name = "btnDotNetLogging_GlobalStatic_Debug";
            btnDotNetLogging_GlobalStatic_Debug.Size = new Size(123, 23);
            btnDotNetLogging_GlobalStatic_Debug.TabIndex = 4;
            btnDotNetLogging_GlobalStatic_Debug.Text = "디버그 로그";
            btnDotNetLogging_GlobalStatic_Debug.UseVisualStyleBackColor = true;
            btnDotNetLogging_GlobalStatic_Debug.Click += btnDotNetLogging_GlobalStatic_Debug_Click;
            // 
            // btnDotNetLogging_GlobalStatic_Warning
            // 
            btnDotNetLogging_GlobalStatic_Warning.Location = new Point(6, 80);
            btnDotNetLogging_GlobalStatic_Warning.Name = "btnDotNetLogging_GlobalStatic_Warning";
            btnDotNetLogging_GlobalStatic_Warning.Size = new Size(123, 23);
            btnDotNetLogging_GlobalStatic_Warning.TabIndex = 4;
            btnDotNetLogging_GlobalStatic_Warning.Text = "경고 로그";
            btnDotNetLogging_GlobalStatic_Warning.UseVisualStyleBackColor = true;
            btnDotNetLogging_GlobalStatic_Warning.Click += btnDotNetLogging_GlobalStatic_Warning_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(groupBox1);
            groupBox5.Controls.Add(groupBox2);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(150, 263);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Form log";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(groupBox3);
            groupBox6.Controls.Add(groupBox4);
            groupBox6.Location = new Point(168, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(150, 263);
            groupBox6.TabIndex = 10;
            groupBox6.TabStop = false;
            groupBox6.Text = "DotNetLogging";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 280);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLog_Info;
        private Button btnLog_Debug;
        private Button btnLog_Warning;
        private Button btnLogGlobal_Info;
        private Button btnLogGlobal_Debug;
        private Button btnLogGlobal_Warning;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnDotNetLogging_Form_Info;
        private Button btnDotNetLogging_Form_Debug;
        private Button btnDotNetLogging_Form_Warning;
        private GroupBox groupBox4;
        private Button btnDotNetLogging_GlobalStatic_Info;
        private Button btnDotNetLogging_GlobalStatic_Debug;
        private Button btnDotNetLogging_GlobalStatic_Warning;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
    }
}