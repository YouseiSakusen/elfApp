using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// Panelコントロールを表します。
	/// </summary>
	public class elfPanel : Panel
	{
		#region "メソッド"

		/// <summary>
		/// チェックされているRadioButtonを取得します。
		/// </summary>
		/// <returns></returns>
		public RadioButton GetCheckedRadioButton() { return WinControlUtility.GetCheckedRadioButton(this); }

		#endregion
	}
}
