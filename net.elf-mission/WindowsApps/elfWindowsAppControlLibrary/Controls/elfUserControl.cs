using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// ユーザコントロールを表します。
	/// </summary>
	public partial class elfUserControl : UserControl
	{
		#region "メソッド"

		/// <summary>
		/// 問い合わせメッセージを表示します。
		/// </summary>
		/// <param name="msg">メッセージに表示する文字列。</param>
		/// <returns>ユーザの操作結果を表すDialogResult列挙型の内の1つ。</returns>
		protected DialogResult showQuestionMessage(string msg) { return WinControlUtility.ShowQuestionMessage(this, msg); }

		/// <summary>
		/// エラーメッセージを表示します。
		/// </summary>
		/// <param name="msg">表示する文字列。</param>
		protected void showErrorMessage(string msg) { WinControlUtility.ShowErrorMessage(this, msg); }

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public elfUserControl()
		{
			InitializeComponent();
		}

		#endregion
	}
}
