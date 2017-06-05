using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// ThumbNailViewに表示するアイテムを表します。
	/// </summary>
	public class ThumbNailItem : ListViewItem
	{
		#region "変数"

		/// <summary>
		/// イメージファイルのパスを表します。
		/// </summary>
		private string imgPath = string.Empty;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// イメージの形を取得・設定します。
		/// </summary>
		public ImagePattern ImagePattern { get; set; } = ImagePattern.Landscape;

		/// <summary>
		/// イメージファイルのパスを取得・設定します。
		/// </summary>
		public string ImageFilePath
		{
			get
			{
				return this.imgPath;
			}
			set
			{
				this.imgPath = value;
				this.Text = Path.GetFileName(value);
			}
		}

		/// <summary>
		/// リスト内のインデックスを取得・設定します。
		/// </summary>
		public int ItemListIndex { get; set; } = -1;

		#endregion
	}
}
