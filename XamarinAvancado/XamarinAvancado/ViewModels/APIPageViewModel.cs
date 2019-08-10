using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Navigation;
using System.Net.Http;
using XamarinAvancado.API;
using XamarinAvancado.Models;

namespace XamarinAvancado.ViewModels
{
    public class APIPageViewModel : ViewModelBase
    {
        APIHandler api = new APIHandler();
        private RootObject _weather;

        public RootObject Weather
        {
            get { return _weather; }
            set { SetProperty(ref _weather, value); }
        }

        public APIPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {

            Weather = api.GetData(parameters["city"].ToString());
        }
    }
}
