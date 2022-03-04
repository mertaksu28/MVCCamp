using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll(string search);
        List<Content> GetAllByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        Content GetById(int id);
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
    }
}
