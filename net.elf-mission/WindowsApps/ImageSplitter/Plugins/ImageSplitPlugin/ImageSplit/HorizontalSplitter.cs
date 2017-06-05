using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// 横方向にイメージを分割します。
	/// </summary>
	internal class HorizontalSplitter : Splitter
	{
		#region "メソッド"

		/// <summary>
		/// 左側又は上側の矩形を取得します。
		/// </summary>
		/// <returns>左側又は上側の矩形を表すRectangle。</returns>
		protected override Rectangle getLeftOrTopRectangle()
		{
			var topHeight = this.TargetImage.Height / 2;
			if (this.Settings.IsRemovedCenterLine)
				topHeight -= (int)this.Settings.RemovedCenterLineWidth / 2;

			return new Rectangle(0, 0, this.TargetImage.Width, topHeight);
		}

		/// <summary>
		/// 右側又は下側の矩形を取得します。
		/// </summary>
		/// <param name="leftOrTopRect">左側又は上側の矩形を表すRectangle。</param>
		/// <returns>右側又は下側の矩形を表すRectangle。</returns>
		protected override Rectangle getRightOrBottomRectangle(Rectangle leftOrTopRect)
		{
			var bottomHeight = this.TargetImage.Height - leftOrTopRect.Height;
			var y = leftOrTopRect.Height;

			if (this.Settings.IsRemovedCenterLine)
			{
				var removeHeight = (int)this.Settings.RemovedCenterLineWidth / 2;
				bottomHeight -= removeHeight;
				y += removeHeight;
			}


			return new Rectangle(0, y, leftOrTopRect.Width, bottomHeight);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="srcImage">処理対象の元BatchTargetImage。</param>
		/// <param name="settings">分割設定を表すImageSplitSettings。</param>
		public HorizontalSplitter(BatchTargetImage srcImage, ImageSplitSettings settings) : base(srcImage, settings) { }

		#endregion
	}
}
