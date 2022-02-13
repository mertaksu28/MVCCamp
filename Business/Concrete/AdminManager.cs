using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }
        public Admin GetById(int id)
        {
            return _adminDal.Get(a => a.Id == id);
        }

        public Admin GetUserName(string userName)
        {
            return _adminDal.Get(a => a.UserName == userName);
        }

        public Admin GetUserNameAndPassWord(string userName, string password)
        {
            return _adminDal.Get(a => a.UserName == userName && a.Password == password);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
