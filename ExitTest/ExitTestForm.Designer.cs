namespace ExitTest
{
	partial class ExitTestForm
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
			this.btnApplicationExit = new System.Windows.Forms.Button();
			this.btnEnvironmentExit = new System.Windows.Forms.Button();
			this.btnProcessKill = new System.Windows.Forms.Button();
			this.btnForegroundEnd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnApplicationExit
			// 
			this.btnApplicationExit.Location = new System.Drawing.Point(12, 12);
			this.btnApplicationExit.Name = "btnApplicationExit";
			this.btnApplicationExit.Size = new System.Drawing.Size(207, 23);
			this.btnApplicationExit.TabIndex = 0;
			this.btnApplicationExit.Text = "Application.Exit()";
			this.btnApplicationExit.UseVisualStyleBackColor = true;
			this.btnApplicationExit.Click += new System.EventHandler(this.btnApplicationExit_Click);
			// 
			// btnEnvironmentExit
			// 
			this.btnEnvironmentExit.Location = new System.Drawing.Point(12, 70);
			this.btnEnvironmentExit.Name = "btnEnvironmentExit";
			this.btnEnvironmentExit.Size = new System.Drawing.Size(207, 23);
			this.btnEnvironmentExit.TabIndex = 1;
			this.btnEnvironmentExit.Text = "Environment.Exit()";
			this.btnEnvironmentExit.UseVisualStyleBackColor = true;
			this.btnEnvironmentExit.Click += new System.EventHandler(this.btnEnvironmentExit_Click);
			// 
			// btnProcessKill
			// 
			this.btnProcessKill.Location = new System.Drawing.Point(12, 99);
			this.btnProcessKill.Name = "btnProcessKill";
			this.btnProcessKill.Size = new System.Drawing.Size(207, 23);
			this.btnProcessKill.TabIndex = 2;
			this.btnProcessKill.Text = "Process.GetCurrentProcess().Kill();";
			this.btnProcessKill.UseVisualStyleBackColor = true;
			this.btnProcessKill.Click += new System.EventHandler(this.btnProcessKill_Click);
			// 
			// btnForegroundEnd
			// 
			this.btnForegroundEnd.Location = new System.Drawing.Point(109, 41);
			this.btnForegroundEnd.Name = "btnForegroundEnd";
			this.btnForegroundEnd.Size = new System.Drawing.Size(110, 23);
			this.btnForegroundEnd.TabIndex = 3;
			this.btnForegroundEnd.Text = "Foreground End";
			this.btnForegroundEnd.UseVisualStyleBackColor = true;
			this.btnForegroundEnd.Click += new System.EventHandler(this.btnForegroundEnd_Click);
			// 
			// ExitTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(233, 147);
			this.Controls.Add(this.btnForegroundEnd);
			this.Controls.Add(this.btnProcessKill);
			this.Controls.Add(this.btnEnvironmentExit);
			this.Controls.Add(this.btnApplicationExit);
			this.Name = "ExitTestForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitTestForm_FormClosed);
			this.Load += new System.EventHandler(this.ExitTestForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Button btnApplicationExit;
		private Button btnEnvironmentExit;
		private Button btnProcessKill;
		private Button btnForegroundEnd;
	}
}