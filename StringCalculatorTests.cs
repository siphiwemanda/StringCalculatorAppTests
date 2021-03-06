﻿using System;
using NUnit.Framework;
using StringCalculatorApp;

namespace StringCalculatorAppTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;
        [SetUp]
        public void SetUp()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestCase("5", 5)] 
        [TestCase("", 0)]
        [TestCase( "5,5", 10)]
        public void GivenASingleNumberWillReturnThatValue(string numbersString, int expect)
        {
            var result = _stringCalculator.Add(numbersString);
            Assert.That(result,Is.EqualTo(expect));

        }
        //[Test]
        //public void GivenAnEmptyStringReturnZero()
        //{
        //    var result = _stringCalculator.Add("");
        //    Assert.That(result, Is.EqualTo(0));

        //}
        //[Test]
        //public void GivenTwoNumbersSeparatedByACommaReturnSum()
        //{
        //    var result = _stringCalculator.Add("5,5");
        //    Assert.That(result, Is.EqualTo(10));

        //}
        [Test]
        public void GivenMoreThanTwoNumbersReturnTheSum()
        {
            var result = _stringCalculator.Add("5,5,2,4,5");
            Assert.That(result, Is.EqualTo(21));

        }
        [Test]
        public void GivenANewLineReturnSum()
        {
            var result = _stringCalculator.Add("1\n2,3");
            Assert.That(result, Is.EqualTo(6));

        }
        [Test]
        public void GivenCustomSeparatorsReturnSum()
        {
            var result = _stringCalculator.Add("//;\n1;2");
            Assert.That(result, Is.EqualTo(3));

        }
        [Test]
        public void GivenNegativeNumbersThrowException()
        {
            Assert.That(() => _stringCalculator.Add("1,-1"),
                Throws.TypeOf<Exception>().With.Message.EqualTo("negatives not allowed: -1"));

        }
        [Test]
        public void GivenANumberBiggerThan1000Ignore()
        {
            var result = _stringCalculator.Add("1001,2");
            Assert.That(result, Is.EqualTo(2));

        }
        [Test]
        public void GivenArbitraryLengthSeparatorsWithBracketsReturnSum()
        {
            var result = _stringCalculator.Add("//[***]\n1***2***3");
            Assert.That(result, Is.EqualTo(6));

        }
        [Test]
        public void MultipleSingleLengthSeparatorsReturnSum()
        {
            var result = _stringCalculator.Add("//[*][%]\n1*2%3");
            Assert.That(result, Is.EqualTo(6));

        }
        [Test]
        public void MultipleLongerLengthSeparatorsReturnSum()
        {
            var result = _stringCalculator.Add("//[foo][bar]\n6foo2bar3");
            Assert.That(result, Is.EqualTo(11));

        }
    }
}
