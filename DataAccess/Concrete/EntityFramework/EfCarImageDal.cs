using Core.DataAccess.EntityFramework;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCarProjectDatabaseContext>, ICarImageDal
    {

    }
}
