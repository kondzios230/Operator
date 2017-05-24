using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;
using System;
using Operator.Utils;

namespace Operator.Parsers
{
    public static class VideoParsers
    {
        public static VideoStartStatusEnum ParseStartRecording (string response)
        {
            var x = (from item in XDocument.Parse(response).Descendants("Status") select item.Value).ToList()[0];
            return EnumResponseCodesMapper.VideoStatusMapper[x];
        }
    }
}
