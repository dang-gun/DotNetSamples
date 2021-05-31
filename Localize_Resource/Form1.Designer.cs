
namespace Localize_Resource
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
            this.btnKorean = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKorean
            // 
            this.btnKorean.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnKorean.Location = new System.Drawing.Point(12, 78);
            this.btnKorean.Name = "btnKorean";
            this.btnKorean.Size = new System.Drawing.Size(75, 23);
            this.btnKorean.TabIndex = 8;
            this.btnKorean.Text = "Korean";
            this.btnKorean.UseVisualStyleBackColor = true;
            this.btnKorean.Click += new System.EventHandler(this.btnKorean_Click);
            // 
            // btnEnglish
            // 
            this.btnEnglish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnglish.Location = new System.Drawing.Point(12, 49);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(75, 23);
            this.btnEnglish.TabIndex = 7;
            this.btnEnglish.Text = "English";
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pineapple";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Apple";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 140);
            this.Controls.Add(this.btnKorean);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKorean;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

