using System;
using System.Windows.Forms;
using net.elfmission.WindowsApps.Controls;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグインの呼び出しフォームを表します。
	/// </summary>
	public partial class PluginForm : net.elfmission.WindowsApps.ImageSplitter.ImageSplitterBase
	{
		#region "プロパティ"

		/// <summary>
		/// 実行対象のプラグインを取得・設定します。
		/// </summary>
		public IImageBatchPlugin Plugin { set; get; }

		#endregion

		#region "イベント"

		/// <summary>
		/// OKボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			if (this.pnlBody.CurrentView == null) { return; }

			var view = (PluginSettingViewBase)this.pnlBody.CurrentView;
			if (view.HasSettingError()) { return; }

			view.SettingFinished();
			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// DynamicViewコンテナのWantDynamicViewイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているWantDynamicViewEventArgs。</param>
		private void pnlBody_WantDynamicView(object sender, WantDynamicViewEventArgs e)
		{
			var view = this.Plugin.GetSettingView();
			view.Plugin = this.Plugin;

			e.View = view;
		}

		/// <summary>
		/// 配置コントロールを初期化します。
		/// </summary>
		private void initControls()
		{
			// タイトルを設定
			this.Text = this.Plugin.PluginInformations.SettingFormTitle;
			// プラグインから設定画面を取得して表示
			this.pnlBody.ShowDynamicView(typeof(elfDynamicView).FullName);
		}

		/// <summary>
		/// 画面のLoadイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void PluginForm_Load(object sender, EventArgs e)
		{
			this.initControls();
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public PluginForm()
		{
			InitializeComponent();
		}

		#endregion
	}
}
