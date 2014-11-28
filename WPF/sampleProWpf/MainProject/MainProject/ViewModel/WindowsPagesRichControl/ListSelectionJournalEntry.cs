using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    [Serializable]
    public class ListSelectionJournalEntry:CustomContentState
    {
        private List<string> sourcesItems;
        private List<string> targetItems;
        private string journalName;

        public delegate void ReplayListChange(ListSelectionJournalEntry instanceState);
        private ReplayListChange replayListChange;

        public ListSelectionJournalEntry(IList<string> source, IList<string> target, string _journalName, ReplayListChange replayListChangeCallBack)
        {
            this.sourcesItems = source.ToList();
            this.targetItems = target.ToList();
            this.journalName = _journalName;
            this.replayListChange = replayListChangeCallBack;
        }

        public List<string> SourceItems
        {
            get { return sourcesItems; }
        }

        public List<string> TargetItems
        {
            get { return targetItems; }
        }

        public override string JournalEntryName
        {
            get
            {
                return journalName;
            }
        }

        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {
            this.replayListChange(this);
        }
    }
}
