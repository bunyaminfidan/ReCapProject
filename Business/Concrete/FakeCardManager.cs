﻿using Business.Abstract;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        IFakeCardDal _fakeCardDal;

        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }

        public IResult Add(FakeCard fakeCard)
        {
            _fakeCardDal.Add(fakeCard);

            return new SuccessResult(Messages.FakeCardAdded);
        }

        public IResult Delete(FakeCard fakeCard)
        {
            {
                _fakeCardDal.Delete(fakeCard);

                return new SuccessResult(Messages.FakeCardDeleted);
            }
        }

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(), Messages.FakeCardGetAll);
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(c => c.Number == cardNumber), Messages.GetByCardNumber);
        }

        public IDataResult<List<FakeCard>> GetByIdFakeCard(int id)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(f => f.Id == id), Messages.FakeCardGetById);
        }

        public IResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardDal.Get(c => c.nameOnTheCard == fakeCard.nameOnTheCard && c.Number == fakeCard.Number &&
            c.Cvv == fakeCard.Cvv);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IResult Update(FakeCard fakeCard)
        {
            {
                _fakeCardDal.Update(fakeCard);

                return new SuccessResult(Messages.FakeCardUpdated);
            }
        }
    }
}
