using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Sport_News_Portal.Models
{
    public class RssReader
    {
        //private static string _blogURL = "https://bongda24h.vn/RSS/172.rss";
        public static IEnumerable<Rss> GetRssFeed(string _blogURL)
        {
            XDocument feedXml = XDocument.Load(_blogURL);
            var feeds = from feed in feedXml.Descendants("item")
                        select new Rss
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Match(feed.Element("description").Value, @"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)").Value,
                            PubDate = feed.Element("pubDate").Value,
                            //PubDate = Regex.Match(feed.Element("pubDate").Value, @"^([0-1]?\d|2[0-3])(?::([0-5]?\d))?(?::([0-5]?\d))?$").Value,
                            Category = feed.Element("category").Value
                        };
            return feeds;
        }
    }
}