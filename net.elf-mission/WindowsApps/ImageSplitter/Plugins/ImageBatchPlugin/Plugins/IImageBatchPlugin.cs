using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.elfmission.WindowsApps.Controls;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// 一括処理プラグインのインタフェースを表します。
	/// </summary>
	public interface IImageBatchPlugin
	{
		#region "プロパティ"

		/// <summary>
		/// 処理対象元フォルダ名を取得します。
		/// </summary>
		string SourceFolderName { get; }

		/// <summary>
		/// 一括処理対象フォルダのフルパスを取得・設定します。
		/// </summary>
		string SourceImagePath { get; set; }

		/// <summary>
		/// 選択ファイル保存処理の有効無効を取得・設定します。
		/// </summary>
		bool SelectedFilesFinisherEnabled { get; set; }

		/// <summary>
		/// プラグイン情報を取得します。
		/// </summary>
		PluginInformations PluginInformations { get; }

		/// <summary>
		/// プラグインの配置フォルダパスを取得・設定します。
		/// </summary>
		string PluginFolderPath { get; set; }

		/// <summary>
		/// 非選択ファイルも含めて全ファイルを処理するかを取得・設定します。
		/// </summary>
		bool IsTargetAllFiles { get; }

		#endregion

		#region "メソッド"

		/// <summary>
		/// プラグインの処理を実行します。
		/// </summary>
		/// <param name="target">処理対象のイメージを表すBatchTargetImage</param>
		/// <returns>プラグインの処理結果を表すBatchTargetImageのリスト。</returns>
		List<BatchTargetImage> Execute(BatchTargetImage target);

		/// <summary>
		/// 設定画面用のビューを取得します。
		/// </summary>
		/// <returns>設定画面用のビューを表すPluginSettingViewBase。</returns>
		PluginSettingViewBase GetSettingView();

		#endregion
	}
}
