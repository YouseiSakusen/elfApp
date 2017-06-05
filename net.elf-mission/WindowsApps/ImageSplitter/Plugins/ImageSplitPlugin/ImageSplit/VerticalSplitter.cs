using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// 縦方向にイメージを分割します。
	/// </summary>
	internal class VerticalSplitter : Splitter
	{
		#region "メソッド"

		/// <summary>
		/// 右側又は下側の矩形を取得します。
		/// </summary>
		/// <param name="leftOrTopRect">左側又は上側の矩形を表すRectangle。</param>
		/// <returns>右側又は下側の矩形を表すRectangle。</returns>
		protected override Rectangle getRightOrBottomRectangle(Rectangle leftOrTopRect)
		{
			var rightWidth = this.TargetImage.Width - leftOrTopRect.Width;
			var x = leftOrTopRect.Width;

			if (this.Settings.IsRemovedCenterLine)
			{
				// 中心線除去
				var removeWidth = ((int)this.Settings.RemovedCenterLineWidth / 2);
				rightWidth -= removeWidth;
				x += removeWidth;
			}

			return new Rectangle(x, 0, rightWidth, this.TargetImage.Height);
		}

		/// <summary>
		/// 左側又は上側の矩形を取得します。
		/// </summary>
		/// <returns>左側又は上側の矩形を表すRectangle。</returns>
		protected override Rectangle getLeftOrTopRectangle()
		{
			var leftWidth = this.TargetImage.Width / 2;
			if (this.Settings.IsRemovedCenterLine)
				// 中心線除去
				leftWidth -= ((int)this.Settings.RemovedCenterLineWidth / 2);

			return new Rectangle(0, 0, leftWidth, this.TargetImage.Height);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="srcImage">処理対象の元BatchTargetImage。</param>
		/// <param name="settings">分割設定を表すImageSplitSettings。</param>
		public VerticalSplitter(BatchTargetImage srcImage, ImageSplitSettings settings) : base(srcImage, settings) { }

		#endregion
	}
}
