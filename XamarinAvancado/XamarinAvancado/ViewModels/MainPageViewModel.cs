﻿using Prism.Commands;
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
        public DelegateCommand CallMsg { get; private set; }
        public DelegateCommand GoToAPI { get; private set; }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { SetProperty(ref _cityName, value); }
        }

        public IPageDialogService _dialogService { get; set; }

        public MainPageViewModel(INavigationService navigationService,IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            Title = "Xamarin Avançado";
            CallMsg = new DelegateCommand(ShowMsg);
            GoToAPI = new DelegateCommand(NavigateToAPI);
        }

        public async void ShowMsg()
        {
            bool result = await _dialogService.DisplayAlertAsync("Hello", "I'm a msg", "Ok","Cancel");
        }

        public void NavigateToAPI()
        {
            NavigationService.NavigateAsync($"APIPage?city={CityName}");
        }
    }
}
