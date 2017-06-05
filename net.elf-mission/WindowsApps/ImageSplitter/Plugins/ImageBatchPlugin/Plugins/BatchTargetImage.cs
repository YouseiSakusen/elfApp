using System.Drawing;
using System.IO;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// バッチ処理対象イメージファイルを表します。
	/// </summary>
	public class BatchTargetImage
	{
		#region "変数"

		/// <summary>
		/// 対象ファイルのフルパスを表します。
		/// </summary>
		private string fileFullPath = string.Empty;
		/// <summary>
		/// ファイル名を表します。
		/// </summary>
		private string fileName = string.Empty;
		/// <summary>
		/// 拡張子を除いたファイル名部分を表します。
		/// </summary>
		private string fileNameWithoutExt = string.Empty;
		/// <summary>
		/// ファイル名の拡張子を表します。
		/// </summary>
		private string ext = string.Empty;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// プラグイン処理のエラー番号を取得・設定します。
		/// </summary>
		public int ErrorNumber { get; set; } = 0;

		/// <summary>
		/// エラーの有無を取得・設定します。
		/// </summary>
		public bool HasError { get; set; } = false;

		/// <summary>
		/// 処理対象のImageを取得・設定します。
		/// </summary>
		public Image TargetImage { get; set; } = null;

		/// <summary>
		/// イメージが選択されているかを取得・設定します。
		/// </summary>
		public bool Selected { get; set; } = false;

		/// <summary>
		/// イメージファイルのパスを取得・設定します。
		/// </summary>
		public string FilePath
		{
			get
			{
				return this.fileFullPath;
			}
			set
			{
				this.fileFullPath = value;
				this.fileName = Path.GetFileName(value);
				this.fileNameWithoutExt = Path.GetFileNameWithoutExtension(value);
				this.ext = Path.GetExtension(value);
			}
		}

		/// <summary>
		/// ファイル名の拡張子を取得します。
		/// </summary>
		public string Extension { get { return this.ext; } }

		/// <summary>
		/// 拡張子を除いたファイル名のみの部分を取得します。
		/// </summary>
		public string FileNameWithoutExtension { get { return this.fileNameWithoutExt; } }

		/// <summary>
		/// イメージファイルのファイル名を取得・設定します。
		/// </summary>
		public string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		#endregion

		#region "メソッド"

		/// <summary>
		/// サフィックスを付加した新しいファイル名を取得します。
		/// </summary>
		/// <param name="fileNameRear">拡張子を含むファイル名の後ろ側を表す文字列。</param>
		/// <returns>サフィックスを付加した新しいファイル名を表す文字列。</returns>
		public string CreateNewFileName(string fileNameRear)
		{
			return this.FileNameWithoutExtension + fileNameRear;
		}

		/// <summary>
		/// 処理対象のイメージを取得します。
		/// </summary>
		/// <returns>処理対象のImage。</returns>
		public Image GetTargetImage()
		{
			if (this.TargetImage != null)
				return this.TargetImage;
            else
                return Image.FromFile(this.FilePath);
        }

		#endregion
	}
}
