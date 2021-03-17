using FeedMail.Models;
using FeedMail.Repositories;
using FeedMail.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedReceiverRepository repository;
        private readonly IRssReader rssReader;
        public HomeController(IFeedReceiverRepository repository, IRssReader rssReader)
        {
            this.repository = repository;
            this.rssReader = rssReader;
        }

        public async Task<IActionResult> Index()
        {
            var feedReceiver = await repository.GetFeedReceiverAsync();
            var model = new FeedReceiverModel()
            {
                Email = feedReceiver?.Email,
                NewsFeed = feedReceiver?.NewsFeed.Select(x => x.Url).ToList() ?? new List<string>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(RssReceiverUpdateModel model)
        {
            await repository.UpdateRssLinksAsync(model.Email, model.RssUrls);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Preview()
        {
            var rssReceiver = await repository.GetFeedReceiverAsync();
            var content = rssReader.ReadRss(rssReceiver.NewsFeed.Select(x => x.Url));

            return PartialView(content);
        }
    }
}
