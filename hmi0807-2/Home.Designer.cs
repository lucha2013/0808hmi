﻿namespace hmi0807_2
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
            this.kvButton1 = new KVControl.KVButton();
            this.kvText1 = new KVControl.KVText();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kvButton1
            // 
            this.kvButton1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvButton1.KVMemAddr = null;
            this.kvButton1.KVReadOnly = false;
            this.kvButton1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvButton1.Location = new System.Drawing.Point(169, 105);
            this.kvButton1.Name = "kvButton1";
            this.kvButton1.Size = new System.Drawing.Size(92, 36);
            this.kvButton1.TabIndex = 0;
            this.kvButton1.Text = "kvButton1";
            this.kvButton1.UseVisualStyleBackColor = true;
            // 
            // kvText1
            // 
            this.kvText1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvText1.KVMemAddr = null;
            this.kvText1.KVReadOnly = false;
            this.kvText1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvText1.Location = new System.Drawing.Point(373, 105);
            this.kvText1.Name = "kvText1";
            this.kvText1.Size = new System.Drawing.Size(88, 36);
            this.kvText1.TabIndex = 1;
            this.kvText1.Text = "kvText1";
            this.kvText1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kvText1);
            this.Controls.Add(this.kvButton1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KVControl.KVButton kvButton1;
        private KVControl.KVText kvText1;
        private System.Windows.Forms.Button button1;
    }
}

