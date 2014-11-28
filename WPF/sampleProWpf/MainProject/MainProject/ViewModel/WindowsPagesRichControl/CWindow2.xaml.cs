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
using System.Windows.Shapes;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    /// <summary>
    /// Interaction logic for CWindow1.xaml
    /// </summary>
    public partial class CWindow2
    {
        public CWindow2()
        {
            InitializeComponent();
						this.MouseMove += CWindow2_MouseMove;
        }

				void CWindow2_MouseMove(object sender, MouseEventArgs e)
				{
					if (e.LeftButton == MouseButtonState.Pressed)
					{
						this.DragMove();
					}
				}
    }
}
