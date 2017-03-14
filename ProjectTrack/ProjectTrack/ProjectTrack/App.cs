using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjectTrack.Services;
using ProjectTrack.ViewModel;
using Xamarin.Forms;

namespace ProjectTrack
{
    public class App : Application
    {
        public App()
        {
            var nav = new NavigationService();

            nav.Configure(ViewModelLocator.MainPage, typeof(MainPage));
            nav.Configure(ViewModelLocator.ProjectPage, typeof(ProjectPage));
            nav.Configure(ViewModelLocator.TabbedPage, typeof(Tabbed));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var mainPage = new NavigationPage(new Tabbed());

            nav.Initialize(mainPage);

            MainPage = mainPage;

        }

        private static ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
    }
}
