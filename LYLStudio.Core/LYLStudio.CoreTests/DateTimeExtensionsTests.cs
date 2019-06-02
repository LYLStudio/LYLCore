using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LYLStudio.Core.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void ToTimeFormatedTest()
        {
            DateTime dateTime = DateTime.Now;
            string manual = dateTime.ToString("HHmmss");
            string extension = dateTime.ToTimeFormated();

            Assert.AreEqual(manual, extension);
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToDateFormatedTest()
        {
            DateTime dateTime = DateTime.UtcNow;
            string manual = dateTime.ToString("yyyyMMdd");
            string extension = dateTime.ToDateFormated();

            Assert.AreEqual(manual, extension);
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToLogFormatTest()
        {
            DateTime dateTime = DateTime.Now;
            string manual = dateTime.ToString("yyyyMMddHHmmss.fff");
            string extension = dateTime.ToLogFormat();

            Assert.AreEqual(manual, extension);
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToFastFormatTest()
        {
            DateTime dateTime = DateTime.Now;
            string manual = dateTime.ToString("yyyyMMddTHHmmss");
            string extension = dateTime.ToFastFormat(DateTimeExtensions.FastFormatType.DT15);

            Assert.AreEqual(manual, extension);
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToAgeTest()
        {
            DateTime dateTime = new DateTime(1981, 4, 12);
            DateTime refDateTime = new DateTime(2018, 4, 11);
            int age = dateTime.ToAge(refDateTime);
            Assert.AreEqual(36, age);
        }
    }
}