using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.Controls
{
	/// <summary>
	/// サムネイルビューコントロールを表します。
	/// </summary>
	public class elfThumbNailView : elfListView
	{
		#region "Win32API"

		/// <summary>
		/// Windowメッセージを送信します。
		/// </summary>
		/// <param name="hWnd">送信先ウィンドウのハンドルを表すIntPtr。</param>
		/// <param name="Msg">メッセージを表すuint。</param>
		/// <param name="wParam">メッセージの最初のパラメータを表すint。</param>
		/// <param name="lParam">メッセージの 2 番目のパラメータを表す</param>
		/// <returns></returns>
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, ref LVITEM lParam);

		#endregion

		#region "変数・定数"

		/// <summary>
		/// システム属性を表すオーバーレイアイコンインデックス。
		/// </summary>
		private const int IDX_OVERLAY_SYSTEM = 1;

		/// <summary>
		/// イメージフォルダのパスを表します。。
		/// </summary>
		private string imgFolderPath = string.Empty;
		/// <summary>
		/// 対象の拡張子リストを表します。
		/// </summary>
		private List<string> extensionList = null;
		/// <summary>
		/// サムネイルのサイズを表します。
		/// </summary>
		private ThumbNailSize thumbSize = ThumbNailSize.MediumImage;
		/// <summary>
		/// サムネイル保持用のImageListを表します。
		/// </summary>
		private ImageList imgList = null;
		/// <summary>
		/// サムネイルアイテムリストを表します。
		/// </summary>
		private List<ThumbNailItem> itemList = new List<ThumbNailItem>();

		#endregion

		#region "プロパティ"

		/// <summary>
		/// サムネイルの個数を取得します。
		/// </summary>
		[Browsable(false)]
		public int ThumbNailCount
		{
			get
			{
				return this.itemList.Count;
			}
		}

		/// <summary>
		/// サムネイルの色数を取得・設定します。
		/// </summary>
		[DefaultValue(ColorDepth.Depth24Bit)]
		public ColorDepth ThumbNailColorDepth { get; set; } = ColorDepth.Depth24Bit;

		/// <summary>
		/// サムネイルのサイズを取得します。
		/// </summary>
		[DefaultValue(ThumbNailSize.MediumImage),
		 Browsable(false)]
		public ThumbNailSize ThumbNailSize
		{
			get
			{
				return this.thumbSize;
			}
		}

		/// <summary>
		/// ImageCodecInfoの拡張子リストを取得します。
		/// </summary>
		/// <param name="extensions"></param>
		/// <returns></returns>
		private List<string> getExtensionsFromCodec(string extensions)
		{
			var retList = new List<string>();

			foreach (var ext in extensions.Split(new char[] { ';' }))
			{
				retList.Add(ext.Replace("*", "").ToLower());
			}

			return retList;
		}

		/// <summary>
		/// 指定したフォーマット文字列が対象拡張子に含まれているかを取得します。
		/// </summary>
		/// <param name="formatDescription">フォーマット文字列。</param>
		/// <returns>指定したフォーマット文字列が対象拡張子に含まれているかを表すbool。</returns>
		private bool hasExtensionFlag(string formatDescription)
		{
			switch (formatDescription)
			{
				case "BMP":
					return this.TargetExtensions.HasFlag(SupportedImageTypes.Bitmap);
				case "GIF":
					return this.TargetExtensions.HasFlag(SupportedImageTypes.Gif);
				case "JPEG":
					return this.TargetExtensions.HasFlag(SupportedImageTypes.Jpeg);
				case "PNG":
					return this.TargetExtensions.HasFlag(SupportedImageTypes.Png);
				default:
					return false;
			}
		}

		/// <summary>
		/// 対象の拡張子リストを作成します。
		/// </summary>
		private void createExtensionList()
		{
			this.extensionList = new List<string>();

			foreach (var imgCodec in ImageCodecInfo.GetImageDecoders())
			{
				if (this.hasExtensionFlag(imgCodec.FormatDescription))
				{
					this.extensionList.AddRange(this.getExtensionsFromCodec(imgCodec.FilenameExtension));
				}
			}
		}

		/// <summary>
		/// 対象の拡張子を取得・設定します。
		/// </summary>
		[Editor(typeof(Designs.TargetExtensionEditor), typeof(System.Drawing.Design.UITypeEditor)),
		 DefaultValue(SupportedImageTypes.Bitmap | SupportedImageTypes.Gif | SupportedImageTypes.Jpeg | SupportedImageTypes.Png)]
		public SupportedImageTypes TargetExtensions { get; set; } = SupportedImageTypes.Bitmap |
																	SupportedImageTypes.Gif |
																	SupportedImageTypes.Jpeg |
																	SupportedImageTypes.Png;

		/// <summary>
		/// イメージフォルダのパスを取得・設定します。
		/// </summary>
		[DefaultValue(""),
		 Browsable(false)]
		public string ImageFolderPath
		{
			get
			{
				return this.imgFolderPath;
			}
		}

		#region "非公開プロパティ"

		/// <summary>
		/// VirtualListSizeプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new int VirtualListSize { get; set; } = 0;

		/// <summary>
		/// Viewプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new View View { get; set; } = View.LargeIcon;

		/// <summary>
		/// StateImageListプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageList StateImageList { get; set; } = null;

		/// <summary>
		/// Sortingプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new SortOrder Sorting { get; set; } = SortOrder.None;

		/// <summary>
		/// Itemsプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ListViewItemCollection Items
		{
			get
			{
				return base.Items;
			}
		}

		/// <summary>
		/// ImeModeプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ImeMode ImeMode { get; set; } = ImeMode.NoControl;

		/// <summary>
		/// LabelEditプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool LabelEdit { get; set; } = false;

		/// <summary>
		/// HeaderStyleプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ColumnHeaderStyle HeaderStyle { get; set; } = ColumnHeaderStyle.Clickable;

		/// <summary>
		/// GridLinesプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool GridLines { get; set; } = false;

		/// <summary>
		/// FullRowSelectプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool FullRowSelect { get; set; } = false;

		/// <summary>
		/// Columnsプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ListView.ColumnHeaderCollection Columns
		{
			get
			{
				return base.Columns;
			}
		}

		/// <summary>
		/// BackgroundImageTiledプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool BackgroundImageTiled { get; set; } = false;

		/// <summary>
		/// BackgroundImageプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get; set; } = null;

		/// <summary>
		/// AllowColumnReorderプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AllowColumnReorder { get; set; } = false;

		/// <summary>
		/// HideSelectionプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new bool HideSelection { get; set; } = false;

		/// <summary>
		/// LargeImageListプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageList LargeImageList { get; set; }

		/// <summary>
		/// SmallImageListプロパティは非公開。
		/// </summary>
		[Browsable(false),
		 EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageList SmallImageList { get; set; } = null;

		#endregion

		#endregion

		#region "イベント"

		/// <summary>
		/// ItemDoubleClickイベントデリゲート。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているItemDoubleClickEventArges。</param>
		public delegate void ItemDoubleClickEvent(object sender, ItemDoubleClickEventArges e);
		/// <summary>
		/// ItemDoubleClickイベントハンドラ。
		/// </summary>
		public event ItemDoubleClickEvent ItemDoubleClick;

		#endregion

		#region "メソッド"

		/// <summary>
		/// インデックスを指定してサムネイルアイテムを取得します。
		/// </summary>
		/// <param name="index">取得するサムネイルのインデックスを表すint。</param>
		/// <returns>指定したインデックスのThumbNailItem。</returns>
		public ThumbNailItem GetThumbNailItem(int index)
		{
			if (this.itemList.Count <= index)
				return null;

			return this.itemList[index];
		}

		/// <summary>
		/// 指定した形のサムネイルのみを選択します。
		/// </summary>
		/// <param name="pattern">イメージの形を表すImagePattern列挙型の内の1つ。</param>
		public void SelectImageByPattern(ImagePattern pattern)
		{
			// 選択アイテムをクリア
			this.SelectedIndices.Clear();
			if (!this.VirtualMode)
				this.SelectedItems.Clear();

			foreach (var item in this.itemList)
			{
				if (item.ImagePattern == pattern)
					this.SelectedIndices.Add(item.ItemListIndex);
			}
		}

		/// <summary>
		/// KeyDownイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているKeyEventArgs。</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if ((e.KeyCode == Keys.Enter) && (this.SelectedIndices.Count == 1))
				this.onItemDoubleClick(new ItemDoubleClickEventArges { TargetItem = this.itemList[this.SelectedIndices[0]] });
		}

		/// <summary>
		/// ItemDoubleClickイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているItemDoubleClickEventArges。</param>
		protected virtual void onItemDoubleClick(ItemDoubleClickEventArges e)
		{
			this.ItemDoubleClick(this, e);
		}

		/// <summary>
		/// MouseDoubleClickイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているMouseEventArgs。</param>
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			if (e.Button == MouseButtons.Left)
			{
				var info = this.HitTest(e.Location);
				if ((info != null) && (info.Item != null))
				{
					this.onItemDoubleClick(new ItemDoubleClickEventArges { TargetItem = (ThumbNailItem)info.Item });
				}
			}
		}

		/// <summary>
		/// 全てのサムネイルを選択します。
		/// </summary>
		public void SelectAll()
		{
			try
			{
				this.BeginUpdate();

				if (this.VirtualMode)
				{
					this.SelectedIndices.Clear();
					foreach (var item in this.itemList)
					{
						this.SelectedIndices.Add(item.ItemListIndex);
					}
				}
				else
				{
					foreach (var item in this.itemList)
					{
						item.Selected = true;
					}
				}
			}
			finally
			{
				this.EndUpdate();
			}
		}

		/// <summary>
		/// すべてのサムネイルの情報を取得します。
		/// </summary>
		/// <returns>すべてのサムネイル情報を表すList<ThumbNailItem>。</returns>
		public List<ThumbNailItem> GetAllThumbNails()
		{
			var retList = new List<ThumbNailItem>();
			int i = 0;
			
			foreach (var item in this.itemList)
			{
				var tmpItem = new ThumbNailItem
				{
					ImageFilePath = item.ImageFilePath,
					Name = item.Name
				};

				// 選択状態を取得してセット
				bool isSelect = false;
				if (this.VirtualMode)
				{
					if (i < this.SelectedIndices.Count)
					{
						if (item.Index == this.SelectedIndices[i])
						{
							isSelect = true;
							i++;
						}
					}
				}
				else
				{
					isSelect = item.Selected;
				}
				tmpItem.Selected = isSelect;

				retList.Add(tmpItem);
			}

			return retList;
		}

		/// <summary>
		/// RetrieveVirtualItemイベントを発生させます。
		/// </summary>
		/// <param name="e">イベントデータを格納しているRetrieveVirtualItemEventArgs。</param>
		protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
		{
			if (this.itemList.Count <= e.ItemIndex)
			{
				return;
			}

			ThumbNailItem targetItem = this.itemList[e.ItemIndex];

			if (!this.imgList.Images.ContainsKey(targetItem.ImageFilePath))
			{
				// サムネイルイメージがImageListに存在しない場合のみ作成して追加
				this.imgList.Images.Add(targetItem.ImageFilePath, this.createThumbNailImage(targetItem));
			}

			targetItem.ImageIndex = this.imgList.Images.IndexOfKey(targetItem.ImageFilePath);
			e.Item = targetItem;

			base.OnRetrieveVirtualItem(e);
		}

		/// <summary>
		/// 半透明描画用のImageAttributesを取得します。
		/// </summary>
		/// <returns>半透明描画用のImageAttributes。</returns>
		private ImageAttributes getHalfTransAttributes()
		{
			var matrix = new ColorMatrix
			{
				Matrix00 = 1,
				Matrix11 = 1,
				Matrix22 = 1,
				Matrix33 = 0.4F,
				Matrix44 = 1
			};

			var imgAttr = new ImageAttributes();
			imgAttr.SetColorMatrix(matrix);

			return imgAttr;
		}

		/// <summary>
		/// オーバーレイアイコンを取得します。
		/// </summary>
		/// <returns>オーバーレイアイコンを表すIcon。</returns>
		private Bitmap getOverlayFromResource()
		{
			switch (this.thumbSize)
			{
				case ThumbNailSize.MediumImage:
					return Properties.Resources.systemOverlay_64;
				case ThumbNailSize.LargeImage:
					return Properties.Resources.systemOverlay_128;
				case ThumbNailSize.ExtraLargeImage:
					return Properties.Resources.systemOverlay_256;
				default:
					break;
			}

			return null;
		}

		/// <summary>
		/// システム属性マークをオーバーレイ描画します。
		/// </summary>
		/// <param name="graph">描画先のGraphics。</param>
		private void drawSysFileTypeImage(Graphics graph)
		{
			using (var overlay = this.getOverlayFromResource())
			{
				overlay.MakeTransparent(Color.White);
				graph.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);
			}
		}

		/// <summary>
		/// サムネイルのサイズを取得します。
		/// </summary>
		/// <param name="img">スケールを取得するイメージを表すImage。</param>
		/// <returns>イサムネイルのサイズを表すSize。</returns>
		private Size getThumbImageSize(Image img)
		{
			if ((img.Width <= this.imgList.ImageSize.Width) && (img.Height <= this.imgList.ImageSize.Height))
			{
				return new Size(img.Width, img.Height);
			}

			int longSize = Math.Max(img.Width, img.Height);
			float scale = (float)(this.imgList.ImageSize.Width) / (float)longSize;

			return new Size((int)(img.Width * scale), (int)(img.Height * scale));
		}

		/// <summary>
		/// イメージの形を取得します。
		/// </summary>
		/// <param name="img">形を取得するImage。</param>
		/// <returns>イメージの形を表すImagePattern列挙型の内の1つ。</returns>
		private ImagePattern getImagePattern(Image img)
		{
			var imgWidth = img.Width;
			var imgHeight = img.Height;

			if (imgWidth == imgHeight)
			{
				return ImagePattern.Square;
			}
			else
			{
				if (imgHeight < imgWidth)
					return ImagePattern.Landscape;
				else
					return ImagePattern.Portrait;
			}
		}

		/// <summary>
		/// サムネイルイメージを作成します。
		/// </summary>
		/// <param name="thumbItem">ListViewに追加するThumbNailItem。</param>
		/// <returns>作成したサムネイルイメージを表すImage。</returns>
		private Image createThumbNailImage(ThumbNailItem thumbItem)
		{
			Image img = null;

			try
			{
				img = Image.FromFile(thumbItem.ImageFilePath);
			}
			catch (OutOfMemoryException)
			{
				// 画像読込での例外は握りつぶす
				return null;
			}

			thumbItem.ImagePattern = this.getImagePattern(img);
			Size thumbImgSize = this.getThumbImageSize(img);
			Bitmap canvas = new Bitmap(this.imgList.ImageSize.Width, this.imgList.ImageSize.Height);

			using (Graphics graph = Graphics.FromImage(canvas))
			{
				// 背景色をコントロールの背景色で塗りつぶす
				graph.FillRectangle(new SolidBrush(this.BackColor),
									0, 
									0, 
									this.imgList.ImageSize.Width, 
									this.imgList.ImageSize.Height);

				var imgX = (this.imgList.ImageSize.Width - thumbImgSize.Width) / 2;
				var imgY = (this.imgList.ImageSize.Height - thumbImgSize.Height) / 2;

				// ファイルの属性を取得
				var attr = File.GetAttributes(thumbItem.ImageFilePath);
				if (attr.HasFlag(FileAttributes.Hidden))
					// 隠しファイルを半透明で描画
					graph.DrawImage(img,
									new Rectangle(0, 0, thumbImgSize.Width, thumbImgSize.Height),
									imgX,
									imgY,
									img.Width,
									img.Height,
									GraphicsUnit.Pixel,
									this.getHalfTransAttributes());
				else
					// 通常描画
					graph.DrawImage(img, imgX, imgY, thumbImgSize.Width, thumbImgSize.Height);

				if (attr.HasFlag(FileAttributes.System))
					// システム属性
					this.drawSysFileTypeImage(graph);
			}

			return canvas;
		}

		/// <summary>
		/// 対象のイメージファイルかを取得します。
		/// </summary>
		/// <param name="filePath">対象ファイルのパスを表す文字列。</param>
		/// <returns>対象のイメージファイルかを表すbool。</returns>
		private bool isTargetImage(string filePath)
		{
			// 対象外の拡張子は×
			string extension = System.IO.Path.GetExtension(filePath);
			if (!this.extensionList.Exists(ex => (string.Compare(ex, extension, true)) == 0))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// サムネイルのサイズを取得します。
		/// </summary>
		/// <returns>サムネイルのサイズを表すint。</returns>
		private int getThumbNailSize()
		{
			switch (this.ThumbNailSize)
			{
				case ThumbNailSize.MediumImage:
					return 64;
				case ThumbNailSize.LargeImage:
					return 128;
				case ThumbNailSize.ExtraLargeImage:
					return 256;
				default:
					return 0;
			}
		}

		/// <summary>
		/// イメージリストを初期化します。
		/// </summary>
		private void initImageList()
		{
			// ImageListを初期化
			this.imgList = new ImageList();
			this.imgList.ColorDepth = this.ThumbNailColorDepth;

			var imgSize = this.getThumbNailSize();
			this.imgList.ImageSize = new Size(imgSize, imgSize);

			base.LargeImageList = this.imgList;
		}

		/// <summary>
		/// サムネイルビューを初期化します。
		/// </summary>
		private void initThumbNailView()
		{
			// イメージリストをクリア
			base.LargeImageList = null;
			// リソースを開放
			this.disposeResources();

			// ImageListを初期化
			this.initImageList();
			// 選択アイテムを初期化
			this.SelectedIndices.Clear();
			if (! this.VirtualMode)
				this.SelectedItems.Clear();

			// アイテムを初期化
			this.itemList.Clear();
			this.itemList = new List<ThumbNailItem>();
			base.Items.Clear();
		}

		/// <summary>
		/// イメージフォルダ内のファイルをサムネイル表示します。
		/// </summary>
		private void showThumbNailImages()
		{
			// サムネイルビューを初期化
			this.initThumbNailView();

			var i = 0;

			// ファイル名の昇順で表示
			foreach (var filePath in System.IO.Directory.GetFiles(this.imgFolderPath).OrderBy(p=> p))
			{
				if (!this.isTargetImage(filePath))
				{
					// 対象外ファイルの場合はスキップ
					continue;
				}

				ThumbNailItem thumbItem = new ThumbNailItem { ImageFilePath = filePath };

				if (! this.VirtualMode)
				{
					// サムネイルイメージを作成　※ 通常モードのみ
					this.imgList.Images.Add(filePath, this.createThumbNailImage(thumbItem));
					// 仮想モードの場合はImageKeyがクリアされるので通常モードのみセットする
					thumbItem.ImageKey = filePath;
					// Viewに追加
					base.Items.Add(thumbItem);
				}

				thumbItem.ItemListIndex = i;
				this.itemList.Add(thumbItem);
				i++;
			}

			if (this.VirtualMode)
			{
				// 仮想モードの場合は個数をセット
				base.VirtualListSize = this.itemList.Count;
			}
		}

		/// <summary>
		/// 指定したフォルダ内のイメージファイルをサムネイルで表示します。
		/// </summary>
		/// <param name="imageFolderPath">サムネイル表示するファイルの格納先フォルダのパスを表す文字列。</param>
		/// <param name="thumbSize">サムネイルのサイズを表すThumbNailSize。</param>
		/// <returns>サムネイルの表示結果を表すThumbNailViewStatus列挙型の内の1つ。</returns>
		public ThumbNailViewStatus ShowThumbNail(string imageFolderPath, ThumbNailSize thumbSize)
		{
			if (!(System.IO.Directory.Exists(imageFolderPath)))
			{   // 指定フォルダが存在しない
				return ThumbNailViewStatus.ImageFolderNotExists;
			}

			this.imgFolderPath = imageFolderPath;
			this.thumbSize = thumbSize;

			// 対象の拡張子リストを作成
			this.createExtensionList();
			// サムネイルイメージを表示
			this.showThumbNailImages();

			return ThumbNailViewStatus.ThumbNailLoadsFinished;
		}

		/// <summary>
		/// コンポーネントを初期化します。
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public elfThumbNailView() : base()
		{
			base.HideSelection = false;
			base.View = View.LargeIcon;
		}

		#endregion

		#region "デストラクタ"

		/// <summary>
		/// 使用するリソースをDisposeします。
		/// </summary>
		private void disposeResources()
		{
			if (this.imgList != null)
			{
				this.imgList.Images.Clear();
				this.imgList.Dispose();
				this.imgList = null;
			}
		}

		/// <summary>
		/// ListView によって使用されているリソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージ リソースとアンマネージ リソースの両方を解放する場合は true。アンマネージ リソースだけを解放する場合は false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.disposeResources();
			}
		}

		#endregion
	}
}
