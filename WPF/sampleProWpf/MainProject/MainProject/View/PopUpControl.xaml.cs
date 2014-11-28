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
    /// Interaction logic for PopUpControl.xaml
    /// </summary>
    public partial class PopUpControl : UserControl
    {
        public PopUpControl()
        {
            InitializeComponent();
            this.popLink.CustomPopupPlacementCallback = GetPopupPlacement;
            //this.popLink.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
            
        }

        public CustomPopupPlacement[] placePopup(Size popupSize,
                                           Size targetSize,
                                           Point offset)
        {
            CustomPopupPlacement placement1 =
               new CustomPopupPlacement(new Point(-50, 100), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement placement2 =
                new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);

            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { placement1, placement2 };
            return ttplaces;
        }

        private static CustomPopupPlacement[] GetPopupPlacement(Size popupSize, Size targetSize, Point offset)
        {
            var point = SystemParameters.WorkArea.BottomRight;
            point.Y = point.Y - popupSize.Height;
            return new[] { new CustomPopupPlacement(point, PopupPrimaryAxis.Horizontal) };
        }
    }
}
