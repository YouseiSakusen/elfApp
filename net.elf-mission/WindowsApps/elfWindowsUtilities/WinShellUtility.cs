using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace net.elfmission.WindowsApps
{
	/// <summary>
	/// Windowsのシェルユーティリティを表します。
	/// </summary>
	public static class WinShellUtility
	{
		#region "Win32API"

		/// <summary>
		/// ウィンドウの状態を表す列挙型。
		/// </summary>
		private enum Win32ApiState : int
		{
			/// <summary>
			/// 非表示を表します。
			/// </summary>
			SW_HIDE = 0,
			/// <summary>
			/// 通常の状態を表します。
			/// </summary>
			SW_NORMAL = 1,
			/// <summary>
			/// 最小化されていることを表します。
			/// </summary>
			SW_SHOWMINIMIZED = 2,
			/// <summary>
			/// 最大化されていることを表します。
			/// </summary>
			SW_MAXIMIZE = 3,
			/// <summary>
			/// 非アクティブ状態を表します。
			/// </summary>
			SW_SHOWNOACTIVATE = 4,
			/// <summary>
			/// 表示されていることを表します。
			/// </summary>
			SW_SHOW = 5,
			/// <summary>
			/// 最小化されていることを表します。
			/// </summary>
			SW_MINIMIZE = 6,
			/// <summary>
			/// 非アクティブ状態を表します。
			/// </summary>
			SW_SHOWMINNOACTIVE = 7,
			/// <summary>
			/// 通常の状態を表します。
			/// </summary>
			SW_SHOWNA = 8,
			/// <summary>
			/// 復元することを表します。
			/// </summary>
			SW_RESTORE = 9,
			/// <summary>
			/// デフォルトで表示されていることを表します。
			/// </summary>
			SW_SHOWDEFAULT = 10,
			/// <summary>
			/// 最大化状態を表します。
			/// </summary>
			SW_MAX = 11
		}

		/// <summary>
		/// 指定したウィンドウを前面に表示します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウハンドルを表すIntPtr。</param>
		/// <returns>正常に終了した場合に true が返ります。</returns>
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		/// <summary>
		/// 非同期でウィンドウの表示状態を設定します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウハンドルを表すIntPtr。</param>
		/// <param name="nCmdShow">設定するウィンドウの状態を表すWin32ApiState列挙型の内の1つ。</param>
		/// <returns>設定前にウィンドウが可視状態だった場合に true が返ります。</returns>
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, Win32ApiState nCmdShow);

		/// <summary>
		/// 指定したウィンドウが最小化されているかを取得します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウハンドルを表すIntPtr。</param>
		/// <returns>指定したウィンドウが最小化されているかを表すbool。</returns>
		[DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);

		#endregion

		#region "メソッド"

		/// <summary>
		/// 現在のプロセスと同じプロセスのウィンドウが存在した場合は既存プロセスのウィンドウをアクティブにします。
		/// </summary>
		/// <returns>同じプロセスが存在しないか、アクティブ化に成功した場合はTrue。それ以外はFalseが返ります。</returns>
		public static bool SetActiveByCurrentProcess()
		{
			var proc = WinShellUtility.GetSameProcess();
			if (proc == null)
				return true;

			if (WinShellUtility.IsIconic(proc.MainWindowHandle))
				// 最小化されている場合は復元
				WinShellUtility.ShowWindowAsync(proc.MainWindowHandle, Win32ApiState.SW_RESTORE);

			// ウィンドウをアクティブに
			return WinShellUtility.SetForegroundWindow(proc.MainWindowHandle);
		}

		/// <summary>
		/// 同じプロセスを取得します。
		/// </summary>
		/// <returns>同じProcess。</returns>
		public static Process GetSameProcess()
		{
			var myProc = Process.GetCurrentProcess();
			var procList = Process.GetProcessesByName(myProc.ProcessName);

			foreach (var proc in procList)
			{
				if ((proc.Id != myProc.Id) && (proc.MainModule.FileName == myProc.MainModule.FileName))
					return proc;
			}

			return null;
		}

		/// <summary>
		/// 文字列配列を指定したインデックスまで結合します。
		/// </summary>
		/// <param name="pathList">フォルダ名のリストを表す文字列配列。</param>
		/// <param name="lastIndex">結合する最後のインデックスを表すint。</param>
		/// <returns>文字列配列を指定したインデックスまで結合した文字列。</returns>
		private static string joinPath(string[] pathList, int lastIndex)
		{
			var retPath = string.Empty;

			for (int i = 0; i <= lastIndex; i++)
			{
				retPath += pathList[i];
				if (i != lastIndex) { retPath += Path.DirectorySeparatorChar; }
			}

			return retPath;
		}

		/// <summary>
		/// パス文字列を辿って存在するフォルダのパスを取得します。
		/// </summary>
		/// <param name="folderPath">対象のフォルダパスを表す文字列。</param>
		/// <returns>存在するフォルダのパスを表す文字列。</returns>
		public static string GetExistedFolderPath(string folderPath)
		{
			var pathList = folderPath.Split(new char[] { Path.DirectorySeparatorChar });
			var i = pathList.GetUpperBound(0);

			while (0 <= i)
			{
				var target = joinPath(pathList, i);
				if (Directory.Exists(target)) { return target; }

				i--;
			}

			return string.Empty;
		}

		/// <summary>
		/// OSがWindowsVista以降かを取得します。
		/// </summary>
		/// <returns>OSがWindowsVista以降かを表すbool。</returns>
		public static bool IsVistaOver()
		{
			System.OperatingSystem os = System.Environment.OSVersion;

			if (os.Platform == PlatformID.Win32NT)
			{
				return 6 <= os.Version.Major;
			}
			else
			{
				return false;
			}
		}

		#endregion
	}
}
