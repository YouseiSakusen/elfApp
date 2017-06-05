namespace net.elfmission.WindowsApps.ImageSplitter.Viewers
{
	partial class ViewerForm
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
			this.picView = new net.elfmission.WindowsApps.Controls.elfPictureBox();
			this.lblFileName = new net.elfmission.WindowsApps.Controls.elfLabel();
			((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
			this.SuspendLayout();
			// 
			// picView
			// 
			this.picView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picView.Location = new System.Drawing.Point(0, 0);
			this.picView.Name = "picView";
			this.picView.Size = new System.Drawing.Size(784, 561);
			this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picView.TabIndex = 2;
			this.picView.TabStop = false;
			this.picView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picView_MouseClick);
			// 
			// lblFileName
			// 
			this.lblFileName.BackColor = System.Drawing.Color.Black;
			this.lblFileName.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblFileName.Location = new System.Drawing.Point(243, 297);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(257, 21);
			this.lblFileName.TabIndex = 3;
			this.lblFileName.Text = "elfLabel1";
			// 
			// ViewerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.ControlBox = false;
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.picView);
			this.KeyPreview = true;
			this.Name = "ViewerForm";
			this.Text = "";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerForm_FormClosing);
			this.Load += new System.EventHandler(this.ViewerForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewerForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private Controls.elfPictureBox picView;
		private Controls.elfLabel lblFileName;
	}
}
