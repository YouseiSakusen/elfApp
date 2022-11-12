using System;
using System.IO;
using System.Windows.Forms;
using net.elfmission.WindowsApps;
using Ookii.Dialogs.WinForms;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// ページ分割の設定画面を表します。
	/// </summary>
	internal partial class SplitSettingView : PluginSettingViewBase
	{
		#region メソッド

		/// <summary>
		/// 画面の設定値を取得します。
		/// </summary>
		/// <returns>画面の設定値を表すImageSplitSettings。</returns>
		private ImageSplitSettings getSplitSettings()
		{
			var settings = new ImageSplitSettings
			{
				//保存先フォルダ
				SavedFolderPath = this.txtSaveTo.Text,
				// 選択した保存先フォルダを記憶する
				SavedSelectedFolderPath = this.chkDefaultSaveFolder.Checked,
				// 処理元フォルダ名
				SourceFolderName = this.Plugin.SourceFolderName,
				// 保存先に同名のフォルダを作る
				IsCreateFolderAtSameSourceFolder = this.chkCreateFolder.Checked,
				// 非選択ファイルも同時に処理する
				IsTargetForUnselectedFiles = this.chkUnselectFile.Checked,
				// Jpeg保存品質
				JpegSavedQuality = this.numQuality.Value,
				// 中心を除去する
				IsRemovedCenterLine = this.chkRemoveCenter.Checked,
				// 除去する中心線の幅
				RemovedCenterLineWidth = this.numRemovedCenterWidth.Value
			};

			// 非選択ファイルの処理
			var rdo = this.pnlUnselect.GetCheckedRadioButton();
			if (rdo != null)
				settings.UnselectedFilesOperation = (UnselectedFilesOperation)rdo.Tag;

			// 保存ファイル形式
			rdo = this.gbxSaveFileType.GetCheckedRadioButton();
			if (rdo != null)
				settings.SaveJpeg = (bool)rdo.Tag;
			// 同名ファイル存在時
			rdo = this.gbxExistsFile.GetCheckedRadioButton();
			if (rdo != null)
				settings.IsSkipSameFileName = (bool)rdo.Tag;

			// 分割方法(&P)
			rdo = this.gbxSplit.GetCheckedRadioButton();
			if (rdo != null)
				settings.PageSplitType = (SplitType)rdo.Tag;

			return settings;
		}

		/// <summary>
		/// 設定が確定した場合に呼び出されます。
		/// </summary>
		public override void SettingFinished()
		{
			var settings = this.getSplitSettings();
			this.savePluginSettings(settings);

			((ImageSplitPlugin)this.Plugin).Settings = settings;
		}

		/// <summary>
		/// 保存先フォルダのパスを取得します。
		/// </summary>
		/// <returns>保存先フォルダのパスを表す文字列。</returns>
		private string getSavedFolderPath()
		{
			var savedPath = this.txtSaveTo.Text;

			if (this.chkCreateFolder.Checked)
			{
				savedPath = Path.Combine(savedPath, Plugin.SourceFolderName);
			}

			return savedPath;
		}

		/// <summary>
		/// 保存先フォルダを作成します。
		/// </summary>
		/// <returns>保存先フォルダの作成結果を表すbool。</returns>
		private bool createFolder()
		{
			// フォルダを作成しない場合はOK
			if (! this.chkCreateFolder.Checked) { return true; }

			var savedPath = this.getSavedFolderPath();
			if (Directory.Exists(savedPath))
			{
				return this.showQuestionMessage(Properties.Resources.QES_SAVED_DIRECTORY_EXISTS) == DialogResult.Yes;
			}
			else
			{
				// フォルダを作成
				Directory.CreateDirectory(savedPath);
				return true;
			}
		}

		/// <summary>
		/// 設定エラーの有無を取得します。
		/// </summary>
		/// <returns>設定エラーの有無を表すbool。</returns>
		public override bool HasSettingError()
		{
			if (string.IsNullOrEmpty(this.txtSaveTo.Text))
			{
				this.showErrorMessage(Properties.Resources.ERR_SAVED_FOLDER_IS_BLANK);
				return true;
			}
			if (! System.IO.Directory.Exists(this.txtSaveTo.Text))
			{
				this.showErrorMessage(Properties.Resources.ERR_SAVED_FOLDER_NOT_FOUND);
				return true;
			}
			if (! this.createFolder()) { return true; }
			if ((this.chkRemoveCenter.Checked) && ((this.numRemovedCenterWidth.Value % 2) != 0))
			{	// 中心線の幅は偶数
				this.showErrorMessage(Properties.Resources.ERR_CENTER_WIDTH_IS_NOT_EVEN);
				return true;
			}

			return false;
		}

		#endregion

		#region イベント

		/// <summary>
		/// 中心線除去CheckBoxのCheckedをセットします。
		/// </summary>
		private void setChkRemoveCenterChecked()
		{
			this.pnlRemoveCenter.Enabled = this.chkRemoveCenter.Checked;
		}

		/// <summary>
		/// 中心線除去CheckBoxのCheckedChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void chkRemoveCenter_CheckedChanged(object sender, EventArgs e)
		{
			this.setChkRemoveCenterChecked();
		}

		/// <summary>
		/// Jpeg品質NumberTextBoxのValueChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void numQuality_ValueChanged(object sender, EventArgs e)
		{
			this.trcJpegQuality.Value = (int)this.numQuality.Value;
		}

		/// <summary>
		/// Jpeg品質トラックバーのScrollイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納している</param>
		private void trcJpegQuality_Scroll(object sender, EventArgs e)
		{
			this.numQuality.Value = this.trcJpegQuality.Value;
		}

		/// <summary>
		/// Jpegファイルで保存RadioButtonのCheckedをセットします。
		/// </summary>
		private void setRdoJepgChecked()
		{
			var saveJpg = this.rdoJepg.Checked;

			this.trcJpegQuality.Enabled = saveJpg;
			this.numQuality.Enabled = saveJpg;
		}

		/// <summary>
		/// Jpegファイルで保存RadioButtonのCheckedChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void rdoJepg_CheckedChanged(object sender, EventArgs e)
		{
			this.setRdoJepgChecked();
		}

		/// <summary>
		/// 非選択ファイルも同時に処理するチェックボックスのCheckedをセットします。
		/// </summary>
		private void setChkUnselectFileChecked()
		{
			this.pnlUnselect.Enabled = this.chkUnselectFile.Checked;
		}

		/// <summary>
		/// 非選択ファイルも同時に処理するチェックボックスのCheckedChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void chkUnselectFile_CheckedChanged(object sender, EventArgs e)
		{
			this.setChkUnselectFileChecked();
		}

		/// <summary>
		/// 参照ボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void btnRef_Click(object sender, EventArgs e)
		{
			if (this.txtSaveTo.Text == string.Empty)
				return;

			using (var dialog = new VistaFolderBrowserDialog()
				{
					SelectedPath = this.txtSaveTo.Text,
					Description = "分割したイメージの出力先を選択してください。",
					ShowNewFolderButton= true,
				})
			{
				if (dialog.ShowDialog(this.FindForm()) != DialogResult.OK) return;

				this.txtSaveTo.Text = dialog.SelectedPath;
			}

			//if (this.txtSaveTo.Text != string.Empty)
			//	this.fbdSplit.SelectedPath = this.txtSaveTo.Text;
			//if (this.fbdSplit.ShowDialog(this.FindForm()) == DialogResult.OK)
			//	this.txtSaveTo.Text = fbdSplit.SelectedPath;
		}

		/// <summary>
		/// ページの分割方法を設定します。
		/// </summary>
		/// <param name="settings"></param>
		private void setSplitType(ImageSplitSettings settings)
		{
			switch (settings.PageSplitType)
			{
				case SplitType.Vertical1_2:
					this.rdoVerti1_2.Checked = true;
					break;
				case SplitType.Vertical2_1:
					this.rdoVerti2_1.Checked = true;
					break;
				case SplitType.Horizontal1_2:
					this.rdoHori1_2.Checked = true;
					break;
				case SplitType.Horizontal2_1:
					this.rdoHori2_1.Checked = true;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// ページ分割方式RadioButtonを初期化します。
		/// </summary>
		private void initSplitTypeRadioButtons()
		{
			this.rdoHori1_2.Tag = SplitType.Horizontal1_2;
			this.rdoHori2_1.Tag = SplitType.Horizontal2_1;
			this.rdoVerti1_2.Tag = SplitType.Vertical1_2;
			this.rdoVerti2_1.Tag = SplitType.Vertical2_1;
		}

		/// <summary>
		/// 保存ファイル形式を設定します。
		/// </summary>
		/// <param name="settings">プラグイン設定を表すImageSplitSettings。</param>
		private void setSavedFileType(ImageSplitSettings settings)
		{
			if (settings.SaveJpeg)
				this.rdoJepg.Checked = true;
			else
				this.rdoBmp.Checked = true;

			this.setRdoJepgChecked();
			this.trcJpegQuality.Value = (int)settings.JpegSavedQuality;
			this.numQuality.Value = settings.JpegSavedQuality;
			this.gbxSaveFileType.Enabled = this.Plugin.SelectedFilesFinisherEnabled;

			// 同名ファイルが存在した場合
			if (settings.IsSkipSameFileName)
				this.rdoSkip.Checked = true;
			else
				this.rdoOverWrite.Checked = true;
		}

		/// <summary>
		/// 保存ファイル形式RadioButtonを初期化します。
		/// </summary>
		private void initSavedFileTypeRadioButtons()
		{
			this.rdoJepg.Tag = true;
			this.rdoBmp.Tag = false;
			this.rdoSkip.Tag = true;
			this.rdoOverWrite.Tag = false;
		}

		/// <summary>
		/// 非選択ファイルの処理を設定します。
		/// </summary>
		/// <param name="settings">プラグイン設定を表すImageSplitSettings。</param>
		private void setUnselectedFilesOperation(ImageSplitSettings settings)
		{
			this.chkUnselectFile.Checked = settings.IsTargetForUnselectedFiles;
			this.setChkUnselectFileChecked();

			switch (settings.UnselectedFilesOperation)
			{
				case UnselectedFilesOperation.CopyFiles:
					this.rdoCopyUnselect.Checked = true;
					break;
				case UnselectedFilesOperation.CreatNewFiles:
					this.rdoSaveNew.Checked = true;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 非選択ファイルの処理RadioButtonを初期化します。
		/// </summary>
		private void initUnselectedFilesOperationRadioButtons()
		{
			this.rdoCopyUnselect.Tag = UnselectedFilesOperation.CopyFiles;
			this.rdoSaveNew.Tag = UnselectedFilesOperation.CreatNewFiles;
		}

		/// <summary>
		/// 保存先フォルダをセットします。
		/// </summary>
		/// <param name="settings">設定情報を表すImageSplitSettings。</param>
		private void setSavedPath(ImageSplitSettings settings)
		{
			if (settings.SavedSelectedFolderPath)
			{	// 保存先フォルダを保存する場合のみ
				var folderPath = WinShellUtility.GetExistedFolderPath(settings.SavedFolderPath);
				if (string.IsNullOrEmpty(folderPath))
					// 存在しない場合はマイドキュメント
					folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

				this.txtSaveTo.Text = folderPath;
			}
		}

		/// <summary>
		/// コントロールを初期化します。
		/// </summary>
		private void initControls()
		{
			var settings = this.getPluginSettings<ImageSplitSettings>();

			// 保存先フォルダ
			this.setSavedPath(settings);
			// 選択した保存先フォルダを記憶する
			this.chkDefaultSaveFolder.Checked = settings.SavedSelectedFolderPath;
			// 保存先に同名のフォルダを作る
			this.chkCreateFolder.Checked = settings.IsCreateFolderAtSameSourceFolder;
			// 非選択ファイルの処理RadioButtonの初期化
			this.initUnselectedFilesOperationRadioButtons();
			// 非選択ファイルも同時に処理する
			this.setUnselectedFilesOperation(settings);
			// 保存ファイル形式RadioButtonを初期化
			this.initSavedFileTypeRadioButtons();
			// 保存ファイル形式
			this.setSavedFileType(settings);
			// 分割方法RadioButtonを初期化します。
			this.initSplitTypeRadioButtons();
			// 分割方法
			this.setSplitType(settings);
			// 中心を除去する
			this.chkRemoveCenter.Checked = settings.IsRemovedCenterLine;
			this.setChkRemoveCenterChecked();
			// 除去する幅
			this.numRemovedCenterWidth.Value = settings.RemovedCenterLineWidth;
		}

		/// <summary>
		/// 設定画面のLoadイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void SplitSettingView_Load(object sender, EventArgs e)
		{
			// コントロールを初期化
			this.initControls();
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public SplitSettingView()
		{
			InitializeComponent();
		}

		#endregion
	}
}
