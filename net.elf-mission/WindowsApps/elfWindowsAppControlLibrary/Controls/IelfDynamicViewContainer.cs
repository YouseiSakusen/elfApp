using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// WantDynamicViewデリゲートを表します。
	/// </summary>
	/// <param name="sender">イベントのソース。</param>
	/// <param name="e">イベントデータを格納しているWantDynamicViewEventArgs。</param>
	public delegate void WantDynamicViewEventHandler(object sender, WantDynamicViewEventArgs e);

	/// <summary>
	/// DynamicViewコンテナインタフェースを表します。
	/// </summary>
	public interface IelfDynamicViewContainer
	{
		#region "メソッド"

		/// <summary>
		/// DynamicViewを表示します。
		/// </summary>
		/// <param name="viewKey">表示するDynamicViewを識別するキーを表す文字列。</param>
		void ShowDynamicView(string viewKey);

		/// <summary>
		/// DynamicViewを要求します。
		/// </summary>
		/// <param name="viewKey">表示するDynamicViewを識別するためのキーを表す文字列。</param>
		/// <returns>表示するDynamicView。</returns>
		elfDynamicView RequestedDynamicView(string viewKey);

		#endregion

		#region "イベント"

		/// <summary>
		/// DynamicViewを要求する場合に発生するイベント。
		/// </summary>
		event WantDynamicViewEventHandler WantDynamicView;

		#endregion
	}
}
