using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_test_framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_test_framework.Tests
{
    [TestClass()]
    public class CountConsecutiveTestsMSTest
    {
        const string EMPTY = "";
        const string BLANK = "           ";
        const string POPULATED = "Mississippi";
        const string POPULATED_WHITESPACE = "Mississippi is";
        const string POPULATED_WHITESPACE_NUM = "Mississippi is a 3766 km long river"; 

        [TestMethod()]
        [DataRow(EMPTY, 0)]
        [DataRow(BLANK, 0)]
        [DataRow(POPULATED, 7)]
        [DataRow(POPULATED_WHITESPACE, 8)]
        [DataRow(POPULATED_WHITESPACE_NUM, 18)]
        public void UnequalCharacters_OfInput_ReturnsCorrectCount(string _input, int expected)
        {
            string input = _input; 
            int expected_count = expected;

            int count = CountConsecutive.UnequalCharacters(input);

            Assert.AreEqual(count, expected_count);
        }

        [TestMethod()]
        [DataRow(EMPTY, 0)]
        [DataRow(BLANK, 0)]
        [DataRow(POPULATED, 3)]
        [DataRow(POPULATED_WHITESPACE, 3)]
        [DataRow(POPULATED_WHITESPACE_NUM, 3)]
        public void IdenticalLatinCharacters_OfInput_ReturnsCorrectCount(string _input, int expected)
        {
            string input = _input;
            int expected_count = expected;

            int count = CountConsecutive.IdenticalLatinCharacters(input);

            Assert.AreEqual(count, expected_count);
        }

        [TestMethod()]
        [DataRow(EMPTY, 0)]
        [DataRow(BLANK, 0)]
        [DataRow(POPULATED, 0)]
        [DataRow(POPULATED_WHITESPACE, 0)]
        [DataRow(POPULATED_WHITESPACE_NUM, 1)]
        public void IdenticalDigits_OfInput_ReturnsCorrectCount(string _input, int expected)
        {
            string input = _input;
            int expected_count = expected;

            int count = CountConsecutive.IdenticalDigits(input);

            Assert.AreEqual(count, expected_count);
        }
    }
}