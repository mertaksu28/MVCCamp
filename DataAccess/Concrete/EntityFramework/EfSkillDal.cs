using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSkillDal : EfGenericRepository<Skill>, ISkillDal
    {
    }
}
