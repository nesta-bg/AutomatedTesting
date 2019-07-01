using Moq;
using NUnit.Framework;
using System.Net;
using TestWarrior.Mocking;

namespace TestWarrior.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _instalerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _instalerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //It doesn't throw an exception
            //_fileDownloader.Setup(fd => fd.DownloadFile("", "")).Throws<WebException>();

            //_fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            //It - class defined in Moq
            _fileDownloader.Setup(fd =>
               fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
               .Throws<WebException>();

            var result = _instalerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            //By default when we called DownloadFile in InstallerHelper It doesn't do anything 
            //(It doesn't throw an exception).

            var result = _instalerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
