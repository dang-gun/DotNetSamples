﻿
namespace Localize_WinFormsResourceShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnKorean = new System.Windows.Forms.Button();
            this.btnReStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnEnglish
            // 
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnKorean
            // 
            resources.ApplyResources(this.btnKorean, "btnKorean");
            this.btnKorean.Name = "btnKorean";
            this.btnKorean.UseVisualStyleBackColor = true;
            this.btnKorean.Click += new System.EventHandler(this.btnKorean_Click);
            // 
            // btnReStart
            // 
            resources.ApplyResources(this.btnReStart, "btnReStart");
            this.btnReStart.Name = "btnReStart";
            this.btnReStart.UseVisualStyleBackColor = true;
            this.btnReStart.Click += new System.EventHandler(this.btnReStart_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReStart);
            this.Controls.Add(this.btnKorean);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnKorean;
        private System.Windows.Forms.Button btnReStart;
    }
}

