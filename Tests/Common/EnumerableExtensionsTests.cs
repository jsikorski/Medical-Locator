using System.Collections.Generic;
using Common.Extensions;
using NUnit.Framework;

namespace Tests.Common
{
    public class EnumerableExtensionsTests
    {
        [Test]
        public void empty_list_is_correctly_transformed()
        {
            var enumerable = new List<string>();
            string expected = string.Empty;
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void single_element_list_is_correctly_transformed()
        {
            var enumerable = new List<string> { "A" };
            const string expected = "a";
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void multiple_elements_list_is_correctly_transformed()
        {
            var enumerable = new List<string> { "A", "B", "C" };
            const string expected = "a|b|c";
            string actual = enumerable.ToUrlFormat();
            Assert.AreEqual(expected, actual);
        }
    }
}
