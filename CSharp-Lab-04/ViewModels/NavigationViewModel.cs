using CSharp_Lab_04.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_04.ViewModels
{
    internal enum NavigationViewTypes
    {
        DataViewModel,
        AddPersonViewModel,
        EditPersonViewModel
    }

    internal class NavigationViewModel : INotifyPropertyChanged
    {
        private INavigatable _currentViewModel;

        public NavigationViewModel()
        {
            Navigate(NavigationViewTypes.DataViewModel);
        }

        public INavigatable CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        #region Navigation Methods

        internal void Navigate(NavigationViewTypes type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType == type)
                return;
            INavigatable viewModel = GetVM(type);
            if (viewModel == null)
                return;
            CurrentViewModel = viewModel;
        }

        private INavigatable GetVM(NavigationViewTypes type)
        {
            INavigatable viewModel;
            switch (type)
            {
                case NavigationViewTypes.DataViewModel:
                    viewModel = new DataViewModel(() => Navigate(NavigationViewTypes.AddPersonViewModel),
                        () => Navigate(NavigationViewTypes.EditPersonViewModel));
                    break;
                case NavigationViewTypes.AddPersonViewModel:
                    viewModel = new AddPersonViewModel(() => Navigate(NavigationViewTypes.DataViewModel));
                    break;
                case NavigationViewTypes.EditPersonViewModel:
                    viewModel = new EditPersonViewModel(() => Navigate(NavigationViewTypes.DataViewModel));
                    break;
                default:
                    return null;
            }
            return viewModel;
        }

        #endregion

        #region PropChangedImplementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
