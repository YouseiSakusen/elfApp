using System.Text;
using System.Xml.Serialization;

namespace net.elfmission.Utilities
{
	public static class XmlUtility
	{
		#region "メソッド"

		/// <summary>
		/// オブジェクトをXMLファイルにシリアライズします。
		/// </summary>
		/// <param name="xmlFilePath">オブジェクトをシリアライズするXMLファイルのパスを表す文字列。</param>
		/// <param name="target">XMLファイルにシリアライズするobject。</param>
		public static void XmlSerializeTo(string xmlFilePath, object target)
		{
			if (target == null) { return; }

			using (var writer = new System.IO.StreamWriter(xmlFilePath, false, new UTF8Encoding(false)))
			{
				var serializer = new XmlSerializer(target.GetType());
				serializer.Serialize(writer, target);
			}
		}

		/// <summary>
		/// XMLファイルから指定したオブジェクトをデシリアライズします。
		/// </summary>
		/// <typeparam name="T">デシリアライズする型。</typeparam>
		/// <param name="xmlFilePath">オブジェクトを保存したXMLファイルへのフルパスを表す文字列。</param>
		/// <returns>XMLファイルからデシリアライズしたT。</returns>
		public static T XmlDeserializeFrom<T>(string xmlFilePath) where T : class
		{
			if (! System.IO.File.Exists(xmlFilePath)) { return null; }

			using (var reader = new System.IO.StreamReader(xmlFilePath, new UTF8Encoding(false)))
			{
				var serializer = new XmlSerializer(typeof(T));

				return serializer.Deserialize(reader) as T;
			}
		}

		#endregion
	}
}
