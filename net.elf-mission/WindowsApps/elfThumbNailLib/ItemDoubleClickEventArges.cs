using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// ItemDoubleClickイベントデータを格納します。
	/// </summary>
	public class ItemDoubleClickEventArges : EventArgs
	{
		#region "プロパティ"

		/// <summary>
		/// ダブルクリックされた対象のサムネイルを取得・設定します。
		/// </summary>
		public ThumbNailItem TargetItem { get; set; } = null;

		#endregion
	}
}
