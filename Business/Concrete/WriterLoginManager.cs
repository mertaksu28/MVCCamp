using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace Business.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string userName, string passwordd)
        {
            return _writerDal.Get(w => w.WriterMail == userName && w.WriterPassword == passwordd);
        }
    }
}
