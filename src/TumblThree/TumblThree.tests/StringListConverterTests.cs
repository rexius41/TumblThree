using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TumblThree.Applications.Data.Tests
{
    [TestClass]
    public class StringListConverterTests
    {
        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
            var list = new[] { "item1", "item2", "item3" };
            var separator = ", ";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("item1, item2, item3", result);
        }

        [TestMethod]
        public void FromString_ReturnsCorrectList()
        {
            // Arrange
            var text = "item1, item2, item3";
            var separator = ", ";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new[] { "item1", "item2", "item3" }, (System.Collections.ICollection)result);
        }

        [TestMethod]
        public void ToString_ReturnsEmptyString_WhenListIsEmpty()
        {
            // Arrange
            var list = new string[0];
            var separator = ", ";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void FromString_ReturnsEmptyList_WhenTextIsEmpty()
        {
            // Arrange
            var text = "";
            var separator = ", ";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new string[0], (System.Collections.ICollection)result);
        }

        [TestMethod]
        public void ToString_ReturnsSingleItem_WhenListHasOneItem()
        {
            // Arrange
            var list = new[] { "item1" };
            var separator = ", ";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("item1", result);
        }

        [TestMethod]
        public void FromString_ReturnsSingleItemList_WhenTextHasOneItem()
        {
            // Arrange
            var text = "item1";
            var separator = ", ";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new[] { "item1" }, (System.Collections.ICollection)result);
        }

        [TestMethod]
        public void ToString_ReturnsStringWithCustomSeparator()
        {
            // Arrange
            var list = new[] { "item1", "item2", "item3" };
            var separator = " | ";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("item1 | item2 | item3", result);
        }

        [TestMethod]
        public void FromString_ReturnsListWithCustomSeparator()
        {
            // Arrange
            var text = "item1 | item2 | item3";
            var separator = " | ";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new[] { "item1", "item2", "item3" }, (System.Collections.ICollection)result);
        }

        [TestMethod]
        public void ToString_ReturnsStringWithTrimmedItems()
        {
            // Arrange
            var list = new[] { " item1 ", " item2 ", " item3 " };
            var separator = ", ";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("item1, item2, item3", result);
        }

        [TestMethod]
        public void FromString_ReturnsListWithTrimmedItems()
        {
            // Arrange
            var text = " item1 , item2 , item3 ";
            var separator = ", ";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new[] { "item1", "item2", "item3" }, (System.Collections.ICollection)result);
        }

        [TestMethod]
        public void ToString_ReturnsStringWithNoSeparator()
        {
            // Arrange
            var list = new[] { "item1", "item2", "item3" };
            var separator = "";

            // Act
            var result = StringListConverter.ToString(list, separator);

            // Assert
            Assert.AreEqual("item1item2item3", result);
        }

        [TestMethod]
        public void FromString_ReturnsListWithNoSeparator()
        {
            // Arrange
            var text = "item1item2item3";
            var separator = "";

            // Act
            var result = StringListConverter.FromString(text, separator);

            // Assert
            CollectionAssert.AreEqual(new[] { "item1item2item3" }, (System.Collections.ICollection)result);
        }
    }
}
