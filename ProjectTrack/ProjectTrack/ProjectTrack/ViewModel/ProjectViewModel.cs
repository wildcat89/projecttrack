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
        private NozbeService nozbeService;
        private Project _selectedProject;
        public Project SelectedProject {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;

                if (_selectedProject == null)
                    return;

                ShowTasksCommand.Execute(_selectedProject.Id);

                SelectedProject = null;
            }
        }
        public NotifyTaskCompletion<List<Project>> Projects { get; private set; }

        public NotifyTaskCompletion<List<NozbeTask>> Tasks { get; private set; }

        public ICommand ShowTasksCommand { get; private set; }

        public ProjectViewModel(INavigationService navigationService)
        {

            nozbeService = new NozbeService("xxx@gmail.com", "xxx");

            Projects = new NotifyTaskCompletion<List<Project>>(GetProjects());
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            ShowTasksCommand = new Command<string>(ShowTasks);

        }

        public async Task<List<Project>> GetProjects()
        {
            var projects = await nozbeService.Projects();
            return JsonConvert.DeserializeObject<List<Project>>(projects);
        }

        void ShowTasks(string Id)
        {
            _navigationService.NavigateTo(ViewModelLocator.TaskPage, Id);
        }
    }
}
