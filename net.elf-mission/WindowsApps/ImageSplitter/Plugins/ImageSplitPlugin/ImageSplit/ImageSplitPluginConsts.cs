namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// 非選択ファイルの処理を表す列挙型。
	/// </summary>
	public enum UnselectedFilesOperation
	{
		/// <summary>
		/// 処理しない。
		/// </summary>
		SkipFiles,
		/// <summary>
		/// コピーする。
		/// </summary>
		CopyFiles,
		/// <summary>
		/// 新規ファイルに保存する。
		/// </summary>
		CreatNewFiles
	}

	/// <summary>
	/// ページの分割方法を表す列挙型。
	/// </summary>
	public enum SplitType
	{
		/// <summary>
		/// 分割しない。
		/// </summary>
		NoSplit,
		/// <summary>
		/// 垂直方向に分割して左を小さい番号のページとして保存。
		/// </summary>
		Vertical1_2,
		/// <summary>
		/// 垂直方向に分割して左は大きい番号のページとして保存。
		/// </summary>
		Vertical2_1,
		/// <summary>
		/// 水平方向に分割して上を小さい番号のページとして保存。
		/// </summary>
		Horizontal1_2,
		/// <summary>
		/// 水平方向に分割して上は大きい番号のページとして保存。
		/// </summary>
		Horizontal2_1
	}
}