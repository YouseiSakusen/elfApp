namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	partial class PluginForm
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
			this.pnlButton = new net.elfmission.WindowsApps.Controls.elfPanel();
			this.btnOk = new net.elfmission.WindowsApps.Controls.elfButton();
			this.btnCancel = new net.elfmission.WindowsApps.Controls.elfButton();
			this.pnlBody = new net.elfmission.WindowsApps.Controls.elfDynamicViewContainerPanel();
			this.pnlButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlButton
			// 
			this.pnlButton.Controls.Add(this.btnOk);
			this.pnlButton.Controls.Add(this.btnCancel);
			this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButton.Location = new System.Drawing.Point(0, 390);
			this.pnlButton.Name = "pnlButton";
			this.pnlButton.Size = new System.Drawing.Size(624, 51);
			this.pnlButton.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(432, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(87, 26);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(525, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 26);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlBody
			// 
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 0);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(8);
			this.pnlBody.Size = new System.Drawing.Size(624, 390);
			this.pnlBody.TabIndex = 1;
			this.pnlBody.WantDynamicView += new net.elfmission.WindowsApps.Controls.WantDynamicViewEventHandler(this.pnlBody_WantDynamicView);
			// 
			// PluginForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginForm";
			this.Load += new System.EventHandler(this.PluginForm_Load);
			this.pnlButton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.elfPanel pnlButton;
		private Controls.elfButton btnOk;
		private Controls.elfButton btnCancel;
		private Controls.elfDynamicViewContainerPanel pnlBody;
	}
}
