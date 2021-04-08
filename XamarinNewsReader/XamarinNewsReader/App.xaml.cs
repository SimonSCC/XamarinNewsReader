using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNewsReader.Data;
using XamarinNewsReader.Interfaces;

namespace XamarinNewsReader
{
    public partial class App : Application
    {
        static FavoritesDatabase database;

        public static FavoritesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FavoritesDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Favorites.db3")); //Favorites.db3 can be named anything
                }
                return database;
            }
        }

        public static ViewModels.MainViewModel ViewModel { get; set; }

        public static INavigation MainNavigation { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
