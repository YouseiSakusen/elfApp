using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// イメージ分割処理を表す抽象クラス。
	/// </summary>
	internal abstract class Splitter : IDisposable
	{
		#region "変数"

		/// <summary>
		/// 元イメージを表します。
		/// </summary>
		private Image img = null;
		/// <summary>
		/// イメージの分割設定を表します。
		/// </summary>
		private ImageSplitSettings settings = null;
		/// <summary>
		/// 元イメージの情報を表します。
		/// </summary>
		private BatchTargetImage srcImage = null;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// 元イメージの情報を取得します。
		/// </summary>
		internal BatchTargetImage SourceImage
		{
			get
			{
				return this.srcImage;
			}
		}

		/// <summary>
		/// イメージの分割設定を取得します。
		/// </summary>
		internal ImageSplitSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		/// <summary>
		/// 処理対象のImageを取得します。
		/// </summary>
		internal Image TargetImage
		{
			get
			{
				return this.img;
			}
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// 処理後のイメージ情報リストに変換します。
		/// </summary>
		/// <param name="leftOrTop">左側又は上側のBatchTargetImage。</param>
		/// <param name="rightOrBottom">右側又は下側のBatchTargetImage。</param>
		/// <param name="finisherEnabled">保存処理が有効かを表すbool。</param>
		/// <returns>処理後のBatchTargetImageリスト</returns>
		private List<BatchTargetImage> toBatchTargetImageList(BatchTargetImage leftOrTop, BatchTargetImage rightOrBottom, bool finisherEnabled)
		{
			DefaultImageWriter.SaveImage(leftOrTop, this.Settings, finisherEnabled);
			DefaultImageWriter.SaveImage(rightOrBottom, this.Settings, finisherEnabled);

			return this.Settings.ToBatchTargetImageList(leftOrTop, rightOrBottom);
		}

		/// <summary>
		/// 処理後イメージの情報を取得します。
		/// </summary>
		/// <param name="isLeftOrTop">左側又は上側イメージの場合はtrue。右側又は下側イメージの場合はfalseを指定します。</param>
		/// <returns>処理後イメージの情報を表すBatchTargetImage。</returns>
		private BatchTargetImage createDestinationImage(bool isLeftOrTop)
		{
			var newFileName = this.SourceImage.CreateNewFileName(this.settings.GetFileNameRear(isLeftOrTop));
			var savedPath = this.Settings.CreateSavedFilePath(newFileName);

			return new BatchTargetImage { FilePath = savedPath, Selected = this.SourceImage.Selected };
		}

		/// <summary>
		/// 右側又は下側の矩形を取得します。
		/// </summary>
		/// <param name="leftOrTopRect">左側又は上側の矩形を表すRectangle。</param>
		/// <returns>右側又は下側の矩形を表すRectangle。</returns>
		protected abstract Rectangle getRightOrBottomRectangle(Rectangle leftOrTopRect);

		/// <summary>
		/// トリミングされたイメージを取得します。
		/// </summary>
		/// <param name="rect">トリミングする矩形を表すRectangle。</param>
		/// <returns>トリミングされたImage。</returns>
		private Image getTrimmingImage(Rectangle rect)
		{
			var retImage = new BatchTargetImage();

			using (var bmp = new Bitmap(this.TargetImage))
			{
				return bmp.Clone(rect, bmp.PixelFormat);
			}
		}

		/// <summary>
		/// 左側又は上側の矩形を取得します。
		/// </summary>
		/// <returns>左側又は上側の矩形を表すRectangle。</returns>
		protected abstract Rectangle getLeftOrTopRectangle();

		/// <summary>
		/// イメージを分割します。
		/// </summary>
		/// <param name="finisherEnabled">保存処理が有効かを表すbool。</param>
		/// <returns>2分割した結果を表すBatchTargetImageのリスト。</returns>
		internal List<BatchTargetImage> Split(bool finisherEnabled)
		{
			// 左側の矩形を取得
			var leftOrTopRect = this.getLeftOrTopRectangle();
			// 左側のイメージを取得
			var leftOrTopImage = this.createDestinationImage(true);
			leftOrTopImage.TargetImage = this.getTrimmingImage(leftOrTopRect);

			// 右側のイメージを取得
			var rightOrBottomImage = this.createDestinationImage(false);
			rightOrBottomImage.TargetImage = this.getTrimmingImage(this.getRightOrBottomRectangle(leftOrTopRect));

			return this.toBatchTargetImageList(leftOrTopImage, rightOrBottomImage, finisherEnabled);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="srcImage">処理対象の元BatchTargetImage。</param>
		/// <param name="settings">分割設定を表すImageSplitSettings。</param>
		public Splitter(BatchTargetImage srcImage, ImageSplitSettings settings) : base()
		{
			this.img = srcImage.GetTargetImage();
			this.srcImage = srcImage;
			this.settings = settings;
		}

		/// <summary>
		/// デフォルトコンストラクタは外部からの呼び出し禁止。
		/// </summary>
		private Splitter() : base() { }

		#endregion

		#region IDisposable Support

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (this.img != null) { this.img.Dispose(); }
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~Splitter() {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		#endregion
	}
}
