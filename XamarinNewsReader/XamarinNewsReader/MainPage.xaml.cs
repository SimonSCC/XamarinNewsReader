using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNewsReader.Helpers;

namespace XamarinNewsReader
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {


            //this.Content = new StackLayout() //If you were to add ui programmaticly.
            //{

            //}

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged; //Example of plugin usage.
            //This allows us to listen to network connectivity changes.

            if (App.ViewModel == null) // "This is not ultimately what we want to do
            {
                App.ViewModel = new ViewModels.MainViewModel();
            }

            App.MainNavigation = Navigation;

            //var label = Helpers.GeneralHelper.Getlabel();

            App.ViewModel.RefreshNewsAsync();

            var appearedFolders = StorageHelper.GetSpecialFolders();
            var databasePath = StorageHelper.GetLocalFolderPath();

            base.OnAppearing();
        }

   
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            //We can prompt the user that they have no connection if Isconnected is false
            //New Page to tell user there's no internet
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SettingsPage(), true);
        }
    }
}
