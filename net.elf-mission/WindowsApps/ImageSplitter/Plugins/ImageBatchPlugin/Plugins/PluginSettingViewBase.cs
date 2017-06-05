namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグインの設定Viewを表します。
	/// </summary>
	public partial class PluginSettingViewBase : net.elfmission.WindowsApps.Controls.elfDynamicView
	{
		#region "プロパティ"

		/// <summary>
		/// 対象のプラグインを取得・設定します。
		/// </summary>
		public IImageBatchPlugin Plugin { get; set; } = null;

		#endregion

		#region "メソッド"

		/// <summary>
		/// プラグイン設定を保存します。
		/// </summary>
		/// <param name="target">プラグイン設定を表すobject。</param>
		protected void savePluginSettings(object target)
		{
			Utilities.XmlUtility.XmlSerializeTo(((ImageBatchPluginBase)(this.Plugin)).GetPluginSettingFilePath(), target);
		}

		/// <summary>
		/// 設定が確定した場合に呼び出されます。
		/// </summary>
		public virtual void SettingFinished() { }

		/// <summary>
		/// 設定エラーの有無を取得します。
		/// </summary>
		/// <returns>設定エラーの有無を表すbool。</returns>
		public virtual bool HasSettingError() { return true; }

		/// <summary>
		/// プラグインの設定を取得します。
		/// </summary>
		/// <typeparam name="T">プラグインの設定を表す型。</typeparam>
		/// <returns>プラグイン設定を表すT。</returns>
		protected T getPluginSettings<T>() where T : class, new()
		{
			var setting = Utilities.XmlUtility.XmlDeserializeFrom<T>(((ImageBatchPluginBase)this.Plugin).GetPluginSettingFilePath());
			if (setting == null)
			{
				return new T();
			}
			else
			{
				return setting;
			}
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public PluginSettingViewBase()
		{
			InitializeComponent();
		}

		#endregion
	}
}
