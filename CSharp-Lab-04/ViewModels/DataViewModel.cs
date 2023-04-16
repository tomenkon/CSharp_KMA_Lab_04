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
        private string _sorterName;
        private string _filterName;
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


        public string SortingBy
        {
            get => _sorterName;
            set
            {
                _sorterName = value;
                PerformSorting();
            }
        }

        public string FilterBy
        {
            get => _filterName;
            set
            {
                _filterName = value;
            }
        }

        public string FilterValue { get; set; }

        #endregion

        #region Filtering and Sorting

        public static List<string> SortingFields { get; } = new List<string>
        {
            "First name", "Last name", "Email", "Birth date", "Is adult?", "Western zodiac", "Chinese zodiac", "Is B-day?",
            "None"
        };

        private void PerformSorting()
        {
            switch (_sorterName)
            {
                case "First name":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.FirstName));
                    break;
                case "Last name":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.LastName));
                    break;
                case "Email":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.Email));
                    break;
                case "Birth date":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.Person.BirthDate));
                    break;
                case "Is B-day?":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.IsBirthday));
                    break;
                case "Is adult?":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.IsAdult));
                    break;
                case "Western zodiac":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.WesternSign));
                    break;
                case "Chinese zodiac":
                    People = new ObservableCollection<PersonViewModel>(_people.OrderBy(i => i.ChineseSign));
                    break;
                default:
                    People = new ObservableCollection<PersonViewModel>();
                    foreach (var person in UserDataBase.users)
                        _people.Add(new PersonViewModel(person));
                    break;
            }
        }

        private void PerformFiltering()
        {
            People = new ObservableCollection<PersonViewModel>();
            foreach (var person in UserDataBase.users)
                _people.Add(new PersonViewModel(person));

            switch (_filterName)
            {
                case "First name":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.FirstName.Equals(FilterValue)
                                                                       select person);
                    break;
                case "Last name":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.LastName.Equals(FilterValue)
                                                                       select person);
                    break;
                case "Email":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.Email.Equals(FilterValue)
                                                                       select person);
                    break;
                case "Birth date":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.BirthDate.Equals(FilterValue)
                                                                       select person);
                    break;
                case "Is B-day?":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.IsBirthday
                                                                       select person);
                    break;
                case "Is adult?":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.IsAdult
                                                                       select person);
                    break;
                case "Western zodiac":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.WesternSign.Equals(FilterValue)
                                                                       select person);
                    break;
                case "Chinese zodiac":
                    People = new ObservableCollection<PersonViewModel>(from person in _people
                                                                       where person.ChineseSign.Equals(FilterValue)
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
        
        public RelayCommand<object> ApplyFilterCommand =>
            _applyFilters ??= new RelayCommand<object>(_ => PerformFiltering());



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
            MessageBox.Show("Person successfully deleted!");
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
