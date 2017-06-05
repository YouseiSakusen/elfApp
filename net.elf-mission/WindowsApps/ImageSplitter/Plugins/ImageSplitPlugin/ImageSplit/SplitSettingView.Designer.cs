namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	partial class SplitSettingView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitSettingView));
			this.txtSaveTo = new net.elfmission.WindowsApps.Controls.elfTextBox();
			this.btnRef = new net.elfmission.WindowsApps.Controls.elfButton();
			this.fbdSplit = new System.Windows.Forms.FolderBrowserDialog();
			this.chkCreateFolder = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.gbxUnselect = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.pnlUnselect = new net.elfmission.WindowsApps.Controls.elfPanel();
			this.rdoSaveNew = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoCopyUnselect = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.chkUnselectFile = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.gbxSplit = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.rdoHori2_1 = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoHori1_2 = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoVerti1_2 = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoVerti2_1 = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.gbxSaveFileType = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.gbxExistsFile = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.rdoOverWrite = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoSkip = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.numQuality = new net.elfmission.WindowsApps.Controls.elfNumericTextBox();
			this.trcJpegQuality = new net.elfmission.WindowsApps.Controls.elfTrackBar();
			this.rdoBmp = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.rdoJepg = new net.elfmission.WindowsApps.Controls.elfRadioButton();
			this.gbxRemoveCenter = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.pnlRemoveCenter = new net.elfmission.WindowsApps.Controls.elfPanel();
			this.lblRemovedCenterWidth = new net.elfmission.WindowsApps.Controls.elfLabel();
			this.numRemovedCenterWidth = new net.elfmission.WindowsApps.Controls.elfNumericTextBox();
			this.chkRemoveCenter = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.gbxSaveFolder = new net.elfmission.WindowsApps.Controls.elfGroupBox();
			this.chkDefaultSaveFolder = new net.elfmission.WindowsApps.Controls.elfCheckBox();
			this.gbxUnselect.SuspendLayout();
			this.pnlUnselect.SuspendLayout();
			this.gbxSplit.SuspendLayout();
			this.gbxSaveFileType.SuspendLayout();
			this.gbxExistsFile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQuality)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trcJpegQuality)).BeginInit();
			this.gbxRemoveCenter.SuspendLayout();
			this.pnlRemoveCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRemovedCenterWidth)).BeginInit();
			this.gbxSaveFolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSaveTo
			// 
			resources.ApplyResources(this.txtSaveTo, "txtSaveTo");
			this.txtSaveTo.Name = "txtSaveTo";
			this.txtSaveTo.ReadOnly = true;
			// 
			// btnRef
			// 
			resources.ApplyResources(this.btnRef, "btnRef");
			this.btnRef.Name = "btnRef";
			this.btnRef.UseVisualStyleBackColor = true;
			this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
			// 
			// fbdSplit
			// 
			resources.ApplyResources(this.fbdSplit, "fbdSplit");
			// 
			// chkCreateFolder
			// 
			resources.ApplyResources(this.chkCreateFolder, "chkCreateFolder");
			this.chkCreateFolder.Name = "chkCreateFolder";
			this.chkCreateFolder.UseVisualStyleBackColor = true;
			// 
			// gbxUnselect
			// 
			this.gbxUnselect.Controls.Add(this.pnlUnselect);
			this.gbxUnselect.Controls.Add(this.chkUnselectFile);
			resources.ApplyResources(this.gbxUnselect, "gbxUnselect");
			this.gbxUnselect.Name = "gbxUnselect";
			this.gbxUnselect.TabStop = false;
			// 
			// pnlUnselect
			// 
			this.pnlUnselect.Controls.Add(this.rdoSaveNew);
			this.pnlUnselect.Controls.Add(this.rdoCopyUnselect);
			resources.ApplyResources(this.pnlUnselect, "pnlUnselect");
			this.pnlUnselect.Name = "pnlUnselect";
			// 
			// rdoSaveNew
			// 
			resources.ApplyResources(this.rdoSaveNew, "rdoSaveNew");
			this.rdoSaveNew.Name = "rdoSaveNew";
			this.rdoSaveNew.UseVisualStyleBackColor = true;
			// 
			// rdoCopyUnselect
			// 
			resources.ApplyResources(this.rdoCopyUnselect, "rdoCopyUnselect");
			this.rdoCopyUnselect.Name = "rdoCopyUnselect";
			this.rdoCopyUnselect.UseVisualStyleBackColor = true;
			// 
			// chkUnselectFile
			// 
			resources.ApplyResources(this.chkUnselectFile, "chkUnselectFile");
			this.chkUnselectFile.Name = "chkUnselectFile";
			this.chkUnselectFile.UseVisualStyleBackColor = true;
			this.chkUnselectFile.CheckedChanged += new System.EventHandler(this.chkUnselectFile_CheckedChanged);
			// 
			// gbxSplit
			// 
			this.gbxSplit.Controls.Add(this.rdoHori2_1);
			this.gbxSplit.Controls.Add(this.rdoHori1_2);
			this.gbxSplit.Controls.Add(this.rdoVerti1_2);
			this.gbxSplit.Controls.Add(this.rdoVerti2_1);
			resources.ApplyResources(this.gbxSplit, "gbxSplit");
			this.gbxSplit.Name = "gbxSplit";
			this.gbxSplit.TabStop = false;
			// 
			// rdoHori2_1
			// 
			this.rdoHori2_1.Image = global::net.elfmission.WindowsApps.ImageSplitter.Plugins.Properties.Resources.splitVerti2_1;
			resources.ApplyResources(this.rdoHori2_1, "rdoHori2_1");
			this.rdoHori2_1.Name = "rdoHori2_1";
			this.rdoHori2_1.UseVisualStyleBackColor = true;
			// 
			// rdoHori1_2
			// 
			this.rdoHori1_2.Image = global::net.elfmission.WindowsApps.ImageSplitter.Plugins.Properties.Resources.splitVerti1_2;
			resources.ApplyResources(this.rdoHori1_2, "rdoHori1_2");
			this.rdoHori1_2.Name = "rdoHori1_2";
			this.rdoHori1_2.UseVisualStyleBackColor = true;
			// 
			// rdoVerti1_2
			// 
			this.rdoVerti1_2.Image = global::net.elfmission.WindowsApps.ImageSplitter.Plugins.Properties.Resources.splitType1_2;
			resources.ApplyResources(this.rdoVerti1_2, "rdoVerti1_2");
			this.rdoVerti1_2.Name = "rdoVerti1_2";
			this.rdoVerti1_2.UseVisualStyleBackColor = true;
			// 
			// rdoVerti2_1
			// 
			this.rdoVerti2_1.Image = global::net.elfmission.WindowsApps.ImageSplitter.Plugins.Properties.Resources.splitType2_1;
			resources.ApplyResources(this.rdoVerti2_1, "rdoVerti2_1");
			this.rdoVerti2_1.Name = "rdoVerti2_1";
			this.rdoVerti2_1.UseVisualStyleBackColor = true;
			// 
			// gbxSaveFileType
			// 
			this.gbxSaveFileType.Controls.Add(this.gbxExistsFile);
			this.gbxSaveFileType.Controls.Add(this.numQuality);
			this.gbxSaveFileType.Controls.Add(this.trcJpegQuality);
			this.gbxSaveFileType.Controls.Add(this.rdoBmp);
			this.gbxSaveFileType.Controls.Add(this.rdoJepg);
			resources.ApplyResources(this.gbxSaveFileType, "gbxSaveFileType");
			this.gbxSaveFileType.Name = "gbxSaveFileType";
			this.gbxSaveFileType.TabStop = false;
			// 
			// gbxExistsFile
			// 
			this.gbxExistsFile.Controls.Add(this.rdoOverWrite);
			this.gbxExistsFile.Controls.Add(this.rdoSkip);
			resources.ApplyResources(this.gbxExistsFile, "gbxExistsFile");
			this.gbxExistsFile.Name = "gbxExistsFile";
			this.gbxExistsFile.TabStop = false;
			// 
			// rdoOverWrite
			// 
			resources.ApplyResources(this.rdoOverWrite, "rdoOverWrite");
			this.rdoOverWrite.Name = "rdoOverWrite";
			this.rdoOverWrite.UseVisualStyleBackColor = true;
			// 
			// rdoSkip
			// 
			resources.ApplyResources(this.rdoSkip, "rdoSkip");
			this.rdoSkip.Name = "rdoSkip";
			this.rdoSkip.UseVisualStyleBackColor = true;
			// 
			// numQuality
			// 
			this.numQuality.AllowBlank = false;
			resources.ApplyResources(this.numQuality, "numQuality");
			this.numQuality.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numQuality.Name = "numQuality";
			this.numQuality.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numQuality.ValueChanged += new System.EventHandler(this.numQuality_ValueChanged);
			// 
			// trcJpegQuality
			// 
			this.trcJpegQuality.LargeChange = 10;
			resources.ApplyResources(this.trcJpegQuality, "trcJpegQuality");
			this.trcJpegQuality.Maximum = 100;
			this.trcJpegQuality.Minimum = 1;
			this.trcJpegQuality.Name = "trcJpegQuality";
			this.trcJpegQuality.SmallChange = 5;
			this.trcJpegQuality.TickFrequency = 5;
			this.trcJpegQuality.Value = 1;
			this.trcJpegQuality.Scroll += new System.EventHandler(this.trcJpegQuality_Scroll);
			// 
			// rdoBmp
			// 
			resources.ApplyResources(this.rdoBmp, "rdoBmp");
			this.rdoBmp.Name = "rdoBmp";
			this.rdoBmp.UseVisualStyleBackColor = true;
			// 
			// rdoJepg
			// 
			resources.ApplyResources(this.rdoJepg, "rdoJepg");
			this.rdoJepg.Name = "rdoJepg";
			this.rdoJepg.UseVisualStyleBackColor = true;
			this.rdoJepg.CheckedChanged += new System.EventHandler(this.rdoJepg_CheckedChanged);
			// 
			// gbxRemoveCenter
			// 
			this.gbxRemoveCenter.Controls.Add(this.pnlRemoveCenter);
			resources.ApplyResources(this.gbxRemoveCenter, "gbxRemoveCenter");
			this.gbxRemoveCenter.Name = "gbxRemoveCenter";
			this.gbxRemoveCenter.TabStop = false;
			// 
			// pnlRemoveCenter
			// 
			this.pnlRemoveCenter.Controls.Add(this.lblRemovedCenterWidth);
			this.pnlRemoveCenter.Controls.Add(this.numRemovedCenterWidth);
			resources.ApplyResources(this.pnlRemoveCenter, "pnlRemoveCenter");
			this.pnlRemoveCenter.Name = "pnlRemoveCenter";
			// 
			// lblRemovedCenterWidth
			// 
			resources.ApplyResources(this.lblRemovedCenterWidth, "lblRemovedCenterWidth");
			this.lblRemovedCenterWidth.Name = "lblRemovedCenterWidth";
			// 
			// numRemovedCenterWidth
			// 
			this.numRemovedCenterWidth.AllowBlank = false;
			this.numRemovedCenterWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
			resources.ApplyResources(this.numRemovedCenterWidth, "numRemovedCenterWidth");
			this.numRemovedCenterWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numRemovedCenterWidth.Name = "numRemovedCenterWidth";
			this.numRemovedCenterWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// chkRemoveCenter
			// 
			resources.ApplyResources(this.chkRemoveCenter, "chkRemoveCenter");
			this.chkRemoveCenter.Name = "chkRemoveCenter";
			this.chkRemoveCenter.UseVisualStyleBackColor = true;
			this.chkRemoveCenter.CheckedChanged += new System.EventHandler(this.chkRemoveCenter_CheckedChanged);
			// 
			// gbxSaveFolder
			// 
			this.gbxSaveFolder.Controls.Add(this.chkDefaultSaveFolder);
			this.gbxSaveFolder.Controls.Add(this.txtSaveTo);
			this.gbxSaveFolder.Controls.Add(this.btnRef);
			resources.ApplyResources(this.gbxSaveFolder, "gbxSaveFolder");
			this.gbxSaveFolder.Name = "gbxSaveFolder";
			this.gbxSaveFolder.TabStop = false;
			// 
			// chkDefaultSaveFolder
			// 
			resources.ApplyResources(this.chkDefaultSaveFolder, "chkDefaultSaveFolder");
			this.chkDefaultSaveFolder.Name = "chkDefaultSaveFolder";
			this.chkDefaultSaveFolder.UseVisualStyleBackColor = true;
			// 
			// SplitSettingView
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.gbxSaveFolder);
			this.Controls.Add(this.chkRemoveCenter);
			this.Controls.Add(this.gbxRemoveCenter);
			this.Controls.Add(this.gbxSaveFileType);
			this.Controls.Add(this.gbxSplit);
			this.Controls.Add(this.gbxUnselect);
			this.Controls.Add(this.chkCreateFolder);
			this.Name = "SplitSettingView";
			this.Load += new System.EventHandler(this.SplitSettingView_Load);
			this.gbxUnselect.ResumeLayout(false);
			this.gbxUnselect.PerformLayout();
			this.pnlUnselect.ResumeLayout(false);
			this.pnlUnselect.PerformLayout();
			this.gbxSplit.ResumeLayout(false);
			this.gbxSaveFileType.ResumeLayout(false);
			this.gbxSaveFileType.PerformLayout();
			this.gbxExistsFile.ResumeLayout(false);
			this.gbxExistsFile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQuality)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trcJpegQuality)).EndInit();
			this.gbxRemoveCenter.ResumeLayout(false);
			this.pnlRemoveCenter.ResumeLayout(false);
			this.pnlRemoveCenter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRemovedCenterWidth)).EndInit();
			this.gbxSaveFolder.ResumeLayout(false);
			this.gbxSaveFolder.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Controls.elfTextBox txtSaveTo;
		private Controls.elfButton btnRef;
		private System.Windows.Forms.FolderBrowserDialog fbdSplit;
		private Controls.elfCheckBox chkCreateFolder;
		private Controls.elfGroupBox gbxUnselect;
		private Controls.elfRadioButton rdoSaveNew;
		private Controls.elfCheckBox chkUnselectFile;
		private Controls.elfRadioButton rdoCopyUnselect;
		private Controls.elfGroupBox gbxSplit;
		private Controls.elfRadioButton rdoVerti1_2;
		private Controls.elfRadioButton rdoVerti2_1;
		private Controls.elfRadioButton rdoHori1_2;
		private Controls.elfRadioButton rdoHori2_1;
		private Controls.elfGroupBox gbxSaveFileType;
		private Controls.elfRadioButton rdoBmp;
		private Controls.elfRadioButton rdoJepg;
		private Controls.elfPanel pnlUnselect;
		private Controls.elfTrackBar trcJpegQuality;
		private Controls.elfNumericTextBox numQuality;
		private Controls.elfGroupBox gbxRemoveCenter;
		private Controls.elfPanel pnlRemoveCenter;
		private Controls.elfLabel lblRemovedCenterWidth;
		private Controls.elfNumericTextBox numRemovedCenterWidth;
		private Controls.elfCheckBox chkRemoveCenter;
		private Controls.elfGroupBox gbxSaveFolder;
		private Controls.elfCheckBox chkDefaultSaveFolder;
		private Controls.elfGroupBox gbxExistsFile;
		private Controls.elfRadioButton rdoOverWrite;
		private Controls.elfRadioButton rdoSkip;
	}
}
