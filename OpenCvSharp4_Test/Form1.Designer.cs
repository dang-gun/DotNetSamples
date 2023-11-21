namespace OpenCvSharp4_Test
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
            groupBox1 = new GroupBox();
            btnCamCapture = new Button();
            pictureView = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCamCapture);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnCamCapture
            // 
            btnCamCapture.Location = new Point(6, 22);
            btnCamCapture.Name = "btnCamCapture";
            btnCamCapture.Size = new Size(93, 23);
            btnCamCapture.TabIndex = 0;
            btnCamCapture.Text = "Cam Capture";
            btnCamCapture.UseVisualStyleBackColor = true;
            btnCamCapture.Click += btnCamCapture_Click;
            // 
            // pictureView
            // 
            pictureView.Location = new Point(12, 69);
            pictureView.Name = "pictureView";
            pictureView.Size = new Size(575, 369);
            pictureView.SizeMode = PictureBoxSizeMode.Zoom;
            pictureView.TabIndex = 1;
            pictureView.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 450);
            Controls.Add(pictureView);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCamCapture;
        private PictureBox pictureView;
    }
}