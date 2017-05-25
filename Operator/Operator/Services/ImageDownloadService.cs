using HtmlAgilityPack;
using System.Collections.Generic;
using System.Xml;
using Operator.Parsers;
using Operator.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Operator.Models;

namespace Operator.Services
{
    public class ImageDownloadService :IImageDownloadService
    {
        private ICamera camera;
        public ImageDownloadService(ICamera Camera)
        {
            camera = Camera;
        }

        public async Task<List<Photo>> GetImages()
        {
            var cameraResponse = await camera.GetImages();
            return ImageDownloadParsers.ParseImagesList(cameraResponse);
        }
    }
}
