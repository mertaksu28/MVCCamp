using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllByWriter();
        Heading GetById(int id);
        void Add(Heading heading);
        void Delete(Heading heading);
        void Update(Heading heading);
    }
}
