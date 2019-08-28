namespace hmi0807_2
{
    partial class Home
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.kvButton1 = new KVControl.KVButton();
            this.kvFloatText1 = new KVControl.KVFloatText();
            this.kvFloatText2 = new KVControl.KVFloatText();
            this.kvFloatText3 = new KVControl.KVFloatText();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "参数设定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // kvButton1
            // 
            this.kvButton1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvButton1.KVMemAddr = "M1000";
            this.kvButton1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvButton1.Location = new System.Drawing.Point(124, 66);
            this.kvButton1.Name = "kvButton1";
            this.kvButton1.Size = new System.Drawing.Size(75, 23);
            this.kvButton1.TabIndex = 3;
            this.kvButton1.Text = "kvButton1";
            this.kvButton1.UseVisualStyleBackColor = true;
            // 
            // kvFloatText1
            // 
            this.kvFloatText1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvFloatText1.KVMemAddr = "D1000";
            this.kvFloatText1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvFloatText1.Location = new System.Drawing.Point(335, 66);
            this.kvFloatText1.Name = "kvFloatText1";
            this.kvFloatText1.Size = new System.Drawing.Size(100, 21);
            this.kvFloatText1.TabIndex = 4;
            // 
            // kvFloatText2
            // 
            this.kvFloatText2.KVFalseColor = System.Drawing.Color.Empty;
            this.kvFloatText2.KVMemAddr = "D2000";
            this.kvFloatText2.KVTrueColor = System.Drawing.Color.Empty;
            this.kvFloatText2.Location = new System.Drawing.Point(335, 118);
            this.kvFloatText2.Name = "kvFloatText2";
            this.kvFloatText2.Size = new System.Drawing.Size(100, 21);
            this.kvFloatText2.TabIndex = 5;
            // 
            // kvFloatText3
            // 
            this.kvFloatText3.KVFalseColor = System.Drawing.Color.Empty;
            this.kvFloatText3.KVMemAddr = "D3000";
            this.kvFloatText3.KVTrueColor = System.Drawing.Color.Empty;
            this.kvFloatText3.Location = new System.Drawing.Point(335, 189);
            this.kvFloatText3.Name = "kvFloatText3";
            this.kvFloatText3.Size = new System.Drawing.Size(100, 21);
            this.kvFloatText3.TabIndex = 6;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.kvFloatText3);
            this.Controls.Add(this.kvFloatText2);
            this.Controls.Add(this.kvFloatText1);
            this.Controls.Add(this.kvButton1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button button1;

        private KVControl.KVButton kvButton1;
        private KVControl.KVFloatText kvFloatText1;
        private KVControl.KVFloatText kvFloatText2;
        private KVControl.KVFloatText kvFloatText3;
    }
}

