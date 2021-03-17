using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.EntityFramework
{
    public class FeedReceiver
    {
        public FeedReceiver()
        {
            NewsFeed = new List<Rss>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public ICollection<Rss> NewsFeed { get; set; }
    }
}
