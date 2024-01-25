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
            tsmiConfig_ViewOrientation = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            cameraIndexToolStripMenuItem = new ToolStripMenuItem();
            tstxtCameraIndex = new ToolStripTextBox();
            toolStripMenuItem5 = new ToolStripSeparator();
            cameraSizeToolStripMenuItem = new ToolStripMenuItem();
            tstxtCameraSize_Width = new ToolStripTextBox();
            tstxtCameraSize_Height = new ToolStripTextBox();
            toolStripMenuItem6 = new ToolStripSeparator();
            tsmiCamera_Capture = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            tsmiCalibration_SelectFile = new ToolStripMenuItem();
            tsmiCalibration_CameraCapture = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            chessBoardToolStripMenuItem1 = new ToolStripMenuItem();
            tstxtChessBoardWidth = new ToolStripTextBox();
            tstxtChessBoardHeight = new ToolStripTextBox();
            toolStripMenuItem2 = new ToolStripSeparator();
            tsmiCalibration_RadialDistortionCheck = new ToolStripMenuItem();
            tsmiCalibration_RadialDistortionApply = new ToolStripMenuItem();
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
            // tsmiConfig_ViewOrientation
            // 
            tsmiConfig_ViewOrientation.Name = "tsmiConfig_ViewOrientation";
            tsmiConfig_ViewOrientation.Size = new Size(168, 22);
            tsmiConfig_ViewOrientation.Text = "View  Orientation";
            tsmiConfig_ViewOrientation.Click += tsmiConfig_ViewOrientation_Click;
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cameraIndexToolStripMenuItem, tstxtCameraIndex, toolStripMenuItem5, cameraSizeToolStripMenuItem, tstxtCameraSize_Width, tstxtCameraSize_Height, toolStripMenuItem6, tsmiCamera_Capture });
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(60, 20);
            cameraToolStripMenuItem.Text = "Camera";
            // 
            // cameraIndexToolStripMenuItem
            // 
            cameraIndexToolStripMenuItem.Name = "cameraIndexToolStripMenuItem";
            cameraIndexToolStripMenuItem.Size = new Size(161, 22);
            cameraIndexToolStripMenuItem.Text = "Camera Index";
            // 
            // tstxtCameraIndex
            // 
            tstxtCameraIndex.Name = "tstxtCameraIndex";
            tstxtCameraIndex.Size = new Size(100, 23);
            tstxtCameraIndex.Text = "0";
            tstxtCameraIndex.TextChanged += tstxtCameraIndex_TextChanged;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(158, 6);
            // 
            // cameraSizeToolStripMenuItem
            // 
            cameraSizeToolStripMenuItem.Name = "cameraSizeToolStripMenuItem";
            cameraSizeToolStripMenuItem.Size = new Size(161, 22);
            cameraSizeToolStripMenuItem.Text = "Camera Size";
            // 
            // tstxtCameraSize_Width
            // 
            tstxtCameraSize_Width.Name = "tstxtCameraSize_Width";
            tstxtCameraSize_Width.Size = new Size(100, 23);
            tstxtCameraSize_Width.Text = "1980";
            tstxtCameraSize_Width.TextChanged += tstxtCameraSize_Width_TextChanged;
            // 
            // tstxtCameraSize_Height
            // 
            tstxtCameraSize_Height.Name = "tstxtCameraSize_Height";
            tstxtCameraSize_Height.Size = new Size(100, 23);
            tstxtCameraSize_Height.Text = "1080";
            tstxtCameraSize_Height.TextChanged += tstxtCameraSize_Height_TextChanged;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(158, 6);
            // 
            // tsmiCamera_Capture
            // 
            tsmiCamera_Capture.Name = "tsmiCamera_Capture";
            tsmiCamera_Capture.Size = new Size(161, 22);
            tsmiCamera_Capture.Text = "Camera Capture";
            tsmiCamera_Capture.Click += tsmiCamera_Capture_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiCalibration_SelectFile, tsmiCalibration_CameraCapture, toolStripMenuItem1, chessBoardToolStripMenuItem1, tstxtChessBoardWidth, tstxtChessBoardHeight, toolStripMenuItem2, tsmiCalibration_RadialDistortionCheck, tsmiCalibration_RadialDistortionApply, toolStripMenuItem3, tsmiRadialDistortionFileSaveXml, tsmiRadialDistortionFileSaveYml, tsmiRadialDistortionFileSaveJson, toolStripMenuItem4, tsmiRadialDistortionFileLoadXml, tsmiRadialDistortionFileLoadYml, tsmiRadialDistortionFileLoadJson });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(77, 20);
            imageToolStripMenuItem.Text = "Calibration";
            // 
            // tsmiCalibration_SelectFile
            // 
            tsmiCalibration_SelectFile.Name = "tsmiCalibration_SelectFile";
            tsmiCalibration_SelectFile.Size = new Size(252, 22);
            tsmiCalibration_SelectFile.Text = "Select File";
            tsmiCalibration_SelectFile.Click += tsmiCalibration_SelectFile_Click;
            // 
            // tsmiCalibration_CameraCapture
            // 
            tsmiCalibration_CameraCapture.Name = "tsmiCalibration_CameraCapture";
            tsmiCalibration_CameraCapture.Size = new Size(252, 22);
            tsmiCalibration_CameraCapture.Text = "Camera Capture";
            tsmiCalibration_CameraCapture.Click += tsmiCalibration_CameraCapture_Click;
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
            // tsmiCalibration_RadialDistortionCheck
            // 
            tsmiCalibration_RadialDistortionCheck.Name = "tsmiCalibration_RadialDistortionCheck";
            tsmiCalibration_RadialDistortionCheck.Size = new Size(252, 22);
            tsmiCalibration_RadialDistortionCheck.Text = "Radial Distortion Check";
            tsmiCalibration_RadialDistortionCheck.Click += tsmiCalibration_RadialDistortionCheck_Click;
            // 
            // tsmiCalibration_RadialDistortionApply
            // 
            tsmiCalibration_RadialDistortionApply.Name = "tsmiCalibration_RadialDistortionApply";
            tsmiCalibration_RadialDistortionApply.Size = new Size(252, 22);
            tsmiCalibration_RadialDistortionApply.Text = "Radial Distortion Apply";
            tsmiCalibration_RadialDistortionApply.Click += tsmiCalibration_RadialDistortionApply_Click;
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
        private ToolStripMenuItem tsmiCalibration_SelectFile;
        private PictureBox pictureOriginal;
        private PictureBox pictureCalibrated;
        private ToolStripMenuItem conifgToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem chessBoardToolStripMenuItem1;
        private ToolStripTextBox tstxtChessBoardWidth;
        private ToolStripTextBox tstxtChessBoardHeight;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem tsmiCalibration_RadialDistortionCheck;
        private ToolStripMenuItem tsmiCalibration_RadialDistortionApply;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveXml;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveJson;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadXml;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadJson;
        private ToolStripMenuItem tsmiCalibration_CameraCapture;
        private ToolStripMenuItem tsmiRadialDistortionFileSaveYml;
        private ToolStripMenuItem tsmiRadialDistortionFileLoadYml;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private ToolStripMenuItem tsmiCamera_Capture;
        private ToolStripMenuItem cameraIndexToolStripMenuItem;
        private ToolStripTextBox tstxtCameraIndex;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem tsmiConfig_ViewOrientation;
        private ToolStripMenuItem cameraSizeToolStripMenuItem;
        private ToolStripTextBox tstxtCameraSize_Width;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripTextBox tstxtCameraSize_Height;
    }
}
