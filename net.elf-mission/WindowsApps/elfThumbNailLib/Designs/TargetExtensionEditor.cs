using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace net.elfmission.WindowsApps.Controls.Designs
{
	/// <summary>
	/// プロパティグリッドで表示するエディタを表します。
	/// </summary>
	internal class TargetExtensionEditor : UITypeEditor
	{
		#region "メソッド"

		/// <summary>
		/// エディタのスタイルを取得します。
		/// </summary>
		/// <param name="context">追加のコンテキスト情報を取得するためのITypeDescriptorContext。</param>
		/// <returns>エディタのスタイルを表すUITypeEditorEditStyle。</returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		/// <summary>
		/// 指定した値を編集します。
		/// </summary>
		/// <param name="context">追加のコンテキスト情報を取得するためのITypeDescriptorContext。</param>
		/// <param name="provider">サービスを取得するためのIServiceProvider。</param>
		/// <param name="value">編集対象の値を表すobject。</param>
		/// <returns>指定した値を表すobject。</returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService serv = null;

			if (provider != null)
			{
				serv = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
			}
			if (serv == null)
			{
				return value;
			}

			using (TargetExtensionEditorControl ctrl = new TargetExtensionEditorControl((SupportedImageTypes)value, serv))
			{
				serv.DropDownControl(ctrl);

				return ctrl.TargetExtensions;
			}
		}

		#endregion
	}
}
