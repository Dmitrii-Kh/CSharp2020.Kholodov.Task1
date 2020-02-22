using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.CSharpProgramming2020.Task1.Annotations;

namespace KMA.CSharpProgramming2020.Task1
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user = new User();
        private RelayCommand<object> _calcAge;
        
        public DateTime DateOfBirth
        {
            set
            {
                _user.DateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get { return _user.Age; }
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public String EUSign
        {
            get { return _user.EUSign; }
            set
            {
                _user.EUSign = value;
                OnPropertyChanged();
            }
        }
        public String CHSign
        {
            get { return _user.CHSign; }
            set
            {
                _user.CHSign = value;
                OnPropertyChanged();
            }
        }

        private async void CalcAgeImpl()
        {
            await Task.Run(() => Thread.Sleep(100));

            if (_user.DateOfBirth.Year < (DateTime.Today.Year - 135))
            {
                MessageBox.Show("Your age is > 135");
                return;
            }
            else if (_user.DateOfBirth > DateTime.Today)
            {
                MessageBox.Show("You were born in future!");
                return;
            }

            _user.Age = (DateTime.Today - _user.DateOfBirth).Days / 365;
            _user.EUSign = _user.EUSignCalc();
            _user.CHSign = _user.CHSignCalc();

            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(EUSign));
            OnPropertyChanged(nameof(CHSign));

            if (_user.DateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
            {
                MessageBox.Show("Congratulations and best wishes on your Birthday!");
            }
        }

        public RelayCommand<object> CalcAgeCommand
        {
            get
            {
                return _calcAge ?? (_calcAge = new RelayCommand<object>(o => 
                    CalcAgeImpl(), o => CanExecuteCommand()
                ));
            }
        }
        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_user.DateOfBirth.ToString());
        }


        #region INotifyImpl
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
