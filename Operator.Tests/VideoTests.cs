using NUnit.Framework;

namespace Operator.Tests
{
    [TestFixture]
    public class VideoParsersTests
    {
        [Test]
        public  void StartRecordingShouldReturnSuccessCode()
        {
            var response = "<?xml version=''1.0'' encoding=''UTF-8'' ?>\n<Function>\n<Cmd>2001</Cmd>\n<Status>0</Status>\n</Function>";

            VideoParsers.Foo(response);
        }
    }
}
