using Operator.Interfaces;
using Operator.Parsers;
using Operator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Services
{
    public class VideoService : CommonService, IVideoService
    {        
        public async Task<VideoStartStatusEnum> StartRecording()
        {
            var cameraResponse = camera.StartRecording();
            var responseCode = VideoParsers.ParseStartRecording(await cameraResponse);
            return responseCode;
        }
    }
}
