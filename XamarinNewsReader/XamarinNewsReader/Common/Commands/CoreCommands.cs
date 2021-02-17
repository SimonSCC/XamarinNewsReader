using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinNewsReader.News;

namespace XamarinNewsReader.Common.Commands
{

    public class NavigateToDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            navigateToDetailAsync(parameter as News.NewsInformation);
        }

        private async void navigateToDetailAsync(NewsInformation article)
        {
            await App.MainNavigation.PushAsync(new Pages.ItemDetailPage(article), true);
        }
    }

    public class RefreshNewsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool _isBusy = false;

        public bool CanExecute(object parameter)
        {
            return !_isBusy; //Can only execute if not busy 
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            RefreshNewsAsync((string)parameter);
        }

        private async void RefreshNewsAsync(string newsType)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = true;

            switch (newsType)
            {
                case "World":
                    await App.ViewModel.RefreshUdlandNyheder();
                    break;
                case "Trending":
                    await App.ViewModel.RefreshTrendingNews();
                    break;
                case "Technology":
                    await App.ViewModel.RefreshVidenNyheder();
                    break;
            }

            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = false;
        }
    }

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
