using NUnit.Framework;
using TestWarrior.Mocking;
using Moq;

namespace TestWarrior.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //https://github.com/Moq/moq4/wiki/Quickstart moq documentation
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
   
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
