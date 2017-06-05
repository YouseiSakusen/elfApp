using System;
using System.Threading;
using System.Windows.Forms;
using net.elfmission.WindowsApps.Controls;

namespace net.elfmission.WindowsApps.ImageSplitter
{
	#region "列挙型"

	/// <summary>
	/// Viewer画面に表示するファイル名の表示位置を表す列挙型。
	/// </summary>
	public enum ViewerFileNamePosition
	{
		/// <summary>
		/// 左上に左揃えで表示します。
		/// </summary>
		TopLeft,
		/// <summary>
		/// 左下に左揃えで表示します。
		/// </summary>
		BottomLeft,
		/// <summary>
		/// 右上に右揃えで表示します。
		/// </summary>
		TopRight,
		/// <summary>
		/// 右下に右揃えで表示します。
		/// </summary>
		BottomRight
	}

	#endregion

	/// <summary>
	/// アプリケーションクラスを表します。
	/// </summary>
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!WinShellUtility.IsVistaOver())
			{
				// 非サポートOSメッセージ
				WinControlUtility.ShowErrorMessage(Properties.Resources.ImageSplitter_ERR_VERSION_UNMATCH);

				return;
			}

			// 多重起動防止
			using (var mutex = new Mutex(false, Application.ProductName))
			{
				if (mutex.WaitOne(0, false))
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new MainForm());

					mutex.ReleaseMutex();
				}
				else
				{
					if (! WinShellUtility.SetActiveByCurrentProcess())
					{
						// 同じプロセスのメインウィンドウのアクティブ化に失敗した場合はメッセージ
						WinControlUtility.ShowInformationMessage(string.Format(Properties.Resources.ImageSplitter_INF_SAME_APP_EXISTED, Application.ProductName));
					}
				}
			}
		}
	}
}
