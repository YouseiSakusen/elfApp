using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps
{
	/// <summary>
	/// 画面の復元情報を表します。
	/// </summary>
	public class FormRestoreInformations
	{
		#region "プロパティ"

		/// <summary>
		/// 画面の開始位置を取得・設定します。
		/// </summary>
		public FormStartPosition StartPosition { get; set; } = FormStartPosition.CenterScreen;

		/// <summary>
		/// ウィンドウの表示状態を取得・設定します。
		/// </summary>
		public FormWindowState WindowState { get; set; } = FormWindowState.Normal;

		/// <summary>
		/// 画面のサイズを取得・設定します。
		/// </summary>
		public Size FormSize { get; set; } = new Size(800, 600);

		/// <summary>
		/// 画面の表示位置を取得・設定します。
		/// </summary>
		public Point FormPosition { get; set; } = new Point(0, 0);

		#endregion
	}
}
