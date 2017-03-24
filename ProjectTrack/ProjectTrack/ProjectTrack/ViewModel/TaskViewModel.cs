using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjectTrack.Model;
using ProjectTrack.Services;
using Xamarin.Forms;

namespace ProjectTrack.ViewModel
{
    public class TaskViewModel
    {
        private readonly INavigationService _navigationService;
        private NozbeService nozbeService;
        private string _projectId;
        public string ProjectId
        {
            get { return _projectId; }
            set
            {
                if (_projectId == value) return;
                _projectId = value;
                OnPropertyChanged();
                ShowTasksCommand.Execute(ProjectId);
            }
        }

        public ICommand ShowTasksCommand { get; private set; }
        public NotifyTaskCompletion<List<NozbeTask>> Tasks { get; private set; }

        public TaskViewModel(INavigationService navigationService)
        {

            nozbeService = new NozbeService("xxx@gmail.com", "xxx");

            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            ShowTasksCommand = new Command<string>(ShowTasks);
        }

        void ShowTasks(string Id)
        {
            _navigationService.NavigateTo(ViewModelLocator.ProjectPage, Id ?? string.Empty);
            Tasks = new NotifyTaskCompletion<List<NozbeTask>>(GetTasks(Id));
        }

        public async Task<List<NozbeTask>> GetTasks(string Id)
        {
            var tasks = await nozbeService.Tasks(Id);
            return JsonConvert.DeserializeObject<List<NozbeTask>>(tasks);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
