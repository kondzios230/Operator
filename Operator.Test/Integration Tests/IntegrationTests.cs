using NUnit.Framework;
using Operator.Interfaces;
using Operator.Services;
using Operator.Utils;
using System.Threading.Tasks;

namespace Operator.Test
{
    [TestFixture]
    public class IntegrationTests
    {
        private static ICamera camera = new Camera();
        private IVideoService videoService = new VideoService(camera);
        private IImageDownloadService iids = new ImageDownloadService(camera);

        [Test]
        public async Task StartRecordingShouldReturnSuccessCode()
        {
            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.Success);
        }
        [Test]
        public async Task Foo()
        {
          await iids.GetImages();

            Assert.AreEqual(true, VideoStartStatusEnum.Success);
        }
    }
}
