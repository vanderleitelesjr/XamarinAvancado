using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinAvancado.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand GoToSecond { get; private set; }
        public DelegateCommand CallMsg { get; private set; }
        public DelegateCommand DisplayActionSheet { get; private set; }
        public DelegateCommand GoToAPI { get; private set; }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { SetProperty(ref _cityName, value); }
        }

        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public IPageDialogService _dialogService { get; set; }

        public MainPageViewModel(INavigationService navigationService,IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            Title = "Main Page";
            GoToSecond = new DelegateCommand(GoToSecondNavigation);
            CallMsg = new DelegateCommand(ShowMsg);
            DisplayActionSheet = new DelegateCommand(ShowActionSheet);
            GoToAPI = new DelegateCommand(NavigateToAPI);
        }

        public async void ShowActionSheet()
        {
            string result = await _dialogService.DisplayActionSheetAsync("Choose an action", "Cancel", null, "action 1", "action 2", "action 3", "action 4");
        }

        public async void ShowMsg()
        {
            bool result = await _dialogService.DisplayAlertAsync("Hello", "I'm a msg", "Ok","Cancel");
        }

        public void GoToSecondNavigation()
        {
            var par = new NavigationParameters();
            par.Add("par1", "val1");
            par.Add("par2", "val2");
            NavigationService.NavigateAsync("SecondPage",par);
        }

        public void NavigateToAPI()
        {
            NavigationService.NavigateAsync($"APIPage?city={CityName}");
        }
    }
}
