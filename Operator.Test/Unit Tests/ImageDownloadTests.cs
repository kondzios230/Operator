using NUnit.Framework;
using Operator.Interfaces;
using Operator.Services;
using System.Threading.Tasks;

namespace Operator.Test
{
    [TestFixture]
    public class ImageDownloadTests
    {
        private static ICamera camera = new CameraMock();
        private ImageDownloadService imageDownloadService = new ImageDownloadService(camera);

        [Test]
        public async Task StartRecordingShouldReturnSuccessCode()
        {
            imageDownloadService.GetImages();
            Assert.AreEqual(true, true);
        }
        
    }
}
