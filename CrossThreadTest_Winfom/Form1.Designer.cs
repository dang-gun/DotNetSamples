namespace CrossThreadTest_Winfom
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
            btnCrossThread_Error = new Button();
            labCrossThread_TestText = new Label();
            btnNoneError = new Button();
            btnGlobal_Out = new Button();
            btnGlobal_This = new Button();
            SuspendLayout();
            // 
            // btnCrossThread_Error
            // 
            btnCrossThread_Error.Location = new Point(12, 33);
            btnCrossThread_Error.Name = "btnCrossThread_Error";
            btnCrossThread_Error.Size = new Size(184, 23);
            btnCrossThread_Error.TabIndex = 0;
            btnCrossThread_Error.Text = "크로스 스레드 에러";
            btnCrossThread_Error.UseVisualStyleBackColor = true;
            btnCrossThread_Error.Click += btnCrossThread_Error_Click;
            // 
            // labCrossThread_TestText
            // 
            labCrossThread_TestText.Location = new Point(12, 7);
            labCrossThread_TestText.Name = "labCrossThread_TestText";
            labCrossThread_TestText.Size = new Size(184, 23);
            labCrossThread_TestText.TabIndex = 1;
            labCrossThread_TestText.Text = "label1";
            labCrossThread_TestText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNoneError
            // 
            btnNoneError.Location = new Point(12, 62);
            btnNoneError.Name = "btnNoneError";
            btnNoneError.Size = new Size(184, 23);
            btnNoneError.TabIndex = 0;
            btnNoneError.Text = "크로스 스레드 안남 에러";
            btnNoneError.UseVisualStyleBackColor = true;
            btnNoneError.Click += btnNoneError_Click;
            // 
            // btnGlobal_Out
            // 
            btnGlobal_Out.Location = new Point(12, 109);
            btnGlobal_Out.Name = "btnGlobal_Out";
            btnGlobal_Out.Size = new Size(184, 23);
            btnGlobal_Out.TabIndex = 0;
            btnGlobal_Out.Text = "공통화 함수 - 외부 스레드";
            btnGlobal_Out.UseVisualStyleBackColor = true;
            btnGlobal_Out.Click += btnGlobal_Out_Click;
            // 
            // btnGlobal_This
            // 
            btnGlobal_This.Location = new Point(12, 138);
            btnGlobal_This.Name = "btnGlobal_This";
            btnGlobal_This.Size = new Size(184, 23);
            btnGlobal_This.TabIndex = 0;
            btnGlobal_This.Text = "공통화 함수 - 자기 스레드";
            btnGlobal_This.UseVisualStyleBackColor = true;
            btnGlobal_This.Click += btnGlobal_This_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 168);
            Controls.Add(labCrossThread_TestText);
            Controls.Add(btnGlobal_This);
            Controls.Add(btnGlobal_Out);
            Controls.Add(btnNoneError);
            Controls.Add(btnCrossThread_Error);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCrossThread_Error;
        private Label labCrossThread_TestText;
        private Button btnNoneError;
        private Button btnGlobal_Out;
        private Button btnGlobal_This;
    }
}
