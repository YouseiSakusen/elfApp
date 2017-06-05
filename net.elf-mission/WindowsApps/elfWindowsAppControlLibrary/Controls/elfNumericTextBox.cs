using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// NumericUpDownコントロールを表します。
	/// </summary>
	public class elfNumericTextBox : NumericUpDown
	{
		#region "変数"

		private UpDownBase upDownButton = null;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// Null値を許可するかを取得・設定します。
		/// </summary>
		[DefaultValue(true)]
		public bool AllowBlank { get; set; } = true;

		/// <summary>
		/// UpDownButtonの表示状態を取得・設定します。
		/// </summary>
		[DefaultValue(true)]
		public bool UpDownButtonVisible
		{
			get
			{
				if (this.upDownButton == null) { return true; }

				return this.upDownButton.Visible;
			}
			set
			{
				if (this.upDownButton == null) { return; }

				this.upDownButton.Visible = value;
			}
		}

		/// <summary>
		/// テキストの配置を取得・設定します。
		/// </summary>
		[DefaultValue(HorizontalAlignment.Right)]
		public new HorizontalAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// Leaveイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		protected override void OnLeave(EventArgs e)
		{
			if (! this.AllowBlank)
			{
				// Textプロパティは隠れているだけなのでValueを再セット
				if (string.IsNullOrEmpty(this.Text)) { this.Text = this.Value.ToString(); }
			}

			base.OnLeave(e);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// UpDownボタンを取得してPrivate変数にセットします。
		/// </summary>
		private void setUpDownButton()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UpDownBase)
				{
					this.upDownButton = (UpDownBase)ctrl;
					return;
				}
			}
		}

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public elfNumericTextBox() : base()
		{
			this.setUpDownButton();

			base.TextAlign = HorizontalAlignment.Right;
		}

		#endregion
	}
}
