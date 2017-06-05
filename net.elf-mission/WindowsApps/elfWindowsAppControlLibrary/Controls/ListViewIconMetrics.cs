using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// ListViewのアイコン情報を表します。
	/// </summary>
	public class ListViewIconMetrics
	{
		#region "プロパティ"

		/// <summary>
		/// Win32APIの実行結果を取得・設定します。
		/// </summary>
		public bool IsApiSuccessful { get; set; } = false;

		/// <summary>
		/// アイコン同士の水平間隔を取得・設定します。
		/// </summary>
		public int HorizontalSpacing { get; set; } = 0;

		/// <summary>
		/// アイコン同士の垂直間隔を取得・設定します。
		/// </summary>
		public int VerticalSpacing { get; set; } = 0;

		#endregion
	}
}
