using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// Windowsコントロールユーティリティを表します。
	/// </summary>
	public static class WinControlUtility
	{
		#region "Win32API用の宣言"

		/// <summary>
		/// アイテムの状態を設定するフラグを表します。
		/// </summary>
		public const int LVM_SETITEMSTATE = 0x102B;
		/// <summary>
		/// オーバーレイのマスクを表します。
		/// </summary>
		private const int LVIS_OVERLAYMASK = 0x0F00;
		/// <summary>
		/// 状態フラグを表します。
		/// </summary>
		private const int LVIF_STATE = 0x0008;

		/// <summary>
		/// オーバーレイアイコンを指定します。
		/// </summary>
		/// <param name="himl">イメージリストのハンドルを表すIntPtr。</param>
		/// <param name="iImage">オーバーレイに使用するイメージリスト内のアイコンのインデックスを表すint。</param>
		/// <param name="iOverlay">オーバーレイアイコンを識別する1から開始するインデックスを表すint。</param>
		/// <returns>関数の失敗は0、成功した場合は0以外が返ります。</returns>
		[DllImport("comctl32.dll")]
		private static extern int ImageList_SetOverlayImage(IntPtr himl, int iImage, int iOverlay);

		/// <summary>
		/// アイコン情報を取得するパラメータ値を表します。
		/// </summary>
		private const int SPI_GETICONMETRICS = 45;
		/// <summary>
		/// アイコン情報を設定するパラメータ値を表します。
		/// </summary>
		private const int SPI_SETICONMETRICS = 46;

		#region "LOGFONT構造体"

		/// <summary>
		/// フォント名をセットする文字列変数のサイズを表します。
		/// </summary>
		private const int LF_FACESIZE = 32;

		/// <summary>
		/// フォントの太さを表す列挙型。
		/// </summary>
		private enum FontWeight
		{
			FW_DONTCARE = 0,
			FW_THIN = 100,
			FW_EXTRALIGHT = 200,
			FW_ULTRALIGHT = 200,
			FW_LIGHT = 300,
			FW_NORMAL = 400,
			FW_REGULAR = 400,
			FW_MEDIUM = 500,
			FW_SEMIBOLD = 600,
			FW_DEMIBOLD = 600,
			FW_BOLD = 700,
			FW_EXTRABOLD = 800,
			FW_ULTRABOLD = 800,
			FW_HEAVY = 900,
			FW_BLACK = 900
		}
		/// <summary>
		/// フォント情報を表します。
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
		private struct LOGFONT
		{
			/// <summary>
			/// フォントの高さを表すint。
			/// </summary>
			public int lfHeight;
			/// <summary>
			/// フォントの幅を表すint。
			/// </summary>
			public int lfWidth;
			/// <summary>
			/// 行の角度を 0.1 単位で指定します。デフォルトは0。
			/// </summary>
			public int lfEscapement;
			/// <summary>
			/// ベースラインの角度を 0.1 単位で指定します。デフォルトは0。
			/// </summary>
			public int lfOrientation;
			/// <summary>
			/// フォントの太さを表すFontWeight列挙型の内の1つ。
			/// </summary>
			public FontWeight lfWeight;
			/// <summary>
			/// 1 を指定するとイタリック体になります。デフォルトは0。
			/// </summary>
			public byte lfItalic;
			/// <summary>
			/// 1 を指定すると下線付きのフォントになります。デフォルトは0。
			/// </summary>
			public byte lfUnderline;
			/// <summary>
			/// 1 を指定すると、打消しライン付きのフォントになります。デフォルトは0。
			/// </summary>
			public byte lfStrikeOut;
			/// <summary>
			/// キャラクタセットを表すbyte。
			/// </summary>
			public byte lfCharSet;
			/// <summary>
			/// 出力精度を表すbyte。
			/// </summary>
			public byte lfOutPrecision;
			/// <summary>
			/// クリッピング精度を表すbyte。
			/// </summary>
			public byte lfClipPrecision;
			/// <summary>
			/// 出力品質を表すbyte。
			/// </summary>
			public byte lfQuality;
			/// <summary>
			/// フォントのピッチ、およびファミリを表すbyte。
			/// </summary>
			public byte lfPitchAndFamily;
			/// <summary>
			/// フォント名を示す文字列。
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
			public string lfFaceName;
		}

		#endregion

		/// <summary>
		/// アイコン情報を表します。
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ICONMETRICS
		{
			/// <summary>
			/// アイコンのサイズを取得・設定します。
			/// </summary>
			public int cbSize;
			public int iHorzSpacing;
			public int iVertSpacing;
			public int iTitleWrap;
			public LOGFONT lfFont;

			/// <summary>
			/// コンストラクタ。
			/// </summary>
			/// <param name="dummy">ダミーパラメータ。何を渡してもOK。</param>
			public ICONMETRICS(int dummy)
			{
				this.cbSize = 0;
				this.iHorzSpacing = 0;
				this.iVertSpacing = 0;
				this.iTitleWrap = 0;
				this.lfFont = new LOGFONT();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uAction">取得または設定するべき、システム全体のパラメータを指定します</param>
		/// <param name="lpvParam"></param>
		/// <param name="uParam"></param>
		/// <param name="fuWinIni"></param>
		/// <returns></returns>
		[DllImport("user32", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo", SetLastError = true)]
		private static extern bool SystemParametersInfo(long uAction, int lpvParam, ref ICONMETRICS uParam, int fuWinIni);

		#endregion

		#region "メソッド"

		/// <summary>
		/// オーバーレイ情報を取得します。
		/// </summary>
		/// <param name="item">オーバーレイアイコンを描画するListViewItem。</param>
		/// <param name="overlayIndex">描画するオーバーレイインデックスを表すuint。</param>
		/// <returns>オーバーレイ情報を表すLVITEM。</returns>
		public static LVITEM GetOverlayItemInfo(ListViewItem item, uint overlayIndex)
		{
			return new LVITEM
			{
				stateMask = WinControlUtility.LVIS_OVERLAYMASK,
				state = (overlayIndex << 8)
			};
		}

		/// <summary>
		/// オーバーレイアイコンを設定します。
		/// </summary>
		/// <param name="imgList">オーバーレイアイコンを登録しているImageList。</param>
		/// <param name="imageListIndex">オーバーレイに使用するイメージリスト内のアイコンのインデックスを表すint。</param>
		/// <param name="overlayIndex">オーバーレイアイコンを識別する1から開始するインデックスを表すint。</param>
		public static void SetOverlayImageList(ImageList imgList, int imageListIndex, int overlayIndex)
		{
			var ret = ImageList_SetOverlayImage(imgList.Handle, imageListIndex, overlayIndex);
			if (ret == 0)
			{
				throw new Exception("Win32API： ImageList_SetOverlayImageの呼び出しに失敗しました。");
			}
		}

		/// <summary>
		/// ListViewの大きいアイコンの情報を取得します。
		/// </summary>
		/// <returns>ListViewの大きいアイコンの情報を表すListViewIconMetrics。</returns>
		public static ListViewIconMetrics GetListViewIconMetrics()
		{
			var metrics = new ICONMETRICS(0);
			metrics.cbSize = Marshal.SizeOf(metrics);

			var ret = SystemParametersInfo(WinControlUtility.SPI_GETICONMETRICS, Marshal.SizeOf(metrics), ref metrics, 0);
			var retMetric = new ListViewIconMetrics { IsApiSuccessful = ret };

			if (ret)
			{
				retMetric.HorizontalSpacing = metrics.iHorzSpacing;
				retMetric.VerticalSpacing = metrics.iVertSpacing;
			}

			return retMetric;
		}

		/// <summary>
		/// 情報メッセージを表示します。
		/// </summary>
		/// <param name="msg">表示するメッセージを表す文字列。</param>
		public static void ShowInformationMessage(string msg)
		{
			WinControlUtility.showMessageBox(null, msg, Properties.Resources.MsgBoxTitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 情報メッセージを表示します。
		/// </summary>
		/// <param name="container">メッセージボックスを表示するコンテナ。(FormやUserControl等)</param>
		/// <param name="msg">表示するメッセージを表す文字列。</param>
		public static void ShowInformationMessage(Control container, string msg)
		{
			WinControlUtility.showMessageBox(container, msg, Properties.Resources.MsgBoxTitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 問い合わせメッセージを表示します。
		/// </summary>
		/// <param name="container">メッセージボックスを表示するコンテナ。(FormやUserControl等)</param>
		/// <param name="msg">表示するメッセージを表す文字列。</param>
		/// <returns>ユーザの操作結果を表すDialogResult列挙型の内の1つ。</returns>
		public static DialogResult ShowQuestionMessage(Control container, string msg)
		{
			return WinControlUtility.showMessageBox(container, msg, Properties.Resources.MsgBoxTitleQuestion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		/// <summary>
		/// 警告メッセージを表示します。
		/// </summary>
		/// <param name="container">メッセージボックスを表示するコンテナ。(FormやUserControl等)</param>
		/// <param name="msg">表示する文字列。</param>
		public static void ShowWarningMessage(Control container, string msg)
		{
			WinControlUtility.showMessageBox(container, msg, Properties.Resources.MsgBoxTitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// エラーメッセージを表示します。
		/// </summary>
		/// <param name="msg">表示する文字列。</param>
		public static void ShowErrorMessage(string msg)
		{
			WinControlUtility.showMessageBox(null, msg, Properties.Resources.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// エラーメッセージを表示します。
		/// </summary>
		/// <param name="container">メッセージボックスを表示するコンテナ。(FormやUserControl等)</param>
		/// <param name="msg">表示する文字列。</param>
		public static void ShowErrorMessage(Control container, string msg)
		{
			WinControlUtility.showMessageBox(container, msg, Properties.Resources.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// メッセージボックスを表示します。
		/// </summary>
		/// <param name="container">メッセージボックスを表示するコンテナ。(FormやUserControl等)</param>
		/// <param name="msg">表示するメッセージを表す文字列。</param>
		/// <param name="msgBoxTitle">メッセージボックスのタイトルを表す文字列。</param>
		/// <param name="msgButtons">メッセージボックスのボタンを表すMessageBoxButtons列挙型の内の1つ。</param>
		/// <param name="msgIcon">メッセージボックスのアイコンを表すMessageBoxIcon列挙型の内の1つ。</param>
		/// <returns>ユーザの操作結果を表すDialogResult列挙型の内の1つ。</returns>
		private static DialogResult showMessageBox(Control container, string msg, string msgBoxTitle, MessageBoxButtons msgButtons, MessageBoxIcon msgIcon)
		{
			// メッセージボックスのオーナーを取得
			var owner = container.FindForm();

			if (owner == null)
			{
				return MessageBox.Show(msg, msgBoxTitle, msgButtons, msgIcon);
			}
			else
			{
				return MessageBox.Show(owner, msg, msgBoxTitle, msgButtons, msgIcon);
			}
		}

		/// <summary>
		/// 指定したコンテナ上からチェックされたRadioButtonを取得します。
		/// </summary>
		/// <param name="container">RadioButtonが配置されているControl。</param>
		/// <returns>指定したコンテナ上でチェックされたRadioButton。</returns>
		public static RadioButton GetCheckedRadioButton(Control container)
		{
			foreach (Control ctrl in container.Controls)
			{
				if (ctrl is RadioButton)
				{
					if (((RadioButton)ctrl).Checked)
						return (RadioButton)ctrl;
				}
			}

			return null;
		}

		#endregion
	}
}
