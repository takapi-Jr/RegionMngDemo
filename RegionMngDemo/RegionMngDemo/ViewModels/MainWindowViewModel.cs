using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;

namespace RegionMngDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ReactiveCommand<string> NavigationCommand { get; } = new ReactiveCommand<string>();

        public IRegionManager RegionManager { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.RegionManager = regionManager;

            NavigationCommand.Subscribe<string>(viewName =>
            {
                this.RegionManager.RequestNavigate("ContentRegion", viewName);
            });
        }
    }
}
