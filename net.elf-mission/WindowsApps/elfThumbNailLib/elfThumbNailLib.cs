using System;

namespace net.elfmission.WindowsApps.Controls
{
	#region "列挙型"

	/// <summary>
	/// サムネイルのサイズを表す列挙型。
	/// </summary>
	public enum ThumbNailSize
	{
		/// <summary>
		/// 小さいイメージを表します。
		/// </summary>
		SmallImage,
		/// <summary>
		/// 中サイズのイメージを表します。
		/// </summary>
		MediumImage,
		/// <summary>
		/// 大きいサイズのイメージを表します。
		/// </summary>
		LargeImage,
		/// <summary>
		/// 特大サイズのイメージを表します。
		/// </summary>
		ExtraLargeImage
	}

	/// <summary>
	/// elfThumbNailViewでサポートするイメージファイルを表す列挙型。
	/// </summary>
	[Flags]
	public enum SupportedImageTypes
	{
		/// <summary>
		/// イメージタイプ無しを表します。
		/// </summary>
		ImageTypeNone = 0,
		/// <summary>
		/// ビットマップ形式のファイルを表します。
		/// </summary>
		Bitmap = 0x01,
		/// <summary>
		/// Jpeg形式のファイルを表します。
		/// </summary>
		Jpeg = 0x02,
		/// <summary>
		/// PNG形式のファイルを表します。
		/// </summary>
		Png = 0x04,
		/// <summary>
		/// GIF形式のファイルを表します。
		/// </summary>
		Gif = 0x08
	}

	/// <summary>
	/// elfThumbNailViewの状態を表す列挙型。
	/// </summary>
	public enum ThumbNailViewStatus
	{
		/// <summary>
		/// 空のViewを表します。
		/// </summary>
		EmptyView,
		/// <summary>
		/// 同一フォルダ選択済み。
		/// </summary>
		SameImageFolderSelected,
		/// <summary>
		/// イメージフォルダが存在しない。
		/// </summary>
		ImageFolderNotExists,
		/// <summary>
		/// サムネイルのロード完了。
		/// </summary>
		ThumbNailLoadsFinished
	}

	#endregion
}