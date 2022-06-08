namespace StopwatchTimerTest
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labTimer = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labStopwatch = new System.Windows.Forms.Label();
			this.btn10Sec = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labTimer);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 100);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Timer";
			// 
			// labTimer
			// 
			this.labTimer.AutoSize = true;
			this.labTimer.Location = new System.Drawing.Point(6, 20);
			this.labTimer.Name = "labTimer";
			this.labTimer.Size = new System.Drawing.Size(39, 15);
			this.labTimer.TabIndex = 0;
			this.labTimer.Text = "label1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labStopwatch);
			this.groupBox2.Location = new System.Drawing.Point(244, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 100);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Stopwatch";
			// 
			// labStopwatch
			// 
			this.labStopwatch.AutoSize = true;
			this.labStopwatch.Location = new System.Drawing.Point(6, 20);
			this.labStopwatch.Name = "labStopwatch";
			this.labStopwatch.Size = new System.Drawing.Size(39, 15);
			this.labStopwatch.TabIndex = 0;
			this.labStopwatch.Text = "label2";
			// 
			// btn10Sec
			// 
			this.btn10Sec.Location = new System.Drawing.Point(12, 145);
			this.btn10Sec.Name = "btn10Sec";
			this.btn10Sec.Size = new System.Drawing.Size(157, 23);
			this.btn10Sec.TabIndex = 3;
			this.btn10Sec.Text = "10초 진행";
			this.btn10Sec.UseVisualStyleBackColor = true;
			this.btn10Sec.Click += new System.EventHandler(this.btn10Sec_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 261);
			this.Controls.Add(this.btn10Sec);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Button btn10Sec;
		private Label labTimer;
		private Label labStopwatch;
	}
}