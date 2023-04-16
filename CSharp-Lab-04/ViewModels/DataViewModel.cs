using CSharp_Lab_04.Tools;
using CSharp_Lab_04.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CSharp_Lab_04.ViewModels
{
    class DataViewModel : INotifyPropertyChanged, INavigatable
    {
        #region Fields
        private ObservableCollection<PersonViewModel> _people;
        private Action _goToEditView;
        private Action _goToAddView;
        private RelayCommand<object> _addPersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private RelayCommand<object> _detelePersonCommand;
        #endregion

        #region Properties
        public DataViewModel(Action goToAddView, Action goToEditView)
        {
            People = new ObservableCollection<PersonViewModel>();
            foreach (var person in UserDataBase.users)
                _people.Add(new PersonViewModel(person));

            _goToAddView = goToAddView;
            _goToEditView = goToEditView;
        }

        public ObservableCollection<PersonViewModel> People { 
            get => _people;
            set 
            {
                _people = value;
                NotifyPropertyChanged();
            }
        }

        public static PersonViewModel? SelectedPerson { get; set; }


        #endregion


        #region Commands

        public RelayCommand<object> AddPersonCommand =>
            _addPersonCommand ??= new RelayCommand<object>(_ => AddPerson());

        public RelayCommand<object> EditPersonCommand =>
            _editPersonCommand ??= new RelayCommand<object>(_ => EditPerson());

        public RelayCommand<object> DeletePersonCommand =>
            _detelePersonCommand ??= new RelayCommand<object>(_ => DeletePerson());

        private void AddPerson()
        {
            _goToAddView?.Invoke();
        }

        private void EditPerson()
        {
            if (SelectedPerson == null)
            {
                MessageBox.Show("Select a person to edit!");
                return;
            }
            _goToEditView?.Invoke();
        }

        private void DeletePerson()
        {
            if (SelectedPerson == null)
            {
                MessageBox.Show("You should select a person to delete");
                return;
            }

            UserDataBase.users.Remove(SelectedPerson.Person);
            People = new ObservableCollection<PersonViewModel>();
            foreach (var person in UserDataBase.users)
                _people.Add(new PersonViewModel(person));
        }

        #endregion

        #region Interface Implementation
        public NavigationViewTypes ViewType => NavigationViewTypes.DataViewModel;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
