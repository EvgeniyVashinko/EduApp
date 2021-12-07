using EduApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
