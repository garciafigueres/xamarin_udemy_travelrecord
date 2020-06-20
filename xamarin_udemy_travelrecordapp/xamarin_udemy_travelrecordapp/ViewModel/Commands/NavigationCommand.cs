using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace xamarin_udemy_travelrecordapp.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {

        public HomeVM HomeViewModel { get; set; }

        public NavigationCommand(HomeVM homeVM)
        {
            HomeViewModel = homeVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }

    /*
    public class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public HomeVM HomeViewModel;

        public NavigationCommand(HomeVM homeVM)
        {
            HomeViewModel = homeVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
    */
}
