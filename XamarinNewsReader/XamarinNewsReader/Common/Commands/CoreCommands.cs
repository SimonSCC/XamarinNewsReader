using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinNewsReader.Common.Commands
{
    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingsPage(), true);
        }

    }
}
