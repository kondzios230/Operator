using NUnit.Framework;
using Operator.Interfaces;
using Operator.Models;
using Operator.Services;
using System.Threading.Tasks;
using System.Linq;

namespace Operator.Test
{
    [TestFixture]
    public class ImageDownloadTests
    {
        private static ICamera camera = new CameraMock();
        private ImageDownloadService imageDownloadService = new ImageDownloadService(camera);

        [Test]
        public async Task GetImagesShouldReturnProperImages()
        {
            var imgs = await imageDownloadService.GetImages();

            var flag = imgs.All(i => CheckIfPhotoIsOK(i));
             
            Assert.AreEqual(true, flag && imgs.Count==3);
        }

        private bool CheckIfPhotoIsOK(Photo photo)
        {
            return photo.Name.Contains("2017_0520")
                && photo.Path.Contains("2017_0520")
                && photo.Size.Contains("KB")
                && photo.Date.Contains("2017/05/20");
        }
        
    }
}
