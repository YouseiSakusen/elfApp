using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using net.elfmission.WindowsApps.Controls;

namespace net.elfmission.WindowsApps.ImageSplitter.Viewers
{
	/// <summary>
	/// ビューワー画面を表します。
	/// </summary>
	public partial class ViewerForm : net.elfmission.WindowsApps.ImageSplitter.ImageSplitterBase
	{
		#region "変数・定数"

		/// <summary>
		/// 領域幅の割合(全体幅に対する)を表します。
		/// </summary>
		private const int AreaWidthRatio = 4;

		/// <summary>
		/// 現在表示しているサムネイルのインデックスを表します。
		/// </summary>
		private int currentIndex = -1;
		/// <summary>
		/// 左側領域の右端座標を表します。
		/// </summary>
		private int leftAreaRight = 0;
		/// <summary>
		/// 右側領域の左端座標を表します。
		/// </summary>
		private int rightAreaLeft = 0;
		/// <summary>
		/// 次ファイル表示に使うキーを表します。
		/// </summary>
		private Keys nextForwardKey = Keys.Left;
		/// <summary>
		/// 前のファイル表示に使うキーを表します。
		/// </summary>
		private Keys backKey = Keys.Right;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// 全サムネイルのリストを取得・設定します。
		/// </summary>
		public List<ThumbNailItem> AllThumbNailList { get; set; } = null;

		/// <summary>
		/// 選択しているサムネイルのインデックスを取得・設定します。
		/// </summary>
		public int SelectedThumbNailIndex { get; set; } = 0;

		#endregion

		#region "イベント"

		/// <summary>
		/// 次に表示するサムネイルのインデックスを取得します。
		/// </summary>
		/// <param name="isLeftAreaClick">左側がクリックされたかを表すbool。</param>
		/// <returns>次に表示するサムネイルのインデックスを表すint。</returns>
		private int getNextFileIndex(bool isLeftAreaClick)
		{
			if (isLeftAreaClick)
			{
				if (this.nextForwardKey == Keys.Left)
					return this.currentIndex + 1;
				else
					return this.currentIndex - 1;
			}
			else
			{
				if (this.nextForwardKey == Keys.Left)
					return this.currentIndex - 1;
				else
					return this.currentIndex + 1;
			}
		}

		/// <summary>
		/// PictureBoxのMouseClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているMouseEventArgs。</param>
		private void picView_MouseClick(object sender, MouseEventArgs e)
		{
			// 左側エリアがクリックされた場合は前のファイル
			if (e.X < this.leftAreaRight)
			{
				this.showImage(this.getNextFileIndex(true));
				return;
			}
			// 右側エリアがクリックされた場合は次のファイル
			if (this.rightAreaLeft <= e.X)
			{
				this.showImage(this.getNextFileIndex(false));
				return;
			}

			// それ以外の領域をクリックすると終了
			this.Close();
		}

		/// <summary>
		/// 画面のKeyDownイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているKeyEventArgs。</param>
		private void ViewerForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == this.nextForwardKey)
				// 次のファイル
				this.showImage(this.currentIndex + 1);
			else if (e.KeyCode == this.backKey)
				// 前のファイル
				this.showImage(this.currentIndex - 1);
			else if (e.KeyCode == Keys.Escape)
				// 終了
				this.Close();
		}

		/// <summary>
		/// 画面のFormClosingイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているFormClosingEventArgs。</param>
		private void ViewerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Properties.Settings.Default.AskCloseForViewer)
			{
				if (this.showQuestionMessage(Properties.Resources.ImageSplitter_QES_CLOSE_VIEWER_FORM) == DialogResult.No)
					e.Cancel = true;
			}
		}

		/// <summary>
		/// ピクチャボックスにImageをセットします。
		/// </summary>
		/// <param name="thumb">セットするImageを表すThumbNailItem。</param>
		private void setImage(ThumbNailItem thumb)
		{
			var img = Image.FromFile(thumb.ImageFilePath);

			if ((this.picView.Width < img.Width) && (this.picView.Height < img.Height))
				this.picView.SizeMode = PictureBoxSizeMode.StretchImage;
			else
				this.picView.SizeMode = PictureBoxSizeMode.CenterImage;

			this.picView.Image = img;
		}

		/// <summary>
		/// イメージを表示します。
		/// </summary>
		/// <param name="index">表示するイメージのインデックスを表すint。</param>
		private void showImage(int index)
		{
			if (this.AllThumbNailList == null)
				return;
			if ((index < 0) || (this.AllThumbNailList.Count <= index))
			{
				if (Properties.Settings.Default.CloseViewerForm)
				{
					this.Close();
				}

				return;
			}
			if (this.picView.Image != null)
			{
				this.picView.Image.Dispose();
				this.picView.Image = null;
			}

			this.currentIndex = index;
			var thumb = this.AllThumbNailList[this.currentIndex];

			// 画像を表示
			this.setImage(thumb);
			this.lblFileName.Text = thumb.ImageFilePath + "　[ " + (this.currentIndex + 1).ToString() + " / " + this.AllThumbNailList.Count.ToString() + " ]";
		}

		/// <summary>
		/// コントロールを初期化します。
		/// </summary>
		private void initControls()
		{
			// ファイル名の文字色
			this.lblFileName.ForeColor = Properties.Settings.Default.ViewerFormFileNameColor;
			// ファイル名の表示位置
			this.picView.Controls.Add(this.lblFileName);

			switch (Properties.Settings.Default.ViewerFormFileNamePosition)
			{
				case ViewerFileNamePosition.TopLeft:
					this.lblFileName.Dock = DockStyle.Top;
					this.lblFileName.TextAlign = ContentAlignment.TopLeft;
					break;
				case ViewerFileNamePosition.TopRight:
					this.lblFileName.Dock = DockStyle.Top;
					this.lblFileName.TextAlign = ContentAlignment.TopRight;
					break;
				case ViewerFileNamePosition.BottomLeft:
					this.lblFileName.Dock = DockStyle.Bottom;
					this.lblFileName.TextAlign = ContentAlignment.BottomLeft;
					break;
				case ViewerFileNamePosition.BottomRight:
					this.lblFileName.Dock = DockStyle.Bottom;
					this.lblFileName.TextAlign = ContentAlignment.BottomRight;
					break;
				default:
					break;
			}
			// イメージを表示
			this.showImage(this.SelectedThumbNailIndex);

			// 左側エリアの幅
			this.leftAreaRight = this.Width / ViewerForm.AreaWidthRatio;
			// 右側エリアの左端座標
			this.rightAreaLeft = this.Width - this.leftAreaRight;

			if (Properties.Settings.Default.IsLeftUseForForward)
			{   // 次ファイルの表示に左を使う
				this.nextForwardKey = Keys.Left;
				this.backKey = Keys.Right;
			}
			else
			{
				this.nextForwardKey = Keys.Right;
				this.backKey = Keys.Left;
			}
		}

		/// <summary>
		/// 画面のLoadイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void ViewerForm_Load(object sender, EventArgs e)
		{
			this.initControls();
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public ViewerForm()
		{
			InitializeComponent();
		}

		#endregion
	}
}
