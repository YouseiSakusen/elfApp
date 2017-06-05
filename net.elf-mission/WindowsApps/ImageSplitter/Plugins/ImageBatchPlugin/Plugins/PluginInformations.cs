using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグイン情報を表します。
	/// </summary>
	public class PluginInformations
	{
		#region "プロパティ"

		/// <summary>
		/// 設定画面のタイトルを取得・設定します。
		/// </summary>
		public string SettingFormTitle { get; set; } = string.Empty;

		/// <summary>
		/// 設定画面の有無を取得・設定します。
		/// </summary>
		public bool HasSettingView { get; set; } = true;

		/// <summary>
		/// メニューアイテムの文字列を取得・設定します。
		/// </summary>
		public string MenuText { get; set; } = string.Empty;

		/// <summary>
		/// メニューに表示するイメージを取得・設定します。
		/// </summary>
		public Image MenuImage { get; set; } = null;

		#endregion
	}
}
