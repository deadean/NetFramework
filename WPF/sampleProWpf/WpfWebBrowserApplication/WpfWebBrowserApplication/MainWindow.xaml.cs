using System;
using System.Windows;
using mshtml;

namespace WpfWebBrowserApplication
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			browser.Navigate(new Uri("http://mybrandw.s66.r53.com.ua/", UriKind.RelativeOrAbsolute));
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				var document = browser.Document as IHTMLDocument3;
				var htmlElement = document.getElementById("hMainNews");
				htmlElement.click();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
