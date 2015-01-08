using System;
using NUnit.Framework;
using Database.Plugin;

namespace Database.Plugin.Tests.iOSClassic
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CreateDatabase()
        {
            var connection = CrossDatabase.Current.GetConnection("test.db");
            Assert.IsNotNull(connection);
        }
    }
}
