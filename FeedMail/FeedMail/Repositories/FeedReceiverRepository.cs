using FeedMail.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Repositories
{
    public interface IFeedReceiverRepository
    {
        Task<FeedReceiver> GetFeedReceiverAsync();
        Task<FeedReceiver> CreateAsync(string email);
        Task UpdateRssLinksAsync(string email, IEnumerable<string> urls);
    }

    public class FeedReceiverRepository: IFeedReceiverRepository
    {
        private readonly FeedMailContext context;

        public FeedReceiverRepository(FeedMailContext context)
        {
            this.context = context;
        }

        public async Task<FeedReceiver> GetFeedReceiverAsync() => await context.FeedReceivers.Include(x=>x.NewsFeed).FirstOrDefaultAsync();
        public async Task<FeedReceiver> CreateAsync(string email)
        {
            var feedReceiver = new FeedReceiver
            {
                Email = email
            };

            context.FeedReceivers.Add(feedReceiver);
            await context.SaveChangesAsync();

            return feedReceiver;
        }

        public async Task UpdateRssLinksAsync(string email, IEnumerable<string> urls)
        {
            var feedReceiver = context
                    .FeedReceivers
                    .Include(x=>x.NewsFeed)
                    .FirstOrDefault();

            if(feedReceiver == null)
            {
                feedReceiver = await CreateAsync(email);
            }

            var feedNews = urls.Select(url => new Rss()
            {
                Url = url
            });

            feedReceiver.NewsFeed.Clear();
            feedReceiver.Email = email;

            foreach (var feed in feedNews)
            {
                feedReceiver.NewsFeed.Add(feed);
            }

            await context.SaveChangesAsync();
        }
    }
}
