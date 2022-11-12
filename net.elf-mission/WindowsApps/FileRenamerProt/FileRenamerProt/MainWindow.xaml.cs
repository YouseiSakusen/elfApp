using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using HtmlAgilityPack;

namespace FileRenamerProt
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			using (var client = new HttpClient())
			{
				var htmlDoc = new HtmlDocument();
				htmlDoc.LoadHtml(await client.GetStringAsync("https://ja.wikipedia.org/wiki/%E5%B9%BC%E5%A5%B3%E6%88%A6%E8%A8%98"));

				var nodeList = htmlDoc.DocumentNode.SelectNodes(@"//h3/span[contains(text(), ""各話リスト"")]/following::table[@class=""wikitable""]");

			} 
		}
	}
}
