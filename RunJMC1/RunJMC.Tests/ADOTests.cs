using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RunJMC.Data.Repositories;
using RunJMC.Models.Tables;

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

        [Test]
        public void CreateEntry()
        {
            var repo = new EntriesRepository();

            Entry entry = new Entry();
            entry.CategoryId = 1;
            entry.Content = "<p>Testestestest!!!!</p>";
            entry.IsApproved = false;
            entry.IsStatic = false;
            entry.Title = "A new test title.";
            entry.UserId = "00000000-0000-0000-0000-000000000000";

            repo.AddEntry(entry);
            var entries = repo.GetAllEntries().ToList();

            Assert.AreEqual(3, entries.Count);
        }
    }
}
