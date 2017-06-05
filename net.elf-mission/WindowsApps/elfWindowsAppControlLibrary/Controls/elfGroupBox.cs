using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// GroupBoxコントロールを表します。
	/// </summary>
	public class elfGroupBox : GroupBox
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
