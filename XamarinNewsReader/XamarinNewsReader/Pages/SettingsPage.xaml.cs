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

            this.BindingContext = App.ViewModel;

            //displayNameEntry.Text = "Simon";
            //bioEditor.Text = "Simon is kewl";
            articleCountSlider.Value = 10;
            categoryPicker.SelectedIndex = 1;
            var label = Helpers.GeneralHelper.Getlabel();
            var extendedLabel = Helpers.GeneralHelper.Getlabel("Running Paperboy on", true);

            var orientation = Helpers.GeneralHelper.GetOrientation();

            App.ViewModel.PlatformLabel = label;
            App.ViewModel.ExtendedPlatformLabel = extendedLabel;

            App.ViewModel.CurrentOrientation = orientation;
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {

        }
    }


}