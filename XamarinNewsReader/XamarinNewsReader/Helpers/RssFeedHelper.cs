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

            return resultAsNews;



        }

        //internal async static Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType scienceAndTechnology)
        //{
        //    throw new NotImplementedException();
        //}

        //App crashing, maybe because it is loading a lot of pictures.
    }
}
