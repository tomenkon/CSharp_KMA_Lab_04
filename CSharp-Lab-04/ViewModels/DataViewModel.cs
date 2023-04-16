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

        private RelayCommand<object> _applyFilters;
        private RelayCommand<object> _cancelFilters;
        private string _sorterName;
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

        #region Filtering and Sorting


        public static List<string> SortingFields { get; } = new List<string>
        {
            "First name", "Last name", "Email", "Date of birth", "IsBirthday", "IsAdult", "Sun sign", "Chinese sign",
            "No sorting"
        };

        public string SortingBy
        {
            get => _sorterName;
            set
            {
                _sorterName = value;
                PerformSorting();
            }
        }


        private void PerformSorting()
        {
            switch (_sorterName)
            {
                case "First Name":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.Person.FirstName
                                                                       select person);
                    break;
                case "Last name":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.LastName
                                                                       select person);
                    break;
                case "Email":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.Email
                                                                       select person);
                    break;
                case "Date of birth":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.Person.BirthDate
                                                                       select person);
                    break;
                case "IsBirthday":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.IsBirthday
                                                                       select person);
                    break;
                case "IsAdult":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.IsAdult
                                                                       select person);
                    break;
                case "Sun sign":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.WesternSign
                                                                       select person);
                    break;
                case "Chinese sign":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       orderby person.ChineseSign
                                                                       select person);
                    break;
                default:
                    People = new ObservableCollection<PersonViewModel>();
                    foreach (var person in UserDataBase.users)
                        _people.Add(new PersonViewModel(person));
                    break;
            }
        }

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
            People.Remove(SelectedPerson);
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
