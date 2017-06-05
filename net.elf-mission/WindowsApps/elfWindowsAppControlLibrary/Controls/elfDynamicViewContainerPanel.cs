using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// DynamicViewのコンテナパネルを表します。
	/// </summary>
	public class elfDynamicViewContainerPanel : elfPanel, IelfDynamicViewContainer
	{
		#region "IelfDynamicViewContainerインプリメント"

		/// <summary>
		/// DynamicViewの管理クラスを表します。
		/// </summary>
		private elfDynamicViewManager manager = null;

		/// <summary>
		/// DynamicViewを要求する場合に発生するイベント。
		/// </summary>
		public event WantDynamicViewEventHandler WantDynamicView;

		/// <summary>
		/// 現在表示しているViewを取得します。
		/// </summary>
		public elfDynamicView CurrentView
		{
			get
			{
				return this.manager.CurrentView;
			}
		}

		/// <summary>
		/// DynamicViewを表示します。
		/// </summary>
		/// <param name="viewKey">表示するDynamicViewを識別するキーを表す文字列。</param>
		public void ShowDynamicView(string viewKey)
		{
			this.manager.ShowDynamicView(viewKey);
		}

		/// <summary>
		/// DynamicViewを要求します。
		/// </summary>
		/// <param name="viewKey">表示するDynamicViewを識別するためのキーを表す文字列。</param>
		/// <returns>表示するDynamicView。</returns>
		public elfDynamicView RequestedDynamicView(string viewKey)
		{
			var e = new WantDynamicViewEventArgs { ViewKey = viewKey };

			this.onWantDynamicView(e);
			return e.View;
		}

		/// <summary>
		/// WantDynamicViewイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているWantDynamicViewEventArgs。</param>
		protected virtual void onWantDynamicView(WantDynamicViewEventArgs e) { WantDynamicView(this, e); }

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public elfDynamicViewContainerPanel() : base()
		{
			this.manager = new elfDynamicViewManager(this);
		}

		#endregion

		#region "デストラクタ"

		/// <summary>
		/// Control とその子コントロールが使用しているアンマネージ リソースを解放します。オプションで、マネージ リソースも解放します。
		/// </summary>
		/// <param name="disposing">マネージ リソースとアンマネージ リソースの両方を解放する場合は true。アンマネージ リソースだけを解放する場合は false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) { this.manager.Dispose(); }

			base.Dispose(disposing);
		}

		#endregion
	}
}
