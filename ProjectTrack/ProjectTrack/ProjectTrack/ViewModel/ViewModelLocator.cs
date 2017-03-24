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
        public const string ProjectPage = "ProjectPage";
        public const string TabbedPage = "Tabbed";
        public const string TaskPage = "TaskPage";
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ProjectViewModel>();
            SimpleIoc.Default.Register<TaskViewModel>();

            // Services
            //Here we will be registering services to IOC
        }

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public ProjectViewModel Project
        {
            get { return ServiceLocator.Current.GetInstance<ProjectViewModel>(); }
        }

        public TaskViewModel Task
        {
            get { return ServiceLocator.Current.GetInstance<TaskViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
