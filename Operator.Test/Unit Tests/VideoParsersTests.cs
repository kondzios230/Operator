using NUnit.Framework;
using System.Threading.Tasks;

namespace Operator.Test
{
    [TestFixture]
    public class VideoParsersTests
    {
        private static ICamera camera = new CameraMock();
        private IVideoService videoService = new VideoService(camera);

        [Test]
        public async Task StartRecordingShouldReturnSuccessCode()
        {
            SetCameraMockVideoStartStatus(VideoStartStatusEnum.Success);

            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.Success);
        }

        [Test]
        public async Task StartRecordingShouldReturnFailNotEnoughSpace()
        {
            SetCameraMockVideoStartStatus(VideoStartStatusEnum.FailNotEnoughSpace);

            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.FailNotEnoughSpace);
        }

        [Test]
        public async Task StartRecordingShouldReturnFailWrongMode()
        {
            SetCameraMockVideoStartStatus(VideoStartStatusEnum.FailWrongMode);

            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.FailWrongMode);
        }

        [Test]
        public async Task StartRecordingShouldReturnFailNoCard()
        {
            SetCameraMockVideoStartStatus(VideoStartStatusEnum.FailNoCard);

            var response = await videoService.StartRecording();

            Assert.AreEqual(response, VideoStartStatusEnum.FailNoCard);
        }

        private void SetCameraMockVideoStartStatus(VideoStartStatusEnum status)
        {
            if(camera!=null && camera as CameraMock!=null)
            {
                (camera as CameraMock).status = (int)status;
            }
        }
    }
}
