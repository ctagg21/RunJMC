using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RunJMC.Data.Repositories;

namespace RunJMC.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [Test]
        public void GetAllEntries()
        {
            var repo = new EntriesRepository();

            var entries = repo.GetAllEntries().ToList();

            Assert.AreEqual(2, entries.Count);
        }

        [Test]
        public void GetEntryByTag()
        {
            var repo = new EntriesRepository();

            var entries = repo.GetEntriesByTag(2).ToList();

            Assert.AreEqual(entries[0].Title, "Test Title" );
            Assert.AreEqual(2, entries.Count);
        }
    }
}
