using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinNewsReader.Models
{
    public class Filter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NameOfFilter { get; set; }
        public bool IsFilterActive { get; set; }
        public PositiveOrNegative PositiveOrNegative { get; set; }


        private List<string> filteredWords;

        [Ignore]

        public List<string> FilteredWords
        {
            get
            {
                if (filteredWords == null || filteredWords.Count == 0)
                {
                    filteredWords = FilteredDBStringToList();
                }
                return filteredWords;
            }
            set { filteredWords = value; }
        }

        private List<string> FilteredDBStringToList()
        {
            return FilteredWordsDB.Split(',').ToList();
        }

        public string FilteredWordsDB { get; set; }


        public string Description { get; set; }

        public Filter()
        {

        }
        public Filter(string name, string description, PositiveOrNegative positiveOrNegative, List<string> filteredWords)
        {
            IsFilterActive = false;
            NameOfFilter = name;
            PositiveOrNegative = positiveOrNegative;
            FilteredWords = filteredWords;
            Description = description;

            FilteredWordsDB = TransformListToString();

        }

        private string TransformListToString()
        {
            string result = string.Empty;
            foreach (string item in FilteredWords)
            {
                result += item.Trim() + ",";
            }
            result = result.Remove(result.Length - 1, 1);
            return result;
        }

        public override bool Equals(object obj)
        {
            if (((Filter)obj).NameOfFilter == this.NameOfFilter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return NameOfFilter;
        }

    }




    public enum PositiveOrNegative
    {
        Positive,
        Negative
    }
}
