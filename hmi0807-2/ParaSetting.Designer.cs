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
            this.button1 = new System.Windows.Forms.Button();
            this.kvButton1 = new KVControl.KVButton();
            this.kvFloatText1 = new KVControl.KVFloatText();
            this.kvFloatText2 = new KVControl.KVFloatText();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 278);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // kvButton1
            // 
            this.kvButton1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvButton1.KVMemAddr = null;
            this.kvButton1.KVTags = new KVDrive.ITag[] {
        null};
            this.kvButton1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvButton1.Location = new System.Drawing.Point(251, 91);
            this.kvButton1.Name = "kvButton1";
            this.kvButton1.Size = new System.Drawing.Size(104, 44);
            this.kvButton1.TabIndex = 3;
            this.kvButton1.Text = "kvButton1";
            this.kvButton1.UseVisualStyleBackColor = true;
            // 
            // kvFloatText1
            // 
            this.kvFloatText1.KVFalseColor = System.Drawing.Color.Empty;
            this.kvFloatText1.KVMemAddr = null;
            this.kvFloatText1.KVTags = new KVDrive.ITag[] {
        null};
            this.kvFloatText1.KVTrueColor = System.Drawing.Color.Empty;
            this.kvFloatText1.Location = new System.Drawing.Point(476, 91);
            this.kvFloatText1.Name = "kvFloatText1";
            this.kvFloatText1.Size = new System.Drawing.Size(100, 25);
            this.kvFloatText1.TabIndex = 4;
            // 
            // kvFloatText2
            // 
            this.kvFloatText2.KVFalseColor = System.Drawing.Color.Empty;
            this.kvFloatText2.KVMemAddr = null;
            this.kvFloatText2.KVTags = new KVDrive.ITag[] {
        null};
            this.kvFloatText2.KVTrueColor = System.Drawing.Color.Empty;
            this.kvFloatText2.Location = new System.Drawing.Point(476, 158);
            this.kvFloatText2.Name = "kvFloatText2";
            this.kvFloatText2.Size = new System.Drawing.Size(100, 25);
            this.kvFloatText2.TabIndex = 5;
            // 
            // ParaSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kvFloatText2);
            this.Controls.Add(this.kvFloatText1);
            this.Controls.Add(this.kvButton1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ParaSetting";
            this.Text = "ParaSetting";
            this.Load += new System.EventHandler(this.ParaSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private KVControl.KVButton kvButton1;
        private KVControl.KVFloatText kvFloatText1;
        private KVControl.KVFloatText kvFloatText2;
    }
}