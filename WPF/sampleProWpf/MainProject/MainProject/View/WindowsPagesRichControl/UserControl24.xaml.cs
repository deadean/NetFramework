using MainProject.ViewModel.WindowsPagesRichControl;
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

namespace MainProject.View.WindowsPagesRichControl
{
    /// <summary>
    /// Interaction logic for UserControl24.xaml
    /// </summary>
    public partial class UserControl24 : UserControl
    {
        public UserControl24()
        {
            InitializeComponent();
            this.DataContextChanged += UserControl24_DataContextChanged;
        }

        void UserControl24_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            (e.NewValue as CSample24Vm).ControlInstance = this;
        }

        private void ctrMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            txtExceptionMediaElement.Text = e.ErrorException.Message;
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void sliderPosition_ValueChanged(object sender, RoutedEventArgs e)
        {
            media.Pause();
            media.Position = TimeSpan.FromSeconds(sliderPosition.Value);
            media.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("file.mpg", UriKind.Relative));

            VideoDrawing videoDrawing = new VideoDrawing();
            videoDrawing.Rect = new Rect(150, 0, 100, 100);
            videoDrawing.Player = player;

            DrawingBrush brush = new DrawingBrush(videoDrawing);
            this.Background = brush;

            player.Play();
        }
    }
}
