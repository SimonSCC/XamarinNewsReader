using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinNewsReader.News;
using XamarinNewsReader.News.Trending;

namespace XamarinNewsReader.Helpers
{
    //public static class NewsHelper
    //{
    //    public static async Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType category)
    //    {
    //        List<NewsInformation> results = new List<NewsInformation>();

    //        string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/?Category={category}";

    //        var client = new HttpClient();
    //        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

    //        var uri = new Uri(searchUrl);
    //        var result = await client.GetStringAsync(uri);
    //        var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

    //        results = (from item in newsResult.value
    //                   select new NewsInformation()
    //                   {
    //                       Title = item.name,
    //                       Description = item.description,
    //                       CreatedDate = item.datePublished,
    //                       ImageUrl = item.image?.thumbnail?.contentUrl,

    //                   }).ToList();

    //        return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
    //    }

    //    public static async Task<List<NewsInformation>> GetAsync(string searchQuery)
    //    {
    //        List<NewsInformation> results = new List<NewsInformation>();

    //        string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={searchQuery}&count=10&offset=0&mkt=en-us&safeSearch=Moderate";

    //        var client = new HttpClient();
    //        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

    //        var uri = new Uri(searchUrl);
    //        var result = await client.GetStringAsync(uri);
    //        var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

    //        results = (from item in newsResult.value
    //                   select new NewsInformation()
    //                   {
    //                       Title = item.name,
    //                       Description = item.description,
    //                       CreatedDate = item.datePublished,
    //                       ImageUrl = item.image?.thumbnail?.contentUrl,

    //                   }).ToList();

    //        return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
    //    }

    //    public async static Task<List<NewsInformation>> GetTrendingAsync()
    //    {
    //        List<NewsInformation> results = new List<NewsInformation>();

    //        string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/trendingtopics";

    //        var client = new HttpClient();
    //        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

    //        var uri = new Uri(searchUrl);
    //        var result = await client.GetStringAsync(uri);
    //        var newsResult = JsonConvert.DeserializeObject<TrendingNewsResult>(result);

    //        results = (from item in newsResult.value
    //                   select new NewsInformation()
    //                   {
    //                       Title = item.name,
    //                       Description = item.query.text,
    //                       CreatedDate = DateTime.Now,
    //                       ImageUrl = item.image.url,

    //                   }).ToList();

    //        return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();

    //    }

    //    public async static void Test()
    //    {
    //        var key = "d5fc50d9685949d9b6e8abf981f7efda";
    //        var searchTerm = "Quantum Computing";
    //        var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(key));

    //        var newsResults = client.News.SearchAsync(query: searchTerm, market: "en-us", count: 10).Result;


    //        if (newsResults.Value.Count > 0)
    //        {
    //            var firstNewsResult = newsResults.Value[0];

    //            Console.WriteLine($"TotalEstimatedMatches value: {newsResults.TotalEstimatedMatches}");
    //            Console.WriteLine($"News result count: {newsResults.Value.Count}");
    //            Console.WriteLine($"First news name: {firstNewsResult.Name}");
    //            Console.WriteLine($"First news url: {firstNewsResult.Url}");
    //            Console.WriteLine($"First news description: {firstNewsResult.Description}");
    //            Console.WriteLine($"First news published time: {firstNewsResult.DatePublished}");
    //            Console.WriteLine($"First news provider: {firstNewsResult.Provider[0].Name}");
    //        }

    //        else
    //        {
    //            Console.WriteLine("Couldn't find news results!");
    //        }
    //        Console.WriteLine("Enter any key to exit...");
    //        Console.ReadKey();
    //    }
    //}
}
