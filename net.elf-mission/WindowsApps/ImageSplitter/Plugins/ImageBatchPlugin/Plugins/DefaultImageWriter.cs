using System.Drawing.Imaging;
using System.IO;

namespace net.elfmission.WindowsApps.ImageSplitter.Plugins
{
	/// <summary>
	/// デフォルトのイメージ保存機能を表します。
	/// </summary>
	public class DefaultImageWriter
	{
		#region "メソッド"

		/// <summary>
		/// Jpeg保存用のパラメータリストを取得します。
		/// </summary>
		/// <param name="settings">プラグインの設定を表すPluginSettingBase。</param>
		/// <returns>Jpeg保存用のパラメータリストを表すEncoderParameters。</returns>
		private static EncoderParameters getJpegSavedParameterList(PluginSettingBase settings)
		{
			var paramList = new EncoderParameters(1);
			var param = new EncoderParameter(Encoder.Quality, (long)settings.JpegSavedQuality);
			paramList.Param[0] = param;

			return paramList;
		}

		/// <summary>
		/// Jpeg用のコーデックを取得します。
		/// </summary>
		/// <returns>Jpeg用のコーデックを表すImageCodecInfo。</returns>
		private static ImageCodecInfo getJpegCodec()
		{
			var encoder = ImageCodecInfo.GetImageEncoders();
			foreach (var enc in encoder)
			{
				if (enc.MimeType == "image/jpeg") { return enc; }
			}

			return null;
		}

		/// <summary>
		/// イメージを保存します。
		/// </summary>
		/// <param name="target">保存対象のイメージを表すBatchTargetImage。</param>
		/// <param name="settings">プラグインの設定を表すPluginSettingBase。</param>
		/// <param name="finisherEnabled">保存処理が有効かを表すbool。</param>
		public static void SaveImage(BatchTargetImage target, PluginSettingBase settings, bool finisherEnabled)
		{
			// 保存機能無効の場合は抜ける
			if (!finisherEnabled) { return; }

			// コーデックを取得
			var codec = DefaultImageWriter.getJpegCodec();
			if (codec == null)
			{
				target.HasError = true;
				target.ErrorNumber = (int)PluginError.ImageCodecNotFound;

				return;
			}
			// 同名ファイルはスキップ
			if (settings.IsSkipSameFileName)
			{
				if (File.Exists(target.FilePath))
				{
					target.HasError = true;
					target.ErrorNumber = (int)PluginError.ExistsSameFileName;

					return;
				}
			}

			try
			{
				if (settings.SaveJpeg)
				{
					target.TargetImage.Save(target.FilePath, codec, DefaultImageWriter.getJpegSavedParameterList(settings));
				}
				else
				{
					target.TargetImage.Save(target.FilePath, ImageFormat.Bmp);
				}
			}
			finally
			{
				target.TargetImage.Dispose();
				target.TargetImage = null;
			}
		}

		#endregion
	}
}
