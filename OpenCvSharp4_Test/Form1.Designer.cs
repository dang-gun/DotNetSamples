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
            pictureView = new PictureBox();
            menuStrip1 = new MenuStrip();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            tsmiCamCapture = new ToolStripMenuItem();
            tsmiDeviceList = new ToolStripMenuItem();
            tsmiCamera_DeviceList_ListRefresh = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)pictureView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureView
            // 
            pictureView.Location = new Point(0, 24);
            pictureView.Name = "pictureView";
            pictureView.Size = new Size(575, 369);
            pictureView.SizeMode = PictureBoxSizeMode.Zoom;
            pictureView.TabIndex = 1;
            pictureView.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cameraToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(599, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiCamCapture, tsmiDeviceList });
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(60, 20);
            cameraToolStripMenuItem.Text = "Camera";
            // 
            // tsmiCamCapture
            // 
            tsmiCamCapture.Name = "tsmiCamCapture";
            tsmiCamCapture.Size = new Size(180, 22);
            tsmiCamCapture.Text = "Capture";
            tsmiCamCapture.Click += tsmiCamCapture_Click_1;
            // 
            // tsmiDeviceList
            // 
            tsmiDeviceList.DropDownItems.AddRange(new ToolStripItem[] { tsmiCamera_DeviceList_ListRefresh, toolStripMenuItem1 });
            tsmiDeviceList.Name = "tsmiDeviceList";
            tsmiDeviceList.Size = new Size(180, 22);
            tsmiDeviceList.Text = "Device List";
            // 
            // tsmiCamera_DeviceList_ListRefresh
            // 
            tsmiCamera_DeviceList_ListRefresh.Name = "tsmiCamera_DeviceList_ListRefresh";
            tsmiCamera_DeviceList_ListRefresh.Size = new Size(180, 22);
            tsmiCamera_DeviceList_ListRefresh.Text = "List Refresh";
            tsmiCamera_DeviceList_ListRefresh.Click += tsmiCamera_DeviceList_ListRefresh_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 450);
            Controls.Add(pictureView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResizeEnd += Form1_ResizeEnd;
            ((System.ComponentModel.ISupportInitialize)pictureView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private ToolStripMenuItem tsmiCamCapture;
        private ToolStripMenuItem tsmiDeviceList;
        private ToolStripMenuItem tsmiCamera_DeviceList_ListRefresh;
        private ToolStripSeparator toolStripMenuItem1;
    }
}