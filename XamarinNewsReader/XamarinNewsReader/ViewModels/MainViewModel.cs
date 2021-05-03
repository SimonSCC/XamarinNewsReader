using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Extensions;
using XamarinNewsReader.Helpers;
using XamarinNewsReader.Interfaces;
using XamarinNewsReader.Models;
using XamarinNewsReader.News;

namespace XamarinNewsReader.ViewModels
{
    public class MainViewModel : Common.ObservableBase
    {
        private List<string> CovidModeSearchParams = new List<string> { "covid", "covid-19", "johnson & johnson", "corona"};


        public MainViewModel() //This is so that when we create a new MainViewModel it will have empty collections.
        {
            this.AlleNyheder = new ObservableCollection<News.NewsInformation>();
            this.Verden = new ObservableCollection<News.NewsInformation>();
            this.Viden = new ObservableCollection<News.NewsInformation>();
            this.Favorites = new FavoritesCollection();

            CovidModeActivated = false;

            this.CurrentUser = new UserInformation()
            {
                DisplayName = "Simon",
                BioContent = "Simon is kewl",
                ProfileImageUrl = "https://i.pravatar.cc/300",
                
            };

        }


        private bool covidmodeactivated;

        public bool CovidModeActivated
        {
            get { return this.covidmodeactivated; }
            set { this.SetProperty(ref this.covidmodeactivated, value); }
        }

        private string searchQuery;
        public string SearchQuery
        {
            get { return this.searchQuery; }
            set { this.SetProperty(ref this.searchQuery, value); }
        }

        private ObservableCollection<News.NewsInformation> _searchResults;
        public ObservableCollection<News.NewsInformation> SearchResults
        {
            get { return this._searchResults; }
            set { this.SetProperty(ref this._searchResults, value); }
        }



        private string _platformLabel;
        public string PlatformLabel
        {
            get { return this._platformLabel; }
            set { this.SetProperty(ref this._platformLabel, value); }
        }
        private string _extendedPlatformLabel;
        public string ExtendedPlatformLabel
        {
            get { return this._extendedPlatformLabel; }
            set { this.SetProperty(ref this._extendedPlatformLabel, value); }
        }

        private DeviceOrientations _currentOrientation;
        public DeviceOrientations CurrentOrientation
        {
            get { return this._currentOrientation; }
            set { this.SetProperty(ref this._currentOrientation, value); }
        }
       
        //Favorite
        private FavoritesCollection _favorites;
        public FavoritesCollection Favorites
        {
            get { return this._favorites; }
            set { this.SetProperty(ref this._favorites, value); }
        }
        //End

        //AlleNyhder
        private ObservableCollection<News.NewsInformation> _alleNyheder;

        public ObservableCollection<News.NewsInformation> AlleNyheder
        {
            get { return this._alleNyheder; }
            set { this.SetProperty(ref this._alleNyheder, value); }
        }
        //End

        //Verden
        private ObservableCollection<News.NewsInformation> _verden;

        public ObservableCollection<News.NewsInformation> Verden
        {
            get { return this._verden; }
            set { this.SetProperty(ref this._verden, value); }
        }
        //End

        //Viden
        private ObservableCollection<News.NewsInformation> _viden;

        public ObservableCollection<News.NewsInformation> Viden
        {
            get { return this._viden; }
            set { this.SetProperty(ref this._viden, value); }
        }
        //End

        //IsBusy
        private bool _isBusy;

        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }
        //End

        //UserInformation
        private UserInformation _currentUser;

        public UserInformation CurrentUser
        {
            get { return _currentUser; }
            set { this.SetProperty(ref this._currentUser, value); }
        }
        //End



        public async void RefreshNewsAsync()
        {
            this.IsBusy = true;

            await RefreshTrendingNews();
            await RefreshVidenNyheder();
            await RefreshUdlandNyheder();

            this.IsBusy = false;

        }

        public async Task RefreshUdlandNyheder()
        {
            this.Verden.Clear();
            List<NewsInformation> news = null;

            if (this.CovidModeActivated)
            {
                news = await RssFeedHelper.SearchAsyncOnSpecificCategoryMultipleQueries(CovidModeSearchParams, NewsCategoryType.Udland);

            }
            else
            {
                news = await RssFeedHelper.GetNewsByCategory(NewsCategoryType.Udland);

            }


            foreach (NewsInformation newsInformation in news)
            {
                this.Verden.Add(newsInformation);
            }

        }

        public async Task RefreshVidenNyheder()
        {
            this.Viden.Clear();
            List<NewsInformation> news = null;

            if (CovidModeActivated)
            {
                news = await RssFeedHelper.SearchAsyncOnSpecificCategoryMultipleQueries(CovidModeSearchParams, NewsCategoryType.Viden);
            }
            else
            {
                news = await RssFeedHelper.GetNewsByCategory(NewsCategoryType.Viden);
            }

      

            foreach (NewsInformation newsInformation in news)
            {
                this.Viden.Add(newsInformation);
            }
        }

        public async Task RefreshTrendingNews()
        {
            this.AlleNyheder.Clear();
            List<NewsInformation> news = null;


            if (CovidModeActivated)
            {
                news = await RssFeedHelper.SearchAsyncOnSpecificCategoryMultipleQueries(CovidModeSearchParams, NewsCategoryType.AlleNyheder);
            }
            else
            {
                news = await RssFeedHelper.GetNewsByCategory(NewsCategoryType.AlleNyheder);
            }

            foreach (NewsInformation newsInformation in news)
            {
                this.AlleNyheder.Add(newsInformation);
            }

        }

        public async Task RefreshFavoritesAsync()
        {
            this.IsBusy = true;

            this.Favorites.Clear();

            var favorites = await App.Database.GetItemsAsync();

            foreach (var favorite in favorites)
            {
                //YOu could expand here. Technology is hardcoded.
                this.Favorites.Add(favorite.AsFavorite("Technology"));
            }

            this.IsBusy = false;
        }

        public async Task RefreshSearchResults()
        {
            this.IsBusy = true;

            if (SearchResults != null)
            {
                this.SearchResults.Clear();
            }

            string query = this.SearchQuery;

            var news = await RssFeedHelper.SearchAsync(query);

         
            if (this.SearchResults == null)
            {
               this.SearchResults = new ObservableCollection<NewsInformation>();
            }
            foreach (var item in news)
            {
                this.SearchResults.Add(item);
            }

            this.IsBusy = false;
        }
    }
}
