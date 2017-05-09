using NUnit.Framework;

namespace Operator.Test
{
    [TestFixture]
    public class VideoParsersTests
    {
        [Test]
        public void StartRecordingShouldReturnSuccessCode()
        {
            var cameraMock = new CameraMock();
            var videoService = new VideoService(cameraMock);

            var response = videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.Success);
        }
    }
}
