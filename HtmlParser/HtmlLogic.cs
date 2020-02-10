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
            string result = "";
            var htmlDoc = GetHtmlDocument(source);
            foreach(var item in htmlDoc.DocumentNode.QuerySelectorAll("a"))
            {
                result += $"{item.InnerText}, ";
            }

            return result;
        }
    }
}