using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace net.elfmission.WindowsApps.ImageSplitter
{
	/// <summary>例外を書き込みます。</summary>
	public static class ExceptionWriter
	{
		private const string LOG_FILE_NAME = "ImageSplitterError";

		private static StringBuilder getLogContents(Exception ex)
		{
			var log = new StringBuilder(2000);

			log.AppendLine("=================================================================");
			log.AppendLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
			log.AppendLine(ex.ToString());

			return log;
		}

		private static string getLogPath(string logFolderPath)
		{
			var seq = 1;
			var logPath = Path.Combine(logFolderPath, ExceptionWriter.LOG_FILE_NAME + seq.ToString() + ".log");
			if (File.Exists(logPath))
			{
				do
				{
					var info = new FileInfo(logPath);
					if (1024 < info.Length / 1024)
						seq++;
					else
						break;

					logPath = Path.Combine(logFolderPath, ExceptionWriter.LOG_FILE_NAME + seq.ToString() + ".log");
				} while (File.Exists(logPath));
			}

			return logPath;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ex"></param>
		/// <param name="logFolderPath"></param>
		public static void WriteLog(Exception ex, string logFolderPath)
		{
			var logPath = ExceptionWriter.getLogPath(logFolderPath);
			var contents = ExceptionWriter.getLogContents(ex).ToString();

			if (File.Exists(logPath))
			{
				File.AppendAllText(logPath, contents);
			}
			else
			{
				File.WriteAllText(logPath, contents);
			}
		}
	}
}
