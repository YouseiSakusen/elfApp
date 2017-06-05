using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// 一括処理プラグインのインタフェースを表します。
	/// </summary>
	public interface IImageBatchPlugin
	{
		/// <summary>
		/// プラグイン情報を取得します。
		/// </summary>
		/// <returns>プラグイン情報を表すPluginInformations。</returns>
		PluginInformations GetPluginInformations();
	}
}
