using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// WantDynamicViewイベントデータを格納します。
	/// </summary>
	public class WantDynamicViewEventArgs : EventArgs
	{
		#region "プロパティ"

		/// <summary>
		/// DynamicViewを識別するためのキーを取得・設定します。
		/// </summary>
		public string ViewKey { get; set; } = string.Empty;

		/// <summary>
		/// 表示するDynamicViewを取得・設定します。
		/// </summary>
		public elfDynamicView View { get; set; } = null;

		#endregion
	}
}
