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
    public class ListViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ListViewModel(INavigationService navigationService)
        {
            Title = "Second Page";

            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            NavigationCommand =
                 new RelayCommand<string>((parameter) =>
                       Navigate(parameter));
        }

        public string Title { get; set; }

        private void Navigate(string parameter)
        {
            _navigationService.
               NavigateTo(ViewModelLocator.MainPage, parameter ?? string.Empty);
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

    }
}
