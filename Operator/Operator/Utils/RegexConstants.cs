using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Utils
{
    public static class RegexConstants
    {
        public const string VideoStartRecordingResponse = "<?xml version=''1.0'' encoding=''UTF-8'' \\?>\n<Function>\n<Cmd>2001</Cmd>\n<Status>(.*?)</Status>\n</Function>";
    }
}
