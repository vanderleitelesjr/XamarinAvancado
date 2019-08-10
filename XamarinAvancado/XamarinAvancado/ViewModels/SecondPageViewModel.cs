using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinAvancado.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public SecondPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("par1"))
            {
                string par1 = parameters["par1"].ToString();
                string par2 = parameters["par2"].ToString();
            }
        }
    }
}
