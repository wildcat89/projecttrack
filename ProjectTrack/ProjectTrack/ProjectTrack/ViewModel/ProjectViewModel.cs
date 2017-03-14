using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjectTrack.Model;
using ProjectTrack.Services;
using Xamarin.Forms;

namespace ProjectTrack.ViewModel
{
    public class ProjectViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public List<Project> Projects { get; set; }
        public ProjectViewModel(INavigationService navigationService)
        {

            NozbeService nozbeService = new NozbeService("xxx@gmail.com", "xxx");
            string projects = nozbeService.Projects();

            Projects = JsonConvert.DeserializeObject<List<Project>>(projects);
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

        }

    }
}
