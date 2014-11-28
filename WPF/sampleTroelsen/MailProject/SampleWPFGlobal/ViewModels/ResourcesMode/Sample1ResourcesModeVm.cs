using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.ResourcesMode
{
    public class Sample1ResourcesModeVm:ViewModelBase
    {
        List<BitmapImage> images = new List<BitmapImage>();
        private int currImage = 0;
        private const int MAX_IMAGES = 2;

        private BitmapImage mvImageSource;
        public BitmapImage ImageSource
        {
            get { return mvImageSource; }
            set
            {
                mvImageSource = value;
                this.OnPropertyChanged(x=>x.ImageSource);
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        string path = Environment.CurrentDirectory;

                        // In the Debug folder Images folder must be present
                        //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\1.jpg", path))));
                        //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\2.jpg", path))));
                        //images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\3.jpg", path))));

                        images.Add(new BitmapImage(new Uri(@"/Images/1.jpg", UriKind.Relative)));
                        images.Add(new BitmapImage(new Uri(@"/Images/2.jpg", UriKind.Relative)));
                        images.Add(new BitmapImage(new Uri(@"/Images/3.jpg", UriKind.Relative)));

                        ImageSource = images[currImage];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (--currImage < 0)
                        currImage = MAX_IMAGES;
                    ImageSource = images[currImage];
                });
            }
        }

        public ICommand NextCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (++currImage > MAX_IMAGES)
                        currImage = 0;
                    ImageSource = images[currImage];
                });
            }
        }

        public ICommand ChangeDynamicResourceCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var window = x as UserControl;
                    if (window == null)
                        return;
                    window.Resources["myBrushButton"] = new SolidColorBrush(Colors.Red);
                });
            }
        }

        

    }
}
