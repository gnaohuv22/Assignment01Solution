using BusinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}

