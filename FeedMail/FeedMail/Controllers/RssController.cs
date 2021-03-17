using FeedMail.Repositories;
using FeedMail.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Controllers
{
    [Route("api/rss")]
    [ApiController]
    public class RssController : ControllerBase
    {
        private readonly IFeedReceiverRepository repository;
        private readonly INewsFeedSender feedSender;
        private readonly IRssReader rssReader;
        public RssController(IFeedReceiverRepository repository, INewsFeedSender feedSender, IRssReader rssReader)
        {
            this.repository = repository;
            this.feedSender = feedSender;
            this.rssReader = rssReader;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendRss()
        {
            var rssReceiver = await repository.GetFeedReceiverAsync();
            var content = rssReader.ReadRss(rssReceiver.NewsFeed.Select(x => x.Url));

            await feedSender.SendFeedsAsync(rssReceiver.Email, content);

            return Ok();
        }
    }
}
