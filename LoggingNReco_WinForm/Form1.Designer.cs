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
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            groupBox1.Location = new Point(12, 12);
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
            groupBox2.Location = new Point(12, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(139, 117);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "GlobalStatic";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(169, 257);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
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
    }
}