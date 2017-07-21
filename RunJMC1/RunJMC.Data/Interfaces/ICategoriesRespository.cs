using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunJMC.Models.Tables;

namespace RunJMC.Data.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
    }
}
