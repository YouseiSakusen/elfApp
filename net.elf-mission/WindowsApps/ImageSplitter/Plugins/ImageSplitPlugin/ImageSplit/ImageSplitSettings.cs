using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// ImageSplitPluginの設定を表します。
	/// </summary>
	public class ImageSplitSettings : PluginSettingBase
	{
		#region "変数"

		/// <summary>
		/// 保存対象パスを表します。
		/// </summary>
		private string savedTargetPath = string.Empty;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// 保存先フォルダのパスを取得・設定します。
		/// </summary>
		public string SavedFolderPath { get; set; } = string.Empty;

		/// <summary>
		/// 保存先に同名のフォルダを作るかを取得・設定します。
		/// </summary>
		public bool IsCreateFolderAtSameSourceFolder { get; set; } = false;

		/// <summary>
		/// 非選択ファイルも同時に処理するかを取得・設定します。
		/// </summary>
		public bool IsTargetForUnselectedFiles { get; set; } = true;

		/// <summary>
		/// 非選択ファイルの処理方法を取得・設定します。
		/// </summary>
		public UnselectedFilesOperation UnselectedFilesOperation { get; set; } = UnselectedFilesOperation.CopyFiles;

		/// <summary>
		/// ページの分割方法を取得・設定します。
		/// </summary>
		public SplitType PageSplitType { get; set; } = SplitType.Vertical2_1;

		/// <summary>
		/// 中心線を除去するかを取得・設定します。
		/// </summary>
		public bool IsRemovedCenterLine { get; set; } = false;

		/// <summary>
		/// 除去する中心線の幅を取得・設定します。
		/// </summary>
		public decimal RemovedCenterLineWidth { get; set; } = 20;

		/// <summary>
		/// 選択したフォルダパスを記憶するかを取得・設定します。
		/// </summary>
		public bool SavedSelectedFolderPath { get; set; } = true;

		/// <summary>
		/// 処理対象元フォルダ名を取得・設定します。
		/// </summary>
		public string SourceFolderName { get; set; } = string.Empty;

		/// <summary>
		/// 保存先フォルダのパスを取得します。
		/// </summary>
		/// <returns>保存先フォルダのパスを表す文字列。。</returns>
		private string getDestinatedFolderPath()
		{
			if (string.IsNullOrEmpty(this.savedTargetPath))
			{
				if (this.IsCreateFolderAtSameSourceFolder)
					this.savedTargetPath = Path.Combine(this.SavedFolderPath, this.SourceFolderName);
				else
					this.savedTargetPath = this.SavedFolderPath;
			}

			return this.savedTargetPath;
		}

		/// <summary>
		/// 保存先フォルダのパスを取得します。
		/// </summary>
		public string DestinatedFolderPath
		{
			get
			{
				return this.getDestinatedFolderPath();
			}
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// 一括処理対象イメージのリストに変換します。
		/// </summary>
		/// <param name="leftOrTop">左側又は上側のイメージを表すBatchTargetImage。</param>
		/// <param name="rightOrBottom">右側又は下側のイメージを表すBatchTargetImage。</param>
		/// <returns>BatchTargetImageのリスト。</returns>
		public List<BatchTargetImage> ToBatchTargetImageList(BatchTargetImage leftOrTop, BatchTargetImage rightOrBottom)
		{
			var retList = new List<BatchTargetImage>();

			switch (this.PageSplitType)
			{
				case SplitType.Vertical1_2:
				case SplitType.Horizontal1_2:
					retList.Add(leftOrTop);
					retList.Add(rightOrBottom);
					break;
				case SplitType.Vertical2_1:
				case SplitType.Horizontal2_1:
					retList.Add(rightOrBottom);
					retList.Add(leftOrTop);
					break;
				default:
					break;
			}
			
			return retList;
		}

		/// <summary>
		/// 保存ファイルパスを作成します。
		/// </summary>
		/// <param name="newFileName">新しいファイル名を表す文字列。</param>
		/// <returns>保存ファイルパスを表す文字列。</returns>
		public string CreateSavedFilePath(string newFileName)
		{
			var destPath = this.getDestinatedFolderPath();
			
			return Path.Combine(destPath, newFileName);
		}

        /// <summary>
        /// 保存ファイルの拡張子を取得します。
        /// </summary>
        /// <returns>保存ファイルの拡張子を表す文字列。</returns>
        public string GetFileExtension()
        {
            if (this.SaveJpeg)
                return ".jpg";
            else
                return ".bmp";
        }

        /// <summary>
        /// 拡張子を含むファイル名の後ろ側を取得します。
        /// </summary>
        /// <param name="isLeftOrTop">左側又は上側イメージの場合はtrue。右側又は下側の場合はfalseを指定します。</param>
        /// <returns>拡張子を含むファイル名の後ろ側を表す文字列。</returns>
        public string GetFileNameRear(bool isLeftOrTop)
        {
            var suffix = string.Empty;

            switch (this.PageSplitType)
            {
                case SplitType.Vertical1_2:
                case SplitType.Horizontal1_2:
                    if (isLeftOrTop)
                    {
                        suffix = "_1";
                    }
                    else
                    {
                        suffix = "_2";
                    }
                    break;
                case SplitType.Vertical2_1:
                case SplitType.Horizontal2_1:
                    if (isLeftOrTop)
                    {
                        suffix = "_2";
                    }
                    else
                    {
                        suffix = "_1";
                    }
                    break;
                default:
                    return string.Empty;
            }

            return suffix += this.GetFileExtension();
        }

		/// <summary>
		/// Splitterのファクトリメソッド。
		/// </summary>
		/// <param name="srcImage">処理対象の元BatchTargetImage。</param>
		/// <returns>Splitterのインスタンス。</returns>
		internal Splitter CreateSplitter(BatchTargetImage srcImage)
		{
			switch (this.PageSplitType)
			{
				case SplitType.Vertical1_2:
				case SplitType.Vertical2_1:
					return new VerticalSplitter(srcImage, this);
				case SplitType.Horizontal1_2:
				case SplitType.Horizontal2_1:
					return new HorizontalSplitter(srcImage, this);
				default:
					break;
			}

			return null;
		}

		#endregion
	}
}
