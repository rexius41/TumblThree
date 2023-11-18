using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TumblThree.Applications.Converter;

namespace TumblThree.Applications.Converter.Tests
{
    [TestClass]
    public class SingleOrArrayConverterTests
    {
        [TestMethod]
        public void CanConvert_ReturnsTrue()
        {
            var converter = new SingleOrArrayConverter<int>();
            var result = converter.CanConvert(typeof(List<int>));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadJson_Array_ReturnsList()
        {
            var converter = new SingleOrArrayConverter<int>();
            var reader = new JsonTextReader(new StringReader("[1, 2, 3]"));
            var result = converter.ReadJson(reader, typeof(List<int>), null, new JsonSerializer());
            Assert.IsInstanceOfType(result, typeof(List<int>));
        }

        [TestMethod]
        public void ReadJson_SingleValue_ReturnsListWithSingleValue()
        {
            var converter = new SingleOrArrayConverter<int>();
            var reader = new JsonTextReader(new StringReader("1"));
            var result = converter.ReadJson(reader, typeof(List<int>), null, new JsonSerializer());
            Assert.IsInstanceOfType(result, typeof(List<int>));
            Assert.AreEqual(1, ((List<int>)result)[0]);
        }

        [TestMethod]
        public void CanWrite_ReturnsTrue()
        {
            var converter = new SingleOrArrayConverter<int>();
            var result = converter.CanWrite;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WriteJson_ListWithSingleValue_SerializesSingleValue()
        {
            var converter = new SingleOrArrayConverter<int>();
            var writer = new StringWriter();
            var jsonWriter = new JsonTextWriter(writer);
            converter.WriteJson(jsonWriter, new List<int> { 1 }, new JsonSerializer());
            writer.Flush();
            var result = writer.ToString();
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void WriteJson_ListWithMultipleValues_SerializesList()
        {
            var converter = new SingleOrArrayConverter<int>();
            var writer = new StringWriter();
            var jsonWriter = new JsonTextWriter(writer);
            converter.WriteJson(jsonWriter, new List<int> { 1, 2, 3 }, new JsonSerializer());
            jsonWriter.Flush();
            var result = writer.ToString();
            Assert.AreEqual("[1,2,3]", result);
        }
    }
}
