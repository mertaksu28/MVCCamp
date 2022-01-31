using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager
    {
        EfGenericRepository<Category> efGenericRepository = new EfGenericRepository<Category>();

        public List<Category> GetAll()
        {
            return efGenericRepository.GetAll();
        }

        public void Add(Category category)
        {
            if (category.CategoryName.Length > 51 || category.CategoryName == "" || category.Description == "" || category.CategoryName.Length <= 3)
            {
                // Hata mesajı
            }
            else
            {
                efGenericRepository.Insert(category);
            }
        }
    }
}
