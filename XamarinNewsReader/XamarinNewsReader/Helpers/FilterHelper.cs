using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Data;
using XamarinNewsReader.Models;

namespace XamarinNewsReader.Helpers
{
    public class FilterHelper
    {
        public bool IsPositiveFiltersActive
        {
            get
            {
                if (this.AllActivePositiveFilteredWords.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public bool IsNegativeFiltersActive
        {
            get
            {
                if (this.AllActiveNegativeFilteredWords.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public ObservableCollection<Filter> CustomFilters { get; set; }
        public List<Filter> AllActivePositiveFilteredWords { get; set; } //Only show news that contain these words
        public List<Filter> AllActiveNegativeFilteredWords { get; set; }


        

    
        public FilterHelper()
        {
            AllActivePositiveFilteredWords = new List<Filter>();
            AllActiveNegativeFilteredWords = new List<Filter>();
            CustomFilters = new ObservableCollection<Filter>();
        }

     

        private bool DoesFilterExistInList(Filter filter, List<Filter> list)
        {
            if (list.Contains(filter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPositiveFilter(Filter filter)
        {
            if (DoesFilterExistInList(filter, AllActivePositiveFilteredWords))
            {
                return;
            }

            AllActivePositiveFilteredWords.Add(filter);
        }
        public void AddNegativeFilter(Filter filter)
        {
            if (DoesFilterExistInList(filter, AllActiveNegativeFilteredWords))
            {
                return;
            }

            AllActiveNegativeFilteredWords.Add(filter);
        }

        public void RemoveNegativeFilter(Filter filter)
        {
            AllActiveNegativeFilteredWords.Remove(filter);
        }

        public void RemovePositiveFilter(Filter filter)
        {
            AllActivePositiveFilteredWords.Remove(filter);
        }



        //HandleDB Stuff


        public async Task<ObservableCollection<Filter>> GetFiltersFromDB()
        {
            List<Filter> filters = await App.Database.GetAllFilters();
            return new ObservableCollection<Filter>(filters);
        }


        public void AddCustomFilterToDB(Filter filter)
        {
            App.Database.SaveFilterAsync(filter);
        }


        public async void RemoveCustomFilterInDB(Filter filter)
        {
            await App.Database.DeleteFilterAsync(filter);
            await App.ViewModel.RefreshCustomFilters();
        }

    }
}
