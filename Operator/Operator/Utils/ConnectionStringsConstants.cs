using System.Collections.Generic;

namespace Operator.Utils
{
    public static class ConnectionStringsConstants
    {
        private const string baseAddress = "http://192.168.1.254";

        private const string startRecording = "/?custom=1&cmd=2001&par=1";

        private const string getImages = "/DCIM/PHOTO";

        private static Dictionary<ConnectionString, string> connectionStringsMapper =
            new Dictionary<ConnectionString, string>() {
                { ConnectionString.StartRecording,startRecording }
               , { ConnectionString.GetImages,getImages }
            };

        public static string GetAddress(ConnectionString connectionString)
        {
            return connectionString == ConnectionString.BaseAddress ? baseAddress : baseAddress + connectionStringsMapper[connectionString];
        }
    }

    public enum ConnectionString
    {
        BaseAddress,
        StartRecording,
        GetImages
    }
}
