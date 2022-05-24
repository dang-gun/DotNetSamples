namespace SoundPlayerTest
{
	partial class frmSoundPlayerTest
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSoundPlay_Stop = new System.Windows.Forms.Button();
			this.btnSoundPlay_Double = new System.Windows.Forms.Button();
			this.btnSoundPlay_One = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnMciSend_Reset = new System.Windows.Forms.Button();
			this.btnMciSend_Stop = new System.Windows.Forms.Button();
			this.btnMciSend_DoubleRestart = new System.Windows.Forms.Button();
			this.btnMciSend_Double = new System.Windows.Forms.Button();
			this.btnMciSend_One = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSoundPlay_Stop);
			this.groupBox1.Controls.Add(this.btnSoundPlay_Double);
			this.groupBox1.Controls.Add(this.btnSoundPlay_One);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(161, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SoundPlay";
			// 
			// btnSoundPlay_Stop
			// 
			this.btnSoundPlay_Stop.Location = new System.Drawing.Point(6, 138);
			this.btnSoundPlay_Stop.Name = "btnSoundPlay_Stop";
			this.btnSoundPlay_Stop.Size = new System.Drawing.Size(150, 23);
			this.btnSoundPlay_Stop.TabIndex = 2;
			this.btnSoundPlay_Stop.Text = "Stop";
			this.btnSoundPlay_Stop.UseVisualStyleBackColor = true;
			this.btnSoundPlay_Stop.Click += new System.EventHandler(this.btnSoundPlay_Stop_Click);
			// 
			// btnSoundPlay_Double
			// 
			this.btnSoundPlay_Double.Location = new System.Drawing.Point(5, 51);
			this.btnSoundPlay_Double.Name = "btnSoundPlay_Double";
			this.btnSoundPlay_Double.Size = new System.Drawing.Size(150, 23);
			this.btnSoundPlay_Double.TabIndex = 1;
			this.btnSoundPlay_Double.Text = "Double";
			this.btnSoundPlay_Double.UseVisualStyleBackColor = true;
			this.btnSoundPlay_Double.Click += new System.EventHandler(this.btnSoundPlay_Double_Click);
			// 
			// btnSoundPlay_One
			// 
			this.btnSoundPlay_One.Location = new System.Drawing.Point(6, 22);
			this.btnSoundPlay_One.Name = "btnSoundPlay_One";
			this.btnSoundPlay_One.Size = new System.Drawing.Size(150, 23);
			this.btnSoundPlay_One.TabIndex = 0;
			this.btnSoundPlay_One.Text = "One";
			this.btnSoundPlay_One.UseVisualStyleBackColor = true;
			this.btnSoundPlay_One.Click += new System.EventHandler(this.btnSoundPlay_One_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnMciSend_Reset);
			this.groupBox2.Controls.Add(this.btnMciSend_Stop);
			this.groupBox2.Controls.Add(this.btnMciSend_DoubleRestart);
			this.groupBox2.Controls.Add(this.btnMciSend_Double);
			this.groupBox2.Controls.Add(this.btnMciSend_One);
			this.groupBox2.Location = new System.Drawing.Point(191, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(164, 209);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "mciSendString";
			// 
			// btnMciSend_Reset
			// 
			this.btnMciSend_Reset.Location = new System.Drawing.Point(6, 167);
			this.btnMciSend_Reset.Name = "btnMciSend_Reset";
			this.btnMciSend_Reset.Size = new System.Drawing.Size(150, 23);
			this.btnMciSend_Reset.TabIndex = 2;
			this.btnMciSend_Reset.Text = "Reset";
			this.btnMciSend_Reset.UseVisualStyleBackColor = true;
			this.btnMciSend_Reset.Click += new System.EventHandler(this.btnMciSend_Reset_Click);
			// 
			// btnMciSend_Stop
			// 
			this.btnMciSend_Stop.Location = new System.Drawing.Point(6, 138);
			this.btnMciSend_Stop.Name = "btnMciSend_Stop";
			this.btnMciSend_Stop.Size = new System.Drawing.Size(150, 23);
			this.btnMciSend_Stop.TabIndex = 2;
			this.btnMciSend_Stop.Text = "Stop";
			this.btnMciSend_Stop.UseVisualStyleBackColor = true;
			this.btnMciSend_Stop.Click += new System.EventHandler(this.btnMciSend_Stop_Click);
			// 
			// btnMciSend_DoubleRestart
			// 
			this.btnMciSend_DoubleRestart.Location = new System.Drawing.Point(6, 80);
			this.btnMciSend_DoubleRestart.Name = "btnMciSend_DoubleRestart";
			this.btnMciSend_DoubleRestart.Size = new System.Drawing.Size(150, 23);
			this.btnMciSend_DoubleRestart.TabIndex = 1;
			this.btnMciSend_DoubleRestart.Text = "Double Restart";
			this.btnMciSend_DoubleRestart.UseVisualStyleBackColor = true;
			this.btnMciSend_DoubleRestart.Click += new System.EventHandler(this.btnMciSend_DoubleRestart_Click);
			// 
			// btnMciSend_Double
			// 
			this.btnMciSend_Double.Location = new System.Drawing.Point(6, 51);
			this.btnMciSend_Double.Name = "btnMciSend_Double";
			this.btnMciSend_Double.Size = new System.Drawing.Size(150, 23);
			this.btnMciSend_Double.TabIndex = 0;
			this.btnMciSend_Double.Text = "Double";
			this.btnMciSend_Double.UseVisualStyleBackColor = true;
			this.btnMciSend_Double.Click += new System.EventHandler(this.btnMciSend_Double_Click);
			// 
			// btnMciSend_One
			// 
			this.btnMciSend_One.Location = new System.Drawing.Point(6, 22);
			this.btnMciSend_One.Name = "btnMciSend_One";
			this.btnMciSend_One.Size = new System.Drawing.Size(150, 23);
			this.btnMciSend_One.TabIndex = 0;
			this.btnMciSend_One.Text = "One";
			this.btnMciSend_One.UseVisualStyleBackColor = true;
			this.btnMciSend_One.Click += new System.EventHandler(this.btnMciSend_One_Click);
			// 
			// frmSoundPlayerTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 229);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmSoundPlayerTest";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox1;
		private Button btnSoundPlay_Double;
		private Button btnSoundPlay_One;
		private GroupBox groupBox2;
		private Button btnMciSend_Double;
		private Button btnMciSend_One;
		private Button btnSoundPlay_Stop;
		private Button btnMciSend_DoubleRestart;
		private Button btnMciSend_Reset;
		private Button btnMciSend_Stop;
	}
}