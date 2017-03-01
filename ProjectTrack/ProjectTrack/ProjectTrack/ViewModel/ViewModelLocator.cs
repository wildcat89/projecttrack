using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace ProjectTrack.ViewModel
{
    public class ViewModelLocator
    {
        public const string MainPage = "MainPage";
        public const string ListPage = "ListPage";
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ListViewModel>();

            // Services
            //Here we will be registering services to IOC
        }

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public ListViewModel List
        {
            get { return ServiceLocator.Current.GetInstance<ListViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
