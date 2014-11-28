using MainProject.View.Documents_And_Printing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.Documents_And_Printing
{
    public class CSample27Vm:ViewModelBase
    {
        #region Fields

        private FlowDocument mvDocument;
        private FlowDocument mvDocument1;
        private MemoryStream annotationStream;
        private AnnotationService service;

        #endregion

        #region Ctor

        public CSample27Vm()
        {
            Command1 = new DelegateCommand(OnCommand1);
            Command2 = new DelegateCommand(OnCommand2);
            Command3 = new DelegateCommand(OnCommand3);
            
        }

        #endregion

        #region Private Services
        #endregion

        #region Public Services
        #endregion

        #region Protected Methods

        public override void OnControlInstanceChanged()
        {
            this.TryCatch(() =>
            {
                base.OnControlInstanceChanged();

                ControlInstance.WithType<CSample27View>(x => service = new AnnotationService(x.ctr2));
                annotationStream = new MemoryStream();
                AnnotationStore store = new XmlStreamStore(annotationStream);

                service.Enable(store);
            }, "OnControlInstanceChanged");
        }

        #endregion

        #region Properties

        public FlowDocument Document { get { return mvDocument; } set { mvDocument = value; this.OnPropertyChanged(x => x.Document); } }
        public FlowDocument Document1 { get { return mvDocument1; } set { mvDocument1 = value; this.OnPropertyChanged(x => x.Document1); } }

        #endregion

        #region Commands

        public DelegateCommand Command1 { get; set; }
        public DelegateCommand Command2 { get; set; }
        public DelegateCommand Command3 { get; set; }

        #endregion

        #region Commands Execute Handlers

        private void OnCommand1()
        {
            MessageBox.Show("Click!");
        }

        private void OnCommand2()
        {
            var documentFile = "EntityFramework.xml";
            {
                var str = File.ReadAllText(documentFile);
                var run = new Run(str);
                var par = new Paragraph();
                par.Inlines.Add(run);

                Document = new FlowDocument(par);
            }
        }

        private void OnCommand3()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*"; 
            if (fd.ShowDialog() == DialogResult.OK)
            {
                ControlInstance.WithType<CSample27View>(x =>
                {
                    TextRange documentRage = new TextRange(x.ctr1.Document.ContentStart, x.ctr1.Document.ContentEnd);
                    using (FileStream fs = File.Open(fd.FileName, FileMode.Open))
                    {
                        documentRage.Load(fs, DataFormats.Rtf);
                    }
                });
            }
        }

        #endregion

        #region Message Handlers
        #endregion

        #region Events Handlers
        #endregion

    }
}
