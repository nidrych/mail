﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.Models
{
    public class RssReceiverUpdateModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<string> RssUrls { get; set; }
    }
}
