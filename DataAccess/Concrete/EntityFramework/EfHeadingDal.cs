using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHeadingDal : EfGenericRepository<Heading>, IHeadingDal
    {
    }
}
