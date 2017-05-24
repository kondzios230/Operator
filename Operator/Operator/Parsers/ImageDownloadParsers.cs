using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Parsers
{
    public static class ImageDownloadParsers
    {
        public static List<string> ParseImagesList(string response)
        {
            var source = WebUtility.HtmlDecode(response);
            var htmlResult = new HtmlDocument();
            htmlResult.LoadHtml(source);

            return htmlResult?.DocumentNode?.Descendants("a")?.Where(n => !n.InnerHtml.Contains("Remove")).ToList()?.Select(n=>n.Attributes["href"]?.Value).ToList();
        }
    }
}
