﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sport_News_Portal.Models
{
    public class Rss
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        public string Category { get; set; }
    }
}