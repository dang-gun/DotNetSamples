
namespace SelfHost
{
    partial class MainForm
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnChrome = new System.Windows.Forms.Button();
            this.btnMsEdge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(213, 23);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://localhost:5000/";
            // 
            // btnChrome
            // 
            this.btnChrome.Location = new System.Drawing.Point(12, 41);
            this.btnChrome.Name = "btnChrome";
            this.btnChrome.Size = new System.Drawing.Size(100, 50);
            this.btnChrome.TabIndex = 1;
            this.btnChrome.Text = "크롬 열기";
            this.btnChrome.UseVisualStyleBackColor = true;
            this.btnChrome.Click += new System.EventHandler(this.btnChrome_Click);
            // 
            // btnMsEdge
            // 
            this.btnMsEdge.Location = new System.Drawing.Point(125, 41);
            this.btnMsEdge.Name = "btnMsEdge";
            this.btnMsEdge.Size = new System.Drawing.Size(100, 50);
            this.btnMsEdge.TabIndex = 2;
            this.btnMsEdge.Text = "엣지 열기";
            this.btnMsEdge.UseVisualStyleBackColor = true;
            this.btnMsEdge.Click += new System.EventHandler(this.btnMsEdge_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 104);
            this.Controls.Add(this.btnMsEdge);
            this.Controls.Add(this.btnChrome);
            this.Controls.Add(this.txtUrl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnChrome;
        private System.Windows.Forms.Button btnMsEdge;
    }
}

