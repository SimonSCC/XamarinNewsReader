using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinNewsReader.Extensions;
using XamarinNewsReader.Models;
using XamarinNewsReader.News;

namespace XamarinNewsReader.Common.Commands
{
    public class ToggleFavoriteCommand : ICommand
    {
        private bool _isBusy = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
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
            ToggleFavoriteAsync(parameter as News.NewsInformation);
        }

        private async void ToggleFavoriteAsync(News.NewsInformation article)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = true;

            await App.ViewModel.Favorites.AddAsync(await article.AsFavorite("Technology"));

            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = false;

        }
    }

    public class SpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Helpers.GeneralHelper.Speak((string)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }


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
            if (parameter.GetType() == typeof(NewsInformation))
            {
                navigateToDetailAsync(parameter as NewsInformation);
            }
            else if (parameter.GetType() == typeof(FavoriteInformation))
            {
                FavoriteInformation paramterAsFavoriteInfo = parameter as FavoriteInformation;
                NewsInformation convertedInfo = new NewsInformation()
                {
                    CreatedDate = paramterAsFavoriteInfo.ArticleDate,
                    Description = paramterAsFavoriteInfo.Description,
                    ImageUrl = paramterAsFavoriteInfo.ImageUrl,
                    Title = paramterAsFavoriteInfo.Title,
                };

                navigateToDetailAsync(convertedInfo);

            }

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
            //if (string.IsNullOrEmpty(App.ViewModel.SearchQuery)) return;

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
                case "Search":
                    await App.ViewModel.RefreshSearchResults();
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

    public class NavigateToFiltersCommand : ICommand
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
            await App.MainNavigation.PushAsync(new Pages.FilterPage(), true);
        }
    }



    public class NavigateToAddFilterPageCommand : ICommand
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
            await App.MainNavigation.PushAsync(new Pages.AddFilterPage(), true);
        }
    }
}
