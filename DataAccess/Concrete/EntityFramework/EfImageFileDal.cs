﻿using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageFileDal : EfGenericRepository<ImageFile>, IImageFileDal
    {
    }
}
