

using System.Text.RegularExpressions;

namespace Operator
{
    public static class VideoParsers
    {
        public static VideoStartStatusEnum ParseStartRecording (string response)
        {
            var parsedStatus = Regex.Match(response, RegexConstants.VideoStartRecordingResponse);
            return EnumResponseCodesMapper.VideoStatusMapper[parsedStatus.Groups[1].ToString()];
        }
    }
}
