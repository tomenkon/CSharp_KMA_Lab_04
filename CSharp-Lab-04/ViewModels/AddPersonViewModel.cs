using CSharp_Lab_04.Models;
using CSharp_Lab_04.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp_Lab_04.ViewModels
{
    class AddPersonViewModel : INotifyPropertyChanged, INavigatable
    {
        #region Fields

        private bool _isEnabled = true;
        private RelayCommand<object> _proceedCommand;
        private Action _gotoDataView;

        #endregion

        public AddPersonViewModel(Action gotoDataView)
        {
            _gotoDataView = gotoDataView;
        }


        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Today;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedCommand =>
            _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), BoxesFilled);

        #endregion

        internal async void Proceed()
        {
            IsEnabled = false;
            Person person;
            try
            {
                person = new Person(FirstName, LastName, Email, BirthDate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                IsEnabled = true;
                return;
            }
            if (person.IsIncomplete())
            {
                IsEnabled = true;
                return;
            }

            UserDataBase.users.Add(person);
            MessageBox.Show("Person has been successfully added");
            _gotoDataView.Invoke();
        }

        private bool BoxesFilled(object obj)
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) &&
                   !String.IsNullOrWhiteSpace(Email);
        }

        public NavigationViewTypes ViewType => NavigationViewTypes.AddPersonViewModel;

        #region PropChangedImplementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
