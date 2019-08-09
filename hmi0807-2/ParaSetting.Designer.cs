namespace hmi0807_2
{
    partial class ParaSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.kvButton1.KVMemAddr = "MR2000";
            this.kvButton1.KVReadOnly = false;
            this.kvButton1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvButton1.KVType = KVControl.KVType.Light;
            this.kvButton1.Location = new System.Drawing.Point(188, 88);
            this.kvButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kvButton1.Name = "kvButton1";
            this.kvButton1.Size = new System.Drawing.Size(78, 36);
            this.kvButton1.TabIndex = 0;
            this.kvButton1.Text = "抬起";
            this.kvButton1.KVTags[0] = new KVDrive.BoolTag(2, KVDrive.Storage.Empty, kvButton1.KVMemAddr);
            this.kvButton1.UseVisualStyleBackColor = true;
            // 
            // kvText1
            // 
            this.kvText1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvText1.KVMemAddr = "EM2000";
            this.kvText1.KVReadOnly = false;
            this.kvText1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvText1.KVType = KVControl.KVType.NumberInput;
            this.kvText1.Location = new System.Drawing.Point(330, 87);
            this.kvText1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kvText1.Name = "kvText1";
            this.kvText1.Size = new System.Drawing.Size(87, 37);
            this.kvText1.TabIndex = 1;
            this.kvText1.Text = this.kvText1.KVMemAddr;
            this.kvText1.KVTags[0] = new KVDrive.FloatTag(1, KVDrive.Storage.Empty, kvText1.KVMemAddr);
            this.kvText1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 222);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ParaSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kvText1);
            this.Controls.Add(this.kvButton1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ParaSetting";
            this.Text = "ParaSetting";
            this.Load += new System.EventHandler(this.ParaSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KVControl.KVButton kvButton1;
        private KVControl.KVText kvText1;
        private System.Windows.Forms.Button button1;
    }
}