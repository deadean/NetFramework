using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using LizenzaDevelopment.ADAICA.Data.GLOB.ctrGLOB.ViewModel.Commands;
using ViewModelLib.Types;
using System.Windows.Markup;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample2Vm:ViewModelBase
    {
        private string FileName = "YourXaml.xaml";
        public Sample2Vm()
        {
            if (File.Exists(FileName))
            {
                ContentText = File.ReadAllText(FileName);
            }
            else
            {
                ContentText =
                "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n"
                + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n"
                + "Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\">\n"
                + "<StackPanel>\n"
                + "</StackPanel>\n"
                + "</Window>";
            }
        }
        public ICommand ViewCommand
        {
            get
            {
                return new RelayCommand((x) =>
                    {
                        File.WriteAllText(FileName, ContentText);
                        Window myWindow = null;
                        try
                        {
                            using (Stream sr = File.Open(FileName, FileMode.Open))
                            {
                                myWindow = (Window)XamlReader.Load(sr);
                                // Show window as a dialog and clean up.
                                myWindow.ShowDialog();
                                myWindow.Close();
                                myWindow = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });
            }
        }

        private string mvContentText = String.Empty;

        public string ContentText
        {
            get { return mvContentText; }
            set
            {
                mvContentText = value;
                this.OnPropertyChanged(x=>x.ContentText);
            }
        }
    }
}
