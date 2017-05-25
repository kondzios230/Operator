using Operator.Utils;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Operator.Interfaces;

namespace Operator.Services
{
    public class Camera : ICamera
    {
        public async  Task<string> GetImages()
        {
            using (var c = new HttpClient() { Timeout = new System.TimeSpan(0, 0, 15) })
            {
                return await c.GetStringAsync(ConnectionStringsConstants.GetAddress(ConnectionString.GetImages));
            }
        }

        public async Task<string> StartRecording()
        {
            using (var c = new HttpClient() { Timeout = new System.TimeSpan(0,0,5) })
            {
                return await c.GetStringAsync(ConnectionStringsConstants.GetAddress(ConnectionString.StartRecording));
            }
        }
    }
}
