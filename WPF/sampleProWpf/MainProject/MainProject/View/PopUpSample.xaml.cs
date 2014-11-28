using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject.View
{
	/// <summary>
	/// Interaction logic for PopUpSample.xaml
	/// </summary>
	public partial class PopUpSample : UserControl
	{
		public PopUpSample()
		{
			InitializeComponent();
			//this.popUp.CustomPopupPlacementCallback = GetPopupPlacement;
			popUp.MouseMove += new MouseEventHandler(pop_MouseMove);

		}

		void pop_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				popUp.PlacementRectangle = new Rect(new Point(e.GetPosition(this).X,
						e.GetPosition(this).Y), new Point(200, 200));

			}
		}

		private static CustomPopupPlacement[] GetPopupPlacement(Size popupSize, Size targetSize, Point offset)
		{
			var res = Mouse.GetPosition(Application.Current.MainWindow);
			var point = new Point(0,0);
			//point = res;
			//var pointTarget = new Point(targetSize.Width, targetSize.Height);
			//var pointBottomRight = SystemParameters.WorkArea.BottomRight;

			//bool isUseBottom = pointTarget.X < pointBottomRight.X;
			//point = isUseBottom ? pointBottomRight : pointTarget;
			////point.X -= 40;
			//point.X -= 57;
			//point.Y = point.Y - popupSize.Height - (isUseBottom ? 57 : 73);

			//try
			//{
			//	//point.Y = GetScreenFromWindow(Application.Current.MainWindow) < 860 ? point.Y - 100 : point.Y;
			//}
			//catch (Exception ex)
			//{
			//}

			return new[]
			{
				new CustomPopupPlacement(point, PopupPrimaryAxis.Horizontal),
				new CustomPopupPlacement(point, PopupPrimaryAxis.Vertical)
			};
		}
	}
}
