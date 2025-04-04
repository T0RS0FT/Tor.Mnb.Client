﻿using Tor.Mnb.Client.Extensions;

namespace Tor.Mnb.Client.Tests
{
    [TestClass]
    public class DateOnlyExtensionsTests
    {
        [TestMethod]
        public void DateOnlyExtensionsToFixerFormatTest()
        {
            var date = DateOnly.FromDateTime(DateTime.UtcNow);

            var expected = $"{date.Year:D4}-{date.Month:D2}-{date.Day:D2}";

            Assert.AreEqual(expected, date.ToMnbFormat());
        }
    }
}
