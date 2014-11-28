using MainProject.ViewModel.TestSample;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace MainProject.View.TestSample
{
    /// <summary>
    /// Interaction logic for ListBoxSample.xaml
    /// </summary>
    public partial class ListBoxSample : UserControl
    {
        public ListBoxSample()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)lstBoxMessagies1.Items).CollectionChanged += ListBoxSample_CollectionChanged;
        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void PreviewGotKeyboardFocusHandler(object sender, KeyboardFocusChangedEventArgs e)
        {
            //var item = sender as ListBoxItem;
            //if (item == null)
            //    return;

            //item.IsSelected = !item.IsSelected;
            //if (item.IsSelected)
            //    lstBoxMessagies.SelectedItems.Add(item);
            //else
            //    lstBoxMessagies.SelectedItems.Remove(item);
            //lstBoxMessagies.SelectedValue = item;
            //e.Handled = true;
            
        }

        private void lstBoxMessagies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListBoxItem;
            if (item == null)
                return;

            var message = item.DataContext as CMessage;

            item.IsSelected = !item.IsSelected;

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (item.IsSelected)
                    lstBoxMessagies.SelectedItems.Add(message);
                else
                    lstBoxMessagies.SelectedItems.Remove(message);
            }
            else
                lstBoxMessagies.SelectedItem = message;
        }

        void ListBoxSample_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                lstBoxMessagies1.ScrollIntoView(e.NewItems[0]);
            }
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Move");
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Enter");
        }

        private void TextBox_DragOver(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Over");
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DragEnter");
        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("PreviewMouseLeftButtonDown");
        }

        private void TextBox_PreviewDragEnter(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("PreviewDragEnter");
        }

        private void TextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GotMouseCapture");
        }


        private void TextBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void lstBoxMessagies_MouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("lstBoxMessagies_MouseMove");
        }

        


    }
}
