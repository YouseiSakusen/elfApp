using System.Collections.Generic;
using System.IO;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins.ImageSplit
{
	/// <summary>
	/// イメージ分割プラグインを表します。
	/// </summary>
	public class ImageSplitPlugin : ImageBatchPluginBase
	{
		#region "変数"

		/// <summary>
		/// プラグイン情報を表します。
		/// </summary>
		private PluginInformations pluginInfo = null;

		#endregion

		#region "プロパティ"

		/// <summary>
		/// 画面で設定した設定値を取得・設定します。
		/// </summary>
		public ImageSplitSettings Settings { get; set; } = null;

		/// <summary>
		/// プラグイン情報を取得します。
		/// </summary>
		public override PluginInformations PluginInformations
		{
			get
			{
				if (this.pluginInfo == null)
				{
					this.pluginInfo = new PluginInformations
					{
						MenuText = Properties.Resources.MenuText,
						MenuImage = Properties.Resources.MenuImage,
						SettingFormTitle = Properties.Resources.SettingFormTitle
					};
				}

				return this.pluginInfo;
			}
		}

		/// <summary>
		/// 非選択ファイルも含めて全ファイルを処理するかを取得・設定します。
		/// </summary>
		public override bool IsTargetAllFiles
		{
			get
			{
				if (this.Settings != null)
					return this.Settings.IsTargetForUnselectedFiles;
				else
					return true;
			}
		}

        #endregion

        #region "メソッド"

        /// <summary>
        /// 非選択ファイルを処理後のBatchTargetImageに変換します。
        /// </summary>
        /// <param name="srcTarget">元イメージのBatchTargetImage。</param>
        /// <returns>処理後の非選択ファイルを表すBatchTargetImage。</returns>
        private BatchTargetImage toUnselectedTarge(BatchTargetImage srcTarget)
        {
            var ext = string.Empty;

            if (this.Settings.UnselectedFilesOperation == UnselectedFilesOperation.CopyFiles)
                ext = srcTarget.Extension;
            else
                ext = this.Settings.GetFileExtension();

            var fileName = Path.GetFileNameWithoutExtension(srcTarget.FileName) + ext;
            var destPath = Path.Combine(this.Settings.DestinatedFolderPath, fileName);

            return new BatchTargetImage { FilePath = destPath, Selected = srcTarget.Selected };
        }

        /// <summary>
        /// 非選択ファイルを新規ファイルとして保存する。
        /// </summary>
        /// <param name="target">元イメージのBatchTargetImage。</param>
        /// <returns>処理後の非選択ファイルを表すBatchTargetImage。</returns>
        private BatchTargetImage createNewFileFromUnselectedFile(BatchTargetImage target)
        {
            var newTarget = this.toUnselectedTarge(target);

            newTarget.TargetImage = target.GetTargetImage();
            DefaultImageWriter.SaveImage(newTarget, this.Settings, this.SelectedFilesFinisherEnabled);

            return newTarget;
        }

		/// <summary>
		/// 非選択ファイルをコピーします。
		/// </summary>
		/// <param name="target">コピー対象のファイルを表すBatchTargetImage。</param>
		/// <returns>コピーした非選択ファイルを表すBatchTargetImage。</returns>
		private BatchTargetImage copyUnselectedFile(BatchTargetImage target)
		{
            var retTarget = this.toUnselectedTarge(target);

			// 非選択ファイルをコピー
			File.Copy(target.FilePath, retTarget.FilePath, Settings.IsSkipSameFileName == false);

			return retTarget;
		}

		/// <summary>
		/// プラグインの処理を実行します。
		/// </summary>
		/// <param name="target">処理対象のイメージを表すBatchTargetImage</param>
		/// <returns>プラグインの処理結果を表すBatchTargetImageのリスト。</returns>
		public override List<BatchTargetImage> Execute(BatchTargetImage target)
		{
			var retList = new List<BatchTargetImage>();

			if (target.Selected)
			{   // 選択ファイル
				using (var splitter = this.Settings.CreateSplitter(target))
				{
					retList.AddRange(splitter.Split(this.SelectedFilesFinisherEnabled));
				}
			}
			else
			{	// 非選択ファイル
				if (this.Settings.IsTargetForUnselectedFiles)
				{
					switch (this.Settings.UnselectedFilesOperation)
					{
						case UnselectedFilesOperation.CopyFiles:
							// コピー
							retList.Add(this.copyUnselectedFile(target));
							break;
						case UnselectedFilesOperation.CreatNewFiles:
                            // 新規保存
                            retList.Add(this.createNewFileFromUnselectedFile(target));
							break;
						default:
							break;
					}
				}
				else
				{
					retList.Add(target);
				}
			}

			return retList;
		}

		/// <summary>
		/// 設定画面用のビューを取得します。
		/// </summary>
		/// <returns>設定画面用のビューを表すelfDynamicView。</returns>
		public override PluginSettingViewBase GetSettingView()
		{
			return new SplitSettingView();
		}

		#endregion
	}
}
