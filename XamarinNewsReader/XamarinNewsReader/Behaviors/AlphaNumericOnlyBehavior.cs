using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinNewsReader
{
    public class AlphaNumericOnlyBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(SearchBar entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(args.NewTextValue, @"^[a-zA-Z0-9\s]+$");
            ((SearchBar)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
