using Core.Utilitis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public   interface IRegisteredCreditCardService
    {
        IDataResult<List<RegisteredCreditCard>> GetAll();
        IDataResult<List<RegisteredCreditCard>> GetByRegisteredCreditCardId(int id);
        IResult Add(RegisteredCreditCard registeredCreditCard);
        IResult Delete(RegisteredCreditCard registeredCreditCard);
        IResult Update(RegisteredCreditCard registeredCreditCard);

        IDataResult<List<RegisteredCreditCard>> GetByUserId(int id);

        IResult isRegisteredCreditCard(RegisteredCreditCard registeredCreditCard);


    }
}
