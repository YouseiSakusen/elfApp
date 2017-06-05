namespace net.elfmission.WindowsApps.Controls.Designs
{
    partial class TargetExtensionEditorControl
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.chkBitmap = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkJpeg = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkPng = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkGif = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.SuspendLayout();
			// 
			// chkBitmap
			// 
			this.chkBitmap.AutoSize = true;
			this.chkBitmap.Location = new System.Drawing.Point(3, 12);
			this.chkBitmap.Name = "chkBitmap";
			this.chkBitmap.Size = new System.Drawing.Size(60, 16);
			this.chkBitmap.TabIndex = 0;
			this.chkBitmap.Text = "Bitmap";
			this.chkBitmap.UseVisualStyleBackColor = true;
			this.chkBitmap.CheckedChanged += new System.EventHandler(this.checkBox_CheckdChanged);
			// 
			// chkJpeg
			// 
			this.chkJpeg.AutoSize = true;
			this.chkJpeg.Location = new System.Drawing.Point(3, 44);
			this.chkJpeg.Name = "chkJpeg";
			this.chkJpeg.Size = new System.Drawing.Size(49, 16);
			this.chkJpeg.TabIndex = 1;
			this.chkJpeg.Text = "Jpeg";
			this.chkJpeg.UseVisualStyleBackColor = true;
			this.chkJpeg.CheckedChanged += new System.EventHandler(this.checkBox_CheckdChanged);
			// 
			// chkPng
			// 
			this.chkPng.AutoSize = true;
			this.chkPng.Location = new System.Drawing.Point(3, 76);
			this.chkPng.Name = "chkPng";
			this.chkPng.Size = new System.Drawing.Size(47, 16);
			this.chkPng.TabIndex = 2;
			this.chkPng.Text = "PNG";
			this.chkPng.UseVisualStyleBackColor = true;
			this.chkPng.CheckedChanged += new System.EventHandler(this.checkBox_CheckdChanged);
			// 
			// chkGif
			// 
			this.chkGif.AutoSize = true;
			this.chkGif.Location = new System.Drawing.Point(3, 108);
			this.chkGif.Name = "chkGif";
			this.chkGif.Size = new System.Drawing.Size(42, 16);
			this.chkGif.TabIndex = 3;
			this.chkGif.Text = "GIF";
			this.chkGif.UseVisualStyleBackColor = true;
			this.chkGif.CheckedChanged += new System.EventHandler(this.checkBox_CheckdChanged);
			// 
			// TargetExtensionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.Controls.Add(this.chkGif);
			this.Controls.Add(this.chkPng);
			this.Controls.Add(this.chkJpeg);
			this.Controls.Add(this.chkBitmap);
			this.Name = "TargetExtensionEditor";
			this.Size = new System.Drawing.Size(114, 137);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private elfCheckBox chkBitmap;
        private elfCheckBox chkJpeg;
        private elfCheckBox chkPng;
        private elfCheckBox chkGif;
    }
}
