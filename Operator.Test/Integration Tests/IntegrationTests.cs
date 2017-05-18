using NUnit.Framework;
using Operator.Services;
using System.Threading.Tasks;

namespace Operator.Test
{
    [TestFixture]
    public class IntegrationTests
    {
        private static ICamera camera = new Camera();
        private IVideoService videoService = new VideoService(camera);

        [Test]
        public async Task StartRecordingShouldReturnSuccessCode()
        {
            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.Success);
        }
    }
}
