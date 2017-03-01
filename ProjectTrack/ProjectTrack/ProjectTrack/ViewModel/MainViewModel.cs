using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ProjectTrack.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Title { get; set; }
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            Title = "ProjectTrack";

            if (navigationService == null)
                throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            NavigationCommand =
                 new RelayCommand<string>((parameter) =>
                       Navigate(parameter));

        }

        private void Navigate(string parameter)
        {
            _navigationService.
               NavigateTo(ViewModelLocator.ListPage, parameter ?? string.Empty);
        }

        public RelayCommand<string> NavigationCommand { get; private set; }
    }
}
