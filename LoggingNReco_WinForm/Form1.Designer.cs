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
            SuspendLayout();
            // 
            // btnLog_Info
            // 
            btnLog_Info.Location = new Point(12, 12);
            btnLog_Info.Name = "btnLog_Info";
            btnLog_Info.Size = new Size(123, 23);
            btnLog_Info.TabIndex = 4;
            btnLog_Info.Text = "정보 로그";
            btnLog_Info.UseVisualStyleBackColor = true;
            btnLog_Info.Click += btnLog_Info_Click;
            // 
            // btnLog_Debug
            // 
            btnLog_Debug.Location = new Point(12, 41);
            btnLog_Debug.Name = "btnLog_Debug";
            btnLog_Debug.Size = new Size(123, 23);
            btnLog_Debug.TabIndex = 4;
            btnLog_Debug.Text = "디버그 로그";
            btnLog_Debug.UseVisualStyleBackColor = true;
            btnLog_Debug.Click += btnLog_Debug_Click;
            // 
            // btnLog_Warning
            // 
            btnLog_Warning.Location = new Point(12, 70);
            btnLog_Warning.Name = "btnLog_Warning";
            btnLog_Warning.Size = new Size(123, 23);
            btnLog_Warning.TabIndex = 4;
            btnLog_Warning.Text = "경고 로그";
            btnLog_Warning.UseVisualStyleBackColor = true;
            btnLog_Warning.Click += btnLog_Warning_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 124);
            Controls.Add(btnLog_Warning);
            Controls.Add(btnLog_Debug);
            Controls.Add(btnLog_Info);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLog_Info;
        private Button btnLog_Debug;
        private Button btnLog_Warning;
    }
}