using System.Runtime.InteropServices;

namespace net.elfmission.WindowsApps
{
	namespace Controls
	{
		#region "LVITEM構造体"

		/// <summary>
		/// リストビューアイテムの属性を表します。
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LVITEM
		{
			/// <summary>
			/// 有効メンバを表すuint。
			/// </summary>
			public uint mask;
			/// <summary>
			/// アイテムのインデックスを表すint。
			/// </summary>
			public int iItem;
			/// <summary>
			/// サブアイテムのインデックスを表すint。
			/// </summary>
			public int iSubItem;
			/// <summary>
			/// アイテムの状態・イメージを表すuint。
			/// </summary>
			public uint state;
			/// <summary>
			/// state のフラグを表すuint。
			/// </summary>
			public uint stateMask;
			/// <summary>
			/// アイテムの文字列。
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string pszText;
			/// <summary>
			/// pszTextメンバのサイズを表すint。
			/// </summary>
			public int cchTextMax;
			/// <summary>
			/// イメージのインデックスを表すint。
			/// </summary>
			public int iImage;
			/// <summary>
			/// アイテムのパラメータを表すuint。
			/// </summary>
			public uint lParam;
			/// <summary>
			/// インデントを表すint。
			/// </summary>
			public int iIndent;
		}

		#endregion
	}

	/// <summary>
	/// イメージの形を表す列挙型。
	/// </summary>
	public enum ImagePattern
	{
		/// <summary>
		/// 形無し(初期化用)
		/// </summary>
		None,
		/// <summary>
		/// 正方形を表します。
		/// </summary>
		Square,
		/// <summary>
		/// 横長長方形を表します。
		/// </summary>
		Landscape,
		/// <summary>
		/// 縦長長方形を表します。
		/// </summary>
		Portrait
	}
}