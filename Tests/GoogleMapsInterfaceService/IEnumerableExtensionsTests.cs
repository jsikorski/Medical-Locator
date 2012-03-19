using System.Collections.Generic;
using NUnit.Framework;
using GoogleMapsInterfaceService.Extensions;

namespace Tests.GoogleMapsInterfaceService
{
    public class IEnumerableExtensionsTests
    {
        [Test]
        public void ToUrlFormatEmptyListTest()
        {
            var enumerable = new List<string>();
            string expected = string.Empty;
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToUrlFormatSingleElementListTest()
        {
            var enumerable = new List<string> { "A" };
            const string expected = "A";
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToUrlFormatMultipleElementsListTest()
        {
            var enumerable = new List<string> { "A", "B", "C" };
            const string expected = "A|B|C";
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }
    }
}