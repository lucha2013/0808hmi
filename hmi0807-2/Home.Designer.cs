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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "参数设定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // kvButton1
            // 
            this.kvButton1.KVFalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kvButton1.KVMemAddr = "M1000";
            this.kvButton1.KVTags = new KVDrive.ITag[] {
        null};
            this.kvButton1.KVTrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kvButton1.Location = new System.Drawing.Point(160, 88);
            this.kvButton1.Name = "kvButton1";
            this.kvButton1.Size = new System.Drawing.Size(105, 40);
            this.kvButton1.TabIndex = 3;
            this.kvButton1.Text = "kvButton1";
            this.kvButton1.UseVisualStyleBackColor = true;
            // 
            // kvFloatText1
            // 
            this.kvFloatText1.KVFalseColor = System.Drawing.Color.Red;
            this.kvFloatText1.KVMemAddr = "D1000";
            this.kvFloatText1.KVTags = new KVDrive.ITag[] {
        null};
            this.kvFloatText1.KVTrueColor = System.Drawing.Color.Black;
            this.kvFloatText1.Location = new System.Drawing.Point(364, 98);
            this.kvFloatText1.Name = "kvFloatText1";
            this.kvFloatText1.Size = new System.Drawing.Size(100, 25);
            this.kvFloatText1.TabIndex = 4;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kvFloatText1);
            this.Controls.Add(this.kvButton1);
            this.Controls.Add(this.button1);
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
    }
}

