namespace OpenCvSharp4_Calibration
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
            menuStrip1 = new MenuStrip();
            conifgToolStripMenuItem = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            cameraIndexToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripMenuItem5 = new ToolStripSeparator();
            tsmiCamera_Capture = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            tsmiSelectFile = new ToolStripMenuItem();
            tsmiCameraCapture = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            chessBoardToolStripMenuItem1 = new ToolStripMenuItem();
            tstxtChessBoardWidth = new ToolStripTextBox();
            tstxtChessBoardHeight = new ToolStripTextBox();
            toolStripMenuItem2 = new ToolStripSeparator();
            tsmiRadialDistortionCheck = new ToolStripMenuItem();
            tsmiRadialDistortionApply = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            tsmiRadialDistortionFileSaveXml = new ToolStripMenuItem();
            tsmiRadialDistortionFileSaveYml = new ToolStripMenuItem();
            tsmiRadialDistortionFileSaveJson = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            tsmiRadialDistortionFileLoadXml = new ToolStripMenuItem();
            tsmiRadialDistortionFileLoadYml = new ToolStripMenuItem();
            tsmiRadialDistortionFileLoadJson = new ToolStripMenuItem();
            splitMain = new SplitContainer();
            pictureOriginal = new PictureBox();
            pictureCalibrated = new PictureBox();
            tsmiConfig_ViewOrientation = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureCalibrated).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { conifgToolStripMenuItem, cameraToolStripMenuItem, imageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(664, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // conifgToolStripMenuItem
            // 
            conifgToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiConfig_ViewOrientation });
            conifgToolStripMenuItem.Name = "conifgToolStripMenuItem";
            conifgToolStripMenuItem.Size = new Size(55, 20);
            conifgToolStripMenuItem.Text = "Conifg";
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cameraIndexToolStripMenuItem, toolStripTextBox1, toolStripMenuItem5, tsmiCamera_Capture });
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(60, 20);
            cameraToolStripMenuItem.Text = "Camera";
            // 
            // cameraIndexToolStripMenuItem
            // 
            cameraIndexToolStripMenuItem.Name = "cameraIndexToolStripMenuItem";
            cameraIndexToolStripMenuItem.Size = new Size(180, 22);
            cameraIndexToolStripMenuItem.Text = "Camera Index";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            toolStripTextBox1.Text = "0";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(177, 6);
            // 
            // tsmiCamera_Capture
            // 
            tsmiCamera_Capture.Name = "tsmiCamera_Capture";
            tsmiCamera_Capture.Size = new Size(180, 22);
            tsmiCamera_Capture.Text = "Camera Capture";
            tsmiCamera_Capture.Click += tsmiCamera_Capture_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiSelectFile, tsmiCameraCapture, toolStripMenuItem1, chessBoardToolStripMenuItem1, tstxtChessBoardWidth, tstxtChessBoardHeight, toolStripMenuItem2, tsmiRadialDistortionCheck, tsmiRadialDistortionApply, toolStripMenuItem3, tsmiRadialDistortionFileSaveXml, tsmiRadialDistortionFileSaveYml, tsmiRadialDistortionFileSaveJson, toolStripMenuItem4, tsmiRadialDistortionFileLoadXml, tsmiRadialDistortionFileLoadYml, tsmiRadialDistortionFileLoadJson });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(77, 20);
            imageToolStripMenuItem.Text = "Calibration";
            // 
            // tsmiSelectFile
            // 
            tsmiSelectFile.Name = "tsmiSelectFile";
            tsmiSelectFile.Size = new Size(252, 22);
            tsmiSelectFile.Text = "Select File";
            tsmiSelectFile.Click += tsmiSelectFile_Click;
            // 
            // tsmiCameraCapture
            // 
            tsmiCameraCapture.Name = "tsmiCameraCapture";
            tsmiCameraCapture.Size = new Size(252, 22);
            tsmiCameraCapture.Text = "Camera Capture";
            tsmiCameraCapture.Click += tsmiCameraCapture_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(249, 6);
            // 
            // chessBoardToolStripMenuItem1
            // 
            chessBoardToolStripMenuItem1.Name = "chessBoardToolStripMenuItem1";
            chessBoardToolStripMenuItem1.Size = new Size(252, 22);
            chessBoardToolStripMenuItem1.Text = "Chess Board";
            // 
            // tstxtChessBoardWidth
            // 
            tstxtChessBoardWidth.Name = "tstxtChessBoardWidth";
            tstxtChessBoardWidth.Size = new Size(100, 23);
            tstxtChessBoardWidth.Text = "10";
            // 
            // tstxtChessBoardHeight
            // 
            tstxtChessBoardHeight.Name = "tstxtChessBoardHeight";
            tstxtChessBoardHeight.Size = new Size(100, 23);
            tstxtChessBoardHeight.Text = "7";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(249, 6);
            // 
            // tsmiRadialDistortionCheck
            // 
            tsmiRadialDistortionCheck.Name = "tsmiRadialDistortionCheck";
            tsmiRadialDistortionCheck.Size = new Size(252, 22);
            tsmiRadialDistortionCheck.Text = "Radial Distortion Check";
            tsmiRadialDistortionCheck.Click += tsmiRadialDistortionCheck_Click;
            // 
            // tsmiRadialDistortionApply
            // 
            tsmiRadialDistortionApply.Name = "tsmiRadialDistortionApply";
            tsmiRadialDistortionApply.Size = new Size(252, 22);
            tsmiRadialDistortionApply.Text = "Radial Distortion Apply";
            tsmiRadialDistortionApply.Click += tsmiRadialDistortionApply_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(249, 6);
            // 
            // tsmiRadialDistortionFileSaveXml
            // 
            tsmiRadialDistortionFileSaveXml.Name = "tsmiRadialDistortionFileSaveXml";
            tsmiRadialDistortionFileSaveXml.Size = new Size(252, 22);
            tsmiRadialDistortionFileSaveXml.Text = "Radial Distortion File Save(XML)";
            tsmiRadialDistortionFileSaveXml.Click += tsmiRadialDistortionFileSaveXml_Click;
            // 
            // tsmiRadialDistortionFileSaveYml
            // 
            tsmiRadialDistortionFileSaveYml.Name = "tsmiRadialDistortionFileSaveYml";
            tsmiRadialDistortionFileSaveYml.Size = new Size(252, 22);
            tsmiRadialDistortionFileSaveYml.Text = "Radial Distortion File Save(YML)";
            tsmiRadialDistortionFileSaveYml.Click += tsmiRadialDistortionFileSaveYml_Click;
            // 
            // tsmiRadialDistortionFileSaveJson
            // 
            tsmiRadialDistortionFileSaveJson.Name = "tsmiRadialDistortionFileSaveJson";
            tsmiRadialDistortionFileSaveJson.Size = new Size(252, 22);
            tsmiRadialDistortionFileSaveJson.Text = "Radial Distortion File Save(JSON)";
            tsmiRadialDistortionFileSaveJson.Click += tsmiRadialDistortionFileSaveJson_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(249, 6);
            // 
            // tsmiRadialDistortionFileLoadXml
            // 
            tsmiRadialDistortionFileLoadXml.Name = "tsmiRadialDistortionFileLoadXml";
            tsmiRadialDistortionFileLoadXml.Size = new Size(252, 22);
            tsmiRadialDistortionFileLoadXml.Text = "Radial Distortion File Load(XML)";
            tsmiRadialDistortionFileLoadXml.Click += tsmiRadialDistortionFileLoadXml_Click;
            // 
            // tsmiRadialDistortionFileLoadYml
            // 
            tsmiRadialDistortionFileLoadYml.Name = "tsmiRadialDistortionFileLoadYml";
            tsmiRadialDistortionFileLoadYml.Size = new Size(252, 22);
            tsmiRadialDistortionFileLoadYml.Text = "Radial Distortion File Load(YML)";
            tsmiRadialDistortionFileLoadYml.Click += tsmiRadialDistortionFileLoadYml_Click;
            // 
            // tsmiRadialDistortionFileLoadJson
            // 
            tsmiRadialDistortionFileLoadJson.Name = "tsmiRadialDistortionFileLoadJson";
            tsmiRadialDistortionFileLoadJson.Size = new Size(252, 22);
            tsmiRadialDistortionFileLoadJson.Text = "Radial Distortion File Load(JSON)";
            tsmiRadialDistortionFileLoadJson.Click += tsmiRadialDistortionFileLoadJson_Click;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 24);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(pictureOriginal);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pictureCalibrated);
            splitMain.Size = new Size(664, 454);
            splitMain.SplitterDistance = 299;
            splitMain.TabIndex = 1;
            // 
            // pictureOriginal
            // 
            pictureOriginal.Dock = DockStyle.Fill;
            pictureOriginal.Location = new Point(0, 0);
            pictureOriginal.Name = "pictureOriginal";
            pictureOriginal.Size = new Size(299, 454);
            pictureOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureOriginal.TabIndex = 0;
            pictureOriginal.TabStop = false;
            // 
            // pictureCalibrated
            // 
            pictureCalibrated.Dock = DockStyle.Fill;
            pictureCalibrated.Location = new Point(0, 0);
            pictureCalibrated.Name = "pictureCalibrated";
            pictureCalibrated.Size = new Size(361, 454);
            pictureCalibrated.SizeMode = PictureBoxSizeMode.Zoom;
            pictureCalibrated.TabIndex = 0;
            pictureCalibrated.TabStop = false;
            // 
            // tsmiConfig_ViewOrientation
            // 
            tsmiConfig_ViewOrientation.Name = "tsmiConfig_ViewOrientation";
            tsmiConfig_ViewOrientation.Size = new Size(180, 22);
            tsmiConfig_ViewOrientation.Text = "View  Orientation";
            tsmiConfig_ViewOrientation.Click += tsmiConfig_ViewOrientation_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 478);
            Controls.Add(splitMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureCalibrated).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private SplitContainer splitMain;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem tsmiSelectFile;
        private PictureBox pictureOriginal;
        private PictureBox pictureCalibrated;
        private ToolStripMenuItem conifgToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem chessBoardToolStripMenuItem1;
        private ToolStripTextBox tstxtChessBoardWidth;
        private ToolStripTextBox tstxtChessBoardHeight;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem tsmiRadialDistortionCheck;
        private ToolStripMenuItem tsmiRadialDistortionApply;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveXml;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveJson;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadXml;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadJson;
        private ToolStripMenuItem tsmiCameraCapture;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveYml;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadYml;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private ToolStripMenuItem tsmiCamera_Capture;
        private ToolStripMenuItem cameraIndexToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem tsmiConfig_ViewOrientation;
    }
}
