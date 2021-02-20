using Core.Utilitis;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICostumerService
    {
        IDataResult<List<Costumer>> GetAll();
        IDataResult<List<Costumer>> GetByCostumerId(int costumerId);
        IResult Add(Costumer costumer);
        IResult Update(Costumer costumer);
        IResult Delete(Costumer costumer);

    }
}
