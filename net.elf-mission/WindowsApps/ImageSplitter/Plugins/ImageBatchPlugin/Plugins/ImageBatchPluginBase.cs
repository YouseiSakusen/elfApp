using System.IO;
using System.Collections.Generic;
using System;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグインのベースクラスを表します。
	/// </summary>
	public abstract class ImageBatchPluginBase : IImageBatchPlugin
	{
		#region "変数"

		/// <summary>
		/// 一括処理対象フォルダのパスを表します。
		/// </summary>
		private string srcImagePath = string.Empty;
		/// <summary>
		/// 処理対象フォルダ名を表します。
		/// </summary>
		private string targetFolderName = string.Empty;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// プラグインの配置フォルダパスを取得・設定します。
		/// </summary>
		public string PluginFolderPath { get; set; } = string.Empty;

		/// <summary>
		/// プラグイン情報を取得します。
		/// </summary>
		public abstract PluginInformations PluginInformations { get; }

		/// <summary>
		/// 選択ファイル保存処理の有効無効を取得・設定します。
		/// </summary>
		public bool SelectedFilesFinisherEnabled { get; set; } = false;

		/// <summary>
		/// 一括処理対象フォルダのフルパスを取得・設定します。
		/// </summary>
		public string SourceImagePath
		{
			get
			{
				return this.srcImagePath;
			}
			set
			{
				this.srcImagePath = value;

				var folderNameList = value.Split(new char[] { Path.DirectorySeparatorChar });
				this.targetFolderName = folderNameList[folderNameList.GetUpperBound(0)];
			}
		}

		/// <summary>
		/// 処理対象元フォルダ名を取得します。
		/// </summary>
		public string SourceFolderName
		{
			get
			{
				return this.targetFolderName;
			}
		}

		/// <summary>
		/// 非選択ファイルも含めて全ファイルを処理するかを取得・設定します。
		/// </summary>
		public abstract bool IsTargetAllFiles { get; }

		#endregion

		#region "メソッド"

		/// <summary>
		/// プラグインの処理を実行します。
		/// </summary>
		/// <param name="target">処理対象のイメージを表すBatchTargetImage</param>
		/// <returns>プラグインの処理結果を表すBatchTargetImageのリスト。</returns>
		public abstract List<BatchTargetImage> Execute(BatchTargetImage target);

		/// <summary>
		/// プラグインの設定ファイルパスを取得します。
		/// </summary>
		/// <returns></returns>
		internal string GetPluginSettingFilePath()
		{
			return Path.Combine(this.PluginFolderPath, this.GetType().Name + ".xml");
		}

		/// <summary>
		/// 設定画面用のビューを取得します。
		/// </summary>
		/// <returns>設定画面用のビューを表すPluginSettingViewBase。</returns>
		public abstract PluginSettingViewBase GetSettingView();

		#endregion
	}
}
