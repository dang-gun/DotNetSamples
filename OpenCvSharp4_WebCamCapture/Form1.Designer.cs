namespace OpenCvSharp4_WebCamCapture
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
            panel1 = new Panel();
            txtCameraSize_Height = new TextBox();
            txtCameraSize_Width = new TextBox();
            label2 = new Label();
            txtCameraIndex = new TextBox();
            label1 = new Label();
            btnCameraCapture = new Button();
            pictureOutput = new PictureBox();
            btnCameraCapture_1TimeUse = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureOutput).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCameraSize_Height);
            panel1.Controls.Add(txtCameraSize_Width);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCameraIndex);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 68);
            panel1.TabIndex = 0;
            // 
            // txtCameraSize_Height
            // 
            txtCameraSize_Height.Location = new Point(159, 29);
            txtCameraSize_Height.Name = "txtCameraSize_Height";
            txtCameraSize_Height.Size = new Size(44, 23);
            txtCameraSize_Height.TabIndex = 1;
            txtCameraSize_Height.Text = "1080";
            // 
            // txtCameraSize_Width
            // 
            txtCameraSize_Width.Location = new Point(109, 29);
            txtCameraSize_Width.Name = "txtCameraSize_Width";
            txtCameraSize_Width.Size = new Size(44, 23);
            txtCameraSize_Width.TabIndex = 1;
            txtCameraSize_Width.Text = "1980";
            // 
            // label2
            // 
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Camera Size : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCameraIndex
            // 
            txtCameraIndex.Location = new Point(109, 0);
            txtCameraIndex.Name = "txtCameraIndex";
            txtCameraIndex.Size = new Size(44, 23);
            txtCameraIndex.TabIndex = 1;
            txtCameraIndex.Text = "0";
            // 
            // label1
            // 
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "Camera Index : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCameraCapture
            // 
            btnCameraCapture.Location = new Point(12, 86);
            btnCameraCapture.Name = "btnCameraCapture";
            btnCameraCapture.Size = new Size(153, 23);
            btnCameraCapture.TabIndex = 1;
            btnCameraCapture.Text = "Camera Capture";
            btnCameraCapture.UseVisualStyleBackColor = true;
            btnCameraCapture.Click += btnCameraCapture_Click;
            // 
            // pictureOutput
            // 
            pictureOutput.Location = new Point(12, 115);
            pictureOutput.Name = "pictureOutput";
            pictureOutput.Size = new Size(446, 323);
            pictureOutput.SizeMode = PictureBoxSizeMode.Zoom;
            pictureOutput.TabIndex = 2;
            pictureOutput.TabStop = false;
            // 
            // btnCameraCapture_1TimeUse
            // 
            btnCameraCapture_1TimeUse.Location = new Point(171, 86);
            btnCameraCapture_1TimeUse.Name = "btnCameraCapture_1TimeUse";
            btnCameraCapture_1TimeUse.Size = new Size(170, 23);
            btnCameraCapture_1TimeUse.TabIndex = 3;
            btnCameraCapture_1TimeUse.Text = "Camera Capture - 1-time use";
            btnCameraCapture_1TimeUse.UseVisualStyleBackColor = true;
            btnCameraCapture_1TimeUse.Click += btnCameraCapture_1TimeUse_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(btnCameraCapture_1TimeUse);
            Controls.Add(pictureOutput);
            Controls.Add(btnCameraCapture);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "OpenCvSharp4 - Web Cam Capture";
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureOutput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtCameraIndex;
        private Label label1;
        private TextBox txtCameraSize_Height;
        private TextBox txtCameraSize_Width;
        private Label label2;
        private Button btnCameraCapture;
        private PictureBox pictureOutput;
        private Button btnCameraCapture_1TimeUse;
    }
}
