using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TumblThree.Domain.Models.Blogs;
using TumblThree.Domain.Models.Files;

namespace TumblThree.Applications.Services.BlogServiceTests
{
    [TestClass]
    public class BlogServiceTests
    {
        private Mock<IBlog> _blogMock;
        private Mock<IFiles> _filesMock;
        private BlogService _blogService;

        [TestInitialize]
        public void SetUp()
        {
            _blogMock = new Mock<IBlog>();
            _filesMock = new Mock<IFiles>();
            _blogService = new BlogService(_blogMock.Object, _filesMock.Object);
        }

        [TestMethod]
        public void UpdateBlogProgress_ShouldUpdateBlogProgress()
        {

            _blogMock.SetupGet(b => b.DownloadedItems).Returns(5);
            _blogMock.SetupGet(b => b.TotalCount).Returns(10);

  
            _blogService.UpdateBlogProgress();

            _blogMock.VerifySet(b => b.Progress = 50, Times.Once);
        }

        [TestMethod]
        public void CreateDataFolder_ShouldCreateFolderIfNotExists()
        {

            _blogMock.Setup(b => b.Name).Returns("TestBlog");
            _blogMock.Setup(b => b.DownloadLocation()).Returns("C:\\TestDirectory");

            var result = _blogService.CreateDataFolder();


            Assert.IsTrue(result);
            Assert.IsTrue(Directory.Exists("C:\\TestDirectory"));
        }

        [TestMethod]
        public void CheckIfFileExistsInDirectory_ShouldReturnTrueIfExists()
        {

            _blogMock.Setup(b => b.DownloadLocation()).Returns("C:\\TestDirectory");
            _filesMock.Setup(f => f.Save()).Verifiable();


            var result = _blogService.CheckIfFileExistsInDirectory("http://example.com/testfile.jpg");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SaveFiles_ShouldCallSaveOnFiles()
        {
   
            _blogService.SaveFiles();


            _filesMock.Verify(f => f.Save(), Times.Once);
        }


        [TestCleanup]
        public void TearDown()
        {
            _blogMock = null;
            _filesMock = null;
            _blogService = null;
        }
    }
}
