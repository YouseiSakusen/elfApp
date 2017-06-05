using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace net.elfmission.WindowsApps.Controls.Designs
{
    /// <summary>
    /// 対象拡張子プロパティエディタを表します。
    /// </summary>
    internal partial class TargetExtensionEditorControl : net.elfmission.WindowsApps.Controls.elfUserControl
    {
        #region "変数"

        /// <summary>
        /// 対象のイメージタイプを表します。
        /// </summary>
        private SupportedImageTypes targetImages = SupportedImageTypes.ImageTypeNone;
        /// <summary>
        /// プロパティエディタサービスを表します。
        /// </summary>
        private IWindowsFormsEditorService editServ = null;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// ThumbNailView.TargetExtensionsプロパティへの設定値を取得します。
		/// </summary>
		internal SupportedImageTypes TargetExtensions
		{
			get
			{
				return this.targetImages;
			}
		}

		#endregion

		#region "イベント"

		/// <summary>
		/// チェックボックスのCheckdChangedイベントハンドラ。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void checkBox_CheckdChanged(object sender, System.EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked)
            {
                this.targetImages |= (SupportedImageTypes)chkBox.Tag;
            }
            else
            {
                this.targetImages &= ~(SupportedImageTypes)chkBox.Tag;
            }
        }

		#endregion

		#region "コンストラクタ"

		/// <summary>
		/// 値をコントロールに反映します。
		/// </summary>
		/// <param name="imgTypes">設定する値を表すSupportedImageTypes。</param>
		private void setValueToControl(SupportedImageTypes imgTypes)
		{
			this.targetImages = imgTypes;

			this.chkBitmap.Checked = ((imgTypes & SupportedImageTypes.Bitmap) != 0);
			this.chkGif.Checked = ((imgTypes & SupportedImageTypes.Gif) != 0);
			this.chkJpeg.Checked = ((imgTypes & SupportedImageTypes.Jpeg) != 0);
			this.chkPng.Checked = ((imgTypes & SupportedImageTypes.Png) != 0);
		}

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="imageTypes">ThumbNailView.TargetExtensionsプロパティを設定します。</param>
        /// <param name="editorService">プロパティエディタのサービスを表すIWindowsFormsEditorService。</param>
        public TargetExtensionEditorControl(SupportedImageTypes imageTypes, IWindowsFormsEditorService editorService) : this()
        {
			this.setValueToControl(imageTypes);
            this.editServ = editorService;
        }

        /// <summary>
        /// コントロールを初期化します。
        /// </summary>
        private void initControls()
        {
            this.chkBitmap.Tag = SupportedImageTypes.Bitmap;
            this.chkGif.Tag = SupportedImageTypes.Gif;
            this.chkJpeg.Tag = SupportedImageTypes.Jpeg;
            this.chkPng.Tag = SupportedImageTypes.Png;
        }

        /// <summary>
        /// デフォルトコンストラクタ。
        /// </summary>
        public TargetExtensionEditorControl()
        {
            InitializeComponent();

            // コントロールを初期化
            this.initControls();
        }

        #endregion
    }
}
