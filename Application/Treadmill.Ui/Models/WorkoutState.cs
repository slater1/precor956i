﻿using System.ComponentModel;
using Treadmill.Domain.Services;
using Xamarin.Forms;

namespace Treadmill.Ui.Models
{
    public class WorkoutState : BindableObject
    {
        private bool _paused;
        private bool _workoutActive;

        public bool Paused
        {
            get => _paused;
            set
            {
                if (_paused == value)
                    return;

                _paused = value;
                OnPropertyChanged();
            }
        }

        public bool Active
        {
            get => _workoutActive;
            set
            {
                if (_workoutActive == value)
                    return;

                _workoutActive = value;
                OnPropertyChanged();
            }
        }

        public WorkoutState(IRemoteTreadmillService treadmill)
        {
            treadmill.PropertyChanged += HandlePropertyChanged;
        }

        public void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var treadmill = sender as IRemoteTreadmillService;

            switch (e.PropertyName)
            {
                case nameof(IRemoteTreadmillService.Active):
                    Active = treadmill.Active;
                    break;
                case nameof(IRemoteTreadmillService.Paused):
                    Paused = treadmill.Paused;
                    break;
            }
        }
    }
}
