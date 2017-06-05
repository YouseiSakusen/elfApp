namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// プラグインエラーを表す列挙型。
	/// </summary>
	public enum PluginError
	{
		/// <summary>
		/// エラー無し
		/// </summary>
		ErrorNone = 0,
		/// <summary>
		/// イメージコーデック無し
		/// </summary>
		ImageCodecNotFound = 1,
		/// <summary>
		/// 同名ファイルあり
		/// </summary>
		ExistsSameFileName = 2
	}
}
