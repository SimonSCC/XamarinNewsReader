using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNewsReader
{
    public partial class App : Application
    {
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
