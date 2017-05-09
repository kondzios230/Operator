using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    public static class RegexConstants
    {
        public const string VideoStartRecordingResponse = @"<?xml version=''1.0'' encoding=''UTF-8'' \?><Function><Cmd>2001<\/Cmd><Status>(.*?)<\/Status><\/Function>";
    }
}
