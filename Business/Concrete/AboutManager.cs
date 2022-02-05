using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Insert(about);
        }

        public void Delete(About about)
        {
            _aboutDal.Delete(about);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(a => a.AboutId == id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
