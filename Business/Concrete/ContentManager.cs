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

        public List<Content> GetAll(string search)
        {
            if (search == null)
            {
                return _contentDal.GetAll();
            }
            else
            {
                return _contentDal.GetAll(c => c.ContentValue.Contains(search));
            }

        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.GetAll(c => c.WriterId == id);
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
