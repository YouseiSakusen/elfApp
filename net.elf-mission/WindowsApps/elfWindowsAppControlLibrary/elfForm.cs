using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps
{
	/// <summary>
	/// Windowsアプリケーションで使用するフォームのスーパークラス。
	/// </summary>
	public partial class elfForm : Form
	{

		#region "プロパティ"

		/// <summary>
		/// 製品情報をタイトルバーに表示するかを表すbool。
		/// </summary>
		[DefaultValue(false)]
		public bool ShowProductInformationAtTitle { get; set; } = false;

		#endregion

		#region "メソッド"

		/// <summary>
		/// 画面の位置・サイズを復元します。
		/// </summary>
		/// <param name="info">画面の復元情報を表すFormRestoreInformations。</param>
		protected void restoredForm(FormRestoreInformations info)
		{
			this.WindowState = info.WindowState;
			this.Width = info.FormSize.Width;
			this.Height = info.FormSize.Height;
			this.StartPosition = info.StartPosition;

			if (info.StartPosition == FormStartPosition.Manual)
			{
				this.Left = info.FormPosition.X;
				this.Top = info.FormPosition.Y;
			}
		}

		/// <summary>
		/// 問い合わせメッセージを表示します。
		/// </summary>
		/// <param name="msg">メッセージに表示する文字列。</param>
		/// <returns>ユーザの操作結果を表すDialogResult列挙型の内の1つ。</returns>
		protected DialogResult showQuestionMessage(string msg)
		{
			return WindowsApps.Controls.WinControlUtility.ShowQuestionMessage(this, msg);
		}

		/// <summary>
		/// 情報メッセージを表示します。
		/// </summary>
		/// <param name="msg">表示するメッセージ。</param>
		protected void showInformationMessage(string msg)
		{
			WindowsApps.Controls.WinControlUtility.ShowInformationMessage(this, msg);
		}

		/// <summary>
		/// エラーメッセージを表示します。
		/// </summary>
		/// <param name="msg">表示する文字列。</param>
		protected void showErrorMessage(string msg)
		{
			WindowsApps.Controls.WinControlUtility.ShowErrorMessage(this, msg);
		}

		/// <summary>
		/// 警告メッセージを表示します。
		/// </summary>
		/// <param name="msg">表示する文字列。</param>
		protected void showWarningMessage(string msg)
		{
			WindowsApps.Controls.WinControlUtility.ShowWarningMessage(this, msg);
		}

		/// <summary>
		/// Loadイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// タイトルに製品情報を表示
			if (this.ShowProductInformationAtTitle)
			{

				this.Text = Application.ProductName + " Ver." + Application.ProductVersion;
			}
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public elfForm()
		{
			InitializeComponent();
		}

		#endregion

	}
}
