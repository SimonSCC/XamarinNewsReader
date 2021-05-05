using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNewsReader.Models;

namespace XamarinNewsReader.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            LoadCustomFilters();

            base.OnAppearing();
        }

        private async void LoadCustomFilters()
        {
            this.BindingContext = App.ViewModel;
            await App.ViewModel.RefreshCustomFilters();


        }

        private void Filter_CheckedChanges(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkbox = ((CheckBox)sender);
            Filter filter = (Filter)checkbox.BindingContext;
            if (filter.IsFilterActive)
            {
                if (filter.PositiveOrNegative == PositiveOrNegative.Positive)
                {
                    App.ViewModel._filterHelper.AddPositiveFilter(filter);
                }
                else
                {
                    App.ViewModel._filterHelper.AddNegativeFilter(filter);
                }
            }
            else
            {
                if (filter.PositiveOrNegative == PositiveOrNegative.Positive)
                {
                    App.ViewModel._filterHelper.RemovePositiveFilter(filter);
                }
                else
                {
                    App.ViewModel._filterHelper.RemoveNegativeFilter(filter);
                }
            }
        }

        private void Delete_Filter(object sender, EventArgs e)
        {
            Filter filter = (Filter)((ImageButton)sender).BindingContext;

            if (filter.IsFilterActive)
            {
                if (filter.PositiveOrNegative == PositiveOrNegative.Positive)
                {
                    App.ViewModel._filterHelper.RemovePositiveFilter(filter);
                }
                else
                {
                    App.ViewModel._filterHelper.RemoveNegativeFilter(filter);
                }
            }

            App.ViewModel._filterHelper.RemoveCustomFilterInDB(filter);

        }

        private void customFilterListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.Item == null) return;

            if (sender is ListView lv) lv.SelectedItem = null;
        }



        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Filter filter = new Filter("Test", "Testing", PositiveOrNegative.Positive, new List<string>() { "mette" });
        //    App.ViewModel._filterHelper.AddCustomFilterToDB(filter);

        //    var test = App.ViewModel._filterHelper.GetFiltersFromDB();
        //}
    }
}