using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグイン設定の基底クラスを表します。
	/// </summary>
	public class PluginSettingBase
	{
		#region "プロパティ"

		/// <summary>
		/// Jpeg形式で保存するかを取得・設定します。
		/// </summary>
		public bool SaveJpeg { get; set; } = true;

		/// <summary>
		/// Jpeg保存時の品質を取得・設定します。
		/// </summary>
		public decimal JpegSavedQuality { get; set; } = 80;

		/// <summary>
		/// 同名のファイルが存在した場合はスキップするかを取得・設定します。
		/// </summary>
		public bool IsSkipSameFileName { get; set; } = true;

		#endregion
	}
}
