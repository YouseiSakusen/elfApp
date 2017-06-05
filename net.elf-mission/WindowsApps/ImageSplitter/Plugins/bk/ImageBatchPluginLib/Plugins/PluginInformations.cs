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
