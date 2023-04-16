using CSharp_Lab_04.Models;
using CSharp_Lab_04.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp_Lab_04.ViewModels
{
    class EditPersonViewModel : INotifyPropertyChanged, INavigatable
    {
        private RelayCommand<object> _editPersonCommand;
        private bool _isEnabled = true;
        private Action _gotoDataView;

        public EditPersonViewModel(Action gotoDataView)
        {
            _gotoDataView = gotoDataView;
        }

        #region Properties

        public string FirstName { get; set; } = DataViewModel.SelectedPerson.FirstName;
        public string LastName { get; set; } = DataViewModel.SelectedPerson.LastName;
        public string Email { get; set; } = DataViewModel.SelectedPerson.Email;
        public DateTime BirthDate { get; set; } = DataViewModel.SelectedPerson.Person.BirthDate;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<object> UpdateCommand => _editPersonCommand ??= new RelayCommand<object>(_ => UpdatePerson());

        #endregion

        private async void UpdatePerson()
        {
            IsEnabled = false;
            try
            {
                await Task.Run(async () =>
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
                    int currentIndex = UserDataBase.users.IndexOf(DataViewModel.SelectedPerson.Person);
                    UserDataBase.users.Remove(DataViewModel.SelectedPerson.Person);
                    UserDataBase.users.Insert(currentIndex, person);
                    MessageBox.Show("Person successfully edited!");
                    _gotoDataView.Invoke();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        public NavigationViewTypes ViewType => NavigationViewTypes.EditPersonViewModel;

        #region PropChangedImplementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
