using MainProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample5Vm:ViewModelBase
    {
        public CSample5Vm()
        {
            var mainControl = (Application.Current.MainWindow as Window);
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            binding.Executed += (x,y) => 
            {
                var wnd = new Window2();
                wnd.Owner = (Application.Current.MainWindow as Window);
                wnd.CommandBindings.AddRange((Application.Current.MainWindow as Window).CommandBindings);
                wnd.Show();
            };
            binding.CanExecute += (x, y) => { y.CanExecute = true; };
            mainControl.CommandBindings.Add(binding);

            binding = new CommandBinding(DataCommands.Requery);
            binding.Executed += (x, y) =>
            {
                MessageBox.Show("Command Requery is fired!");
            };
            binding.CanExecute += (x, y) => { y.CanExecute = true; };

            mainControl.CommandBindings.Add(binding);

            binding = new CommandBinding(DataCommands.ApplicationUndo);
            binding.Executed += (x, y) =>
            {
                var historyItem = Items.LastOrDefault();
                
                if (historyItem.CanUndo) 
                    historyItem.Undo();

                Items.Remove(historyItem);
            };
            binding.CanExecute += (x, y) => { y.CanExecute = true; };

            mainControl.CommandBindings.Add(binding);
            //mainControl.AddHandler(CommandManager.PreviewCanExecuteEvent, new ExecutedRoutedEventHandler(CommandExecuted1));
        }

        public ICommand StartCommandForUndo
        {
            get 
            {
                return new DelegateCommand<object>((x) => 
                {
                    TextBox txt = x as TextBox;
                    if (txt != null)
                    {
                        //RoutedCommand cmd = (RoutedCommand)e.Command;
                        CCommandHistoryItem historyItem = new CCommandHistoryItem(
                        "Name", txt, "Text", txt.Text);
                        Items.Add(historyItem);
                    }
                });
            }
        }

        private void CommandExecuted1(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is ICommandSource) return;
            if (e.Command == DataCommands.ApplicationUndo) return;
            TextBox txt = e.Source as TextBox;
            if (txt != null)
            {
                RoutedCommand cmd = (RoutedCommand)e.Command;
                CCommandHistoryItem historyItem = new CCommandHistoryItem(
                cmd.Name, txt, "Text", txt.Text);
                ListBoxItem item = new ListBoxItem();
                item.Content = historyItem;
                Items.Add(historyItem);
            }
        }

        private ObservableCollection<CCommandHistoryItem> mvItems = new ObservableCollection<CCommandHistoryItem>();

        public ObservableCollection<CCommandHistoryItem> Items
        {
            get { return mvItems; }
            set { mvItems = value; }
        }

        public ICommand CommandForUndoStart
        {
            get { return new DelegateCommand(() => { MessageBox.Show("Hello!"); }); }
        }
        
        public ICommand CommandFire
        {
            get { return new DelegateCommand(() => { MessageBox.Show("Hello!"); }); }
        }

        public ICommand ShowText
        {
            get { return new DelegateCommand<object>((x) => { MessageBox.Show("Start FROM TARGET"); }, (x) => { return true; }); }
        }

        public ICommand LargTextCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var textBlock = x as TextBlock;
                    
                    if (x == null)
                        return;

                    textBlock.FontSize = 25;
                });
            }
        }

    }
}
