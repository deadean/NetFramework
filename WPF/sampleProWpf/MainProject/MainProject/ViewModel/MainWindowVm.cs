using MainProject.ViewModel.AdditionalTopics;
using MainProject.ViewModel.Data;
using MainProject.ViewModel.Documents_And_Printing;
using MainProject.ViewModel.TestSample;
using MainProject.ViewModel.WindowsPagesRichControl;
using Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class MainWindowVm:ViewModelBase
    {
        public MainWindowVm()
        {
            //System.Windows.SystemCommands.
            this.MenuSamples = new ObservableCollection<CMenuItemVm>();
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Sample1", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample1(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "DependencyProperty", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample2Vm(); }) });

            ObservableCollection<CMenuItemVm> subMenu = new ObservableCollection<CMenuItemVm>();
            subMenu.Add(new CMenuItemVm() { Name = "Controls", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample3Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Application", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample4Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Element Binding and Commands", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample5Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Interesting Tricks", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample6Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Resources", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample7Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Styles And Behaviours", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample8Vm(); }) });
            
            ObservableCollection<CMenuItemVm> subMenu1 = new ObservableCollection<CMenuItemVm>();
            subMenu1.Add(new CMenuItemVm() { Name = "Transforms", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample10Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Drawing and animations", SubMenu=subMenu1,  ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample9Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Geometric and Drawing", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample11Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Effects and Visuals", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample12Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Animation Basics", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample13Vm(); }) });
            subMenu.Add(new CMenuItemVm()
            {
                Name = "Advanced Animation",
                ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample15Vm(); }),
            });
            subMenu.Add(new CMenuItemVm()
            {
                Name = "Games",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
                { 
                    new CMenuItemVm(){Name="Bombs",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample18Vm();})}
                }
            });
            subMenu.Add(new CMenuItemVm() { Name = "Templates and Custom Elements", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample14Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Custom Controls", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample17Vm(); }) });
            subMenu.Add(new CMenuItemVm()
            {
                Name = "Themes",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
            { 
                new CMenuItemVm(){ Name="Theme1",ActivateCommand = new DelegateCommand(()=>{ 
                    ResourceDictionary newDictionary = new ResourceDictionary();
                    newDictionary.Source = new Uri("MainProject;component/Resources/Theme1.xaml",UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries[4] = newDictionary; })},

                new CMenuItemVm(){ Name="Royale",ActivateCommand = new DelegateCommand(()=>{ 
                    ResourceDictionary newDictionary = new ResourceDictionary();
                    newDictionary.Source = new Uri("MainProject;component/Resources/Royale.NormalColor.xaml", UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries[4] = newDictionary; })},

                new CMenuItemVm(){ Name="Theme2",ActivateCommand = new DelegateCommand(()=>{ 
                    ResourceDictionary newDictionary = new ResourceDictionary();
                    newDictionary.Source = new Uri("MainProject;component/Resources/Theme2.xaml",UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries[4] = newDictionary; })}
            }
            });

            this.MenuSamples.Add(new CMenuItemVm() { Name = "Deeper to WPF", SubMenu = subMenu });

            this.MenuSamples.Add(new CMenuItemVm() { Name = "Data", SubMenu = new ObservableCollection<CMenuItemVm>() 
            { 
                new CMenuItemVm(){Name = "Data Binding", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample19Vm();}) },
                new CMenuItemVm(){Name = "Formatting Bound Data", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample20Vm();}) },
                new CMenuItemVm(){Name = "Data View", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample21Vm();}) },
                new CMenuItemVm(){Name = "ListView, Trees, Grids", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample22Vm();}) },
                new CMenuItemVm(){Name = "Windows.Pages.Rich Controls", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample23Vm();}) }
            } });

            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "Windows.Pages.Rich Controls",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
            { 
                new CMenuItemVm(){Name = "Windows.Pages.", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample23Vm();}) },
                new CMenuItemVm(){Name = "Sound and Video", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample24Vm();}) },
                new CMenuItemVm(){Name = "3D-drawing", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample26Vm();}) }
            }
            });

            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "Documents and Printing",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
            { 
                new CMenuItemVm(){Name = "Documents ", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample27Vm();}) },
                new CMenuItemVm(){Name = "Printing ", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample28Vm();}) },
            }
            });

            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "AdditionalTopics",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
            { 
                new CMenuItemVm(){Name = "Interacting with Windows Forms", ActivateCommand = new DelegateCommand(()=>{CurrentItem = new CSample29Vm();}) },
            }
            });

            subMenu = new ObservableCollection<CMenuItemVm>();
            subMenu.Add(new CMenuItemVm() { Name = "Pop Up", ActivateCommand = new DelegateCommand(() => { CurrentItem = new PopUpSampleVm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "TabControl with VM", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample16Vm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "ListBox Sample", ActivateCommand = new DelegateCommand(() => { CurrentItem = new ListBoxSampleVm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "On Top Window Sample", ActivateCommand = new DelegateCommand(() => { CurrentItem = new OnTopWindowSampleVm(); }) });
            subMenu.Add(new CMenuItemVm() { Name = "Async samples", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CSample25Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Test Samples", SubMenu = subMenu });

            this.MenuSamples.Add(new CMenuItemVm() { Name = "Test", ActivateCommand = new DelegateCommand(() => { CurrentItem = new CTestVm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Exit", ActivateCommand = new DelegateCommand<object>((x) => (x as MainWindow).Close()) });
        }

        public ObservableCollection<CMenuItemVm> MenuSamples { get; set; }
        private ViewModelBase mvCurrentItem;
        public ViewModelBase CurrentItem
        {
            get { return mvCurrentItem; }
            set
            {
                mvCurrentItem = value;
                this.OnPropertyChanged(x => x.CurrentItem);
            }
        }

        public bool CanClose()
        {
            return true;
        }

    }
}
