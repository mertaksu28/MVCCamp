using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : EfGenericRepository<About>, IAboutDal
    {
    }
}
