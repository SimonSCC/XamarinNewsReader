using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using XamarinNewsReader.News;
using System.Xml;
using System.Xml.Xsl;
using System.Threading.Tasks;
using XamarinNewsReader.Models;

namespace XamarinNewsReader.Helpers
{
    public static class RssFeedHelper
    {
        public async static Task<List<NewsInformation>> GetNewsByCategory(NewsCategoryType category)
        {

            string feedUri = $"https://www.dr.dk/nyheder/service/feeds/{category}";



            //XmlReaderSettings settings = new XmlReaderSettings()
            //{
            //    Async = true;
            //}

            var reader = XmlReader.Create(feedUri);
            var feed = await Task.Run(() => SyndicationFeed.Load(reader));




            List<NewsInformation> resultAsNews = new List<NewsInformation>();
            foreach (SyndicationItem item in feed.Items)
            {
                NewsInformation newsInfo = new NewsInformation()
                {
                    Title = item.Title.Text,
                    CreatedDate = item.PublishDate.DateTime,
                    Description = item.Summary.Text,

                };

                foreach (SyndicationElementExtension extension in item.ElementExtensions)
                {
                    XElement element = extension.GetObject<XElement>();

                    string potentialImageLink = element.Value.TrimStart('\n', ' ').TrimEnd('\n', ' ');

                    if (potentialImageLink.StartsWith("https://") || potentialImageLink.StartsWith("http://") && potentialImageLink.EndsWith(".jpg")
                        || potentialImageLink.EndsWith(".png") || potentialImageLink.EndsWith(".gif"))
                    {
                        newsInfo.ImageUrl = potentialImageLink;
                    }
                }
                //if (resultAsNews.Count == 7) //Try to prevent crash from loading images by only showing 7 articles
                //{
                //    return resultAsNews;
                //}

                resultAsNews.Add(newsInfo);
            }


            //Sort on timestamp
            return resultAsNews.OrderByDescending(o => o.CreatedDate).ToList();



        }

        public static async Task<List<NewsInformation>> SearchAsyncOnSpecificCategoryWithFilters(FilterHelper filterHelper, NewsCategoryType category)
        {
            List<NewsInformation> matchingNews = new List<NewsInformation>();
            List<NewsInformation> news = await GetNewsByCategory(category);

            if (filterHelper.IsPositiveFiltersActive)
            {
                foreach (Filter filter in filterHelper.AllActivePositiveFilteredWords)
                {
                    UseFilter(filter, ref matchingNews, ref news);
                }
            }
            else
            {
                matchingNews = news;
            }


            //Filter off NegativeFilteredWords
            if (filterHelper.IsNegativeFiltersActive)
            {
                foreach (Filter filter in filterHelper.AllActiveNegativeFilteredWords)
                {
                    List<NewsInformation> newsToRemove = UseFilter(filter, ref matchingNews, ref news);
                    foreach (NewsInformation newsInformation in newsToRemove)
                    {
                        matchingNews.Remove(newsInformation);
                    }
                }
            }

            
            return matchingNews.OrderByDescending(o => o.CreatedDate).ToList();
        }



        private static List<NewsInformation> UseFilter(Filter filter, ref List<NewsInformation> matchingNews, ref List<NewsInformation> news)
        {
            List<NewsInformation> newsToRemove = new List<NewsInformation>();

            for (int i = 0; i < filter.FilteredWords.Count; i++)
            {
                Console.WriteLine(filter.FilteredWords[i]);
                filter.FilteredWords[i] = filter.FilteredWords[i].ToLower();


                //List<NewsInformation> news = await GetNewsByCategory(category);
                foreach (NewsInformation article in news)
                {
                    if (article.Title.ToLower().Contains(filter.FilteredWords[i]) || article.Description.ToLower().Contains(filter.FilteredWords[i]))
                    {

                        if (filter.PositiveOrNegative == PositiveOrNegative.Positive)
                        {
                            if (!DoesArticleAlreadyExistInMatch(ref matchingNews, article))
                            {
                                matchingNews.Add(article);
                            }
                        }
                        else
                        {
                            newsToRemove.Add(article);
                            //matchingNews.Remove(article); //Maybe override equals in newsinformation
                        }


                    }
                }
            }
            return newsToRemove;
        }



        public static async Task<List<NewsInformation>> SearchAsync(string searchQuery)
        {
            List<NewsInformation> matchingNews = new List<NewsInformation>();

            searchQuery = searchQuery.ToLower();

            foreach (NewsCategoryType categoryType in Enum.GetValues(typeof(NewsCategoryType)))
            {
                FilterHelper searchFilter = new FilterHelper();
                searchFilter.AllActivePositiveFilteredWords.Add(new Filter("SearchQuery", "", PositiveOrNegative.Positive, new List<string> { searchQuery }));
                List<NewsInformation> fromMethod = await SearchAsyncOnSpecificCategoryWithFilters(searchFilter, categoryType);

                foreach (NewsInformation item in fromMethod)
                {
                    if (!DoesArticleAlreadyExistInMatch(ref matchingNews, item))
                    {
                        matchingNews.Add(item);
                    }
                }

            }

            return matchingNews.OrderByDescending(o => o.CreatedDate).ToList();
        }

        private static bool DoesArticleAlreadyExistInMatch(ref List<NewsInformation> matchingNews, NewsInformation article)
        {
            foreach (NewsInformation item in matchingNews)
            {
                if (item.Title == article.Title)
                {
                    return true;
                }
            }
            return false;
        }

        //internal async static Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType scienceAndTechnology)
        //{
        //    throw new NotImplementedException();
        //}

        //App crashing, maybe because it is loading a lot of pictures.
    }
}
