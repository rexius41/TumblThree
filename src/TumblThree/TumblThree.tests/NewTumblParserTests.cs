using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace TumblThree.Applications.Parser.Tests
{
    [TestClass]
    public class NewTumblParserTests
    {
        private NewTumblParser parser;

        [TestInitialize]
        public void Setup()
        {
            parser = new NewTumblParser();
        }

        [TestMethod]
        public void GetPhotoUrlRegex_ShouldReturnValidRegex()
        {

            var regex = parser.GetPhotoUrlRegex();


            Assert.IsNotNull(regex);
            Assert.IsFalse(regex.IsMatch("http://example.com/image.png"));
        }

        [TestMethod]
        public void GetGenericPhotoUrlRegex_ShouldReturnValidRegex()
        {
  
            var regex = parser.GetGenericPhotoUrlRegex();


            Assert.IsNotNull(regex);
            Assert.IsFalse(regex.IsMatch("https://example.com/image.jpg"));
        }

        [TestMethod]
        public void SearchForPhotoUrl_ShouldReturnValidUrls()
        {

            string searchableText = "This is a test string with an image URL: \"http://newtumbl.com/image.jpg\"";

    
            var urls = parser.SearchForPhotoUrl(searchableText);


            Assert.IsNotNull(urls);
            Assert.AreEqual(1, urls.Count());
            Assert.AreEqual("http://newtumbl.com/image.jpg", urls.First());
        }

        [TestMethod]
        public void SearchForGenericPhotoUrl_ShouldReturnValidUrls()
        {
            // Arrange
            string searchableText = "This is a test string with a generic image URL: \"https://example.com/image.jpg\"";

            // Act
            var urls = parser.SearchForGenericPhotoUrl(searchableText);

            // Assert
            Assert.IsNotNull(urls);
            Assert.AreEqual(1, urls.Count());
            Assert.AreEqual("https://example.com/image.jpg", urls.First());
        }

        [TestMethod]
        public void IsNewTumblUrl_ShouldReturnTrueForValidUrl()
        {
            // Arrange
            string url = "http://example.com/nT_123";

            // Act
            var result = parser.IsNewTumblUrl(url);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNewTumblUrl_ShouldReturnFalseForInvalidUrl()
        {
            // Arrange
            string url = "http://example.com/invalid";

            // Act
            var result = parser.IsNewTumblUrl(url);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
