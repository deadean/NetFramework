using SampleWPFGlobal.ViewModels.DependencyMode;
using SampleWPFGlobal.ViewModels.GraphicsMode;
using SampleWPFGlobal.ViewModels.ResourcesMode;
using SampleWPFGlobal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class MainWindowVm:ViewModelBase
    {
        public MainWindowVm()
        {
            this.MenuSamples = new ObservableCollection<CMenuItemVm>();
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Sample1", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample1Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "WPF Editor", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample2Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Sample3", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample3Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "MyWordPad", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample4Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "SampleTabControl", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample5Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm() { Name = "Color Editor", ActivateCommand = new DelegateCommand(() => { CurrentItem = new Sample6Vm(); }) });
            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "WPF GRAPHICS MODE",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
                {
                    new CMenuItemVm(){Name = "Sample1GRAPHICS",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample1GraphicsModeVm();})},
                    new CMenuItemVm(){Name = "Sample2GRAPHICS",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample2GraphicsModeVm();})},
                    new CMenuItemVm(){Name = "Sample3GRAPHICS_Transformation",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample3GraphicsModeVm();})},
                    new CMenuItemVm(){Name = "Sample4GRAPHICS_DrawingBrush",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample4GraphicsModeVm();})},
                    new CMenuItemVm(){Name = "Sample4GRAPHICS_VisualLayer",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample5GraphicsModeVm();})}
                }
            });

            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "WPF Resources MODE",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
                {
                    new CMenuItemVm(){Name = "Sample1",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample1ResourcesModeVm();})},
                    new CMenuItemVm(){Name = "Animation",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample2ResourcesModeVm();})},
                    new CMenuItemVm(){Name = "Styles",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample3ResourcesModeVm();})},
                    new CMenuItemVm(){Name = "Show Animate Window",ActivateCommand = new DelegateCommand(()=>
                    {
                        //SimpleUiWindow _simpleUiWindow = new SimpleUiWindow();
                        //_simpleUiWindow.MotionBlur = false;
                        //_simpleUiWindow.AnimationDuration = TimeSpan.FromMilliseconds(1200);
                        //_simpleUiWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        //_simpleUiWindow.Show();

                        var _simpleUiWindow = new Window1();
                        _simpleUiWindow.DataContext = new Sample4ResourcesModeVm(){SomeText="HELKLO"};
                        _simpleUiWindow.MotionBlur = false;
                        _simpleUiWindow.AnimationDuration = TimeSpan.FromMilliseconds(1200);
                        _simpleUiWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        _simpleUiWindow.Show();

                    })},
                }
            });

            this.MenuSamples.Add(new CMenuItemVm()
            {
                Name = "WPF Dependency MODE",
                SubMenu = new ObservableCollection<CMenuItemVm>() 
                {
                    new CMenuItemVm(){Name = "Sample1",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample1DependencyModeVm();})},
                    new CMenuItemVm(){Name = "Sample2",ActivateCommand = new DelegateCommand(()=>{CurrentItem = new Sample2DependencyModeVm();})},
                }
            });


        }

        private string mvHeader = "hello";
        public string Header
        {
            get { return mvHeader; }
            set
            {
                mvHeader = value;
                this.OnPropertyChanged(x=>x.Header);
            }
        }

        public ObservableCollection<CMenuItemVm> MenuSamples { get; set; }

        private ViewModelBase mvCurrentItem;
        public ViewModelBase CurrentItem
        {
            get { return mvCurrentItem; }
            set
            {
                mvCurrentItem = value;
                this.OnPropertyChanged(x=>x.CurrentItem);
            }
        }
    }
}
