using Core.Utilitis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IFakeCardService
    {
        IDataResult<List<FakeCard>> GetAll();
        IDataResult<List<FakeCard>> GetByIdFakeCard(int id);
        IResult Add(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
    }
}
