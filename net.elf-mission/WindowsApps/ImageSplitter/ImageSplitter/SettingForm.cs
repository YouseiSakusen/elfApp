using System;
using System.Windows.Forms;

namespace net.elfmission.WindowsApps.ImageSplitter
{
	/// <summary>
	/// アプリケーションの設定画面を表します。
	/// </summary>
	public partial class SettingForm : net.elfmission.WindowsApps.ImageSplitter.ImageSplitterBase
	{
		#region "イベント"

		/// <summary>
		/// 色の参照ボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void btnColor_Click(object sender, EventArgs e)
		{
			if (this.cdgColor.ShowDialog(this) == DialogResult.OK)
			{
				this.lblViewerFileNameColor.ForeColor = this.cdgColor.Color;
			}
		}

		/// <summary>
		/// OKボタンのClickイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.ThumbNailColorDepth = (ColorDepth)this.cmbThumbColor.SelectedItem;
			Properties.Settings.Default.ViewerFormFileNamePosition = (ViewerFileNamePosition)this.cmbFileNamePosition.SelectedItem;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// ファイル名位置選択ComboBoxのFormatイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているListControlConvertEventArgs。</param>
		private void cmbFileNamePosition_Format(object sender, ListControlConvertEventArgs e)
		{
			switch ((ViewerFileNamePosition)e.ListItem)
			{
				case ViewerFileNamePosition.TopLeft:
					e.Value = Properties.Resources.ImageSplitter_CMB_FILE_NAME_POS_TOPLEFT;
					break;
				case ViewerFileNamePosition.TopRight:
					e.Value = Properties.Resources.ImageSplitter_CMB_FILE_NAME_POS_TOPRIGHT;
					break;
				case ViewerFileNamePosition.BottomLeft:
					e.Value = Properties.Resources.ImageSplitter_CMB_FILE_NAME_POS_BOTTOM_LEFT;
					break;
				case ViewerFileNamePosition.BottomRight:
					e.Value = Properties.Resources.ImageSplitter_CMB_FILE_NAME_POS_BOTTOM_RIGHT;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// サムネイルの色数ComboBoxのFormatイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているListControlConvertEventArgs。</param>
		private void cmbThumbColor_Format(object sender, ListControlConvertEventArgs e)
		{
			switch ((ColorDepth)e.ListItem)
			{
				case ColorDepth.Depth4Bit:
					e.Value = Properties.Resources.ImageSplitter_CMB_COLOR_DEPTH_04;
					break;
				case ColorDepth.Depth8Bit:
					e.Value = Properties.Resources.ImageSplitter_CMB_COLOR_DEPTH_08;
					break;
				case ColorDepth.Depth16Bit:
					e.Value = Properties.Resources.ImageSplitter_CMB_COLOR_DEPTH_16;
					break;
				case ColorDepth.Depth24Bit:
					e.Value = Properties.Resources.ImageSplitter_CMB_COLOR_DEPTH_24;
					break;
				case ColorDepth.Depth32Bit:
					e.Value = Properties.Resources.ImageSplitter_CMB_COLOR_DEPTH_32;
					break;
			}
		}

		/// <summary>
		/// コントロールを初期化します。
		/// </summary>
		private void initControls()
		{
			// サムネイルの色数ComboBoxの初期化
			this.cmbThumbColor.DataSource = Enum.GetValues(typeof(ColorDepth));
			this.cmbThumbColor.SelectedItem = Properties.Settings.Default.ThumbNailColorDepth;

			// ビューワー画面のファイル名位置
			this.cmbFileNamePosition.DataSource = Enum.GetValues(typeof(ViewerFileNamePosition));
			this.cmbFileNamePosition.SelectedItem = Properties.Settings.Default.ViewerFormFileNamePosition;
		}

		/// <summary>
		/// 画面のLoadイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void SettingForm_Load(object sender, EventArgs e)
		{
			// コントロールの初期化
			this.initControls();
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public SettingForm()
		{
			InitializeComponent();
		}

		#endregion
	}
}
