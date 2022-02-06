using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfGenericRepository<Message>, IMessageDal
    {
    }
}
