using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetAll();
    }
}
