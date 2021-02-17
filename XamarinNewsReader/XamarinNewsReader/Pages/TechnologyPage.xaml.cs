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
    public partial class TechnologyPage : ContentPage
    {
        public TechnologyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.ViewModel;

            base.OnAppearing();
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new Common.Commands.NavigateToDetailCommand().Execute(e.Item as News.NewsInformation);
        }

        //private async void LoadNewsAsync()  
        //{
        //    //newsListView.IsRefreshing = true;

        //    var news = await Helpers.RssFeedHelper.GetNewsByCategory(News.NewsCategoryType.Viden);

        //    this.BindingContext = news;

        //    //newsListView.IsRefreshing = false;
        //}
    }
}