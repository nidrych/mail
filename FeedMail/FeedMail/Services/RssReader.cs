using FeedMail.EmailTemplates;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace FeedMail.Services
{
    public interface IRssReader
    {
        IEnumerable<RssFeedEmailModel> ReadRss(IEnumerable<string> urls);
    }

    public class RssReader : IRssReader
    {
        private ILogger<RssReader> logger;

        public RssReader(ILogger<RssReader> logger)
        {
            this.logger = logger;
        }
        public IEnumerable<RssFeedEmailModel> ReadRss(IEnumerable<string> urls)
        {
            var rssContent = new List<RssFeedEmailModel>();

          
            foreach(var url in urls)
            {
                try
                {
                    var reader = XmlReader.Create(url);
                    var feedItems = SyndicationFeed.Load(reader);

                    //Loop through all items in the SyndicationFeed
                    foreach (var i in feedItems.Items)
                    {
                        var feedModel = new RssFeedEmailModel()
                        {
                            Title = i.Title.Text,
                            Content = i.Summary.Text
                        };

                        rssContent.Add(feedModel);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError($"Wystapił błąd podczas parsowania url: {url}");
                }
            }

            return rssContent;
        }
    }
}
