using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjectTrack.Model;
using ProjectTrack.Services;
using Xamarin.Forms;

namespace ProjectTrack.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _parameterText;
        private bool _controlTimer;
        private string _timeString;

        public string TimeString
        {

            get
            {
                return _timeString;
            }

            set
            {
                _timeString = value;
                OnPropertyChanged();
            }
        }
        public string Parameter
        {

            get
            {
                return _parameterText;
            }

            set
            {
                _parameterText = value;
                OnPropertyChanged();
            }
        }
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            Parameter = "Start";
            if (navigationService == null)
                throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

        }

        public ICommand StopWatchCommand
        {
            get
            {
                return new Command(() =>
                {
                    StopWatch stopWatch;
                    if (Parameter.Equals("Start"))
                    {
                        stopWatch = new StopWatch();
                        _controlTimer = true;
                        stopWatch.Start = DateTime.Now;
                        Parameter = "Stop";
                        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                        {
                            stopWatch.End = DateTime.Now;
                            stopWatch.Time = stopWatch.End - stopWatch.Start;
                            TimeString = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Time);
                            if (!_controlTimer) return false;
                            return true;
                        });
                    }
                    else
                    {
                        _controlTimer = false;
                        Parameter = "Start";
                    }
                });
            }
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
