using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using net.elfmission.WindowsApps.Controls;
using Ookii.Dialogs.WinForms;

namespace net.elfmission.WindowsApps.ImageSplitter
{
	/// <summary>
	/// アプリケーションのメインフォーム。
	/// </summary>
	public partial class MainForm : ImageSplitterBase
	{
		#region "変数・定数"

		/// <summary>
		/// WebサイトのURLを表します。
		/// </summary>
		private const string WEB_SITE_ADDRESS = "http://elf-mission.net/";

		/// <summary>
		/// プラグインメニューのリストを表します。
		/// </summary>
		private List<ToolStripMenuItem> pluginMenuList = new List<ToolStripMenuItem>();
		/// <summary>
		/// サムネイルサイズ指定メニューのリストを表します。
		/// </summary>
		private List<ToolStripMenuItem> thumbSizeMenuList = new List<ToolStripMenuItem>();

		#endregion

		#region "プロパティ"

		/// <summary>
		/// プラグインのパスを取得します。
		/// </summary>
		public string PluginPath
		{
			get
			{
				return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.PluginFolderName);
			}
		}

		#endregion

		#region "イベント"

		/// <summary>
		/// 作者のWebサイトを開くメニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniGoWeb_Click(object sender, EventArgs e)
		{
			Process.Start(MainForm.WEB_SITE_ADDRESS);
		}

		/// <summary>
		/// 全画面表示メニューClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void fullScreenImageMenu_Click(object sender, EventArgs e)
		{
			if (this.tnvMain.SelectedIndices.Count != 1)
				return;

			this.showFullScreenImage(this.tnvMain.GetThumbNailItem(this.tnvMain.SelectedIndices[0]));
		}

		/// <summary>
		/// 横長(縦長)イメージを選択メニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniSelectImage_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				var tmpMenu = (ToolStripMenuItem)sender;
				this.tnvMain.SelectImageByPattern((ImagePattern)tmpMenu.Tag);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 選択しているイメージをフルスクリーン表示します。
		/// </summary>
		/// <param name="targetItem">フルスクリーン表示対象のThumbNailItem。</param>
		private void showFullScreenImage(ThumbNailItem targetItem)
		{
			using (var viewer = new Viewers.ViewerForm
			{
				AllThumbNailList = this.tnvMain.GetAllThumbNails(),
				SelectedThumbNailIndex = targetItem.ItemListIndex
			})
			{
				viewer.ShowDialog(this);
			}
		}

		/// <summary>
		/// サムネイルビューのItemDoubleClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているItemDoubleClickEventArges。</param>
		private void tnvMain_ItemDoubleClick(object sender, ItemDoubleClickEventArges e)
		{
			this.showFullScreenImage(e.TargetItem);
		}

		/// <summary>
		/// すべて選択メニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniEditSelectAll_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				this.tnvMain.SelectAll();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// プログレスバーを表示します。
		/// </summary>
		/// <param name="targetCount">処理対象の件数を表すint。</param>
		private void showPluginProgress(int targetCount)
		{
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
			this.tpbPlugin.Value = 0;
			this.tpbPlugin.Width = this.Width / 2;
			this.tpbPlugin.Maximum = targetCount;
			this.tpbPlugin.Visible = true;
		}

		/// <summary>
		/// 一括処理対象のリストを取得します。
		/// </summary>
		/// <returns></returns>
		private List<Plugins.BatchTargetImage> getBatchTargetList()
		{
			var retList = new List<Plugins.BatchTargetImage>();
			var thumbNailList = this.tnvMain.GetAllThumbNails();

			foreach (var thumb in thumbNailList)
			{
				var item = new Plugins.BatchTargetImage
				{
					FilePath = thumb.ImageFilePath,
					Selected = thumb.Selected
				};

				retList.Add(item);
			}

			return retList;
		}

		/// <summary>
		/// プラグインを実行します。
		/// </summary>
		/// <param name="plugin">実行するプラグインを表すIImageBatchPlugin。</param>
		private void execPlugin(Plugins.IImageBatchPlugin plugin)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.tscMain.Enabled = false;

				var retList = new List<Plugins.BatchTargetImage>();
				var targetList = this.getBatchTargetList();
				var targetCount = 0;

				if (plugin.IsTargetAllFiles)
					targetCount = targetList.Count;
				else
					targetCount = tnvMain.SelectedIndices.Count;

				// プログレスバーを表示
				if (0 < targetList.Count)
					this.showPluginProgress(targetCount);

				foreach (var item in targetList)
				{
					if (! item.HasError)
					{
						// エラーが無い場合のみ
						retList.AddRange(plugin.Execute(item));
					}

					// プログレスバーをインクリメント
					this.tpbPlugin.Increment(1);

					if (! File.Exists(item.FilePath))
					{
						continue;
					}

					TaskbarManager.Instance.SetProgressValue(this.tpbPlugin.Value, targetCount);
				}
			}
			finally
			{
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
				this.tpbPlugin.Visible = false;
				this.tscMain.Enabled = true;
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// プラグインメニューを実行します。
		/// </summary>
		/// <param name="menuItem">実行するメニューを表すToolStripMenuItem。</param>
		private void executePluginMenu(ToolStripMenuItem menuItem)
		{
			var plugin = (Plugins.IImageBatchPlugin)menuItem.Tag;
			// プラグインの保存処理Enableの値を退避
			var finisherOld = plugin.SelectedFilesFinisherEnabled;
			// プラグインの保存処理を有効化
			plugin.SelectedFilesFinisherEnabled = true;
			// 処理対象元フォルダをセット
			plugin.SourceImagePath = this.tnvMain.ImageFolderPath;

			if (plugin.PluginInformations.HasSettingView)
			{	// 設定画面を表示
				using (var pluginFrm = new Plugins.PluginForm { Plugin = plugin })
				{
					if (pluginFrm.ShowDialog() != DialogResult.OK)
						return;
				}
			}

			// プラグインを実行
			this.execPlugin(plugin);
			// プラグインの保存処理値を元に戻す
			plugin.SelectedFilesFinisherEnabled = finisherOld;

			if (Properties.Settings.Default.ShowFinishedMessage)
				// 完了メッセージを表示
				this.showInformationMessage(Properties.Resources.ImageSplitter_INF_FINISHED_BATCH);
		}

		/// <summary>
		/// プラグインMenuItemのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void pluginMenuItem_Click(object sender, EventArgs e)
		{
			this.executePluginMenu((ToolStripMenuItem)sender);
		}

		/// <summary>
		/// サムネイルビューのSelectedIndexChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void tnvMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			var menuEnabled = 0 < this.tnvMain.SelectedIndices.Count;

			this.pluginMenuList.ForEach(m => m.Enabled = menuEnabled);

			var oneItemSelect = this.tnvMain.SelectedIndices.Count == 1;
			this.mniViewFullScreenImage.Enabled = oneItemSelect;
			this.mniContextFullScreenImage.Enabled = oneItemSelect;
			this.tbtFullScreenImage.Enabled = oneItemSelect;
		}

		/// <summary>
		/// 指定したサムネイルのサイズを保存します。
		/// </summary>
		/// <param name="newSize">保存するサムネイルサイズを表すThumbNailSize列挙型の内の1つ。</param>
		private void saveThumbNailSize(ThumbNailSize newSize)
		{
			// サムネイルのサイズを保存
			Properties.Settings.Default.ThumbNailImageSize = newSize;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// サムネイルサイズメニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void thumbNailSizeMenuItem_Click(object sender, EventArgs e)
		{
			var thumbMenu = (ToolStripMenuItem)sender;

			// チェック状態を切替える
			this.changeThumbNailCheckState(thumbMenu);
			var newSize = (ThumbNailSize)thumbMenu.Tag;

			if (string.IsNullOrEmpty(this.tnvMain.ImageFolderPath))
			{
				// イメージフォルダが設定されていない場合はサイズを保存だけして抜ける
				this.saveThumbNailSize(newSize);
				return;
			}

			var oldSize = Properties.Settings.Default.ThumbNailImageSize;
			
			if (oldSize != newSize)
			{
				// サムネイルを表示
				this.showThumbNails(this.tnvMain.ImageFolderPath, newSize);

				// サムネイルのサイズを保存
				this.saveThumbNailSize(newSize);
			}
		}

		/// <summary>
		/// 指定したサムネイルサイズメニューをチェックします。
		/// </summary>
		/// <param name="checkedMenu"></param>
		private void changeThumbNailCheckState(ToolStripMenuItem checkedMenu)
		{
			foreach (var menuItem in this.thumbSizeMenuList)
			{
				if (object.ReferenceEquals(menuItem, checkedMenu))
				{
					menuItem.CheckState = CheckState.Indeterminate;
				}
				else
				{
					menuItem.CheckState = CheckState.Unchecked;
				}
			}
		}

		/// <summary>
		/// サムネイルサイズメニューのDropDownOpenedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniThumbSize_DropDownOpened(object sender, EventArgs e)
		{
			switch (Properties.Settings.Default.ThumbNailImageSize)
			{
				case ThumbNailSize.MediumImage:
					this.changeThumbNailCheckState(this.mniViewThumbSizeMid);
					break;
				case ThumbNailSize.LargeImage:
					this.changeThumbNailCheckState(this.mniViewThumbSizeLarge);
					break;
				case ThumbNailSize.ExtraLargeImage:
					this.changeThumbNailCheckState(this.mniViewThumbSizeExtraLarge);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 設定画面を表示します。
		/// </summary>
		private void showSettingForm()
		{
			using (SettingForm frm = new SettingForm())
			{
				frm.ShowDialog(this);
			}
		}

		/// <summary>
		/// 設定ツールボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void tbtSetting_Click(object sender, EventArgs e)
		{
			this.showSettingForm();
		}

		/// <summary>
		/// ツール - オプションメニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniOption_Click(object sender, EventArgs e)
		{
			this.showSettingForm();
		}

		/// <summary>
		/// ThumbNailView用メニューの有効を設定します。
		/// </summary>
		/// <param name="enable">有効・無効を表すbool。</param>
		private void changeMenuEnabledForThumbNailView(bool enable)
		{
			this.tnvMain.Enabled = enable;
			this.mniBatch.Enabled = enable;
			this.tbtBatch.Enabled = enable;
			this.tbtSelectAll.Enabled = enable;
			this.mniEditSelectAll.Enabled = enable;
			this.mniEditSelectLandscape.Enabled = enable;
			this.mniEditSelectPortrait.Enabled = enable;
			this.mniContextSelectAll.Enabled = enable;
			this.mniContextSelectLandscape.Enabled = enable;
			this.mniContextSelectPortrait.Enabled = enable;
		}

		/// <summary>
		/// サムネイルを表示します。
		/// </summary>
		/// <param name="folderPath">イメージファイル格納先フォルダのパスを表す文字列。</param>
		/// <param name="thumbSize">サムネイルのサイズを表すThumbNailSize。</param>
		/// <returns>サムネイルの表示結果を表すThumbNailViewStatus。</returns>
		private ThumbNailViewStatus showThumbNails(string folderPath, ThumbNailSize thumbSize)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.tnvMain.BeginUpdate();

				// サムネイルを表示
				ThumbNailViewStatus result = this.tnvMain.ShowThumbNail(folderPath, thumbSize);

				switch (result)
				{
					case ThumbNailViewStatus.ImageFolderNotExists:
						this.showErrorMessage(Properties.Resources.ImageSplitter_ERR_IMAGE_FOLDER_NOT_FOUND);
						break;
					default:
						// メニューを使用可能に
						this.changeMenuEnabledForThumbNailView(true);
						this.slbImageFolderPath.Text = folderPath;
						this.slbCount.Text = this.tnvMain.ThumbNailCount + Properties.Resources.ImageSplitter_INF_IMAGE_FILE_COUNT;
						break;
				}

				return result;
			}
			finally
			{
				this.tnvMain.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 開いたフォルダのパスを保存します。
		/// </summary>
		/// <param name="folderPath">保存するフォルダのパスを表す文字列。</param>
		private void saveOpendPath(string folderPath)
		{
			if (Properties.Settings.Default.IsDefaultSelectAtLastFolder)
			{
				// 前回のパスを保存する設定
				Properties.Settings.Default.LastOpendPath = folderPath;
				Properties.Settings.Default.Save();
			}
		}

		/// <summary>
		/// デフォルトで選択するフォルダのパスを取得します。
		/// </summary>
		/// <returns>デフォルトで選択するフォルダのパスを表す文字列。</returns>
		private string getDefaultFolderPath()
		{
			string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (Properties.Settings.Default.IsDefaultSelectAtLastFolder)
			{
				string lastPath = Properties.Settings.Default.LastOpendPath;

				if (lastPath != string.Empty)
				{
					defaultPath = lastPath;
				}
			}

			return defaultPath;
		}

		/// <summary>
		/// フォルダを開きます。
		/// </summary>
		private void openImageFolder()
		{
			using (var dialog = new VistaFolderBrowserDialog()
				{	SelectedPath = this.getDefaultFolderPath(),
					Description = "イメージファイルが存在するフォルダを選択してください。",
				})
			{
				if (dialog.ShowDialog(this) != DialogResult.OK)
					return;

				// 開いたフォルダのパスを設定に保存
				this.saveOpendPath(dialog.SelectedPath);
				// サムネイルを表示
				this.showThumbNails(dialog.SelectedPath, Properties.Settings.Default.ThumbNailImageSize);
			}
		}

		/// <summary>
		/// 開くツールボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void tbtOpen_Click(object sender, EventArgs e)
		{
			this.openImageFolder();
		}

		/// <summary>
		/// 終了メニューのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void mniEnd_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// プラグイン実行用のToolStripMenuItemを取得します。
		/// </summary>
		/// <param name="plugin">対象のプラグインを表すIImageBatchPlugin。</param>
		/// <returns>プラグイン実行用のToolStripMenuItem。</returns>
		private ToolStripMenuItem getPluginMenuItem(Plugins.IImageBatchPlugin plugin)
		{
			ToolStripMenuItem pluginMenu = new ToolStripMenuItem(plugin.PluginInformations.MenuText, 
																 plugin.PluginInformations.MenuImage,
																 this.pluginMenuItem_Click);
			pluginMenu.Tag = plugin;
			pluginMenu.Enabled = false;
			this.pluginMenuList.Add(pluginMenu);

			return pluginMenu;
		}

		/// <summary>
		/// プラグインメニューを追加します。
		/// </summary>
		/// <param name="plugin">対象のプラグインを表すIImageBatchPlugin。</param>
		private void addPluginMenu(Plugins.IImageBatchPlugin plugin)
		{
			// Toolボタンに追加
			this.tbtBatch.DropDownItems.Add(this.getPluginMenuItem(plugin));
			// メニューに追加
			this.mniBatch.DropDownItems.Add(this.getPluginMenuItem(plugin));
		}

		/// <summary>
		/// プラグインをロードします。
		/// </summary>
		private void loadPlugins()
		{
			foreach (var dllPath in Directory.GetFiles(this.PluginPath, "*.dll"))
			{
				Assembly asm = null;

				try
				{
					asm = Assembly.LoadFrom(dllPath);
				}
				catch (Exception ex)
				{
					// DLL読込エラーは無視
					ExceptionWriter.WriteLog(ex, Path.GetDirectoryName(Application.ExecutablePath));
					continue;
				}

				foreach (var libType in asm.GetTypes())
				{
					// パブリッククラスのみ対象
					if (!libType.IsClass)
						continue;
					if (!libType.IsPublic)
						continue;
					// IImageBatchPluginをインプリメントしているクラスのみ
					if (! typeof(Plugins.IImageBatchPlugin).IsAssignableFrom(libType))
						continue;

					Plugins.IImageBatchPlugin plugin = null;
					try
					{
						plugin = Activator.CreateInstance(libType) as Plugins.IImageBatchPlugin;
						if (plugin == null) continue;

						plugin.PluginFolderPath = this.PluginPath;
					}
					catch (Exception ex)
					{
						// インスタンス化のエラーは無視
						Debug.WriteLine(ex.ToString());
						continue;
					}

					this.addPluginMenu(plugin);
				}
			}

			if (this.tbtBatch.DropDownItems.Count == 0)
			{
				this.addPluginMenu(new ImageSplitter.Plugins.ImageSplit.ImageSplitPlugin());
			}
		}

		/// <summary>
		/// 画面の復元情報を取得します。
		/// </summary>
		/// <returns>画面の復元情報を表すFormRestoreInformations。</returns>
		private FormRestoreInformations getRestoreInfo()
		{
			return new FormRestoreInformations
			{
				FormPosition = Properties.Settings.Default.MainFormPosition,
				FormSize = Properties.Settings.Default.MainFormSize,
				StartPosition = Properties.Settings.Default.MainFormStartPosition,
				WindowState = Properties.Settings.Default.MainFormWindowState
			};
		}

		/// <summary>
		/// コントロールを初期化します。
		/// </summary>
		private void initControls()
		{
			// 画面の表示位置・サイズを復元
			this.restoredForm(this.getRestoreInfo());

			// サムネイルサイズメニューリストを初期化
			this.mniViewThumbSizeMid.Tag = ThumbNailSize.MediumImage;
			this.mniViewThumbSizeLarge.Tag = ThumbNailSize.LargeImage;
			this.mniViewThumbSizeExtraLarge.Tag = ThumbNailSize.ExtraLargeImage;

			this.thumbSizeMenuList.Add(this.mniViewThumbSizeMid);
			this.thumbSizeMenuList.Add(this.mniViewThumbSizeLarge);
			this.thumbSizeMenuList.Add(this.mniViewThumbSizeExtraLarge);

			// 選択メニューの初期化
			this.mniEditSelectLandscape.Tag = ImagePattern.Landscape;
			this.mniEditSelectPortrait.Tag = ImagePattern.Portrait;
			this.mniContextSelectLandscape.Tag = ImagePattern.Landscape;
			this.mniContextSelectPortrait.Tag = ImagePattern.Portrait;
		}

		/// <summary>
		/// 画面のLoadイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			// コントロールを初期化
			this.initControls();
			// プラグインをロード
			this.loadPlugins();
		}

		/// <summary>
		/// 復元情報を保存します。
		/// </summary>
		private void saveRestoreInfo()
		{
			Properties.Settings.Default.MainFormPosition = this.Location;
			Properties.Settings.Default.MainFormSize = this.Size;
			Properties.Settings.Default.MainFormStartPosition = FormStartPosition.Manual;
			Properties.Settings.Default.MainFormWindowState = this.WindowState;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 画面のFormClosingイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているFormClosingEventArgs。</param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 復元情報を保存
			this.saveRestoreInfo();
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		#endregion
	}
}
