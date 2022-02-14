using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {

        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllByWriter()
        {
            return _contentDal.GetAll(c => c.WriterId == 1);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(c => c.ContentId == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.GetAll(h => h.HeadingId == id);
        }

        public void Update(Content content)
        {
            throw new System.NotImplementedException();
        }
    }
}
