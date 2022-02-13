using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetAll();
        Skill GetById(int id);
        void Add(Skill skill);
        void Delete(Skill skill);
        void Update(Skill skill);

    }
}
