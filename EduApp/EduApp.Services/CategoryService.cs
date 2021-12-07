using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var result = await Task.Run(() => _uow.CategoryRepository.All());

            return result;
        }
    }
}
