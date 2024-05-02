using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions
{
    public interface ICategoryService
    {
        public IEnumerable<Category> FindAll();
        public Category CreateOne(CategoryCreateDto category);
    }
}