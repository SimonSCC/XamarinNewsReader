using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNewsReader.News.Trending // Changed form .Models to .News.Trending, why i don't know, Code deosn't work with the .models because of multiple classes
    //Called value
{
    public class TrendingNewsResult
    {
        public string _type { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public Image image { get; set; }
        public string webSearchUrl { get; set; }
        public bool isBreakingNews { get; set; }
        public Query query { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public Provider[] provider { get; set; }
    }

    public class Provider
    {
        public string _type { get; set; }
        public string name { get; set; }
    }

    public class Query
    {
        public string text { get; set; }
    }
}
