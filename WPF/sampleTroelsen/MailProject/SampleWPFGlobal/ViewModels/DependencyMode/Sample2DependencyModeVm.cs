using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.DependencyMode
{
    public class Sample2DependencyModeVm:ViewModelBase
    {
        public Sample2DependencyModeVm()
        {
            ElementName = "System.Windows.Controls.Button";
        }
        private string dataToShow = String.Empty;
        private string mvElementName = String.Empty;

        public ICommand ShowLogicalTreeCommand
        {
            get
            {
                return new DelegateCommand<object>((x) => 
                {
                    var userControl = x as UserControl;
                    dataToShow = "";
                    BuildLogicalTree(0, userControl);
                    DisplayArea= dataToShow;
                });
            }
        }

        public ICommand ShowVisualTreeCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var userControl = x as UserControl;
                    dataToShow = "";
                    BuildVisualTree(0, userControl);
                    DisplayArea = dataToShow;
                });
            }
        }

        public ICommand ShowTemplateCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {

                    var userControl = x as StackPanel;
                    dataToShow = "";
                    ShowTemplate(userControl);
                    DisplayArea = dataToShow;
                });
            }
        }

        public ICommand TestOnClick
        {
            get { return new DelegateCommand(() => { MessageBox.Show("dd"); }); }
        }

        public string DisplayArea
        {
            get { return this.dataToShow; }
            set
            {
                this.dataToShow = value;
                this.OnPropertyChanged(x=>x.DisplayArea);
            }

        }

        public string ElementName
        {
            get { return this.mvElementName; }
            set
            {
                this.mvElementName = value;
                this.OnPropertyChanged(x => x.ElementName);
            }

        }

        private Control ctrlToExamine = null;

        void BuildLogicalTree(int depth, object obj)
        {
            // Add the type name to the dataToShow member variable.
            dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // If an item is not a DependencyObject, skip it.
            if (!(obj is DependencyObject))
                return;
            // Make a recursive call for each logical child.
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))BuildLogicalTree(depth + 5, child);
        }

        void BuildVisualTree(int depth, DependencyObject obj)
        {
            // Add the type name to the dataToShow member variable.
            dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // Make a recursive call for each visual child.
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        private void ShowTemplate(StackPanel stackPanel)
        {
        // Remove the control that is currently in the preview area.
        if (ctrlToExamine != null)
            stackPanel.Children.Remove(ctrlToExamine);
        try
        {
            // Load PresentationFramework, and create an instance of the
            // specified control. Give it a size for display purposes, then add to the
            // empty StackPanel.
            Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0," +
            "Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            ctrlToExamine = (Control)asm.CreateInstance(ElementName);
            ctrlToExamine.Height = 200;
            ctrlToExamine.Width = 200;
            ctrlToExamine.Margin = new Thickness(5);
            stackPanel.Children.Add(ctrlToExamine);
            // Define some XML settings to preserve indentation.
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            // Create a StringBuilder to hold the XAML.
            StringBuilder strBuilder = new StringBuilder();
            // Create an XmlWriter based on our settings.
            XmlWriter xWriter = XmlWriter.Create(strBuilder, xmlSettings);
            // Now save the XAML into the XmlWriter object based on the ControlTemplate.
            XamlWriter.Save(ctrlToExamine.Template, xWriter);
            // Display XAML in the text box.
            dataToShow = strBuilder.ToString();
        }
        catch (Exception ex)
        {
            DisplayArea = ex.Message;
        }
        }

    }
}
