using FeedMail.EmailTemplates;
using FluentEmail.Core;
using FluentEmail.Razor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Services
{
    public interface INewsFeedSender
    {
        Task SendFeedsAsync(string email, IEnumerable<RssFeedEmailModel> feeds);
    }

    public class NewsFeedSender : INewsFeedSender
    {
        private readonly IFluentEmail fluentEmail;
        public NewsFeedSender(IFluentEmail fluentEmail)
        {
            this.fluentEmail = fluentEmail;
        }
        public async Task SendFeedsAsync(string email, IEnumerable<RssFeedEmailModel> feeds)
        {
            // var configuration =
            var file = @$"{Directory.GetCurrentDirectory()}\EmailTemplates\Index.cshtml";
            
            fluentEmail.Subject("Zestaw newsów");
            fluentEmail.To(email);
            fluentEmail.UsingTemplateFromFile(file, feeds, true);
            await fluentEmail.SendAsync();
            //.From("news@feedmail.com")
            //.To(email)
            //.Subject("Zestaw newsów");
            //.UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/EmailTemplates/Index.cshtml", feeds, true);

         //   await configuration.SendAsync();
        }
    }
}
