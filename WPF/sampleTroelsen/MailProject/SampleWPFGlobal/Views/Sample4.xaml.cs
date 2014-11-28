using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SampleWPFGlobal.Views
{
    /// <summary>
    /// Interaction logic for Sample4.xaml
    /// </summary>
    public partial class Sample4 : UserControl
    {
        public Sample4()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }

        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += (sender, e) => { e.CanExecute = true; };
            helpBinding.Executed += (sender, e) => { MessageBox.Show("Help is starting now.."); };
            CommandBindings.Add(helpBinding);
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Create an open file dialog box and only show XAML files.
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Text Files |*.txt";
            // Did they click on the OK button?
            if (true == openDlg.ShowDialog())
            {
                // Load all text of selected file.
                string dataFromFile = File.ReadAllText(openDlg.FileName);
                // Show string in TextBox.
                txtData.Text = dataFromFile;
            }
        }
        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text Files |*.txt";
            // Did they click on the OK button?
            if (true == saveDlg.ShowDialog())
            {
                // Save data in the TextBox to the named file.
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;
            // Try to get a spelling error at the current caret location.
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                // Build a string of spelling suggestions.
                foreach (string s in error.Suggestions)
                {
                    spellingHints += string.Format("{0}\n", s);
                }
                // Show suggestions and expand the expander.
                lblSpellingHints.Content = spellingHints;
                expanderSpelling.IsExpanded = true;
            }
        }
    }
}
