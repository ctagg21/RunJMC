using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunJMC.Models.Tables;

namespace RunJMC.Data.Interfaces
{
    public interface ITagsRepository
    {
        IEnumerable<Tag> GetAllTags();
        void AddTag(Tag tag);

    }
}
