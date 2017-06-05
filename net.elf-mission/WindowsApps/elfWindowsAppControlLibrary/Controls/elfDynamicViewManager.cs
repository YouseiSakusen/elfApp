using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// DynamicViewを管理します。
	/// </summary>
	public class elfDynamicViewManager : IDisposable
	{
		#region "変数"

		/// <summary>
		/// DynamicViewのコンテナを表します。
		/// </summary>
		private Control container = null;
		/// <summary>
		/// DynamicViewの参照を保持するDictionary<string, elfDynamicView>。
		/// </summary>
		private Dictionary<string, elfDynamicView> viewDic = null;
		/// <summary>
		/// 現在表示しているViewを表します。
		/// </summary>
		private elfDynamicView currentView = null;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// 現在のViewを取得します。
		/// </summary>
		public elfDynamicView CurrentView
		{
			get
			{
				return this.currentView;
			}
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// キャッシュにViewを追加します。
		/// </summary>
		/// <param name="view">キャッシュに追加するelfDynamicView。</param>
		private void addViewToCache(elfDynamicView view)
		{
			if (!view.AlwaysLoad)
			{
				// 常にLoadする場合はキャッシュに追加しない
				var viewKey = view.GetType().FullName;
				// キーが存在しない場合は追加
				if (! this.viewDic.ContainsKey(viewKey)) { this.viewDic.Add(view.GetType().FullName, view); }
			}
		}

		/// <summary>
		/// コンテナにViewをセットします。
		/// </summary>
		/// <param name="view">表示するViewを表すelfDynamicView。</param>
		private void setViewToContainer(elfDynamicView view)
		{
			this.container.Controls.Add(view);
			view.Parent = this.container;
			view.Dock = DockStyle.Fill;
			view.Visible = true;
			this.currentView = view;

			this.addViewToCache(view);
		}

		/// <summary>
		/// 現在のViewをDisposeします。
		/// </summary>
		private void disposeCurrentView()
		{
			if (this.currentView != null)
			{
				// 現在のViewが常にLoadするViewの場合はリストに登録されていないので改めてDispose
				if (this.currentView.AlwaysLoad) { this.currentView.Dispose(); }
			}

			this.currentView = null;
		}

		/// <summary>
		/// 現在のViewを取り外します。
		/// </summary>
		private void removedCurrentView()
		{
			// Viewが追加されていない場合は抜ける
			if (this.currentView == null)
				return;

			this.currentView.Visible = false;
			this.currentView.Dock = DockStyle.None;
			this.currentView.Parent = null;
			this.container.Controls.Remove(this.currentView);
			this.disposeCurrentView();
		}

		/// <summary>
		/// 表示するViewを取得します。
		/// </summary>
		/// <param name="viewKey">表示するViewを識別するためのキーを表す文字列。</param>
		/// <returns>表示するView。</returns>
		private elfDynamicView getView(string viewKey)
		{
			if (this.viewDic.ContainsKey(viewKey))
				return this.viewDic[viewKey];

			// コンテナにViewを要求
			var view = ((IelfDynamicViewContainer)(this.container)).RequestedDynamicView(viewKey);
			if (view == null)
				throw new NotImplementedException(Properties.Resources.EXP_WantDynamicView_EVENT_NOT_IMPLEMENT);

			return view;
		}

		/// <summary>
		/// DynamicViewを表示します。
		/// </summary>
		/// <param name="viewKey">表示するDynamicViewを識別するキーを表す文字列。</param>
		public void ShowDynamicView(string viewKey)
		{
			// Viewを取得
			var view = this.getView(viewKey);
			// 現在のViewを取り外す
			this.removedCurrentView();
			// Viewをコンテナに表示。
			this.setViewToContainer(view);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="container">IelfDynamicViewContainerをインプリメントしたDynamicViewのコンテナを表すControl。</param>
		public elfDynamicViewManager(Control container) : base()
		{
			if (container == null)
				throw new NullReferenceException(Properties.Resources.EXP_CONTAINER_IS_NULL);
			if (!(container is IelfDynamicViewContainer))
				throw new ArgumentException(Properties.Resources.EXP_CONTAINER_IS_NOT_DYNAMIC_VIEW_CONTAINER);

			this.viewDic = new Dictionary<string, elfDynamicView>();
			this.container = container;
		}

		/// <summary>
		/// デフォルトコンストラクタの呼出しは禁止。
		/// </summary>
		private elfDynamicViewManager() : base() { }

		#endregion

		#region IDisposable Support

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// DynamicViewのリストを解放
					foreach (var key in this.viewDic.Keys)
					{
						this.viewDic[key].Dispose();
					}
					this.viewDic.Clear();

					this.disposeCurrentView();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~elfDynamicViewManager() {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		#endregion
	}
}
