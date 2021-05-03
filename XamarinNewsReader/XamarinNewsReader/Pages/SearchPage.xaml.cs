using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNewsReader.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            InitializeSearch();

            base.OnAppearing();

        }
        private async void InitializeSearch()
        {
            this.BindingContext = App.ViewModel;

            //if (string.IsNullOrEmpty(App.ViewModel.SearchQuery)) App.ViewModel.SearchQuery = "";

            //await App.ViewModel.RefreshSearchResults();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new Common.Commands.NavigateToDetailCommand().Execute(e.Item as News.NewsInformation);
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            new Common.Commands.RefreshNewsCommand().Execute("Search");
        }
    }
}