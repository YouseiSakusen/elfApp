namespace net.elfmission.WindowsApps.ImageSplitter
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tscMain = new net.elfmission.WindowsApps.Controls.elfToolStripContainer();
			this.tnvMain = new net.elfmission.WindowsApps.Controls.elfThumbNailView();
			this.ctmThumbNailView = new net.elfmission.WindowsApps.Controls.elfContextMenuStrip();
			this.mniContextSelectLandscape = new System.Windows.Forms.ToolStripMenuItem();
			this.mniContextSelectPortrait = new System.Windows.Forms.ToolStripMenuItem();
			this.mniContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.tlsSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.mniContextFullScreenImage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMain = new net.elfmission.WindowsApps.Controls.elfMenuStrip();
			this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mniOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.tlsSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.mniEnd = new System.Windows.Forms.ToolStripMenuItem();
			this.mniEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mniEditSelectLandscape = new System.Windows.Forms.ToolStripMenuItem();
			this.mniEditSelectPortrait = new System.Windows.Forms.ToolStripMenuItem();
			this.mniEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mniBatch = new System.Windows.Forms.ToolStripMenuItem();
			this.mniView = new System.Windows.Forms.ToolStripMenuItem();
			this.mniViewFullScreenImage = new System.Windows.Forms.ToolStripMenuItem();
			this.mniViewThumbSize = new System.Windows.Forms.ToolStripMenuItem();
			this.mniViewThumbSizeMid = new System.Windows.Forms.ToolStripMenuItem();
			this.mniViewThumbSizeLarge = new System.Windows.Forms.ToolStripMenuItem();
			this.mniViewThumbSizeExtraLarge = new System.Windows.Forms.ToolStripMenuItem();
			this.mniTool = new System.Windows.Forms.ToolStripMenuItem();
			this.mniOption = new System.Windows.Forms.ToolStripMenuItem();
			this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mniGoWeb = new System.Windows.Forms.ToolStripMenuItem();
			this.tlsMain = new net.elfmission.WindowsApps.Controls.elfToolStrip();
			this.tbtOpen = new System.Windows.Forms.ToolStripButton();
			this.tbtFullScreenImage = new System.Windows.Forms.ToolStripButton();
			this.tbtSelectAll = new System.Windows.Forms.ToolStripButton();
			this.tbtBatch = new System.Windows.Forms.ToolStripDropDownButton();
			this.tlsSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtSetting = new System.Windows.Forms.ToolStripButton();
			this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
			this.sttMain = new net.elfmission.WindowsApps.Controls.elfStatusStrip();
			this.slbImageFolderPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tpbPlugin = new System.Windows.Forms.ToolStripProgressBar();
			this.slbCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tscMain.ContentPanel.SuspendLayout();
			this.tscMain.TopToolStripPanel.SuspendLayout();
			this.tscMain.SuspendLayout();
			this.ctmThumbNailView.SuspendLayout();
			this.mnuMain.SuspendLayout();
			this.tlsMain.SuspendLayout();
			this.sttMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tscMain
			// 
			// 
			// tscMain.ContentPanel
			// 
			this.tscMain.ContentPanel.Controls.Add(this.tnvMain);
			resources.ApplyResources(this.tscMain.ContentPanel, "tscMain.ContentPanel");
			resources.ApplyResources(this.tscMain, "tscMain");
			this.tscMain.Name = "tscMain";
			// 
			// tscMain.TopToolStripPanel
			// 
			this.tscMain.TopToolStripPanel.Controls.Add(this.mnuMain);
			this.tscMain.TopToolStripPanel.Controls.Add(this.tlsMain);
			// 
			// tnvMain
			// 
			this.tnvMain.ContextMenuStrip = this.ctmThumbNailView;
			this.tnvMain.DataBindings.Add(new System.Windows.Forms.Binding("ThumbNailColorDepth", global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default, "ThumbNailColorDepth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			resources.ApplyResources(this.tnvMain, "tnvMain");
			this.tnvMain.HideSelection = false;
			this.tnvMain.Name = "tnvMain";
			this.tnvMain.ThumbNailColorDepth = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Settings.Default.ThumbNailColorDepth;
			this.tnvMain.UseCompatibleStateImageBehavior = false;
			this.tnvMain.VirtualMode = true;
			this.tnvMain.ItemDoubleClick += new net.elfmission.WindowsApps.Controls.elfThumbNailView.ItemDoubleClickEvent(this.tnvMain_ItemDoubleClick);
			this.tnvMain.SelectedIndexChanged += new System.EventHandler(this.tnvMain_SelectedIndexChanged);
			// 
			// ctmThumbNailView
			// 
			this.ctmThumbNailView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniContextSelectLandscape,
            this.mniContextSelectPortrait,
            this.mniContextSelectAll,
            this.tlsSep3,
            this.mniContextFullScreenImage});
			this.ctmThumbNailView.Name = "ctmThumbNailView";
			resources.ApplyResources(this.ctmThumbNailView, "ctmThumbNailView");
			// 
			// mniContextSelectLandscape
			// 
			resources.ApplyResources(this.mniContextSelectLandscape, "mniContextSelectLandscape");
			this.mniContextSelectLandscape.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.size_horizontal;
			this.mniContextSelectLandscape.Name = "mniContextSelectLandscape";
			this.mniContextSelectLandscape.Click += new System.EventHandler(this.mniSelectImage_Click);
			// 
			// mniContextSelectPortrait
			// 
			resources.ApplyResources(this.mniContextSelectPortrait, "mniContextSelectPortrait");
			this.mniContextSelectPortrait.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.size_vertical;
			this.mniContextSelectPortrait.Name = "mniContextSelectPortrait";
			this.mniContextSelectPortrait.Click += new System.EventHandler(this.mniSelectImage_Click);
			// 
			// mniContextSelectAll
			// 
			resources.ApplyResources(this.mniContextSelectAll, "mniContextSelectAll");
			this.mniContextSelectAll.Name = "mniContextSelectAll";
			this.mniContextSelectAll.Click += new System.EventHandler(this.mniEditSelectAll_Click);
			// 
			// tlsSep3
			// 
			this.tlsSep3.Name = "tlsSep3";
			resources.ApplyResources(this.tlsSep3, "tlsSep3");
			// 
			// mniContextFullScreenImage
			// 
			resources.ApplyResources(this.mniContextFullScreenImage, "mniContextFullScreenImage");
			this.mniContextFullScreenImage.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.FullScreenImage;
			this.mniContextFullScreenImage.Name = "mniContextFullScreenImage";
			this.mniContextFullScreenImage.Click += new System.EventHandler(this.fullScreenImageMenu_Click);
			// 
			// mnuMain
			// 
			resources.ApplyResources(this.mnuMain, "mnuMain");
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniEdit,
            this.mniBatch,
            this.mniView,
            this.mniTool,
            this.mniHelp});
			this.mnuMain.Name = "mnuMain";
			// 
			// mniFile
			// 
			this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOpenFolder,
            this.tlsSep2,
            this.mniEnd});
			this.mniFile.Name = "mniFile";
			resources.ApplyResources(this.mniFile, "mniFile");
			// 
			// mniOpenFolder
			// 
			this.mniOpenFolder.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.folder_picture;
			this.mniOpenFolder.Name = "mniOpenFolder";
			resources.ApplyResources(this.mniOpenFolder, "mniOpenFolder");
			this.mniOpenFolder.Click += new System.EventHandler(this.tbtOpen_Click);
			// 
			// tlsSep2
			// 
			this.tlsSep2.Name = "tlsSep2";
			resources.ApplyResources(this.tlsSep2, "tlsSep2");
			// 
			// mniEnd
			// 
			this.mniEnd.Name = "mniEnd";
			resources.ApplyResources(this.mniEnd, "mniEnd");
			this.mniEnd.Click += new System.EventHandler(this.mniEnd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniEditSelectLandscape,
            this.mniEditSelectPortrait,
            this.mniEditSelectAll});
			this.mniEdit.Name = "mniEdit";
			resources.ApplyResources(this.mniEdit, "mniEdit");
			// 
			// mniEditSelectLandscape
			// 
			resources.ApplyResources(this.mniEditSelectLandscape, "mniEditSelectLandscape");
			this.mniEditSelectLandscape.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.size_horizontal;
			this.mniEditSelectLandscape.Name = "mniEditSelectLandscape";
			this.mniEditSelectLandscape.Click += new System.EventHandler(this.mniSelectImage_Click);
			// 
			// mniEditSelectPortrait
			// 
			resources.ApplyResources(this.mniEditSelectPortrait, "mniEditSelectPortrait");
			this.mniEditSelectPortrait.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.size_vertical;
			this.mniEditSelectPortrait.Name = "mniEditSelectPortrait";
			this.mniEditSelectPortrait.Click += new System.EventHandler(this.mniSelectImage_Click);
			// 
			// mniEditSelectAll
			// 
			resources.ApplyResources(this.mniEditSelectAll, "mniEditSelectAll");
			this.mniEditSelectAll.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.asterisk_orange;
			this.mniEditSelectAll.Name = "mniEditSelectAll";
			this.mniEditSelectAll.Click += new System.EventHandler(this.mniEditSelectAll_Click);
			// 
			// mniBatch
			// 
			resources.ApplyResources(this.mniBatch, "mniBatch");
			this.mniBatch.Name = "mniBatch";
			// 
			// mniView
			// 
			this.mniView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniViewFullScreenImage,
            this.mniViewThumbSize});
			this.mniView.Name = "mniView";
			resources.ApplyResources(this.mniView, "mniView");
			// 
			// mniViewFullScreenImage
			// 
			resources.ApplyResources(this.mniViewFullScreenImage, "mniViewFullScreenImage");
			this.mniViewFullScreenImage.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.FullScreenImage;
			this.mniViewFullScreenImage.Name = "mniViewFullScreenImage";
			this.mniViewFullScreenImage.Click += new System.EventHandler(this.fullScreenImageMenu_Click);
			// 
			// mniViewThumbSize
			// 
			this.mniViewThumbSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniViewThumbSizeMid,
            this.mniViewThumbSizeLarge,
            this.mniViewThumbSizeExtraLarge});
			this.mniViewThumbSize.Name = "mniViewThumbSize";
			resources.ApplyResources(this.mniViewThumbSize, "mniViewThumbSize");
			this.mniViewThumbSize.Click += new System.EventHandler(this.mniThumbSize_DropDownOpened);
			// 
			// mniViewThumbSizeMid
			// 
			this.mniViewThumbSizeMid.Name = "mniViewThumbSizeMid";
			resources.ApplyResources(this.mniViewThumbSizeMid, "mniViewThumbSizeMid");
			this.mniViewThumbSizeMid.Click += new System.EventHandler(this.thumbNailSizeMenuItem_Click);
			// 
			// mniViewThumbSizeLarge
			// 
			this.mniViewThumbSizeLarge.Checked = true;
			this.mniViewThumbSizeLarge.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.mniViewThumbSizeLarge.Name = "mniViewThumbSizeLarge";
			resources.ApplyResources(this.mniViewThumbSizeLarge, "mniViewThumbSizeLarge");
			this.mniViewThumbSizeLarge.Click += new System.EventHandler(this.thumbNailSizeMenuItem_Click);
			// 
			// mniViewThumbSizeExtraLarge
			// 
			this.mniViewThumbSizeExtraLarge.Name = "mniViewThumbSizeExtraLarge";
			resources.ApplyResources(this.mniViewThumbSizeExtraLarge, "mniViewThumbSizeExtraLarge");
			this.mniViewThumbSizeExtraLarge.Click += new System.EventHandler(this.thumbNailSizeMenuItem_Click);
			// 
			// mniTool
			// 
			this.mniTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOption});
			this.mniTool.Name = "mniTool";
			resources.ApplyResources(this.mniTool, "mniTool");
			// 
			// mniOption
			// 
			this.mniOption.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.settings;
			this.mniOption.Name = "mniOption";
			resources.ApplyResources(this.mniOption, "mniOption");
			this.mniOption.Click += new System.EventHandler(this.mniOption_Click);
			// 
			// mniHelp
			// 
			this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniGoWeb});
			this.mniHelp.Name = "mniHelp";
			resources.ApplyResources(this.mniHelp, "mniHelp");
			// 
			// mniGoWeb
			// 
			this.mniGoWeb.Name = "mniGoWeb";
			resources.ApplyResources(this.mniGoWeb, "mniGoWeb");
			this.mniGoWeb.Click += new System.EventHandler(this.mniGoWeb_Click);
			// 
			// tlsMain
			// 
			resources.ApplyResources(this.tlsMain, "tlsMain");
			this.tlsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtOpen,
            this.tbtFullScreenImage,
            this.tbtSelectAll,
            this.tbtBatch,
            this.tlsSep1,
            this.tbtSetting});
			this.tlsMain.Name = "tlsMain";
			this.tlsMain.Stretch = true;
			// 
			// tbtOpen
			// 
			this.tbtOpen.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.folder_picture;
			resources.ApplyResources(this.tbtOpen, "tbtOpen");
			this.tbtOpen.Name = "tbtOpen";
			this.tbtOpen.Click += new System.EventHandler(this.tbtOpen_Click);
			// 
			// tbtFullScreenImage
			// 
			resources.ApplyResources(this.tbtFullScreenImage, "tbtFullScreenImage");
			this.tbtFullScreenImage.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.FullScreenImage;
			this.tbtFullScreenImage.Name = "tbtFullScreenImage";
			this.tbtFullScreenImage.Click += new System.EventHandler(this.fullScreenImageMenu_Click);
			// 
			// tbtSelectAll
			// 
			resources.ApplyResources(this.tbtSelectAll, "tbtSelectAll");
			this.tbtSelectAll.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.asterisk_orange;
			this.tbtSelectAll.Name = "tbtSelectAll";
			this.tbtSelectAll.Click += new System.EventHandler(this.mniEditSelectAll_Click);
			// 
			// tbtBatch
			// 
			resources.ApplyResources(this.tbtBatch, "tbtBatch");
			this.tbtBatch.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.layers_map;
			this.tbtBatch.Name = "tbtBatch";
			// 
			// tlsSep1
			// 
			this.tlsSep1.Name = "tlsSep1";
			resources.ApplyResources(this.tlsSep1, "tlsSep1");
			// 
			// tbtSetting
			// 
			this.tbtSetting.Image = global::net.elfmission.WindowsApps.ImageSplitter.Properties.Resources.settings;
			resources.ApplyResources(this.tbtSetting, "tbtSetting");
			this.tbtSetting.Name = "tbtSetting";
			this.tbtSetting.Click += new System.EventHandler(this.mniOption_Click);
			// 
			// fbdMain
			// 
			resources.ApplyResources(this.fbdMain, "fbdMain");
			this.fbdMain.ShowNewFolderButton = false;
			// 
			// sttMain
			// 
			this.sttMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbImageFolderPath,
            this.tpbPlugin,
            this.slbCount});
			resources.ApplyResources(this.sttMain, "sttMain");
			this.sttMain.Name = "sttMain";
			// 
			// slbImageFolderPath
			// 
			this.slbImageFolderPath.Name = "slbImageFolderPath";
			resources.ApplyResources(this.slbImageFolderPath, "slbImageFolderPath");
			this.slbImageFolderPath.Spring = true;
			// 
			// tpbPlugin
			// 
			this.tpbPlugin.Name = "tpbPlugin";
			resources.ApplyResources(this.tpbPlugin, "tpbPlugin");
			// 
			// slbCount
			// 
			this.slbCount.Name = "slbCount";
			resources.ApplyResources(this.slbCount, "slbCount");
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tscMain);
			this.Controls.Add(this.sttMain);
			this.Name = "MainForm";
			this.ShowInTaskbar = true;
			this.ShowProductInformationAtTitle = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tscMain.ContentPanel.ResumeLayout(false);
			this.tscMain.TopToolStripPanel.ResumeLayout(false);
			this.tscMain.TopToolStripPanel.PerformLayout();
			this.tscMain.ResumeLayout(false);
			this.tscMain.PerformLayout();
			this.ctmThumbNailView.ResumeLayout(false);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.tlsMain.ResumeLayout(false);
			this.tlsMain.PerformLayout();
			this.sttMain.ResumeLayout(false);
			this.sttMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FolderBrowserDialog fbdMain;
		private Controls.elfStatusStrip sttMain;
		private System.Windows.Forms.ToolStripStatusLabel slbImageFolderPath;
		private System.Windows.Forms.ToolStripProgressBar tpbPlugin;
		private System.Windows.Forms.ToolStripStatusLabel slbCount;
		private Controls.elfToolStripContainer tscMain;
		private Controls.elfThumbNailView tnvMain;
		private Controls.elfToolStrip tlsMain;
		private System.Windows.Forms.ToolStripButton tbtOpen;
		private System.Windows.Forms.ToolStripDropDownButton tbtBatch;
		private System.Windows.Forms.ToolStripSeparator tlsSep1;
		private System.Windows.Forms.ToolStripButton tbtSetting;
		private Controls.elfMenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem mniFile;
		private System.Windows.Forms.ToolStripMenuItem mniOpenFolder;
		private System.Windows.Forms.ToolStripSeparator tlsSep2;
		private System.Windows.Forms.ToolStripMenuItem mniEnd;
		private System.Windows.Forms.ToolStripMenuItem mniView;
		private System.Windows.Forms.ToolStripMenuItem mniViewThumbSize;
		private System.Windows.Forms.ToolStripMenuItem mniViewThumbSizeMid;
		private System.Windows.Forms.ToolStripMenuItem mniViewThumbSizeLarge;
		private System.Windows.Forms.ToolStripMenuItem mniViewThumbSizeExtraLarge;
		private System.Windows.Forms.ToolStripMenuItem mniBatch;
		private System.Windows.Forms.ToolStripMenuItem mniTool;
		private System.Windows.Forms.ToolStripMenuItem mniOption;
		private System.Windows.Forms.ToolStripMenuItem mniEdit;
		private System.Windows.Forms.ToolStripMenuItem mniEditSelectAll;
		private System.Windows.Forms.ToolStripButton tbtSelectAll;
		private System.Windows.Forms.ToolStripMenuItem mniEditSelectLandscape;
		private System.Windows.Forms.ToolStripMenuItem mniEditSelectPortrait;
		private Controls.elfContextMenuStrip ctmThumbNailView;
		private System.Windows.Forms.ToolStripMenuItem mniContextSelectLandscape;
		private System.Windows.Forms.ToolStripMenuItem mniContextSelectPortrait;
		private System.Windows.Forms.ToolStripMenuItem mniContextSelectAll;
		private System.Windows.Forms.ToolStripMenuItem mniViewFullScreenImage;
		private System.Windows.Forms.ToolStripMenuItem mniContextFullScreenImage;
		private System.Windows.Forms.ToolStripButton tbtFullScreenImage;
		private System.Windows.Forms.ToolStripSeparator tlsSep3;
		private System.Windows.Forms.ToolStripMenuItem mniHelp;
		private System.Windows.Forms.ToolStripMenuItem mniGoWeb;
	}
}

