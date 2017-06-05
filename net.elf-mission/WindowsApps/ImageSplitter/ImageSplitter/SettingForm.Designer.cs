namespace net.elfmission.WindowsApps.ImageSplitter
{
	partial class SettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblThumbColor = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.cmbThumbColor = new net.elfmission.WindowsApps.Controls.elfComboBox();
			this.cmbFileNamePosition = new net.elfmission.WindowsApps.Controls.elfComboBox();
			this.lblFileNamePosition = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.lblFileNameForeColor = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.btnColor = new net.elfmission.WindowsApps.Controls.elfButton();
			this.cdgColor = new System.Windows.Forms.ColorDialog();
			this.elfLabel1 = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.chkIsFowardLeft = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkCloseViewer = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkShowFinishMsg = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.chkSavePath = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.elfCheckBox1 = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.gbxMain = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.gbxViewer = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.gbxViewerOperation = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.gbxViewerFileName = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.lblViewerFileNameColor = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.gbxMain.SuspendLayout();
			this.gbxViewer.SuspendLayout();
			this.gbxViewerOperation.SuspendLayout();
			this.gbxViewerFileName.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblThumbColor
			// 
			resources.ApplyResources(this.lblThumbColor, "lblThumbColor");
			this.lblThumbColor.Name = "lblThumbColor";
			// 
			// cmbThumbColor
			// 
			resources.ApplyResources(this.cmbThumbColor, "cmbThumbColor");
			this.cmbThumbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbThumbColor.FormattingEnabled = true;
			this.cmbThumbColor.Name = "cmbThumbColor";
			this.cmbThumbColor.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbThumbColor_Format);
			// 
			// cmbFileNamePosition
			// 
			resources.ApplyResources(this.cmbFileNamePosition, "cmbFileNamePosition");
			this.cmbFileNamePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFileNamePosition.FormattingEnabled = true;
			this.cmbFileNamePosition.Name = "cmbFileNamePosition";
			this.cmbFileNamePosition.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbFileNamePosition_Format);
			// 
			// lblFileNamePosition
			// 
			resources.ApplyResources(this.lblFileNamePosition, "lblFileNamePosition");
			this.lblFileNamePosition.Name = "lblFileNamePosition";
			// 
			// lblFileNameForeColor
			// 
			resources.ApplyResources(this.lblFileNameForeColor, "lblFileNameForeColor");
			this.lblFileNameForeColor.Name = "lblFileNameForeColor";
			// 
			// btnColor
			// 
			resources.ApplyResources(this.btnColor, "btnColor");
			this.btnColor.Name = "btnColor";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// elfLabel1
			// 
			resources.ApplyResources(this.elfLabel1, "elfLabel1");
			this.elfLabel1.Name = "elfLabel1";
			// 
			// chkIsFowardLeft
			// 
			resources.ApplyResources(this.chkIsFowardLeft, "chkIsFowardLeft");
			this.chkIsFowardLeft.Checked = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.IsLeftUseForForward;
			this.chkIsFowardLeft.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIsFowardLeft.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "IsLeftUseForForward", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkIsFowardLeft.Name = "chkIsFowardLeft";
			this.chkIsFowardLeft.UseVisualStyleBackColor = true;
			// 
			// chkCloseViewer
			// 
			resources.ApplyResources(this.chkCloseViewer, "chkCloseViewer");
			this.chkCloseViewer.Checked = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.CloseViewerForm;
			this.chkCloseViewer.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "CloseViewerForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkCloseViewer.Name = "chkCloseViewer";
			this.chkCloseViewer.UseVisualStyleBackColor = true;
			// 
			// chkShowFinishMsg
			// 
			resources.ApplyResources(this.chkShowFinishMsg, "chkShowFinishMsg");
			this.chkShowFinishMsg.Checked = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.ShowFinishedMessage;
			this.chkShowFinishMsg.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowFinishMsg.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "ShowFinishedMessage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkShowFinishMsg.Name = "chkShowFinishMsg";
			this.chkShowFinishMsg.UseVisualStyleBackColor = true;
			// 
			// chkSavePath
			// 
			resources.ApplyResources(this.chkSavePath, "chkSavePath");
			this.chkSavePath.Checked = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.IsDefaultSelectAtLastFolder;
			this.chkSavePath.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSavePath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "IsDefaultSelectAtLastFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkSavePath.Name = "chkSavePath";
			this.chkSavePath.UseVisualStyleBackColor = true;
			// 
			// elfCheckBox1
			// 
			resources.ApplyResources(this.elfCheckBox1, "elfCheckBox1");
			this.elfCheckBox1.Checked = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.AskCloseForViewer;
			this.elfCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.elfCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "AskCloseForViewer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.elfCheckBox1.Name = "elfCheckBox1";
			this.elfCheckBox1.UseVisualStyleBackColor = true;
			// 
			// gbxMain
			// 
			resources.ApplyResources(this.gbxMain, "gbxMain");
			this.gbxMain.Controls.Add(this.chkSavePath);
			this.gbxMain.Controls.Add(this.lblThumbColor);
			this.gbxMain.Controls.Add(this.cmbThumbColor);
			this.gbxMain.Controls.Add(this.chkShowFinishMsg);
			this.gbxMain.Name = "gbxMain";
			this.gbxMain.TabStop = false;
			// 
			// gbxViewer
			// 
			resources.ApplyResources(this.gbxViewer, "gbxViewer");
			this.gbxViewer.Controls.Add(this.gbxViewerOperation);
			this.gbxViewer.Controls.Add(this.gbxViewerFileName);
			this.gbxViewer.Name = "gbxViewer";
			this.gbxViewer.TabStop = false;
			// 
			// gbxViewerOperation
			// 
			resources.ApplyResources(this.gbxViewerOperation, "gbxViewerOperation");
			this.gbxViewerOperation.Controls.Add(this.chkCloseViewer);
			this.gbxViewerOperation.Controls.Add(this.elfCheckBox1);
			this.gbxViewerOperation.Controls.Add(this.elfLabel1);
			this.gbxViewerOperation.Controls.Add(this.chkIsFowardLeft);
			this.gbxViewerOperation.Name = "gbxViewerOperation";
			this.gbxViewerOperation.TabStop = false;
			// 
			// gbxViewerFileName
			// 
			resources.ApplyResources(this.gbxViewerFileName, "gbxViewerFileName");
			this.gbxViewerFileName.Controls.Add(this.lblViewerFileNameColor);
			this.gbxViewerFileName.Controls.Add(this.lblFileNamePosition);
			this.gbxViewerFileName.Controls.Add(this.lblFileNameForeColor);
			this.gbxViewerFileName.Controls.Add(this.cmbFileNamePosition);
			this.gbxViewerFileName.Controls.Add(this.btnColor);
			this.gbxViewerFileName.Name = "gbxViewerFileName";
			this.gbxViewerFileName.TabStop = false;
			// 
			// lblViewerFileNameColor
			// 
			resources.ApplyResources(this.lblViewerFileNameColor, "lblViewerFileNameColor");
			this.lblViewerFileNameColor.BackColor = System.Drawing.Color.Black;
			this.lblViewerFileNameColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblViewerFileNameColor.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "ViewerFormFileNameColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.lblViewerFileNameColor.ForeColor = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.ViewerFormFileNameColor;
			this.lblViewerFileNameColor.Name = "lblViewerFileNameColor";
			// 
			// SettingForm
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.gbxViewer);
			this.Controls.Add(this.gbxMain);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingForm";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			this.gbxMain.ResumeLayout(false);
			this.gbxMain.PerformLayout();
			this.gbxViewer.ResumeLayout(false);
			this.gbxViewerOperation.ResumeLayout(false);
			this.gbxViewerOperation.PerformLayout();
			this.gbxViewerFileName.ResumeLayout(false);
			this.gbxViewerFileName.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.elfCheckBox chkSavePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
		private Controls.elfLabel lblThumbColor;
		private Controls.elfComboBox cmbThumbColor;
        private Controls.elfCheckBox chkShowFinishMsg;
		private Controls.elfComboBox cmbFileNamePosition;
		private Controls.elfLabel lblFileNamePosition;
		private Controls.elfLabel lblFileNameForeColor;
		private Controls.elfButton btnColor;
		private System.Windows.Forms.ColorDialog cdgColor;
		private Controls.elfCheckBox chkCloseViewer;
		private Controls.elfCheckBox chkIsFowardLeft;
		private Controls.elfLabel elfLabel1;
		private Controls.elfCheckBox elfCheckBox1;
		private Controls.elfGroupBox gbxMain;
		private Controls.elfGroupBox gbxViewer;
		private Controls.elfGroupBox gbxViewerOperation;
		private Controls.elfGroupBox gbxViewerFileName;
		private Controls.elfLabel lblViewerFileNameColor;
	}
}
