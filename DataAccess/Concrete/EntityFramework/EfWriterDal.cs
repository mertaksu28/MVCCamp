using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal : EfGenericRepository<Writer>, IWriterDal
    {
    }
}
