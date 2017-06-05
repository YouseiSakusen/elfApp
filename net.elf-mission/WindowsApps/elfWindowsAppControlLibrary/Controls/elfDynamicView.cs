using System.ComponentModel;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// 動的ビューコントロールを表します。
	/// </summary>
	public partial class elfDynamicView : net.elfmission.WindowsApps.Controls.elfUserControl
	{
		#region "プロパティ"

		/// <summary>
		/// キャッシュを使用せず常に新規でLoadするかを取得・設定します。
		/// </summary>
		[DefaultValue(false)]
		public bool AlwaysLoad { get; set; } = false;

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public elfDynamicView()
		{
			InitializeComponent();
		}

		#endregion
	}
}
