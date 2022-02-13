using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfGenericRepository<Admin>, IAdminDal
    {
    }
}
