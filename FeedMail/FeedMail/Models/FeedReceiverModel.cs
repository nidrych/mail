using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Models
{
    public class FeedReceiverModel
    {
        public string Email { get; set; }
        public ICollection<string> NewsFeed { get; set; }
    }
}
