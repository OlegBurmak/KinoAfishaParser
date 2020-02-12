using System.Collections.Generic;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace AfishaParser.HtmlParser
{
    public static class HtmlLogic
    {
        private static HtmlDocument GetHtmlDocument(string source)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(source);
            return htmlDoc;
        }

        public static string GetText(string source)
        {
            var htmlDoc = GetHtmlDocument(source);
            
            IEnumerable<HtmlNode> aSelector = htmlDoc.DocumentNode.QuerySelectorAll("a");
            IEnumerable<HtmlNode> spanSelector = htmlDoc.DocumentNode.QuerySelectorAll("span");

            string result = "";
            foreach(var item in aSelector)
            {
                result += $"{item.InnerText}, ";
            }
            foreach(var item in spanSelector)
            {
                result += $"{item.InnerText}, ";
            }
            if(result == "" || result ==" ")
            {
                return source;
            }
            return result;
        }
    }
}