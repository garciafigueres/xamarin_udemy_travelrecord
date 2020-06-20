using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin_udemy_travelrecordapp.ViewModel.Commands
{

    public class RegisterNavigationCommand : ICommand
    {
        private MainVM viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterNavigationCommand(MainVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }

    /*
    public class RegisterNavigationCommand : ICommand
    {
        private MainVM viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterNavigationCommand(MainVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
    */
}
