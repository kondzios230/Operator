using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    public class VideoService : IVideoService
    {
        private ICamera camera;
        public VideoService(ICamera Camera)
        {
            camera = Camera;
        }
        public async Task<VideoStartStatusEnum> StartRecording()
        {
            var cameraResponse = camera.StartRecording();
            var responseCode = VideoParsers.ParseStartRecording(await cameraResponse);
            return responseCode;
        }
    }
}
