using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplitPlugin
{
	/// <summary>
	/// イメージ分割プラグインを表します。
	/// </summary>
	public class SplitImagePlugin : IImageBatchPlugin
	{
		#region "メソッド"

		/// <summary>
		/// プラグイン情報を取得します。
		/// </summary>
		/// <returns>プラグイン情報を表すPluginInformations。</returns>
		public PluginInformations GetPluginInformations()
		{
			return new PluginInformations
			{
				MenuText = Properties.Resources.MenuText,
				MenuImage = Properties.Resources.MenuImage
			};
		}

		#endregion
	}
}
