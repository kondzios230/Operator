using HtmlAgilityPack;
using Operator.Models;
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
        public static List<Photo> ParseImagesList(string response)
        {
            var source = WebUtility.HtmlDecode(response);
            var htmlResult = new HtmlDocument();
            htmlResult.LoadHtml(source);
            var tableRows = htmlResult?.DocumentNode?.Descendants("tr").ToList();
            var output = new List<Photo>();

            var tableSize = tableRows.Count();
            for(var i=0; i<tableSize-1; i++)
            {
                var tableRow = tableRows[i];
                var childNodes = tableRow.ChildNodes[0];

                var linkAndNameNode = childNodes.ChildNodes[0];
                var href = linkAndNameNode.Attributes["href"].Value;
                var name = linkAndNameNode.InnerText.Trim('\t', '\r', '\n');

                var sizeAndTimeNode = childNodes.ChildNodes[1];
                var size = sizeAndTimeNode.ChildNodes[0].InnerText.Trim('\t', '\r', '\n');
                var date = sizeAndTimeNode.ChildNodes[1].ChildNodes[0].InnerText.Trim('\t', '\r', '\n');
                output.Add(new Photo(href, name, date, size));
            }
            return output;
        }
    }
}
