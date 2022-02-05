using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfGenericRepository<Contact>, IContactDal
    {
    }
}
