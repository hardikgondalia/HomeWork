using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ScrapingController : Controller
    {
        // GET: Scraping
        public ActionResult Index()
        {
            HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            string urlToLoad = "https://in.finance.yahoo.com/quote/%5ENSEI/history?p=%5ENSEI";
            HttpWebRequest request = HttpWebRequest.Create(urlToLoad) as HttpWebRequest;
            request.Method = "GET";

            /* Sart browser signature */
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            /* Sart browser signature */
            WebResponse response = request.GetResponse();
            var NiftyValues = new ReturnValue();
            htmlDoc.Load(response.GetResponseStream(), true);
            if (htmlDoc.DocumentNode != null)
            {
                var nodes = new List<string> { "36", "37"};
                var articleNodes = htmlDoc.DocumentNode.Descendants("span").Where(d => d.Attributes.Contains("data-reactid")).Where(i => nodes.Contains(i.Attributes["data-reactid"].Value)).ToList();

                if (articleNodes != null && articleNodes.Any())
                {
                    NiftyValues.CurrentValue = WebUtility.HtmlDecode(articleNodes[0].InnerText.Trim());
                    NiftyValues.Movement = WebUtility.HtmlDecode(articleNodes[1].InnerText.Trim());
                }
            }

            var SensexValues = new ReturnValue();
            if(htmlDoc.DocumentNode != null)
            {
                var nodes = new List<string> { "20", "22" };
                var articleNodes = htmlDoc.DocumentNode.Descendants("span").Where(d => d.Attributes.Contains("data-reactid")).Where(i => nodes.Contains(i.Attributes["data-reactid"].Value)).ToList();
                if (articleNodes != null && articleNodes.Any())
                {
                    articleNodes[1].Descendants().Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Comment).ToList().ForEach(n => n.Remove());
                    SensexValues.CurrentValue = WebUtility.HtmlDecode(articleNodes[0].InnerText.Trim());
                    SensexValues.Movement = WebUtility.HtmlDecode(articleNodes[1].InnerText.Trim());
                }
            }

            var DollarValues = new ReturnValue();
            if (htmlDoc.DocumentNode != null)
            {
                var nodes = new List<string> { "46", "48" };
                var articleNodes = htmlDoc.DocumentNode.Descendants("span").Where(d => d.Attributes.Contains("data-reactid")).Where(i => nodes.Contains(i.Attributes["data-reactid"].Value)).ToList();
                if (articleNodes != null && articleNodes.Any())
                {
                    articleNodes[1].Descendants().Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Comment).ToList().ForEach(n => n.Remove());
                    DollarValues.CurrentValue = WebUtility.HtmlDecode(articleNodes[0].InnerText.Trim());
                    DollarValues.Movement = WebUtility.HtmlDecode(articleNodes[1].InnerText.Trim());
                }
            }
            return View();
        }

        public class ReturnValue
        {
            public string CurrentValue { get; set; }
            public string Movement { get; set; }
        }
    }
}