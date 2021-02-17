using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNewsReader.Helpers;
using XamarinNewsReader.News;

namespace XamarinNewsReader.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendingPage : ContentPage
    {

        public TrendingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.ViewModel;

            base.OnAppearing();
        }

        //We no longer does the below, instead we want to bind to a observable collection.
        //private async void LoadNewsAsync()
        //{
        //   //newsListView.IsRefreshing = true; //Property on the newsListView, can be accesed in xaml

        //    List<NewsInformation> news = await RssFeedHelper.GetNewsByCategory(NewsCategoryType.AlleNyheder);


        //    this.BindingContext = news;


        //    //newsListView.IsRefreshing = false;
        //}

        private void newsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //App.Current.Resources["ListTextColor"] = Color.Blue; //Changes text color
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new Common.Commands.NavigateToDetailCommand().Execute(e.Item as News.NewsInformation);
        }
    }
}