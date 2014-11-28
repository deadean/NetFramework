using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
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
    /// Interaction logic for Sample5Tab2.xaml
    /// </summary>
    public partial class Sample5Tab2 : UserControl
    {
        public Sample5Tab2()
        {
            InitializeComponent();
            //myDocumentReader.Document = Application.LoadComponent(new Uri("SampleWPFGlobal;Component/Views/FlowDocument1.xaml",UriKind.Relative)) as FlowDocument;
            //PopulateDocument();
            EnableAnnotations();
        }
        //private void PopulateDocument()
        //{
        //    // Add some data to the List item.
        //    this.listOfFunFacts.FontSize = 14;
        //    this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
        //    this.listOfFunFacts.ListItems.Add(new ListItem(new
        //    Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
        //    this.listOfFunFacts.ListItems.Add(new ListItem(
        //    new Paragraph(new Run("The API supports tables and embedded figures!"))));
        //    this.listOfFunFacts.ListItems.Add(new ListItem(
        //    new Paragraph(new Run("Flow documents are read only!"))));
        //    this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run
        //    ("BlockUIContainer allows you to embed WPF controls in the document!")
        //    )));
        //    // Now add some data to the Paragraph.
        //    // First part of sentence.
        //    Run prefix = new Run("This paragraph was generated ");
        //    // Middle of paragraph.
        //    Bold b = new Bold();
        //    Run infix = new Run("dynamically");
        //    infix.Foreground = Brushes.Red;
        //    infix.FontSize = 30;
        //    b.Inlines.Add(infix);
        //    // Last part of paragraph.
        //    Run suffix = new Run(" at runtime!");
        //    // Now add each piece to the collection of inline elements
        //    // of the Paragraph.
        //    this.paraBodyText.Inlines.Add(prefix);
        //    this.paraBodyText.Inlines.Add(infix);
        //    this.paraBodyText.Inlines.Add(suffix);
        //}
        private void EnableAnnotations()
        {
            // Create the AnnotationService object that works
            // with our FlowDocumentReader.
            AnnotationService anoService = new AnnotationService(myDocumentReader);
            // Create a MemoryStream that will hold the annotations.
            MemoryStream anoStream = new MemoryStream();
            // Now, create an XML-based store based on the MemoryStream.
            // You could use this object to programmatically add, delete,
            // or find annotations.
            AnnotationStore store = new XmlStreamStore(anoStream);
            // Enable the annotation services.
            anoService.Enable(store);
        }

    }
}
