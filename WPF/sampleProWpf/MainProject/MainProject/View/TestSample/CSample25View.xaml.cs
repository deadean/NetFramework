using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for CSample25View.xaml
    /// </summary>
    public partial class CSample25View : UserControl
    {
        private BackgroundWorker modBackgroundWorker;

        public CSample25View()
        {
            InitializeComponent();
            modBackgroundWorker = (BackgroundWorker)this.FindResource("backgroundWorker");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread th = new Thread(() => 
                {
                    try
                    {
                        ctr1.Text = "Update Text 5"; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot change textBlock Text with not own textBlock Dispatcher");
                    }
                    
                });
                th.Start();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(() =>
            {
                this.Dispatcher.Invoke(() => { ctr2.Text = "Update Text 6"; });
            });
            th.Start();
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 1; i < 11; i++)
            {
                if (modBackgroundWorker.CancellationPending)
                {
                    MessageBox.Show("Tasks is stopped");
                    return;
                }
                for (int i1 = 1; i1 < 100000000; i1++)
                {
                    int b = i1 * 789;
                    int c = i1 * 5678;
                    int d = b / c;
                }
                this.Dispatcher.Invoke(() =>
                {
                    ctr3.Text = ctr3.Text + i.ToString() + ",";
                });
                modBackgroundWorker.ReportProgress(i * 10);
                
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ctr4.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("BackgroundWorker has finished all tasks");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.modBackgroundWorker.RunWorkerAsync();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            modBackgroundWorker.CancelAsync();
        }
    }
}
