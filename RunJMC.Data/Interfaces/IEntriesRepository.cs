using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunJMC.Models;

namespace RunJMC.Data.Interfaces
{
    public interface IEntriesRepository
    {
        IEnumerable<Entry> GetAllEntries();
        Entry GetEntryById(int id);
        IEnumerable<Entry> GetEntriesByTag(int id);
        IEnumerable<Entry> GetEntriesByCategory(int id);
        void AddEntry(Entry entry);
        void UpdateEntry(Entry entry);
        void DeleteEntry(int id);
    }
}
