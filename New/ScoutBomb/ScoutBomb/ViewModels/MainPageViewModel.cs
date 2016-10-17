using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScoutBomb.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private TimeSpan _timeLeft;

        public TimeSpan TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                _timeLeft = value;
                OnPropertyChanged("TimeLeft");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
