using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample5Tab2Vm:ViewModelBase
    {
        public ICommand SaveDocument
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var document = x as FlowDocument;
                    if (document == null)
                        return;

                    using (FileStream fStream = File.Open("documentData.xaml", FileMode.Create))
                    {
                        XamlWriter.Save(document, fStream);
                    }
                });
                
            }
        }

        public ICommand LoadDocument
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var document = x as FlowDocument;
                    if (document == null)
                        return;

                    SampleFlowDocumentVm flowDocData = document.DataContext as SampleFlowDocumentVm;

                    using (FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
                    {
                        try
                        {
                            FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
                            //flowDocData
                            document = doc;
                            Document = doc;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error Loading Doc!"); }
                    }
                });
            }
        }

        public ICommand ClearDocument
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Document.Blocks.Clear();
                });
            }
        }

        public Sample5Tab2Vm()
        {
            Document = Application.LoadComponent(new Uri("/SampleWPFGlobal;Component/Views/FlowDocument1.xaml", UriKind.Relative)) as FlowDocument;
            Document.DataContext = new SampleFlowDocumentVm();
        }

        private FlowDocument mvDoc;
        public FlowDocument Document
        {
            get { return mvDoc; }
            set
            {
                mvDoc = value;
                this.OnPropertyChanged(x=>x.Document);
            }
        }
    }
}
