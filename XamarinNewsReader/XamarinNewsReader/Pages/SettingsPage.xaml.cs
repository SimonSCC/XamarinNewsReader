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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            InitializeSettings();

            base.OnAppearing();
        }

        private void InitializeSettings()
        {

            this.BindingContext = App.ViewModel.CurrentUser;

            //displayNameEntry.Text = "Simon";
            //bioEditor.Text = "Simon is kewl";
            articleCountSlider.Value = 10;
            categoryPicker.SelectedIndex = 1;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }


}