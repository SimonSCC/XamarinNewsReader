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
    public partial class AddFilterPage : ContentPage
    {
        public AddFilterPage()
        {
            InitializeComponent();
            this.BindingContext = App.ViewModel;
        }

        private void AddFilter_Click(object sender, EventArgs e)
        {
            AddToDb(ConstructFilter());
        }



        private Filter ConstructFilter()
        {
            return new Filter(GetNameEntry(), GetDescription(), GetTypeOfFilter(), GetFilteredWords());
        }

        private PositiveOrNegative GetTypeOfFilter()
        {
            if (positiveCheck.IsChecked)
            {
                return PositiveOrNegative.Positive;
            }
            else
            {
                return PositiveOrNegative.Negative;
            }
        }

        private string GetDescription()
        {
            return entryDesc.Text;
        }

        private string GetNameEntry()
        {
            return NameEntry.Text;
        }

        private async void AddToDb(Filter filter)
        {
            App.ViewModel._filterHelper.AddCustomFilterToDB(filter);
            await App.ViewModel.RefreshCustomFilters();
            await Navigation.PopAsync();
        }

        private List<string> GetFilteredWords()
        {
            string words = wordList.Text;
            return words.Split(',').ToList();
        }

        
    }
}