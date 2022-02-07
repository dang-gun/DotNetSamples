
namespace ClassToJson
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTestData001_Save = new System.Windows.Forms.Button();
            this.btnTestData001_Load = new System.Windows.Forms.Button();
            this.btnTestData002_Save = new System.Windows.Forms.Button();
            this.btnTestData002_Load = new System.Windows.Forms.Button();
            this.txtStrData1 = new System.Windows.Forms.TextBox();
            this.txtStrData2 = new System.Windows.Forms.TextBox();
            this.numericIntData1 = new System.Windows.Forms.NumericUpDown();
            this.numericIntData2 = new System.Windows.Forms.NumericUpDown();
            this.btnTestData001_View = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtDoubleData = new System.Windows.Forms.TextBox();
            this.txtFloatData = new System.Windows.Forms.TextBox();
            this.numericTypeTest1 = new System.Windows.Forms.NumericUpDown();
            this.numericTypeTest2 = new System.Windows.Forms.NumericUpDown();
            this.btnbtnTestData002_View = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntData1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntData2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeTest2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestData001_Save
            // 
            this.btnTestData001_Save.Location = new System.Drawing.Point(12, 12);
            this.btnTestData001_Save.Name = "btnTestData001_Save";
            this.btnTestData001_Save.Size = new System.Drawing.Size(162, 23);
            this.btnTestData001_Save.TabIndex = 0;
            this.btnTestData001_Save.Text = "TestData001 Save";
            this.btnTestData001_Save.UseVisualStyleBackColor = true;
            this.btnTestData001_Save.Click += new System.EventHandler(this.BtnTestData001_Save_Click);
            // 
            // btnTestData001_Load
            // 
            this.btnTestData001_Load.Location = new System.Drawing.Point(12, 41);
            this.btnTestData001_Load.Name = "btnTestData001_Load";
            this.btnTestData001_Load.Size = new System.Drawing.Size(162, 23);
            this.btnTestData001_Load.TabIndex = 1;
            this.btnTestData001_Load.Text = "TestData001 Load";
            this.btnTestData001_Load.UseVisualStyleBackColor = true;
            this.btnTestData001_Load.Click += new System.EventHandler(this.BtnTestData001_Load_Click);
            // 
            // btnTestData002_Save
            // 
            this.btnTestData002_Save.Location = new System.Drawing.Point(198, 12);
            this.btnTestData002_Save.Name = "btnTestData002_Save";
            this.btnTestData002_Save.Size = new System.Drawing.Size(162, 23);
            this.btnTestData002_Save.TabIndex = 2;
            this.btnTestData002_Save.Text = "TestData002 Save";
            this.btnTestData002_Save.UseVisualStyleBackColor = true;
            this.btnTestData002_Save.Click += new System.EventHandler(this.BtnTestData002_Save_Click);
            // 
            // btnTestData002_Load
            // 
            this.btnTestData002_Load.Location = new System.Drawing.Point(198, 41);
            this.btnTestData002_Load.Name = "btnTestData002_Load";
            this.btnTestData002_Load.Size = new System.Drawing.Size(162, 23);
            this.btnTestData002_Load.TabIndex = 3;
            this.btnTestData002_Load.Text = "TestData002 Load";
            this.btnTestData002_Load.UseVisualStyleBackColor = true;
            this.btnTestData002_Load.Click += new System.EventHandler(this.BtnTestData002_Load_Click);
            // 
            // txtStrData1
            // 
            this.txtStrData1.Location = new System.Drawing.Point(12, 126);
            this.txtStrData1.Name = "txtStrData1";
            this.txtStrData1.Size = new System.Drawing.Size(162, 21);
            this.txtStrData1.TabIndex = 4;
            this.txtStrData1.Text = "StrData1";
            // 
            // txtStrData2
            // 
            this.txtStrData2.Location = new System.Drawing.Point(12, 153);
            this.txtStrData2.Name = "txtStrData2";
            this.txtStrData2.Size = new System.Drawing.Size(162, 21);
            this.txtStrData2.TabIndex = 4;
            this.txtStrData2.Text = "StrData2";
            // 
            // numericIntData1
            // 
            this.numericIntData1.Location = new System.Drawing.Point(12, 180);
            this.numericIntData1.Name = "numericIntData1";
            this.numericIntData1.Size = new System.Drawing.Size(162, 21);
            this.numericIntData1.TabIndex = 5;
            // 
            // numericIntData2
            // 
            this.numericIntData2.Location = new System.Drawing.Point(12, 207);
            this.numericIntData2.Name = "numericIntData2";
            this.numericIntData2.Size = new System.Drawing.Size(162, 21);
            this.numericIntData2.TabIndex = 5;
            // 
            // btnTestData001_View
            // 
            this.btnTestData001_View.Location = new System.Drawing.Point(12, 70);
            this.btnTestData001_View.Name = "btnTestData001_View";
            this.btnTestData001_View.Size = new System.Drawing.Size(162, 23);
            this.btnTestData001_View.TabIndex = 1;
            this.btnTestData001_View.Text = "TestData001 View";
            this.btnTestData001_View.UseVisualStyleBackColor = true;
            this.btnTestData001_View.Click += new System.EventHandler(this.BtnTestData001_View_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 248);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(348, 190);
            this.txtOutput.TabIndex = 6;
            // 
            // txtDoubleData
            // 
            this.txtDoubleData.Location = new System.Drawing.Point(198, 126);
            this.txtDoubleData.Name = "txtDoubleData";
            this.txtDoubleData.Size = new System.Drawing.Size(162, 21);
            this.txtDoubleData.TabIndex = 4;
            this.txtDoubleData.Text = "12.23";
            // 
            // txtFloatData
            // 
            this.txtFloatData.Location = new System.Drawing.Point(198, 153);
            this.txtFloatData.Name = "txtFloatData";
            this.txtFloatData.Size = new System.Drawing.Size(162, 21);
            this.txtFloatData.TabIndex = 4;
            this.txtFloatData.Text = "24.36";
            // 
            // numericTypeTest1
            // 
            this.numericTypeTest1.Location = new System.Drawing.Point(198, 180);
            this.numericTypeTest1.Name = "numericTypeTest1";
            this.numericTypeTest1.Size = new System.Drawing.Size(162, 21);
            this.numericTypeTest1.TabIndex = 5;
            this.numericTypeTest1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericTypeTest2
            // 
            this.numericTypeTest2.Location = new System.Drawing.Point(198, 207);
            this.numericTypeTest2.Name = "numericTypeTest2";
            this.numericTypeTest2.Size = new System.Drawing.Size(162, 21);
            this.numericTypeTest2.TabIndex = 5;
            this.numericTypeTest2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnbtnTestData002_View
            // 
            this.btnbtnTestData002_View.Location = new System.Drawing.Point(198, 70);
            this.btnbtnTestData002_View.Name = "btnbtnTestData002_View";
            this.btnbtnTestData002_View.Size = new System.Drawing.Size(162, 23);
            this.btnbtnTestData002_View.TabIndex = 1;
            this.btnbtnTestData002_View.Text = "TestData001 View";
            this.btnbtnTestData002_View.UseVisualStyleBackColor = true;
            this.btnbtnTestData002_View.Click += new System.EventHandler(this.BtnbtnTestData002_View_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 445);
            this.Controls.Add(this.numericTypeTest2);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.numericTypeTest1);
            this.Controls.Add(this.numericIntData2);
            this.Controls.Add(this.txtFloatData);
            this.Controls.Add(this.numericIntData1);
            this.Controls.Add(this.txtDoubleData);
            this.Controls.Add(this.txtStrData2);
            this.Controls.Add(this.txtStrData1);
            this.Controls.Add(this.btnTestData002_Load);
            this.Controls.Add(this.btnTestData002_Save);
            this.Controls.Add(this.btnbtnTestData002_View);
            this.Controls.Add(this.btnTestData001_View);
            this.Controls.Add(this.btnTestData001_Load);
            this.Controls.Add(this.btnTestData001_Save);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericIntData1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntData2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeTest2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestData001_Save;
        private System.Windows.Forms.Button btnTestData001_Load;
        private System.Windows.Forms.Button btnTestData002_Save;
        private System.Windows.Forms.Button btnTestData002_Load;
        private System.Windows.Forms.TextBox txtStrData1;
        private System.Windows.Forms.TextBox txtStrData2;
        private System.Windows.Forms.NumericUpDown numericIntData1;
        private System.Windows.Forms.NumericUpDown numericIntData2;
        private System.Windows.Forms.Button btnTestData001_View;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtDoubleData;
        private System.Windows.Forms.TextBox txtFloatData;
        private System.Windows.Forms.NumericUpDown numericTypeTest1;
        private System.Windows.Forms.NumericUpDown numericTypeTest2;
        private System.Windows.Forms.Button btnbtnTestData002_View;
    }
}

